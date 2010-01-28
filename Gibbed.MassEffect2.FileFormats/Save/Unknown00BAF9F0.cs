using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // Appears to be appearance data
    public class Unknown00BAF9F0 : IUnrealSerializable
    {
        public string Unknown00; // hair model?
        public List<string> Unknown0C; // 00BAFA70 ?
        public List<NamedFloat> Unknown18; // 00BAFB14 facial values?
        public List<NamedVector3> Unknown24; // 00BAFC01 facial positions?
        public List<Vector3> Unknown30; // 00BAFE30 ?
        public List<Vector3> Unknown3C; // 00BB0053 ?
        public List<Vector3> Unknown48; // 00BB0280 ?
        public List<Vector3> Unknown54; // 00BB04A3 ?
        public List<NamedFloat> Unknown60; // 00BB05E0 facial scalars?
        public List<NamedColor> Unknown6C; // 00BB06E0 facial colors?
        public List<NamedString> Unknown78; // 00BB0852 head textures?

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize<NamedFloat>(ref this.Unknown18);
            stream.Serialize<NamedVector3>(ref this.Unknown24);
            stream.Serialize<Vector3>(ref this.Unknown30);
            stream.Serialize<Vector3>(ref this.Unknown3C);
            stream.Serialize<Vector3>(ref this.Unknown48);
            stream.Serialize<Vector3>(ref this.Unknown54);
            stream.Serialize<NamedFloat>(ref this.Unknown60);
            stream.Serialize<NamedColor>(ref this.Unknown6C);
            stream.Serialize<NamedString>(ref this.Unknown78);
        }
    }
}
