using System;
using System.Collections.Generic;
using System.Text;
using NguTool.Classlib.Extensions;
using NguTool.Classlib.Helpers;

namespace NguTool.Classlib
{
    public static class Character
    {
        private static PlayerData chardata;

        static Character()
        {
            chardata = new PlayerData();
        }

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

        public static void BuyAp(int howMany)
        {
            chardata.addAP(howMany);
        }

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
    }
}
