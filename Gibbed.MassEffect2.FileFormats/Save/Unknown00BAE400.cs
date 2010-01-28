namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE400 : IUnrealSerializable
    {
        public uint Unknown0;
        public bool Unknown4;
        public Unknown00BAE4C0 Unknown8;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown4);
            stream.Serialize<Unknown00BAE4C0>(ref this.Unknown8);
        }
    }
}
