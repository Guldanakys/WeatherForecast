using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//96n2
namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        String[] cityNames = new String[18];
        Dictionary<string, string[]> data = new Dictionary<string, string[]>();
        Dictionary<string, Label> label = new Dictionary<string, Label>();
        
        public Form1()
        {
            InitializeComponent();
            label.Add("almaty", label1);
            label.Add("astana", label2);
            label.Add("karaganda", label3);
            label.Add("atyrau", label4);
            label.Add("uralsk", label5);
            label.Add("semey", label6);
            label.Add("pavlodar", label7);
            label.Add("shymkent", label8);
            label.Add("kostanay", label9);
            label.Add("aktobe", label10);
            label.Add("aktau", label11);
            label.Add("toldykorgan", label12);
            label.Add("kokshetau", label13);
            label.Add("jezkazgan", label14);
            label.Add("petropavlovsk", label15);
            label.Add("taraz", label16);
            label.Add("kyzylorda", label17);
            label.Add("ust-kamenogorsk", label18);

            cityNames[0] = "almaty";
            cityNames[1] = "astana";
            cityNames[2] = "karaganda";
            cityNames[3] = "atyrau";
            cityNames[4] = "uralsk";
            cityNames[5] = "semey";
            cityNames[6] = "pavlodar";
            cityNames[7] = "shymkent";
            cityNames[8] = "kostanay";
            cityNames[9] = "aktobe";
            cityNames[10] = "aktau";
            cityNames[11] = "toldykorgan";
            cityNames[12] = "kokshetau";
            cityNames[13] = "jezkazgan";
            cityNames[14] = "petropavlovsk";
            cityNames[15] = "taraz";
            cityNames[16] = "kyzylorda";
            cityNames[17] = "ust-kamenogorsk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            for (int j = 0; j < 18; j++)
            {
                string name = cityNames[j];
                

                if (!data.ContainsKey(name))
                {
                    Console.WriteLine("online:");

                    string url = string.Format("http://www.kazhydromet.kz/rss-pogoda.php?id={0}", name);

                    XmlReader reader = XmlReader.Create(url);

                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    reader.Close();

                    if (feed.Items.Count() > 0)
                    {
                        string text = feed.Items.ElementAt(1).Summary.Text;

                        string[] arr = text.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);

                        if (arr.Length >= 4)
                        {
                            for (int i = 0; i < arr.Length; ++i)
                            {
                                arr[i] = arr[i].Trim();
                            }

                            data[name] = arr;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data not found!");
                    }
                }
                else
                {
                    Console.WriteLine("offline:");

                }
                label[name].Text = data[name][0];
                //Console.WriteLine(name + ": " + data[name][0]);
            }
        }

    }
}

