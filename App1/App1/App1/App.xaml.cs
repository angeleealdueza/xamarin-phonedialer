using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //startup page
            MainPage = new MainPage();
            /*
            
            MainPage = new ContentPage {
                    Content = new StackLayout
                    {
                        Spacing =0,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label
                            {
                                Text = "Stacking",
                            },
                            new Label
                            {
                                Text = "can also be",
                                HorizontalOptions = LayoutOptions.CenterAndExpand
                            },
                            new Label
                            {
                                Text = "horizontal"
                            }
                        }
                        */
                        /*VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Label
                            {
                                XAlign = TextAlignment.Center,
                                Text = "Welcome to Xamarin Formsz!",
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalOptions = LayoutOptions.CenterAndExpand
                            }
                        }
                    }
            };*/
            
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
