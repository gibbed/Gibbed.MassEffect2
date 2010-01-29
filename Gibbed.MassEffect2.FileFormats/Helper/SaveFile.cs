using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveFile
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("Debug Name")]
        [Category("Other")]
        public string property_DebugName
        {
            get { return this.DebugName; }
            set { this.DebugName = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("Seconds Played")]
        [Category("Information")]
        public float property_SecondsPlayed
        {
            get { return this.SecondsPlayed; }
            set { this.SecondsPlayed = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("Disc")]
        [Category("Other")]
        public int property_Disc
        {
            get { return this.Disc; }
            set { this.Disc = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DisplayName("Base Level Name")]
        [Category("Location")]
        public string property_BaseLevelName
        {
            get { return this.BaseLevelName; }
            set { this.BaseLevelName = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Information")]
        [DisplayName("Difficulty")]
        public Save.DifficultyOptions property_Difficulty
        {
            get { return this.Difficulty; }
            set { this.Difficulty = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Plot")]
        [DisplayName("End Game State")]
        public int property_EndGameState
        {
            get { return this.EndGameState; }
            set { this.EndGameState = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Information")]
        [DisplayName("Time Stamp")]
        public Save.SaveTimeStamp property_TimeStamp
        {
            get { return this.TimeStamp; }
            set { this.TimeStamp = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Location")]
        [DisplayName("Position")]
        public Save.Vector property_SaveLocation
        {
            get { return this.SaveLocation; }
            set { this.SaveLocation = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Location")]
        [DisplayName("Rotation")]
        public Save.Rotator property_SaveRotation
        {
            get { return this.SaveRotation; }
            set { this.SaveRotation = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Current Loading Tip")]
        public int property_CurrentLoadingTip
        {
            get { return this.CurrentLoadingTip; }
            set { this.CurrentLoadingTip = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Levels")]
        public List<Save.Level> property_LevelRecords
        {
            get { return this.LevelRecords; }
            set { this.LevelRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Streaming")]
        public List<Save.StreamingState> property_StreamingRecords
        {
            get { return this.StreamingRecords; }
            set { this.StreamingRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Kismet")]
        public List<Save.KismetBool> property_KismetRecords
        {
            get { return this.KismetRecords; }
            set { this.KismetRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Doors")]
        public List<Save.Door> property_DoorRecords
        {
            get { return this.DoorRecords; }
            set { this.DoorRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("Pawns")]
        public List<Guid> property_PawnRecords
        {
            get { return this.PawnRecords; }
            set { this.PawnRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Game")]
        [DisplayName("Player")]
        public Save.Player property_PlayerRecord
        {
            get { return this.PlayerRecord; }
            set { this.PlayerRecord = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Game")]
        [DisplayName("Henchmen")]
        public List<Save.Henchman> property_HenchmanRecords
        {
            get { return this.HenchmanRecords; }
            set { this.HenchmanRecords = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Plot")]
        [DisplayName("Plot")]
        public Save.PlotTable property_PlotRecord
        {
            get { return this.PlotRecord; }
            set { this.PlotRecord = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Plot")]
        [DisplayName("ME1 Plot")]
        public Save.ME1PlotTable property_ME1PlotRecord
        {
            get { return this.ME1PlotRecord; }
            set { this.ME1PlotRecord = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Plot")]
        [DisplayName("Galaxy Map")]
        public Save.GalaxyMap property_GalaxyMapRecord
        {
            get { return this.GalaxyMapRecord; }
            set { this.GalaxyMapRecord = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Information")]
        [DisplayName("Dependent DLC")]
        public List<Save.DependentDLC> property_DependentDLC
        {
            get { return this.DependentDLC; }
            set { this.DependentDLC = value; }
        }
    }
}
