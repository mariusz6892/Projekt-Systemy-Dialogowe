using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi.Helpers
{
    interface ISpeechSynthesis
    {
        void InitializeSpeechSynthesis();

        void Speak(string message);

        void StopSpeak();
    }
}
