using System.Collections.Generic;

namespace Gibbed.MassEffect2.SaveEdit
{
    internal class PlayerClass
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public PlayerClass(string type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public static List<PlayerClass> GetList()
        {
            return new List<PlayerClass>()
            {
                new PlayerClass("SFXGame.SFXPawn_PlayerAdept", "Adept"),
                new PlayerClass("SFXGame.SFXPawn_PlayerEngineer", "Engineer"),
                new PlayerClass("SFXGame.SFXPawn_PlayerInfiltrator", "Infiltrator"),
                new PlayerClass("SFXGame.SFXPawn_PlayerSentinel", "Sentinel"),
                new PlayerClass("SFXGame.SFXPawn_PlayerSoldier", "Soldier"),
                new PlayerClass("SFXGame.SFXPawn_PlayerVanguard", "Vanguard")
            };
        }
    }
}
