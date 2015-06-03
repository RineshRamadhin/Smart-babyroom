using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Smart_radio_controller_console
{
    class Program
    {
        #region global variables
        public static TimeSpan start = new TimeSpan(16, 0, 0);      // begin tijd voor radio
        public static TimeSpan eind = new TimeSpan(18, 0, 0);       // eind tijd voor radio
        public static float bewegingsmarge = 30;                    // marge voor bewegingsdetectie
        public static string url = "http://192.168.1.50/stadslab";  // url van de HomeWizard
        public static int wachttijd = 5000;                         // wachttijd tussen het loopen
        #endregion

        /// <summary>
        /// entry point voor programma
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // start
            Console.Title = "Proof of Concept - Groep 3";

            // stel waardes in
            Console.WriteLine("Hoelaat gaat de baby slapen [in uren]");
            int startuur = Convert.ToInt32(Console.ReadLine());
            start = new TimeSpan(startuur, 0, 0);
            Console.WriteLine("Hoelaat moet de radio uit [in uren]");
            int einduur = Convert.ToInt32(Console.ReadLine());
            eind = new TimeSpan(einduur, 37, 0);

            // switch aanzetten
            Console.WriteLine("Starten...");
            Console.Write("radio aanzetten...");
            WebRequest webRequest = WebRequest.Create(url + "/sw/0/on");
            webRequest.Method = "GET";
            WebResponse webResp = webRequest.GetResponse();
            Console.WriteLine(" Done \n");
            Thread.Sleep(500);
            Console.Clear();

            //start check loop
            constantCheck();

            // finish
            Console.Clear();
            Console.WriteLine("Babyradio uitgezet op " + DateTime.Now.ToString() + "\n");
            Console.Read();
        }

        /// <summary>
        /// berekend verschil tussen twee bitmap's
        /// </summary>
        /// <param name="first">eerste bitmap</param>
        /// <param name="second">eerste bitmap</param>
        /// <returns>percentage verschil</returns>
        static float berekenVerschil(Bitmap first, Bitmap second)
        {
            int DiferentPixels = 0;
            Bitmap container = new Bitmap(first.Width, first.Height);
            for (int i = 0; i < first.Width; i++)
            {
                for (int j = 0; j < first.Height; j++)
                {
                    int r1 = second.GetPixel(i, j).R;
                    int g1 = second.GetPixel(i, j).G;
                    int b1 = second.GetPixel(i, j).B;

                    int r2 = first.GetPixel(i, j).R;
                    int g2 = first.GetPixel(i, j).G;
                    int b2 = first.GetPixel(i, j).B;

                    if (r1 != r2 && g1 != g2 && b1 != b2)
                    {
                        DiferentPixels++;
                        container.SetPixel(i, j, Color.Red);
                    }
                    else
                        container.SetPixel(i, j, first.GetPixel(i, j));
                }
            }
            int TotalPixels = first.Width * first.Height;
            float verschil = (float)((float)DiferentPixels / (float)TotalPixels);
            float percentage = verschil * 100;
            return percentage;
        }

        /// <summary>
        /// maakt foto met de webcam en sla op als bitmap
        /// </summary>
        /// <returns>bitmap</returns>
        static Bitmap maaktFoto()
        {
            // TODO: make a photo using the webcam and return it as an bitmap.
            Bitmap first = new Bitmap("First.jpg");
            return first;
        }

        /// <summary>
        /// check of tijd tussen twee tijden is
        /// </summary>
        /// <returns>true/false</returns>
        static Boolean checkTijd()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < eind))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// loop om telkens de condities te checken
        /// </summary>
        static void constantCheck()
        {
            // loop constant
            while (true)
            {
                // print huidige tijd
                Console.WriteLine("Starttijd run: " + DateTime.Now.ToString() + "\n");

                // maak foto's
                Console.Write("Maakt foto's...");
                Bitmap first = maaktFoto();
                Thread.Sleep(500);                  // wachttijd tussen foto's maken
                Bitmap second = maaktFoto();
                Console.WriteLine("     Done");

                // bereken verschil tussen foto's
                Console.Write("Bereken verschil...");
                float percentage = berekenVerschil(first, second);
                Console.WriteLine(" Done \n");

                // bij hoge beweging EN binnen tijdspan blijf aan, anders ga uit.
                if (percentage <= bewegingsmarge && checkTijd())
                {
                    // haal huidige status op
                    var json = new WebClient().DownloadString(url + "/swlist");
                    JObject o = JObject.Parse(json);
                    String status = o["status"].ToString();

                    // check of de switch al aan is
                    if (status == "off")
                    {
                        // zet switch No. 0 aan
                        Console.Write("Radio aanzetten...");
                        WebRequest webRequest = WebRequest.Create(url + "/sw/0/on");
                        webRequest.Method = "GET";
                        WebResponse webResp = webRequest.GetResponse();
                        Console.WriteLine("  Done \n");
                    }
                    else
                    {
                        // hou switch No. 0 aan
                        Console.Write("Radio aanhouden...");
                        Console.WriteLine("  Done \n");
                    }
                }
                else
                {
                    // zet switch No. 0 uit
                    Console.Write("Radio uitzetten...");
                    WebRequest webRequest = WebRequest.Create(url + "/sw/0/off");
                    webRequest.Method = "GET";
                    WebResponse webResp = webRequest.GetResponse();
                    Console.WriteLine("  Done \n");
                    Thread.Sleep(wachttijd);
                    break;
                }

                // clear de console
                Thread.Sleep(wachttijd);
                Console.Clear();
            }
        }
    }
}
