using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;

namespace DemoWordDic
{
    class Program
    {
        private static void GetMeaning(ThesResult tr)
        {
            if (tr.IsGenerated)
                Console.WriteLine("Generated over stem " +
                  "(The original word form wasn't in the thesaurus)");
            foreach (ThesMeaning meaning in tr.Meanings)
            {
                Console.WriteLine();
                Console.WriteLine("  Meaning: " + meaning.Description);

                foreach (string synonym in meaning.Synonyms)
                {
                    Console.WriteLine("    Synonym: " + synonym);

                }
            }
        }

        static void Main(string[] args)
        {

            MyThes thes = new MyThes("th_en_us_new.dat");

            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                //List<string> a= hunspell.("salary");
                
                string word = "blackl";
                ThesResult tr = thes.Lookup(word, hunspell);
              
                if (tr != null)
                    GetMeaning(tr);
                else
                {
                    List<string> wordList = hunspell.Suggest(word);
                    foreach (var w in wordList)
                    {
                        tr = thes.Lookup(w, hunspell);
                        if (tr != null)
                            GetMeaning(tr);
                    }
                }
            }
        }
    }
}
