using Newtonsoft.Json;
using NguTool.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NguTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerData character;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadSaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerDataTextbox.Clear();
                character = LoadSaveHelper.ReadSaveData();

                var playerText = JsonConvert.SerializeObject(character, Formatting.Indented);
                PlayerDataTextbox.Text = playerText;
                StatusTextbox.Text = "Loaded file";
            }
            catch(Exception ex)
            {
                StatusTextbox.Text = $"Error loading save file!\r\n{ex.Message}";
            }
            UpdateEverything();

        }

        private void LoadJsonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerDataTextbox.Clear();
                character = LoadSaveHelper.ReadJsonData();

                var playerText = JsonConvert.SerializeObject(character, Formatting.Indented);
                PlayerDataTextbox.Text = playerText;
                StatusTextbox.Text = "Loaded file";
            }
            catch (Exception ex)
            {
                StatusTextbox.Text = $"Error loading save file!\r\n{ex.Message}";
            }
            UpdateEverything();
        }

        private void SaveSaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadSaveHelper.SavePlayerData(character);
                StatusTextbox.Text = "Saved file";
            }
            catch (Exception ex)
            {
                StatusTextbox.Text = $"Error saving file!\r\n{ex.Message}";
            }
        }

        private void SaveJsonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadSaveHelper.SaveJsonData(character);
                StatusTextbox.Text = "Saved file";
            }
            catch (Exception ex)
            {
                StatusTextbox.Text = $"Error saving file!\r\n{ex.Message}";
            }
        }

        private void SpoilersCheckbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateEverything()
        {
            //cooking

            var cookingScores = Cooking.OptimizeRecipe(character);
            string cookingMessage =
                $"Ing 1: {cookingScores[0].level}\t\t Ing 2:{cookingScores[1].level}\r\n" +
                $"Ing 3: {cookingScores[2].level}\t\t Ing 4:{cookingScores[3].level}\r\n" +
                $"Ing 5: {cookingScores[4].level}\t\t Ing 6:{cookingScores[5].level}\r\n" +
                $"Ing 7: {cookingScores[6].level}\t\t Ing 8:{cookingScores[7].level}";

            CookingTextbox.Text = cookingMessage;


            //AP



        }
    }
}
