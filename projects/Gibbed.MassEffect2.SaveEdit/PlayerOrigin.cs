using System.Collections.Generic;
using OriginType = Gibbed.MassEffect2.FileFormats.Save.OriginType;

namespace Gibbed.MassEffect2.SaveEdit
{
    internal class PlayerOrigin
    {
        public OriginType Type { get; set; }
        public string Name { get; set; }

        public PlayerOrigin(OriginType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public static List<PlayerOrigin> GetList()
        {
            return new List<PlayerOrigin>()
            {
                new PlayerOrigin(OriginType.None, "None"),
                new PlayerOrigin(OriginType.Colonist, "Colonist"),
                new PlayerOrigin(OriginType.Earthborn, "Earthborn"),
                new PlayerOrigin(OriginType.Spacer, "Spacer")
            };
        }
    }
}
