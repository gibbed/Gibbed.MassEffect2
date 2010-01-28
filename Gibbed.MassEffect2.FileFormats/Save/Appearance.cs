using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF8E0
    public class Appearance : IUnrealSerializable
    {
        public PlayerAppearanceType CombatAppearance; // +00
        public int CasualID; // +04
        public int FullBodyID; // +08
        public int TorsoID; // +0C
        public int ShoulderID; // +10
        public int ArmID; // +14
        public int LegID; // +18
        public int SpecID; // +1C
        public int Tint1ID; // +20
        public int Tint2ID; // +24
        public int Tint3ID; // +28
        public int PatternID; // +2C
        public int PatternColorID; // +30
        public int HelmetID; // +34
        public bool HasMorphHead; // +38
        public MorphHead MorphHead; // +3C

        public void Serialize(IUnrealStream stream)
        {
            stream.SerializeEnum(ref this.CombatAppearance);
            stream.Serialize(ref this.CasualID);
            stream.Serialize(ref this.FullBodyID);
            stream.Serialize(ref this.TorsoID);
            stream.Serialize(ref this.ShoulderID);
            stream.Serialize(ref this.ArmID);
            stream.Serialize(ref this.LegID);
            stream.Serialize(ref this.SpecID);
            stream.Serialize(ref this.Tint1ID);
            stream.Serialize(ref this.Tint2ID);
            stream.Serialize(ref this.Tint3ID);
            stream.Serialize(ref this.PatternID);
            stream.Serialize(ref this.PatternColorID);
            stream.Serialize(ref this.HelmetID);
            stream.Serialize(ref this.HasMorphHead);
            
            if (this.HasMorphHead == true)
            {
                stream.Serialize(ref this.MorphHead);
            }
        }
    }
}
