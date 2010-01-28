namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0B60
    public class Weapon : IUnrealSerializable
    {
        public string WeaponClassName; // +00
        public int AmmoUsedCount; // +0C
        public int TotalAmmo; // +10
        public bool CurrentWeapon; // +14.0
        public bool LastWeapon; // +14.1
        public string AmmoPowerName; // +18

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.WeaponClassName);
            stream.Serialize(ref this.AmmoUsedCount);
            stream.Serialize(ref this.TotalAmmo);
            stream.Serialize(ref this.CurrentWeapon);
            stream.Serialize(ref this.LastWeapon);

            if (stream.Version >= 17)
            {
                stream.Serialize(ref this.AmmoPowerName);
            }
        }
    }
}
