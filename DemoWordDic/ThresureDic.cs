using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NHunspell;

namespace DemoWordDic
{
    public class ThresureDic : ApiController
    {
        private List<ThesResult> Lookup(string word)
        {
            MyThes thes = new MyThes("th_en_us_new.dat");
            ThesResult tr = thes.Lookup(word);
            if (tr != null)
                return new List<ThesResult> {tr};
            var ret = new List<ThesResult>();
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                List<string> wordList = hunspell.Suggest(word);
                ret.AddRange(wordList.Select(w => thes.Lookup(w, hunspell)));
            }
            return ret;
        }

      


        public List<string> Meaning(string word)
        {
            List<ThesResult> trList = Lookup(word);
            List<string> retList= (from tr in trList from meaning in tr.Meanings select meaning.Description).ToList();
            return retList;
        }


      


        public List<string> Synonyms(string word)
        {
            List<ThesResult> trList = Lookup(word);
            List<string> retList = (from tr in trList from meaning in tr.Meanings from synonym in meaning.Synonyms select synonym).ToList();
            return retList;
        }
    }
}
