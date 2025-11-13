using instruments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace instrumentssbc.src.BlockTypes
{
    internal class BEInstrumentBlock : BlockEntity
    {
        int ID;

        string blockName = "ABC Bell";
        string bandName = "";
        string songData = "";
        string songName = "No abc selected!";   // Only used to show the current song, not for anything smart


        InstrumentBlockGUI instrumentBlockGUI;

        string instrumentType = "";
        public bool isPlaying = false;
        public BEInstrumentBlock()
        {
         
        }

        public void OnUse(IPlayer byPlayer)
        {
            if (!byPlayer.WorldData.EntityControls.Sneak)
            {
                // Play the song using the current setup
                if (!isPlaying)
                {
                    // Make a new ABCPlayer!
                    if (blockName != "" && songName != "" && (instrumentType != "none" || instrumentType != ""))
                    {
                        if (songData == "") // If there is no songData, the file is probably a server file. Read it from the abc_server folder
                        {
                            string abcServerBaseDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "abc_server"; // EXTREME todo this is copied from main, make into one thing

                            RecursiveFileProcessor.ReadFile(abcServerBaseDir + Path.DirectorySeparatorChar + songName, ref songData);
                            if (songData == "")  // If songData is still empty, then the song wasn't found (or one wasn't selected)
                                return;

                            ABCParsers.GetInstance().MakeNewParser(Api as ICoreServerAPI, byPlayer,
                                songData, ID, blockName, bandName, Pos.ToVec3d() + new Vec3d(0.5, 0, 0.5), instrumentType);
                        }
                        else
                        {
                            ABCParsers.GetInstance().MakeNewParser(Api as ICoreServerAPI, byPlayer,
                                songData, ID, blockName, bandName, Pos.ToVec3d() + new Vec3d(0.5, 0, 0.5), instrumentType);
                        }
                    }
                    else
                        return;
                }
                else
                {
                    ABCParser abcp = ABCParsers.GetInstance().FindByID(ID);
                    ABCStopFromServer packet = new ABCStopFromServer(); // todo copied from main, make a function
                    packet.fromClientID = ID;
                    IServerNetworkChannel ch = (Api as ICoreServerAPI).Network.GetChannel("abc");
                    ch.BroadcastPacket(packet);
                    ABCParsers.GetInstance().Remove((Api as ICoreServerAPI), byPlayer, abcp);
                }
                isPlaying = !isPlaying;
            }
            else
            {
                byte[] data;

                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryWriter writer = new BinaryWriter(ms);
                    writer.Write(byPlayer.PlayerName);
                    writer.Write(bandName);
                    writer.Write(songData);
                    TreeAttribute tree = new TreeAttribute();
                    //inventory.ToTreeAttributes(tree);
                    tree.ToBytes(writer);
                    data = ms.ToArray();
                }
                BlockPos bp = new BlockPos(Pos.X, Pos.Y, Pos.Z);
                ((ICoreServerAPI)Api).Network.SendBlockEntityPacket(
                    (IServerPlayer)byPlayer,
                    bp,
                    69,
                    data
                );
             //   byPlayer.InventoryManager.OpenInventory(inventory);
            }
        }


        public virtual string DialogTitle
        {
            get { return Lang.Get("Music Block"); }
        }
        #region packet handling
        public override void OnReceivedClientPacket(IPlayer fromPlayer, int packetid, byte[] data)
        {
            if (packetid == 1004) // Name change
            {
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        BinaryReader reader = new BinaryReader(ms);
                        blockName = reader.ReadString();
                        if (blockName == null)
                            blockName = "";
                    }
                    MarkDirty();
                }
                if (fromPlayer.InventoryManager != null)
                {
                  //  fromPlayer.InventoryManager.CloseInventory(Inventory);
                }
            }

            if (packetid == 1005) // Band change
            {
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        BinaryReader reader = new BinaryReader(ms);
                        bandName = reader.ReadString();
                        if (bandName == null)
                            bandName = "";
                    }
                    MarkDirty();
                }
                if (fromPlayer.InventoryManager != null)
                {
                  //  fromPlayer.InventoryManager.CloseInventory(Inventory);
                }
            }

            if (packetid == 1006) // Song select
            {
                if (data != null)
                {
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        BinaryReader reader = new BinaryReader(ms);
                        songName = reader.ReadString();
                        songData = reader.ReadString();
                        if (songData == null)
                            songData = "";
                    }
                    MarkDirty();
                }
                if (instrumentBlockGUI != null)
                {
                    instrumentBlockGUI.TryClose();
                }
            }
        }
        public override void OnReceivedServerPacket(int packetid, byte[] data)
        {
            // The server saw a player tried to open the music box - it sent a packet, and here it is!
            // Open the gui.
            base.OnReceivedServerPacket(packetid, data);
            if (packetid == 69)
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    BinaryReader reader = new BinaryReader(ms);
                    string playerName = reader.ReadString();
                    bandName = reader.ReadString();
                    songData = reader.ReadString();
                    TreeAttribute tree = new TreeAttribute();
                    tree.FromBytes(reader);
                    //Inventory.FromTreeAttributes(tree);
                    //Inventory.ResolveBlocksOrItems();

                    IClientWorldAccessor clientWorld = (IClientWorldAccessor)Api.World;

                    if (!Definitions.GetInstance().UpdateSongList(Api as ICoreClientAPI))
                        return;

                    if (instrumentBlockGUI == null)
                    {
                        instrumentBlockGUI = new InstrumentBlockGUI(DialogTitle, Pos, Api as ICoreClientAPI, blockName, bandName, songName);
                        instrumentBlockGUI.OnClosed += () =>
                        {
                            instrumentBlockGUI = null;
                        };
                    }
                    instrumentBlockGUI.TryOpen();
                }
            }
        }
        #endregion  packet handling
        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);
            if (api.Side != EnumAppSide.Server)
                return;
            ID = MusicBlockManager.GetInstance().GetNewID();
        }
        public override void ToTreeAttributes(ITreeAttribute tree)
        {
            base.ToTreeAttributes(tree);
            tree.SetString("name", blockName);
            tree.SetString("band", bandName);
            tree.SetString("file", songData);
            tree.SetString("songname", songName);
        }
        public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
        {
            base.FromTreeAttributes(tree, worldAccessForResolve);
            blockName = tree.GetString("name");
            bandName = tree.GetString("band");
            songData = tree.GetString("file");
            songName = tree.GetString("songname");
        }

        public override void OnBlockRemoved()
        {
            base.OnBlockRemoved();
            if (Api.Side != EnumAppSide.Server)
                return;
            MusicBlockManager.GetInstance().RemoveID(ID);

            if (isPlaying)
            {
                ABCParser abcp = ABCParsers.GetInstance().FindByID(ID);
                ABCStopFromServer packet = new ABCStopFromServer(); // todo copied from main, make a function
                packet.fromClientID = ID;
                IServerNetworkChannel ch = (Api as ICoreServerAPI).Network.GetChannel("abc");
                ch.BroadcastPacket(packet);
                ABCParsers.GetInstance().Remove((Api as ICoreServerAPI), null, abcp);
            }
        }
    }
}
