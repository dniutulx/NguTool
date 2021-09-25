using NguTool.Classlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NguTool.Cli
{
    static class Commands
    {
        // these should be config
        const string defaultLoadFile = @"%userprofile%\AppData\LocalLow\NGU Industries\NGU Idle\NGUSaveSteam.txt";
        const string defaultSaveFile = @"d:\%homepath%\Desktop\cheater.txt";

        internal static CommandResult Parse(string command)
        {
            //string.Split, but treat "quoted strings" as one element
            var commandParts =
                Regex.Matches(command.ToLower(), @"[\""].+?[\""]|[^ ]+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            var baseCommand = commandParts[0];
            var commandParameters = commandParts.Skip(1).ToArray();

            var result = new CommandResult()
            {
                Success = false,
                Message = "Unknown error: result was not set"
            };

            switch (baseCommand)
            {
                #region help
                case "help":
                    result = Help(commandParameters);
                    break;
                #endregion

                #region file load and save
                case "load":
                    result = LoadFile(commandParameters);
                    break;
                case "save":
                    result = SaveFile(commandParameters);
                    break;
                #endregion

                #region sellout shop
                case "buyap":
                    result = BuyAp(commandParameters);
                    break;
                case "buypack":
                    result = BuySelloutPack(commandParameters);
                    break;
                #endregion

                #region analysis
                case "cook":
                    result = GetRecipe(commandParameters);
                    break;

                case "lrb":
                    break;

                    #endregion
            }
            return result;

        }

        private static CommandResult Help(params string[]? parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            //if(!string.IsNullOrEmpty(parameters[0]))
            //{
            //    //TODO get help for specific command
            //}

            return new CommandResult()
            {
                Success = true,
                Message = "if I were helpful I'd have a list of commands here."
            };
        }

        private static CommandResult BuyAp(params string[]? parameters)
        {
            //buyap [options] number
            try
            {
                var count = int.Parse(parameters.Last());
                Character.BuyAp(count);
                return new CommandResult()
                {
                    Success = true,
                    Message = $"bought {count} AP, modified by character bonuses"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"AP buy failed. Message: {ex.Message}"
                };
            }
        }

        private static CommandResult BuySelloutPack(params string[]? parameters)
        {
            //newbie: next or specific
            //special pack: name

            return new CommandResult()
            {
                Success = false,
                Message = "Not implemented"
            };
        }

        private static CommandResult LoadFile(params string[] parameters)
        {
            //load [type] [options] filepath
            try
            {
                var file = parameters.Last().Replace("default", Path.GetFullPath(Environment.ExpandEnvironmentVariables(defaultLoadFile)));
                if (parameters.Length > 1) Character.LoadFromFile(file, parameters[0]);
                else Character.LoadFromFile(file);
                return new CommandResult()
                {
                    Success = true,
                    Message = $"File loaded"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"File load failed. Message: {ex.Message}"
                };
            }
        }
        private static CommandResult SaveFile(params string[] parameters)
        {
            //save [type] [options] filepath
            try
            {
                var file = parameters.Last().Replace("default", Path.GetFullPath(Environment.ExpandEnvironmentVariables(defaultSaveFile)));
                if (parameters.Length > 1) Character.SaveToFile(file, parameters[0]);
                else Character.SaveToFile(file);
                return new CommandResult()
                {
                    Success = true,
                    Message = $"File saved"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"File save failed. Message: {ex.Message}"
                };
            }
        }

        private static CommandResult GetRecipe(params string[]? parameters)
        {
            //cook [options]
            try
            {
                return new CommandResult()
                {
                    Success = true,
                    Message = Character.Cook()
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"Could not get recipe. Message: {ex.Message}"
                };
            }
        }

        private static CommandResult LrbForHours(params string[]? parameters) //fka chicken-4-dayz
        {
            //lrb hours [options] [currentPower] [duration in hours]

            //this whole thing is bad


            try
            {
                var ticks = long.Parse(parameters.Last()) * 3600 * 50;
                string result;

                var ticksPerLevel = new List<int>();

                if (parameters.Contains<string>("allbb"))
                {
                    for (var i = 0; i< 8; i++)
                    {
                        ticksPerLevel.Add(1);
                    }
                }
                else
                {
                    result = Character.LRBByTicks(
                        1,
                        ticks,
                        int.Parse(parameters[1]), //AT
                        int.Parse(parameters[2]), //BEARd
                        int.Parse(parameters[3]), //ngu a normal
                        int.Parse(parameters[4]), //ngu b normal
                        int.Parse(parameters[5]), //ngu a evil
                        int.Parse(parameters[6]), //ngu b evil
                        int.Parse(parameters[7]), //ngu a sad
                        int.Parse(parameters[8])  //ngu b sad
                        );
                }


                return new CommandResult()
                {
                    Success = true
                    //Message = Character.LRBByTicks();
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"LRB failed. Message: {ex.Message}"
                };
            }
        }
        private static CommandResult LrbToGoal(params string[]? parameters) //fka chicken-4-dayz
        {
            //lrb goal [options] [end power]
            
            try
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = "Not implemented"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    Success = false,
                    Message = $"LRB failed. Message: {ex.Message}"
                };
            }
        }
    }

    public class CommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
