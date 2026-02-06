using instruments;
using instrumentssbc.src.BlockTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace instrumentssbc.src.ItemTypes
{
    #region guitars
    public class BanjoItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "banjo";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class BassGuitarItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "bassguitar";
            animation = "holdinglanternrighthand";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class ElectricBassGuitarItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "electricbassguitar";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class LeadGuitarItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "leadguitar";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class NylonGuitarItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "nylonguitar";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class OverdriveGuitarItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "overdriveguitar";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    #endregion guitars


    #region precussion
    public class BrightPianoItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "brightpiano";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class HammerDulcimerItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "dulcimer";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class KotoItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "koto";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class XylophoneItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "xylophone";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    #endregion precussion

    #region modern

    public class SpaceSynthItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "spacesynth";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class SquareWaveItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "squarewave";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class ModelMItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "modelm";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    #endregion modern

    #region woodwinds
    public class FluteItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "flute";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class HarmonicaItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "harmonica";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class OboeItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "oboe";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class OcarinaItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "ocarina";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class JewharpItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "jewharp";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class bagPipesItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "bagpipes";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }

    #endregion woodwinds

    #region other
    public class ReedOrganItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "reedorgan";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    public class RockOrganItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "rockorgan";
            animation = "holdbothhands";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }

    public class MicHighItem : InstrumentItem
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            instrument = "michigh";
            animation = "holdinglanternrighthand";
            Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    #endregion other

    internal class abcBellBlock : InstrumentBlock
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            //instrument = "modelm";
            //animation = "holdinglanternrighthand";
            //Definitions.GetInstance().AddInstrumentType(instrument, animation);
        }
    }
    internal class abcBellBlockEntity : BEInstrumentBlock
    {
      
    }
}
