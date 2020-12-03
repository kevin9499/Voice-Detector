using System;
using System.Collections;
using System.Threading.Tasks;


namespace Voice
{
    interface IPlugin
    {
        Task doSomething(ArrayList args);
    }
}