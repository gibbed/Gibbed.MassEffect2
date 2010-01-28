﻿using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAE380
    public class GalaxyMap : IUnrealSerializable
    {
        public List<Planet> Planets;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Planets);
        }
    }
}
