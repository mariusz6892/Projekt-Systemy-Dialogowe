using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using Microsoft.Speech.Synthesis;

namespace Obsługa_Taxi.Helpers
{
    public class SpeechPage : Page, ISpeechRecognize, ISpeechSynthesis
    {
        private CultureInfo CultureInfo = new CultureInfo("pl-PL");

        private SpeechRecognitionEngine speechRecognitionEngine;

        private SpeechSynthesizer speechSynthesizer;

        public SpeechPage()
        {
            ExecuteBackgroundAction(InitializeSpeech);
        }


        protected virtual void AddCustomSpeechGrammarRules(SrgsRulesCollection srgsRules)
        {
        }

        protected void DispatchAsync(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        protected void DispatchSync(Action action)
        {
            Dispatcher.Invoke(action);
        }

        public void EnableSpeechRecognition()
        {
            try
            {
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (InvalidOperationException ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            catch (NullReferenceException)
            {
            }
        }

        protected void ExecuteBackgroundAction(DoWorkEventHandler action)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += action;
            backgroundWorker.RunWorkerAsync();
        }

        public Grammar GetSpeechGrammar()
        {
            SrgsDocument srgsDocument = new SrgsDocument("./Assets/" + GetType().Name + ".srgs");

            AddCustomSpeechGrammarRules(srgsDocument.Rules);
            Grammar grammar = new Grammar(srgsDocument);
            return grammar;
        }

        public virtual void InitializeSpeech(object sender, DoWorkEventArgs e)
        {
            

            InitializeSpeechSynthesis();

            InitializeSpeechRecognition();

            EnableSpeechRecognition();
        }

        public void InitializeSpeechRecognition()
        {
            speechRecognitionEngine = new SpeechRecognitionEngine(CultureInfo);
            ReloadGrammars();
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
        }

        public void InitializeSpeechSynthesis()
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.SetOutputToDefaultAudioDevice();
        }

        protected void LoadGrammarAsync(Grammar grammar)
        {
            speechRecognitionEngine.LoadGrammarAsync(grammar);
        }

        protected void ReloadGrammars()
        {
            speechRecognitionEngine.UnloadAllGrammars();
            
            LoadGrammarAsync(GetSpeechGrammar());
        }

        public void Speak(string message)
        {
            PromptBuilder promptBuilder = new PromptBuilder(CultureInfo);
            promptBuilder.AppendText(message);

            Prompt prompt = new Prompt(promptBuilder);

            Speak(prompt);
        }

        public async void Speak(Prompt prompt)
        {

            StopSpeechRecognition();

            await Task.Run(() =>
            {
                try
                {
                    speechSynthesizer.Speak(prompt);

                    EnableSpeechRecognition();

                }
                catch (OperationCanceledException)
                {
                }
            });
        }

        protected virtual void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            RecognitionResult result = e.Result;

            Console.WriteLine(GetType().Name + "[" + result.Semantics.Value + "] " + result.Text + " (" + result.Confidence + ")");
        }

        public void StopSpeak()
        {
            speechSynthesizer.SpeakAsyncCancelAll();

            EnableSpeechRecognition();
        }

        public void StopSpeechRecognition()
        {
            try
            {
                speechRecognitionEngine.RecognizeAsyncCancel();
            }
            catch (InvalidOperationException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }

        public void WaitForSpeechRecognition()
        {
            try
            {
                speechRecognitionEngine.RecognizeAsyncStop();
            }
            catch (InvalidOperationException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
