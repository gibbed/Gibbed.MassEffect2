using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileFormats = Gibbed.MassEffect2.FileFormats;

namespace Gibbed.MassEffect2.SaveEdit
{
    internal class PlayerOrigin
    {
        public FileFormats.Save.OriginType Type { get; set; }
        public string Name { get; set; }

        public PlayerOrigin(FileFormats.Save.OriginType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public static List<PlayerOrigin> GetOrigins()
        {
            List<PlayerOrigin> origins = new List<PlayerOrigin>();
            origins.Add(new PlayerOrigin(FileFormats.Save.OriginType.None, "None"));
            origins.Add(new PlayerOrigin(FileFormats.Save.OriginType.Colonist, "Colonist"));
            origins.Add(new PlayerOrigin(FileFormats.Save.OriginType.Earthborn, "Earthborn"));
            origins.Add(new PlayerOrigin(FileFormats.Save.OriginType.Spacer, "Spacer"));
            return origins;
        }
    }
}
