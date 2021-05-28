namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAADB0
    public class StreamingState : IUnrealSerializable
    {
        public string Name;
        public bool Active;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Active);
        }

        public override string ToString()
        {
            return $"{this.Name} = {this.Active}";
        }
    }
}
