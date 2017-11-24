using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturePicker : ContentPage
    {
        public PicturePicker()
        {
            InitializeComponent();

            PickPictureButton.Clicked += async (sender, e) =>
            {
                PickPictureButton.IsEnabled = false;
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

                if (stream != null)
                {
                    Image image = new Image
                    {
                        Source = ImageSource.FromStream(() => stream),
                        BackgroundColor = Color.Gray
                    };

                    TapGestureRecognizer recognizer = new TapGestureRecognizer();
                    recognizer.Tapped += (sender2, args) =>
                    {
                        Content = Stack;
                        PickPictureButton.IsEnabled = true;
                    };
                    image.GestureRecognizers.Add(recognizer);

                    Content = image;
                }
                else
                {
                    PickPictureButton.IsEnabled = true;
                }
            };
        }
    }
}