using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Example1
{
    class Program
    {

        static Dictionary<string, string[]> data = new Dictionary<string, string[]>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            String[] cityNames = new String[18];
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


            //while (true)
            for (int j = 0; j < 18; j++)
            {
                string name = cityNames[j];
                //string name = Console.ReadLine().ToLower();

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

                Console.WriteLine(name + ": " + data[name][0]);
            }
            Console.ReadKey();
        }
    }
}
