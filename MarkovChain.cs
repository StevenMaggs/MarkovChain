using System;
using System.Collections.Generic;

namespace MarkovChainNameGenerator
{
    public static class MarkovChain
    {
        public static string GenerateName(int lengthMin, int lengthMax, string trainingData, int order)
        {
            Dictionary<string, List<string>> ngrams = InitializeNGrams(trainingData, order);
            List<string> parsedTrainingData = ParseTrainingData(trainingData);

            Random random = new Random();
            int nameLength = random.Next(lengthMin, lengthMax + 1);

            string currentGram = parsedTrainingData[random.Next(parsedTrainingData.Count)].Substring(0, order);
            string name = currentGram;

            for (int i = 0; i < nameLength; i++)
            {
                string randomLetter = ngrams[currentGram][random.Next(ngrams[currentGram].Count)];
                name += randomLetter;

                currentGram = name.Substring(name.Length - order, order);
            }

            return name;
        }

        private static Dictionary<string, List<string>> InitializeNGrams(string trainingData, int order)
        {
            Dictionary<string, List<string>> ngrams = new Dictionary<string, List<string>>();
            List<string> parsedTrainingData = ParseTrainingData(trainingData);

            for (int n = 0; n < parsedTrainingData.Count; n++)
            {
                string currentData = parsedTrainingData[n];
                for (int i = 0; i < currentData.Length - order + 1; i++)
                {
                    string currentGram = currentData.Substring(i, order);

                    if (!ngrams.ContainsKey(currentGram))
                        ngrams.Add(currentGram, new List<string>());
                    
                    string nextCharacter = i + order >= currentData.Length ? "" : currentData[i + order].ToString();
                    ngrams[currentGram].Add(nextCharacter);
                }
            }

            return ngrams;
        }

        private static List<string> ParseTrainingData(string trainingData)
        {
            List<string> parsedTrainingData = new List<string>();

            string current = "";
            for (int i = 0; i < trainingData.Length; i++)
            {
                if (trainingData[i] != ' ')
                    current += trainingData[i];
                else
                {
                    parsedTrainingData.Add(current);
                    current = "";
                }
            }
            
            return parsedTrainingData;
        }
    }
}