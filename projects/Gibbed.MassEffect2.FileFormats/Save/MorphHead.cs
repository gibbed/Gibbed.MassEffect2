/* Copyright (c) 2021 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System.Collections.Generic;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class MorphHead : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Hair Mesh")]
        public string HairMesh;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Accessory Meshes")]
        public List<string> AccessoryMeshes;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("Morph Features")]
        public List<MorphFeature> MorphFeatures;

        [UnrealFieldOffset(0x24)]
        [UnrealFieldDisplayName("Offset Bones")]
        public List<OffsetBone> OffsetBones;

        [UnrealFieldOffset(0x30)]
        [UnrealFieldDisplayName("LOD0 Vertices")]
        public List<Vector> LOD0Vertices;
        
        [UnrealFieldOffset(0x3C)]
        [UnrealFieldDisplayName("LOD1 Vertices")]
        public List<Vector> LOD1Vertices;

        [UnrealFieldOffset(0x48)]
        [UnrealFieldDisplayName("LOD2 Vertices")]
        public List<Vector> LOD2Vertices;

        [UnrealFieldOffset(0x54)]
        [UnrealFieldDisplayName("LOD3 Vertices")]
        public List<Vector> LOD3Vertices;

        [UnrealFieldOffset(0x60)]
        [UnrealFieldDisplayName("Scalar Parameters")]
        public List<ScalarParameter> ScalarParameters;

        [UnrealFieldOffset(0x6C)]
        [UnrealFieldDisplayName("Vector Parameters")]
        public List<VectorParameter> VectorParameters;

        [UnrealFieldOffset(0x78)]
        [UnrealFieldDisplayName("Texture Parameters")]
        public List<TextureParameter> TextureParameters;

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
