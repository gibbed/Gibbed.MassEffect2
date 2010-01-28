using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF9F0
    public class Identity : IUnrealSerializable
    {
        public string Hair; // +00
        public List<string> Unknown0C; // 00BAFA70 ?
        public List<NamedFloat> Unknown18; // 00BAFB14 facial values?
        public List<NamedVector3> Unknown24; // 00BAFC01 facial positions?
        public List<Vector3> Unknown30; // 00BAFE30 ?
        public List<Vector3> Unknown3C; // 00BB0053 ?
        public List<Vector3> Unknown48; // 00BB0280 ?
        public List<Vector3> Unknown54; // 00BB04A3 ?
        public List<NamedFloat> Scalars; // +60 00BB05E0
        public List<NamedColor> Colors; // +6C 00BB06E0
        public List<NamedString> Textures; // +78 00BB0852

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Hair);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize<NamedFloat>(ref this.Unknown18);
            stream.Serialize<NamedVector3>(ref this.Unknown24);
            stream.Serialize<Vector3>(ref this.Unknown30);
            stream.Serialize<Vector3>(ref this.Unknown3C);
            stream.Serialize<Vector3>(ref this.Unknown48);
            stream.Serialize<Vector3>(ref this.Unknown54);
            stream.Serialize<NamedFloat>(ref this.Scalars);
            stream.Serialize<NamedColor>(ref this.Colors);
            stream.Serialize<NamedString>(ref this.Textures);
        }
    }
}
