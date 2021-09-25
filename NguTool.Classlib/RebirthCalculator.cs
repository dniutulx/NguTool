using System;
using System.Collections.Generic;
using System.Text;

namespace NguTool
{
    internal static class RebirthCalculator
    {
        private const int TicksPerDay = 4320000;

        /// <summary>
        /// Calculates the amount of time needed to reach a target power
        /// </summary>
        /// <param name="character">Player save data</param>
        /// <param name="currentPower">Current power level including gear</param>
        /// <param name="targetPower">Target power level including gear</param>
        /// <param name="ATPowerTicks">Number of ticks needed to complete 1 AT Power level. 0 = no progress</param>
        /// <param name="BEARdTicks">Number of ticks needed to complete 1 BEARd level. 0 = no progress</param>
        /// <param name="nguAdvANormalTicks">Number of ticks needed to complete 1 NGU Adventure A Normal level. 0 = no progress</param>
        /// <param name="nguAdvBNormalTicks">Number of ticks needed to complete 1 NGU Adventure B Normal level. 0 = no progress</param>
        /// <param name="nguAdvAEvilTicks">Number of ticks needed to complete 1 NGU Adventure A Evil level. 0 = no progress</param>
        /// <param name="nguAdvBEvilTicks">Number of ticks needed to complete 1 NGU Adventure B Evil level. 0 = no progress</param>
        /// <param name="nguAdvASadisticTicks">Number of ticks needed to complete 1 NGU Adventure A Sadistic level. 0 = no progress</param>
        /// <param name="nguAdvBSadisticTicks">Number of ticks needed to complete 1 NGU Adventure B Sadistic level. 0 = no progress</param>
        /// <param name="optimismFactor">Multiplier to account for other features or misplaced optimism. 0 = no progress</param>
        /// <returns>Number of ticks needed to reach target</returns>
        internal static long RebirthToTarget(
            PlayerData character, 
            long currentPower, 
            long targetPower,
            int ATPowerTicks,
            int BEARdTicks,
            int nguAdvANormalTicks,
            int nguAdvBNormalTicks,
            int nguAdvAEvilTicks,
            int nguAdvBEvilTicks,
            int nguAdvASadisticTicks,
            int nguAdvBSadisticTicks,
            float optimismFactor = 1
            )
        {

            //read current ngu/at/beard stats from player data
            //calculate bonus per tick
            //multiply bonus by optimism factor (may include cards, hacks, expected gear change, any other factors)
            //return number of ticks to reach target

            var bonusNeeded = (float)targetPower / (float)currentPower;

            long ticksNeeded = 0;

            return ticksNeeded;
        }

        /// <summary>
        /// Calculates the attainable power for a given rebirth length
        /// </summary>
        /// <param name="character">Player save data</param>
        /// <param name="currentPower">Current power level including gear</param>
        /// <param name="elapsedTicks">Length of the rebirth, in ticks</param>
        /// <param name="ATPowerTicks">Number of ticks needed to complete 1 AT Power level. 0 = no progress</param>
        /// <param name="BEARdTicks">Number of ticks needed to complete 1 BEARd level. 0 = no progress</param>
        /// <param name="nguAdvANormalTicks">Number of ticks needed to complete 1 NGU Adventure A Normal level. 0 = no progress</param>
        /// <param name="nguAdvBNormalTicks">Number of ticks needed to complete 1 NGU Adventure B Normal level. 0 = no progress</param>
        /// <param name="nguAdvAEvilTicks">Number of ticks needed to complete 1 NGU Adventure A Evil level. 0 = no progress</param>
        /// <param name="nguAdvBEvilTicks">Number of ticks needed to complete 1 NGU Adventure B Evil level. 0 = no progress</param>
        /// <param name="nguAdvASadisticTicks">Number of ticks needed to complete 1 NGU Adventure A Sadistic level. 0 = no progress</param>
        /// <param name="nguAdvBSadisticTicks">Number of ticks needed to complete 1 NGU Adventure B Sadistic level. 0 = no progress</param>
        /// <param name="optimismFactor">Multiplier to account for other features or misplaced optimism</param>
        /// <returns>The expected power level at the end of the rebirth</returns>
        internal static long GetRebirthEndPower(
            PlayerData character,
            long currentPower,
            int elapsedTicks,
            int ATPowerTicks,
            int BEARdTicks,
            int nguAdvANormalTicks,
            int nguAdvBNormalTicks,
            int nguAdvAEvilTicks,
            int nguAdvBEvilTicks,
            int nguAdvASadisticTicks,
            int nguAdvBSadisticTicks,
            float optimismFactor = 1
            )
        {

            float bonus = 1;

            int ATPowerLevelsGained = ATPowerTicks > 0 ? elapsedTicks / ATPowerTicks : 0;
            int BEARdLevelsGained = BEARdTicks > 0 ? elapsedTicks / BEARdTicks : 0;
            int nguAdvANormalLevelsGained = nguAdvANormalTicks > 0 ? elapsedTicks / nguAdvANormalTicks : 0;
            int nguAdvBNormalLevelsGained = nguAdvBNormalTicks > 0 ? elapsedTicks / nguAdvBNormalTicks : 0;
            int nguAdvAEvilLevelsGained = nguAdvAEvilTicks > 0 ? elapsedTicks / nguAdvAEvilTicks : 0;
            int nguAdvBEvilLevelsGaineds = nguAdvBEvilTicks > 0 ? elapsedTicks / nguAdvBEvilTicks : 0;
            int nguAdvASadisticLevelsGaineds = nguAdvASadisticTicks > 0 ? elapsedTicks / nguAdvASadisticTicks : 0;
            int nguAdvBSadisticLevelsGained = nguAdvBSadisticTicks > 0 ? elapsedTicks / nguAdvBSadisticTicks : 0;

            //float ATBonus = 

            return (long)(currentPower * bonus);
        }
    }
}
