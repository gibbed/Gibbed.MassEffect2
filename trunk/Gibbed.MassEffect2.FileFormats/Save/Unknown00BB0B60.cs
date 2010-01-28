namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BB0B60 : IUnrealSerializable
    {
        public string Unknown00;
        public uint Unknown0C;
        public uint Unknown10;
        public bool Unknown14_0;
        public bool Unknown14_1;
        public string Unknown18;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown10);
            stream.Serialize(ref this.Unknown14_0);
            stream.Serialize(ref this.Unknown14_1);

            if (stream.Version >= 17)
            {
                stream.Serialize(ref this.Unknown18);
            }
        }
    }
}
