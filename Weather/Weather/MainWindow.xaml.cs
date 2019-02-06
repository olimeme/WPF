using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using MaterialDesignThemes;
using MaterialDesignThemes.Wpf;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Weather
{
    public partial class MainWindow : Window
    {
        const string API_KEY = "N6LHz6fpxFZZfchOxBGvVqQJxAt58Cz0";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ShowWeather(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            ComboBoxItem item = Days.SelectedItem as ComboBoxItem;
            string dayStr = item.ToString();
            string withoutLetters = Regex.Replace(dayStr, "[A-Za-zА-Яа-я]", "").Replace(".", "").Replace(":", "").Replace(" ", "");

            WebClient client = new WebClient();
            var strLocation = (client.DownloadString(@"http://dataservice.accuweather.com/locations/v1/cities/search?apikey=" + API_KEY + "&q=" + City.Text + "&language=en-us"));
            var location = JsonConvert.DeserializeObject<List<Location.Location>>(strLocation);

            try
            {
                var result = client.DownloadString(@"http://dataservice.accuweather.com/forecasts/v1/daily/" + withoutLetters + "day/" + location[0].Key + "?apikey=" + API_KEY + "&language=en-us");
                var wheather = JsonConvert.DeserializeObject<ForeCast>(result);
                listBox.Items.Clear();
                for (int i = 0; i < wheather.DailyForecasts.Count; i++)
                {
                    string workingDirectory = Environment.CurrentDirectory;

                    ListBox weatherBlock = new ListBox()
                    {
                        Width = listBox.Width - 100,
                        Height = listBox.Height,
                        VerticalContentAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(25, 25, 25, 25),
                        Name = "wheather" + i,
                        
                    };

                    TextBlock textBox1 = new TextBlock()
                    {
                        Height = weatherBlock.Height / 3,
                        Width = weatherBlock.Width,
                        Text = "Min:" + wheather.DailyForecasts[i].Temperature.Minimum.Value + "\n Max: " + wheather.DailyForecasts[i].Temperature.Maximum.Value,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 12,
                        FontFamily = new FontFamily("Nirmala UI"),
                        FontWeight = FontWeights.Thin
                    };

                    TextBlock textBox2 = new TextBlock()
                    {
                        Height = weatherBlock.Height / 3,
                        Width = weatherBlock.Width / 2,
                        Text = "Morning: " + wheather.DailyForecasts[i].Day.IconPhrase,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 12,
                        FontFamily = new FontFamily("Nirmala UI"),
                        FontWeight = FontWeights.Thin
                    };

                    TextBlock textBox3 = new TextBlock()
                    {
                        Height = weatherBlock.Height / 3,
                        Width = weatherBlock.Width / 2,
                        Text = "Night: " + wheather.DailyForecasts[i].Night.IconPhrase,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 12,
                        FontFamily = new FontFamily("Nirmala UI"),
                        FontWeight = FontWeights.Thin
                    };

                    Image img = new Image()
                    {
                        Source = new BitmapImage(new Uri(workingDirectory + "/Icons/" + wheather.DailyForecasts[i].Day.Icon + ".png")),
                        Width = 100,
                        Height = 80,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };

                    Image img2 = new Image()
                    {
                        Source = new BitmapImage(new Uri(workingDirectory + "/Icons/" + wheather.DailyForecasts[i].Night.Icon + ".png")),
                        Width = 100,
                        Height = 80,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };

                    weatherBlock.Items.Add(textBox1);
                    weatherBlock.Items.Add(textBox2);
                    weatherBlock.Items.Add(img);
                    weatherBlock.Items.Add(textBox3);
                    weatherBlock.Items.Add(img2);
                    listBox.Items.Add(weatherBlock);
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show("Такого города не существует");
            }


        }

        private void listBox1_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
