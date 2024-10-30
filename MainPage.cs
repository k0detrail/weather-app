using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weather_app
{
    public partial class MainPage : Form
    {
        private const string ApiKey = "941f082f0e3a26b785cb79a1c053ef26";

        public MainPage()
        {
            InitializeComponent();
            LoadWeatherData("Midsayap"); // load initial city data
        }

        private async void LoadWeatherData(string city)
        {
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                    // display the data
                    label1.Text = $"Temperature: {weatherData.Main.Temp}°C";
                    label2.Text = $"Feels Like: {weatherData.Main.FeelsLike}°C";
                    label4.Text = $"Temp min: {weatherData.Main.TempMin}°C";
                    label5.Text = $"Temp max: {weatherData.Main.TempMax}°C";
                    label6.Text = $"Pressure: {weatherData.Main.Pressure}hPa";
                    label7.Text = $"Humidity: {weatherData.Main.Humidity}%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // temperature
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // feels like temperature
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // search box
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(city))
            {
                LoadWeatherData(city);
            }
            else
            {
                MessageBox.Show("Please enter a city name.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // temp min
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // temp max
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // pressure
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // humidity
        }
    }

    public class WeatherData
    {
        public MainInfo Main { get; set; }
    }

    public class MainInfo
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]

        public double TempMax { get; set; }

        [JsonProperty("Pressure")]

        public double Pressure { get; set; }

        [JsonProperty("Humidity")]

        public double Humidity { get; set; }
    }
}