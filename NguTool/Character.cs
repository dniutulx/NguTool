using System;
using System.Collections.Generic;
using System.Text;
using NguTool.Extensions;
using NguTool.Helpers;

namespace NguTool
{
    public static class Character
    {
        private static PlayerData chardata;

        static Character()
        {
            chardata = new PlayerData();
        }

        #region file load and save
        public static void LoadFromFile(string filepath, string format = "game")
        {
            if(format == "json")
            {
                chardata = LoadSaveHelper.ReadJsonData(filepath);
            }
            else
            {
                chardata = LoadSaveHelper.ReadSaveData(filepath);
            }
        }

        public static void SaveToFile(string filepath, string format = "game")
        {
            if (format == "json")
            {
                LoadSaveHelper.SaveJsonData(chardata, filepath);
            }
            else
            {
                LoadSaveHelper.SavePlayerData(chardata, filepath);
            }
        }
        #endregion

        #region sellout shop
        public static void BuyAp(int howMany)
        {
            chardata.addAP(howMany);
        }
        #endregion

        #region analysis
        public static string Cook()
        {
            var recipe = Cooking.OptimizeRecipe(chardata);

            //format to match in game screen
            var output = 
                $"Recipe:\r\n" +
                $"Ingred 1: {recipe[0].level}\t\t Ingred 2: {recipe[1].level}\r\n" +
                $"Ingred 3: {recipe[2].level}\t\t Ingred 4: {recipe[3].level}\r\n" +
                $"Ingred 5: {recipe[4].level}\t\t Ingred 6: {recipe[5].level}\r\n" +
                $"Ingred 7: {recipe[6].level}\t\t Ingred 8: {recipe[7].level}";

            return output;
        }

        public static string LRBByTicks(
            long currentPower,
            long elapsedTicks,
            int ATPowerTicks,
            int BEARdTicks,
            int nguAdvANormalTicks,
            int nguAdvBNormalTicks,
            int nguAdvAEvilTicks,
            int nguAdvBEvilTicks,
            int nguAdvASadisticTicks,
            int nguAdvBSadisticTicks,
            double optimismFactor = 1
            )
        {
            var power = RebirthCalculator.GetRebirthEndPower(
                chardata,
                currentPower,
                elapsedTicks,
                ATPowerTicks,
                BEARdTicks,
                nguAdvANormalTicks,
                nguAdvBNormalTicks,
                nguAdvAEvilTicks,
                nguAdvBEvilTicks,
                nguAdvASadisticTicks,
                nguAdvBSadisticTicks,
                optimismFactor
                );
            return "1";
        }
        public static string LRBByTicks(
           long currentPower,
           long elapsedTicks,
           List<int> ticks,
           double optimismFactor = 1
           )
        {

            var power = RebirthCalculator.GetRebirthEndPower(
                chardata,
                currentPower,
                elapsedTicks,
                ticks[0],
                ticks[1],
                ticks[2],
                ticks[3],
                ticks[4],
                ticks[5],
                ticks[6],
                ticks[7],
                optimismFactor
                );

            return string.Format("{0:#.##E+0}", power);
        }
        #endregion
    }
}
