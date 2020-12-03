using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using System.Text.RegularExpressions;

namespace Voice
{
    class Sentence
    {
        private String value;

        private String plugin;

        private ArrayList args;

        public Sentence(string value, string plugin)
        {
            this.value = value;
            this.plugin = plugin;
            this.args = new ArrayList();
        }

        public String Value { get { return value; } }

        public String Plugin { get { return plugin; } }

        public ArrayList Args { get { return args; } }

        public static ArrayList GetAllSentences()
        {
            ArrayList list = new ArrayList();

            list.Add(new Sentence(@"Il est quelle heure", "time"));
            list.Add(new Sentence(@"Quelle heure est-il", "time"));
            list.Add(new Sentence(@"Qui est (?<searchWord>[a-zA-Z\s]+)", "searchweb"));

            return list;
        }

        public static Sentence searchSentence(String text)
        {
            foreach (Sentence s in GetAllSentences())
            {
                Match result = Regex.Match(text, s.value);
                if (result.Success)
                {
                    Group grp = result.Groups["searchWord"];
                    s.args.Add(grp.Value);
                    return s;
                }
            }
            return null;
        }
    }
}