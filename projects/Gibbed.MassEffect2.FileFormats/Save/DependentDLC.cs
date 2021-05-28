namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAB3B0
    public class DependentDLC : IUnrealSerializable
    {
        public int ModuleID;
        public string Name;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.ModuleID);
            stream.Serialize(ref this.Name);
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.ModuleID})";
        }
    }
}
