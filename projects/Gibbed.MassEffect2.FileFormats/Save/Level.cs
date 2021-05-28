namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0CC0
    public class Level : IUnrealSerializable
    {
        public string LevelName;
        public bool Unknown1; // could be ShouldBeVisible or ShouldBeLoaded
        public bool Unknown2; // could be ShouldBeVisible or ShouldBeLoaded

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.LevelName);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
        }

        public override string ToString()
        {
            return $"{this.LevelName} = {this.Unknown1}, {this.Unknown2}";
        }
    }
}
