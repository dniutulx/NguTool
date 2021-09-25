using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NguTool.Classlib.Extensions
{
    public static class PlayerDataExtensions
    {
        private static int[] BpValues = { 5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //energy power
                                          5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //magic power
                                          5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //energy cap
                                          5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //magic cap
                                          5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //energy bars
                                          5, 10, 15, 20, 25, 30, 35, 35, 40, 40, 40, 45, 45, 45, 50, 50, //magic bars
                                          5, 10, 15, 20, 25, 25, 30, 30, 35, 35, 35, 40, 40, 40, 45, 45, 45, 45, 50, 50, 50, 50, 55, 55, 55, 55, 60, 60, 60, 60, //bosses
                                          30, 30, 100, 100, 100, 100, 100, 100, 100, //misc 1
                                          5, 10, 15, 20, 25, 30, 40, 50, 60, //rebirths
                                          60, 100, 100, 20, 25, 25, 25, 25, 25 //misc 2
                                        };

        internal static int addAP(this PlayerData character, int amount)
        {
            float baseAmount = amount * character.getBonusAPMultiplier();

            int result = (int)Math.Floor(baseAmount);

            character.arbitrary.curArbitraryPoints += result;
            character.arbitrary.curLifetimePoints += result;
            return result;
        }

        internal static float getBonusAPMultiplier(this PlayerData character)
        {
            float mult = 1f;
            int achieveMult = 0;
            if (character.inventory.itemList.itemMaxxed[129]) mult *= 1.2f; //maxed yellow heart bonus

            if (character.adventure.itopod.perkLevel[94] >= 89) mult *= 1.02f; //fibonacci perk 89

            List<int> bonuses = new List<int>();
            character.achievements.achievementComplete.ForEach(x => bonuses.Add(Convert.ToInt32(x)));

            for (int index = 0; index < bonuses.Count; index++)
            {
                achieveMult += bonuses[index] * BpValues[index];
            }
            mult *= 1+ (float)achieveMult / 10000f;
            return mult;
        }
    }
}
