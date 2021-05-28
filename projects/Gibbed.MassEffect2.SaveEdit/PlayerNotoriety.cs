using System.Collections.Generic;
using NotorietyType = Gibbed.MassEffect2.FileFormats.Save.NotorietyType;

namespace Gibbed.MassEffect2.SaveEdit
{
    internal class PlayerNotoriety
    {
        public NotorietyType Type { get; set; }
        public string Name { get; set; }

        public PlayerNotoriety(NotorietyType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public static List<PlayerNotoriety> GetList()
        {
            return new List<PlayerNotoriety>()
            {
                new PlayerNotoriety(NotorietyType.None, "None"),
                new PlayerNotoriety(NotorietyType.Ruthless, "Ruthless"),
                new PlayerNotoriety(NotorietyType.Survivor, "Sole Survivor"),
                new PlayerNotoriety(NotorietyType.Warhero, "War Hero")
            };
        }
    }
}
