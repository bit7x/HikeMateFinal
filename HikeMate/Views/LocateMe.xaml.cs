using HikeMate.Controller;
using HikeMate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace HikeMate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocateMe : Page
    {

        public Boolean trackingOn = false;
        Geolocator geolocator;
        String longitiude = "";
        String latitude = "";
        private Boolean initLocation = true;
        LocationModel location = new LocationModel();
        BasicGeoposition position = new BasicGeoposition();
        Double totalDistance = 0;
        SyncLocationData syncData = new SyncLocationData();

        public LocateMe()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnViewChange_Click(object sender, RoutedEventArgs e)
        {
            MapControl.Style = MapStyle.AerialWithRoads;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getMyLocation();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void getMyLocation()
        {
            if (!trackingOn)
            {

                geolocator = new Geolocator();
                Btn.Content = "Stop Tracking";
                geolocator.DesiredAccuracy = PositionAccuracy.High;
                geolocator.MovementThreshold = 10;
                geolocator.PositionChanged += geolocator_PositionChanged;
                trackingOn = true;
               
            }
            else
            {
                geolocator.PositionChanged -= geolocator_PositionChanged;
                geolocator = null;
                trackingOn = false;
                Btn.Content = "Start Tracking";
            }
        }

        public async  void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                    longitiude = args.Position.Coordinate.Point.Position.Longitude.ToString();
                    latitude = args.Position.Coordinate.Point.Position.Latitude.ToString();
                    if (initLocation == true)
                    {
                        location.Latitude = Convert.ToDouble(latitude);
                        location.Longitiude = Convert.ToDouble(longitiude);
                        initLocation = false;
                    }
                    Longi.Text = "Longitiude : " + longitiude + " ::" + " Latitiude : " + latitude;
                    Decimal longitiudes = Convert.ToDecimal(longitiude);
                    Decimal latitudes = Convert.ToDecimal(latitude);
                    
                position.Latitude = Convert.ToDouble(latitude);
                position.Longitude = Convert.ToDouble(longitiude);
                AddPushpin(position, "Location");
                location.CurrLattitude = Convert.ToDouble(latitude);
                location.CurrLongitiude = Convert.ToDouble(longitiude);
                GenerateDistance distance = new GenerateDistance(location);
                syncWithCloud();
                totalDistance = distance.CalculateDistanceTravelled();
                txtDistance.Text = Convert.ToString(totalDistance);
                });
          
        }

        public void AddPushpin(BasicGeoposition location, string text)
        {
            var pin = new Grid()
            {
                Width = 50,
                Height = 50,
                Margin = new Windows.UI.Xaml.Thickness(-12)
            };

            pin.Children.Add(new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DodgerBlue),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 3,
                Width = 50,
                Height = 50
            });

            pin.Children.Add(new TextBlock()
            {
                Text = text,
                FontSize = 12,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
            });

            MapControl.SetLocation(pin, new Geopoint(location));
            MapControl.Children.Add(pin);
            
        }

        private void syncWithCloud()
        {
            var LocationData = location;
            syncData.InsertLocationItem(LocationData);
        }


    }
}
