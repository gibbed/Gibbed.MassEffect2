namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE517 : IUnrealSerializable
    {
        public uint Unknown0;
        public uint Unknown4;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown4);
        }
    }
}
