using Android.Speech.Tts;
using App1.Droid.DependencyService;
using App1.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechDroid))]
namespace App1.Droid.DependencyService
{
    public class TextToSpeechDroid : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _toSpeak;

        public void Speak(string text)
        {
            _toSpeak = text;
            if(_speaker == null)
                _speaker = new TextToSpeech(Forms.Context,this);
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
        }
    }
}