using System;

namespace Voice
{
    class Program
    {
        static Agent myAgent = Agent.getInstance("700c9cd2111a42569a901b2007952169", "francecentral");
        static void Main(string[] args)
        {
            myAgent.onSpeech += CallbackVoice;
            myAgent.startListening();
            Console.WriteLine("Please press <Return> to continue.");
            Console.ReadLine();
        }

        static async void CallbackVoice(string text)
        {
            await myAgent.stopListening();
            Sentence sentence = Sentence.searchSentence(text);
            if (sentence != null)
            {
                IPlugin plugin = PluginFactory.GetPlugin(myAgent, sentence);
                if (plugin != null)
                {
                    await plugin.doSomething(sentence.Args);
                }
            }
            //await myAgent.SynthesisToSpeakerAsync(text);
            myAgent.startListening();
            //Console.WriteLine("J'ai dit ça :" + text);
        }
    }
}
