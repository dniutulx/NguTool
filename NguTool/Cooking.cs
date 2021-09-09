using System;
using System.Collections.Generic;
using System.Text;

namespace NguTool
{
    internal class Cooking
    {
        const int maxIngredientLevel = 20;

        internal static Dictionary<int, IngredientScored> OptimizeRecipe(PlayerData character)
        {
            var cooking = character.cooking;
            var ingredients = cooking.ingredients;
            var scores = new Dictionary<int, IngredientScored>();
            var pairs = new List<Pair>
            {
                new Pair(){ingredIndex1= cooking.pair1[0], ingredIndex2 = cooking.pair1[1], target = cooking.pair1Target},
                new Pair(){ingredIndex1= cooking.pair2[0], ingredIndex2 = cooking.pair2[1], target = cooking.pair2Target},
                new Pair(){ingredIndex1= cooking.pair3[0], ingredIndex2 = cooking.pair3[1], target = cooking.pair3Target},
                new Pair(){ingredIndex1= cooking.pair4[0], ingredIndex2 = cooking.pair4[1], target = cooking.pair4Target},
            };

            foreach (var pair in pairs)
            {
                var res = OptimizeIngredientPair(ingredients[pair.ingredIndex1], ingredients[pair.ingredIndex2], pair.target);
                Console.WriteLine($"Pair [{pair.ingredIndex1}, {pair.ingredIndex2}]: ing1 level {res.ingredientLevel1}, ing2 level {res.ingredientLevel2}, score {res.score}");
                scores.Add(pair.ingredIndex1,
                    new IngredientScored
                    {
                        level = res.ingredientLevel1,
                        score = res.score
                    }
                );
                scores.Add(pair.ingredIndex2,
                    new IngredientScored
                    {
                        level = res.ingredientLevel2,
                        score = res.score
                    }
                );
            }

            return scores;
        }

        /// <summary>
        /// Returns optimized levels and score for an ingredient pair
        /// </summary>
        /// <param name="ingredient1">First paired ingredient. Used for paired weight</param>
        /// <param name="ingredient2">Second paired ingredient</param>
        /// <param name="pairTarget">Pair target level</param>
        /// <returns></returns>
        internal static OptimizedPair OptimizeIngredientPair(Ingredient ingredient1, Ingredient ingredient2, int pairTarget)
        {

            double workingScore = 0;
            var pair = new OptimizedPair
            {
                ingredientLevel1 = 0,
                ingredientLevel2 = 0,
                score = 0f
            };

            for (int i = 0; i <= maxIngredientLevel; i++)
            {
                for (int j = 0; j <= maxIngredientLevel; j++)
                {
                    workingScore = 0f;
                    if (ingredient1.unlocked)
                    {
                        workingScore += getLocalScore(ingredient1, i) + getLocalScore(ingredient2, i);
                    }
                    if (ingredient2.unlocked)
                    {
                        workingScore += getLocalScore(ingredient1, j) + getLocalScore(ingredient2, j);
                    }
                    if (ingredient1.unlocked && ingredient2.unlocked)
                    {
                        workingScore += getPairedScore(ingredient1, pairTarget, i + j);
                    }
                    if (workingScore > pair.score)
                    {
                        pair.score = workingScore;
                        pair.ingredientLevel1 = i;
                        pair.ingredientLevel2 = j;
                    }
                }
            }
            return pair;
        }

        internal static double getLocalScore(Ingredient ingredient, int level)
        {
            int num = Math.Abs(ingredient.targetLevel - level);
            return Math.Pow(1f - 0.03f * (double)num, 30f) * ingredient.weight;
        }

        /// <summary>
        /// Returns weighted pair score. Per game, only uses the weight of ingredient pair[0]
        /// </summary>
        /// <param name="ingredient1"></param>
        /// <param name="pairTarget"></param>
        /// <param name="pairLevel"></param>
        /// <returns></returns>
        internal static double getPairedScore(Ingredient ingredient1, int pairTarget, int pairLevel)
        {
            int num = Math.Abs(pairTarget - pairLevel);
            return Math.Pow(1f - .02f * num, 40f) * ingredient1.pairedWeight;
        }

    }

    internal class Pair
    {
        internal int ingredIndex1;
        internal int ingredIndex2;
        internal int target;
    }

    internal class OptimizedPair
    {
        internal int ingredientLevel1;
        internal int ingredientLevel2;
        internal double score;
    }

    internal class IngredientScored
    {
        internal int level;
        internal double score;
    }
}
