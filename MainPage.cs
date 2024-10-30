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
        private const string City = "Midsayap";

        public MainPage()
        {
            InitializeComponent();
            LoadWeatherData();
        }

        private async void LoadWeatherData()
        {
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={City}&appid={ApiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                    // display the temperature and feels like temperature
                    label1.Text = $"Temperature: {weatherData.Main.Temp}°C";
                    label2.Text = $"Feels Like: {weatherData.Main.FeelsLike}°C";
                    label4.Text = $"Temp min: {weatherData.Main.TempMin}";
                    label5.Text = $"Temp max: {weatherData.Main.TempMax}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // temperature label click handler
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // feels like temperature label click handler
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // temp min temperature label click handler
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // temp max temperature label click handler
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
    }
}