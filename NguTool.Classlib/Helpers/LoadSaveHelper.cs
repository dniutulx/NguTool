using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace NguTool.Classlib.Helpers
{
    public static class LoadSaveHelper
    {
        public static PlayerData ReadSaveData(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Bad file path: {path}");
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

        public static PlayerData ReadJsonData(string path)
        {
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

        public static bool SavePlayerData(PlayerData character, string path)
        {
            var base64Data = getBase64Data(character);
            File.WriteAllText(path, base64Data);

            return true;
        }

        public static bool SaveJsonData(PlayerData character, string path)
        {
            var data = JsonConvert.SerializeObject(character, Formatting.Indented);
            File.WriteAllText(path, data);

            return true;
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
