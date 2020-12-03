using System;
using System.Collections;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Voice
{
    class PluginSearch : IPlugin
    {
        Agent agent;
        private string chromeBrowserPath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
        private string urlSearch = "https://fr.wikipedia.org/wiki/";
        public PluginSearch(Agent agent)
        {
            this.agent = agent;
        }
        public async Task doSomething(ArrayList args)
        {
            try
            {
                string seachText = args[0].ToString();
                await agent.SynthesisToSpeakerAsync("Voici la page wikipedia pour " + seachText);
                string searchTextForUrl = Regex.Replace(seachText, @"\s", "_");
                System.Diagnostics.Process.Start(chromeBrowserPath, urlSearch + searchTextForUrl);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                Console.WriteLine(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                Console.WriteLine(other.Message);
            }
        }
    }
}