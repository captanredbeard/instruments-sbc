using instruments;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace instrumentssbc.src.BlockTypes
{
    internal class InstrumentBlock : Block
    {
        public override bool OnBlockInteractStart(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
        {

            //return base.OnBlockInteractStart(world, byPlayer, blockSel);
            // Open the GUI to show current song/band, instrument to use, and press another button to choose song
            // Called on the client side. 

            if (world.Api.Side == EnumAppSide.Client)
            {
                // GUI stuff

            }

            if (world.Api.Side == EnumAppSide.Server)
            {
                    BEInstrumentBlock be = world.BlockAccessor.GetBlockEntity(blockSel.Position) as BEInstrumentBlock;
                    if (be != null)
                    be.OnUse(byPlayer);
            }
            return true;
        }
    }

    
    public class InstrumentBlockManager // I've gone singleton crazy
    {
        const int IDOffset = 1000;
        public List<int> activeBlockIDs;

        private static InstrumentBlockManager _instance;
        private InstrumentBlockManager()
        {
            activeBlockIDs = new List<int>();
        }
        public static InstrumentBlockManager GetInstance()
        {
            if (_instance != null)
                return _instance;
            return _instance = new InstrumentBlockManager();
        }
        public void Reset()
        {
            activeBlockIDs.Clear();
        }
        public int GetNewID()
        {
            // Search the list for a free ID
            int i = IDOffset;
            for (int ID = 0; ID < activeBlockIDs.Count; ID++)
            {
                if (activeBlockIDs.Contains(i))
                {
                    i++;
                    continue;
                }
                else
                    break;
            }
            activeBlockIDs.Add(i);
            return i;
        }
        public void RemoveID(int id)
        {
            activeBlockIDs.Remove(id);
        }
    }
}
