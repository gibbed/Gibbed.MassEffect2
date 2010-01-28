using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF9F0
    public class MorphHead : IUnrealSerializable
    {
        public string HairMesh; // +00
        public List<string> AccessoryMeshes; // +0C 00BAFA70
        public List<MorphFeature> MorphFeatures; // +18 00BAFB14
        public List<OffsetBone> OffsetBones; // +24 00BAFC01
        public List<Vector> LOD0Vertices; // +30 00BAFE30 \
        public List<Vector> LOD1Vertices; // +3C 00BB0053  \_ LOD*Vertices (0-3)
        public List<Vector> LOD2Vertices; // +48 00BB0280  /  assumed to be named right
        public List<Vector> LOD3Vertices; // +54 00BB04A3 /
        public List<ScalarParameter> ScalarParameters; // +60 00BB05E0
        public List<VectorParameter> VectorParameters; // +6C 00BB06E0
        public List<TextureParameter> TextureParameters; // +78 00BB0852

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.HairMesh);
            stream.Serialize(ref this.AccessoryMeshes);
            stream.Serialize(ref this.MorphFeatures);
            stream.Serialize(ref this.OffsetBones);
            stream.Serialize(ref this.LOD0Vertices);
            stream.Serialize(ref this.LOD1Vertices);
            stream.Serialize(ref this.LOD2Vertices);
            stream.Serialize(ref this.LOD3Vertices);
            stream.Serialize(ref this.ScalarParameters);
            stream.Serialize(ref this.VectorParameters);
            stream.Serialize(ref this.TextureParameters);
        }
    }
}
