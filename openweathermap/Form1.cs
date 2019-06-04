using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace openweathermap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string connectionWeather(string pref = "/weather")// , /hourly , /daily , /history/city
        {
            string response;
            string str = textBox1.Text;
            string url = "http://api.openweathermap.org/data/2.5"+pref+"?q=" + str + "&appid=ff074a02e8feab3c773b994eeb207aa1&units=metric";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            return response;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string response = connectionWeather();
                
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                label1.Text = "City: " + weatherResponse.Name;
                label2.Text = "Temperature: " + weatherResponse.Main.Temp + ", °C";
                label3.Text = "Humidity: " + weatherResponse.Main.Humidity + ", %";
                label4.Text = "Pressure: " + weatherResponse.Main.Pressure + ", hPa";
                label5.Text = "Cloudiness: " + weatherResponse.Clouds.All + ", %";
                label6.Text = "Wind speed: " + weatherResponse.Wind.Speed + ", m/s";
                label7.Text = weatherResponse.Weather[0].Main;
                label8.Text = "Country: " + weatherResponse.Sys.Country;
                label9.Text = "Sunrise: " + weatherResponse.Sys.ConvertFromUnixTimestamp(weatherResponse.Sys.Sunrise) + ", UTC";
                label10.Text = "Sunset: " + weatherResponse.Sys.ConvertFromUnixTimestamp(weatherResponse.Sys.Sunset) + ", UTC";
                //label1.Text = "Город: " + weatherResponse.Name;
                //label2.Text = "Температура: " + weatherResponse.Main.Temp + ", °C";
                //label3.Text = "Влажность: " + weatherResponse.Main.Humidity + ", %";
                //label4.Text = "Давление: " + weatherResponse.Main.Pressure + ", hPa";
                //label5.Text = "Облачность: " + weatherResponse.Clouds.All + ", %";
                //label6.Text = "Скорость ветра: " + weatherResponse.Wind.Speed;
                //label7.Text = weatherResponse.Weather[0].Description;
                //label8.Text = "Страна: " + weatherResponse.Sys.Country;
                //label9.Text = "Рассвет: " + weatherResponse.Sys.ConvertFromUnixTimestamp(weatherResponse.Sys.Sunrise) + ", UTC";
                //label10.Text = "Закат: " + weatherResponse.Sys.ConvertFromUnixTimestamp(weatherResponse.Sys.Sunset) + ", UTC";

                label1.Update();
                label2.Update();
                label3.Update();
                label4.Update();
                label5.Update();
                label6.Update();
                label7.Update();
                label8.Update();
                label9.Update();
                label10.Update();
            }
            catch
            {
                MessageBox.Show("error connecting!");
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                try
                {
                    Form2 newForm = new Form2(str);
                    newForm.Show();

                }
                catch { MessageBox.Show("form not found!"); }
            }
            catch
            {
                MessageBox.Show("error connecting!");
            }
        }
        private void Label5_Click(object sender, EventArgs e){        }
    }
}
