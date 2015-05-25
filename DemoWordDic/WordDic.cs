using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NHunspell;

namespace DemoWordDic
{
    public class WordDic : ApiController
    {

        public bool IsWordExist(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                Console.WriteLine("Let's determine if"+word+" is spelled correctly.");
                return hunspell.Spell(word);
            }
        }


        public List<string> Suggestion(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                Console.WriteLine("Make suggestions for the word 'Recommendatio'");
               return hunspell.Suggest(word);               
            }
        }

        public List<string> AnalyzeWord(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                
                Console.WriteLine("Analyze the word '" + word + "'");
                return hunspell.Analyze(word);
            }
        }

        public List<string> Stem(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {

                Console.WriteLine("Stem the word '" + word + "'");
                return hunspell.Stem(word);
            }
        }

        public List<string> Pluralize(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {

                Console.WriteLine("Pluralize the word '" + word + "'");
                return hunspell.Generate(word, "boys");
            }
        }
    }
}
