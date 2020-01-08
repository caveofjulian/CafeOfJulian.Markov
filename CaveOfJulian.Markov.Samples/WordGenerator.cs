using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov.Samples
{
    public class WordGenerator
    {
        public void Run()
        {
            double[,] probabilities =
            {
                {0, 0.5, 0.5},
                {0.5, 0, 0.5},
                {0.5, 0.5, 0}
            };

            Func<string, string>[,] funcs =
            {
                {GetNoun, GetVerb, GetAdjective},
                {GetNoun, GetVerb, GetAdjective},
                {GetNoun, GetVerb, GetAdjective},
            };

            var chain = new MarkovActionChain<string>(probabilities, funcs);
            chain.Run();
        }


        public static string GetNoun(string sentence)
        {
            return sentence + GetRandomNoun();
        }
        public static string GetAdjective(string sentence)
        {
            return sentence + GetRandomAdjective();
        }
        public static string GetVerb(string sentence)
        {
            return sentence + GetRandomVerb();
        }
        
        private static string GetRandomNoun()
        {
            return "sample"
        }

        private static string GetRandomAdjective()
        {
            return "sample";
        }

        private static string GetRandomVerb()
        {
            return "sample";
        }
    }
}
