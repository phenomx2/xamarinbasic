using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Interfaces;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var textToSpeech = DependencyService.Get<ITextToSpeech>();
            textToSpeech.Speak(TextToSpeak.Text);
        }
    }
}
