using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Player : IUnrealSerializable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Player")]
        [DisplayName("Is Female")]
        public bool property_IsFemale
        {
            get { return this.IsFemale; }
            set { this.IsFemale = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Class Name")]
        public string property_PlayerClassName
        {
            get { return this.PlayerClassName; }
            set { this.PlayerClassName = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Level")]
        public int property_Level
        {
            get { return this.Level; }
            set { this.Level = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Current XP")]
        public float property_CurrentXP
        {
            get { return this.CurrentXP; }
            set { this.CurrentXP = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Player")]
        [DisplayName("First Name")]
        public string property_FirstName
        {
            get { return this.FirstName; }
            set { this.FirstName = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Player")]
        [DisplayName("Last Name")]
        [Description("String ID of last name. Not actually used.")]
        public int property_LastName
        {
            get { return this.LastName; }
            set { this.LastName = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Origin")]
        public OriginType property_Origin
        {
            get { return this.Origin; }
            set { this.Origin = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Notoriety")]
        public NotorietyType property_Notoriety
        {
            get { return this.Notoriety; }
            set { this.Notoriety = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Talent Points")]
        public int property_TalentPoints
        {
            get { return this.TalentPoints; }
            set { this.TalentPoints = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Powers")]
        [DisplayName("Mapped Power #1")]
        public string property_MappedPower1
        {
            get { return this.MappedPower1; }
            set { this.MappedPower1 = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Powers")]
        [DisplayName("Mapped Power #2")]
        public string property_MappedPower2
        {
            get { return this.MappedPower2; }
            set { this.MappedPower2 = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Powers")]
        [DisplayName("Mapped Power #3")]
        public string property_MappedPower3
        {
            get { return this.MappedPower3; }
            set { this.MappedPower3 = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Player")]
        [DisplayName("Appearance")]
        public Appearance property_Appearance
        {
            get { return this.Appearance; }
            set { this.Appearance = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Powers")]
        [DisplayName("Powers")]
        public List<Power> property_Powers
        {
            get { return this.Powers; }
            set { this.Powers = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Inventory")]
        [DisplayName("Weapons")]
        public List<Weapon> property_Weapons
        {
            get { return this.Weapons; }
            set { this.Weapons = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Inventory")]
        [DisplayName("Loadout")]
        public Loadout property_LoadoutWeapons
        {
            get { return this.LoadoutWeapons; }
            set { this.LoadoutWeapons = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Other")]
        [DisplayName("HotKeys")]
        public List<HotKey> property_HotKeys
        {
            get { return this.HotKeys; }
            set { this.HotKeys = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Credits")]
        public int property_Credits
        {
            get { return this.Credits; }
            set { this.Credits = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Medigel")]
        public int property_Medigel
        {
            get { return this.Medigel; }
            set { this.Medigel = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Energy Zero")]
        public int property_Eezo
        {
            get { return this.Eezo; }
            set { this.Eezo = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Iridium")]
        public int property_Iridium
        {
            get { return this.Iridium; }
            set { this.Iridium = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Palladium")]
        public int property_Palladium
        {
            get { return this.Palladium; }
            set { this.Palladium = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Platinum")]
        public int property_Platinum
        {
            get { return this.Platinum; }
            set { this.Platinum = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("Probes")]
        public int property_Probes
        {
            get { return this.Probes; }
            set { this.Probes = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Resources")]
        [DisplayName("xxx")]
        public float property_CurrentFuel
        {
            get { return this.CurrentFuel; }
            set { this.CurrentFuel = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Player")]
        [DisplayName("Face Code")]
        public string property_FaceCode
        {
            get { return this.FaceCode; }
            set { this.FaceCode = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Statistics")]
        [DisplayName("Class Friendly Name")]
        [Description("String ID of the player's class.")]
        public int property_ClassFriendlyName
        {
            get { return this.ClassFriendlyName; }
            set { this.ClassFriendlyName = value; }
        }
    }
}
