using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace NguTool.Helpers
{
    public static class LoadSaveHelper
    {
        public static PlayerData ReadSaveData()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(Environment.ExpandEnvironmentVariables("%appdata%\\..\\locallow\\ngu industries\\ngu idle\\"));

            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;

            dialog.ShowDialog();
            var path = dialog.FileName;
            if (!File.Exists(path))
            {
                Console.WriteLine("Bad filepath");
                throw new FileNotFoundException();
            }

            try
            {
                var content = File.ReadAllText(path);
                var data = DeserializeBase64<SaveData>(content);
                var checksum = GetChecksum(data.playerData);
                if (checksum != data.checksum)
                {
                    throw new InvalidDataException("Bad checksum");
                }

                return DeserializeBase64<PlayerData>(data.playerData);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in reading save file: {e.Message}");
                throw;
            }
        }

        public static PlayerData ReadJsonData()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = Path.GetFullPath(Environment.ExpandEnvironmentVariables("%appdata%\\..\\locallow\\ngu industries\\ngu idle\\"));

            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;
            dialog.ShowDialog();

            var path = dialog.FileName;
            if (!File.Exists(path))
            {
                Console.WriteLine("Bad filepath");
                throw new FileNotFoundException();
            }

            try
            {
                var content = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<PlayerData>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in reading json file: {e.Message}");
                throw;
            }

        }

        public static bool SavePlayerData(PlayerData character)
        {
            var base64Data = getBase64Data(character);
            try
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.InitialDirectory =
                    Environment.ExpandEnvironmentVariables("%appdata%\\..\\locallow\\ngu industries\\ngu idle\\");
                dialog.FileName = "NGUSave.txt";
                dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.Title = "Save edited file";
                dialog.RestoreDirectory = true;
                dialog.ShowDialog();

                if (dialog.FileName != "")
                {
                    File.WriteAllText(dialog.FileName, base64Data);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Save: " + ex.Message);
                throw;
            }
        }

        public static bool SaveJsonData(PlayerData character)
        {
            var data = JsonConvert.SerializeObject(character, Formatting.Indented);
            try
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.InitialDirectory =
                    Environment.ExpandEnvironmentVariables("%appdata%\\..\\locallow\\ngu industries\\ngu idle\\");
                dialog.FileName = "NGUSave.json";
                dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                dialog.Title = "Save JSON";
                dialog.RestoreDirectory = true;
                dialog.ShowDialog();

                if (dialog.FileName != "")
                {
                    File.WriteAllText(dialog.FileName, data);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Save: " + ex.Message);
                throw;
            }
        }

        private static T DeserializeBase64<T>(string base64Data)
        {
            var textBytes = Convert.FromBase64String(base64Data);
            var formatter = new BinaryFormatter();

            using (var memoryStream = new MemoryStream(textBytes))
            {
                return (T)formatter.Deserialize(memoryStream);
            }
        }

        private static string GetChecksum(string data)
        {
            var md5 = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(md5.ComputeHash(Convert.FromBase64String(data)));
        }

        private static string getBase64Data(PlayerData character)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string text = BinaryFormatterExtensions.SerializeToString(formatter, character);
            string hash = GetChecksum(text);
            SaveData saveData = new SaveData(text, hash);
            return BinaryFormatterExtensions.SerializeToString(formatter, saveData); //yes it is encoded twice
        }

    }
}
