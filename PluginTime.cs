using System;
using System.Collections;
using System.Threading.Tasks;

namespace Voice
{
    class PluginTime : IPlugin
    {
        Agent agent;

        public PluginTime(Agent agent)
        {
            this.agent = agent;
        }
        public async Task doSomething(ArrayList args)
        {
            DateTime localDate = DateTime.Now;
            string text = "Il est " + localDate.Hour + " heure " + localDate.Minute;
            await agent.SynthesisToSpeakerAsync(text);
        }
    }
}