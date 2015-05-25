using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NHunspell;

namespace DemoWordDic
{
    public class HyphenWordDic:ApiController
    {
        public string HyphenateWord(string word)
        {
            using (Hyphen hyphen = new Hyphen("hyph_en_us.dic"))
            {
                Console.WriteLine("Get the hyphenation of the word '"+word+"'");
                HyphenResult hyphenated = hyphen.Hyphenate(word);
               return hyphenated.HyphenatedWord;
            }
        }
    }
}
