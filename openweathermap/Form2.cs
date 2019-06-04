using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace openweathermap
{
    public partial class Form2 : Form
    {
        public Form2(string str)
        {
            InitializeComponent();


            try
            {
                // , /hourly , /daily
                //string str = "Bryansk";
                //api.openweathermap.org/data/2.5/forecast?q={city name},{country code}"
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + str + "&appid=ff074a02e8feab3c773b994eeb207aa1&units=metric";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }
                FiveDayWeatherResponse weatherResponse = JsonConvert.DeserializeObject<FiveDayWeatherResponse>(response);
                label2.Text = weatherResponse.City.Name;
                label4.Text = weatherResponse.City.Country;
                label2.Update();
                label4.Update();
                ///
                var column1 = new DataGridViewColumn();
                column1.HeaderText = "Дата Время"; //текст в шапке
                column1.Width = 150; //ширина колонки
                column1.ReadOnly = true; //значение в этой колонке нельзя править
                column1.Name = "Data"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
                column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
                column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

                var column2 = new DataGridViewColumn();
                column2.HeaderText = "Температура";
                column2.Name = "Temp";
                column2.CellTemplate = new DataGridViewTextBoxCell();

                var column3 = new DataGridViewColumn();
                column3.HeaderText = "Давление";
                column3.Name = "Pressure";
                column3.CellTemplate = new DataGridViewTextBoxCell();

                var column4 = new DataGridViewColumn();
                column4.HeaderText = "Влажность";
                column4.Name = "Humidity";
                column4.CellTemplate = new DataGridViewTextBoxCell();

                var column5 = new DataGridViewColumn();
                column5.HeaderText = "Облока";
                column5.Name = "Cloud";
                column5.CellTemplate = new DataGridViewTextBoxCell();

                var column6 = new DataGridViewColumn();
                column6.HeaderText = "Ветер";
                column6.Name = "Wind";
                column6.CellTemplate = new DataGridViewTextBoxCell();

                var column7 = new DataGridViewColumn();
                column7.Width = 150;
                column7.HeaderText = "Погода";
                column7.Name = "Weather";
                column7.CellTemplate = new DataGridViewTextBoxCell();

                dataGridView1.Columns.Add(column1);
                dataGridView1.Columns.Add(column2);
                dataGridView1.Columns.Add(column3);
                dataGridView1.Columns.Add(column4);
                dataGridView1.Columns.Add(column5);
                dataGridView1.Columns.Add(column6);
                dataGridView1.Columns.Add(column7);
                ///
                ///
                DataGridView dgv = dataGridView1;
                dgv.AllowUserToAddRows = false;
                for (int item = 0; item < weatherResponse.Cnt; item++)
                {
                    string[] content =
                    {
                        weatherResponse.List[item].Dt_txt,
                        string.Format(weatherResponse.List[item].Main.Temp.ToString()),
                        weatherResponse.List[item].Main.Pressure.ToString(),
                        weatherResponse.List[item].Main.Humidity.ToString(),
                        weatherResponse.List[item].Clouds.All.ToString(),
                        weatherResponse.List[item].Wind.Speed.ToString(),
                        weatherResponse.List[item].Weather[0].Description
                    };
                    dgv.Rows.Add(content);
                }
            }
            catch
            {
                MessageBox.Show("error DataGridView!");
            }
        }


    }
}
