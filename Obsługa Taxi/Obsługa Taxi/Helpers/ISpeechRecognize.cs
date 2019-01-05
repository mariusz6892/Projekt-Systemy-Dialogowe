using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;

namespace Obsługa_Taxi.Helpers
{
    interface ISpeechRecognize
    {
        void InitializeSpeechRecognition();

        void EnableSpeechRecognition();

        Grammar GetSpeechGrammar();

        void StopSpeechRecognition();

        void WaitForSpeechRecognition();
    }
}
