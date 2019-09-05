using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        string translatedNumber;

        public MainPage()
        {
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Welcome to Xamarin.Forms!" }
            //    }
            //};

            this.Padding = new Thickness(20, 20, 20, 20);
            StackLayout panel = new StackLayout();
            panel.Spacing = 15;

            panel.Children.Add(new Label
            {
                Text = "enter a phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN"
            });

            panel.Children.Add(translateButton = new Button()
            {
                Text = "translate"
            });

            panel.Children.Add(callButton = new Button()
            {
                Text = "Call",
                IsEnabled = false
            });

            translateButton.Clicked += TranslateButton_Clicked;
            callButton.Clicked += CallButton_Clicked;

            this.Content = panel;
        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?", "Yes", "No"))
            {
                //native phone dialer; dependency injection

                IDialer dialer = DependencyService.Get<IDialer>();

                if(dialer != null)
                {
                    await dialer.DialAsync(translatedNumber);
                }
            }
        }

        private void TranslateButton_Clicked(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if(!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call" + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }

            //throw new NotImplementedException();
        }
    }
}