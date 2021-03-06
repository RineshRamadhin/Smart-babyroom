﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Smart_radio_controller_console
{
    class Program
    {
        #region global variables
        public static TimeSpan start = new TimeSpan(16, 0, 0);      // begin tijd voor radio
        public static TimeSpan eind = new TimeSpan(18, 0, 0);       // eind tijd voor radio
        public static float bewegingsmarge = 62;                    // marge voor bewegingsdetectie
        public static string url = "http://192.168.1.51/stadslab";  // url van de HomeWizard
        public static int wachttijd = 5000;                         // wachttijd tussen het loopen
        public static Boolean maakFoto1 = false;                    // boolean om foto te maken
        public static Boolean maakFoto2 = false;                    // boolean om foto te maken
        public static Bitmap first;
        public static Bitmap second;
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
            Console.WriteLine("Hoeveel tijd tussen checks [in miliseconden]");
            int tussentijd = Convert.ToInt32(Console.ReadLine());
            wachttijd = tussentijd;

            // switch aanzetten
            Console.WriteLine("Starten...");
            Console.Write("radio aanzetten...");
            WebRequest webRequest = WebRequest.Create(url + "/sw/0/on");
            webRequest.Method = "GET";
            WebResponse webResp = webRequest.GetResponse();
            Console.WriteLine(" Done \n");
            Thread.Sleep(500);
            Console.Clear();

            // start cam event
            FilterInfoCollection webcam;
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice cam;
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += cam_NewFrame;
            cam.Start();

            //start check loop
            constantCheck();

            // finish
            cam.NewFrame -= cam_NewFrame;
            cam.Stop();
            Console.Clear();
            Console.WriteLine("Babyradio uitgezet op " + DateTime.Now.ToString() + "\n");
            Console.Read();
        }

        /// <summary>
        /// event handler die een foto maakt wanneer maakFoto = true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        static void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (maakFoto1)
            {
                first = (Bitmap)eventArgs.Frame.Clone();              
                maakFoto1 = false;
            }
            else if (maakFoto2)
            {
                second = (Bitmap)eventArgs.Frame.Clone();
                maakFoto2 = false;
            }
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
                maakFoto1 = true;
                maakFoto2 = true;
                Thread.Sleep(2000);
                Console.WriteLine("     Done");

                // bereken verschil tussen foto's
                Console.Write("Bereken verschil...");
                float percentage = berekenVerschil(first, second);
                Console.WriteLine(" " + percentage.ToString("0.0") + " \n");

                // bij hoge beweging EN binnen tijdspan blijf aan, anders ga uit.
                if (percentage >= bewegingsmarge && checkTijd())
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
