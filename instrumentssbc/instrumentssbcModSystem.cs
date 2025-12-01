using System;
using System.Diagnostics.Metrics;
using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using instrumentssbc.src.ItemTypes;

namespace instrumentssbc
{
    public class instrumentssbcModSystem : ModSystem
    {
        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {

           
            var modid = Mod.Info.ModID;

            api.RegisterItemClass(modid + ":precussionMalletClass",typeof(PrecussionMallet));

            api.RegisterItemClass(modid+ ":banjoClass", typeof(BanjoItem));
            api.RegisterItemClass(modid+":bassGuitarClass", typeof(BassGuitarItem));
            api.RegisterItemClass(modid+ ":electricBassGuitarClass", typeof(ElectricBassGuitarItem));
            api.RegisterItemClass(modid+ ":leadGuitarClass", typeof(LeadGuitarItem));
            api.RegisterItemClass(modid+ ":nylonGuitarClass", typeof(NylonGuitarItem));
            api.RegisterItemClass(modid+ ":overdriveGuitarClass", typeof(OverdriveGuitarItem));
            api.RegisterItemClass(modid+ ":brightPianoClass", typeof(BrightPianoItem));
            api.RegisterItemClass(modid+ ":hammerDulcimerClass", typeof(HammerDulcimerItem));
            api.RegisterItemClass(modid+ ":kotoClass", typeof(KotoItem));
            api.RegisterItemClass(modid+ ":xylophoneClass", typeof(XylophoneItem));
            api.RegisterItemClass(modid+ ":spaceSynthClass", typeof(SpaceSynthItem));
            api.RegisterItemClass(modid+ ":squareWaveClass", typeof(SquareWaveItem));        
            api.RegisterItemClass(modid+ ":fluteClass", typeof(FluteItem));
            api.RegisterItemClass(modid+ ":harmonicaClass", typeof(HarmonicaItem));
            api.RegisterItemClass(modid+ ":oboeClass", typeof(OboeItem));
            api.RegisterItemClass(modid+ ":ocarinaClass", typeof(OcarinaItem));
            api.RegisterItemClass(modid+ ":reedOrganClass", typeof(ReedOrganItem));
            api.RegisterItemClass(modid+ ":rockOrganClass", typeof(RockOrganItem));
            api.RegisterItemClass(modid+ ":micHighClass", typeof(MicHighItem));
            api.RegisterItemClass(modid+ ":jewHarpClass", typeof(JewharpItem));
            api.RegisterItemClass(modid + ":bagPipesClass", typeof(bagPipesItem));
            //    api.RegisterItemClass(modid+ ":modelMClass", typeof(ModelMItem));

            api.RegisterBlockClass(modid + ":abcbellBlock", typeof(abcBellBlock));
            api.RegisterBlockEntityClass(modid + ":abcbellBlockEntity", typeof(abcBellBlockEntity));
        }


       
        
    }
}
