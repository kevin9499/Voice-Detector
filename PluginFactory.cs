using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace Voice
{
    class PluginFactory
    {
        public static IPlugin GetPlugin(Agent agent, Sentence sentence)
        {
            Console.WriteLine("Sentence pluging: " + sentence.Plugin);
            if (sentence.Plugin.Equals("time"))
            {
                return new PluginTime(agent);

            }
            else if (sentence.Plugin.Equals("searchweb"))
            {
                return new PluginSearch(agent);
            }
            else
            {
                return null;
            }
        }
    }
}
