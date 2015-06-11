using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Net;
using System.Threading;
using System.Speech.Synthesis;

namespace Smart_radio_controller_windows_forms
{
    public partial class main : Form
    {
        #region global variables
        public static TimeSpan start = new TimeSpan(16, 0, 0);      // begin tijd voor radio
        public static TimeSpan eind = new TimeSpan(18, 0, 0);       // eind tijd voor radio
        public static float bewegingsmarge = 62;                    // marge voor bewegingsdetectie
        public static string url = "http://192.168.1.51/stadslab";  // url van de HomeWizard
        public static int wachttijd = 5000;                         // wachttijd tussen het loopen
        public static Boolean maakFoto1 = false;                    // boolean om foto te maken
        public static Boolean maakFoto2 = false;                    // boolean om foto te maken
        public static Bitmap first;                                 // eerste foto
        public static Bitmap second;                                // tweede foto
        public static Thread thread;                                // thread voor auto check
        public static SpeechSynthesizer synthesizer;                // spraakmeldingen
        #endregion

        /// <summary>
        /// main thread
        /// </summary>
        public main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// form load thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // initialiseer globale waardes
            synthesizer = new SpeechSynthesizer();
            thread = new Thread(new ThreadStart(constantCheck));

            // vul huidige waardes in
            main_starttijd_current.Text = start.ToString();
            main_eindtijd_current.Text = eind.ToString();
            main_tussentijd_current.Text = wachttijd.ToString() + " ms";

            // zet de radio aan
            radio_aan();

            // start cam event
            FilterInfoCollection webcam;
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice cam;
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += cam_NewFrame;
            cam.Start();
        }

        /// <summary>
        /// event handler die een foto maakt wanneer maakFoto(1/2) = true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (maakFoto1)
            {
                first = (Bitmap)eventArgs.Frame.Clone();
                PictureBox.CheckForIllegalCrossThreadCalls = false;
                main_foto1_picture.Image = first;
                maakFoto1 = false;
            }
            else if (maakFoto2)
            {
                second = (Bitmap)eventArgs.Frame.Clone();
                PictureBox.CheckForIllegalCrossThreadCalls = false;
                main_foto2_picture.Image = second;
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
        public void constantCheck()
        {
            int count = 1;
            // loop constant
            while (true)
            {
                // voor de errors
                TextBox.CheckForIllegalCrossThreadCalls = false;

                // stel laatste run in
                main_laatsterun_time.Text = DateTime.Now.ToString();
                main_laatsterun.Text = count + "e run:";
                count = count + 1;

                // maak foto's
                maakFoto1 = true;
                maakFoto2 = true;
                Thread.Sleep(2000);

                // bereken verschil tussen foto's
                float percentage = berekenVerschil(first, second);
                main_verschil.Text = percentage + " %";

                // bij hoge beweging EN binnen tijdspan blijf aan, anders ga uit.
                if (percentage >= bewegingsmarge && checkTijd())
                {                    
                    // zet switch No. 0 aan 
                    //WebRequest webRequest = WebRequest.Create(url + "/sw/0/on");
                    //webRequest.Method = "GET";
                    //WebResponse webResp = webRequest.GetResponse();

                    // current label
                    main_settings_current.Text = "Auto (AAN)";

                    // status
                    main_status.BackColor = Color.Green;
                    main_status.Text = "Radio AAN";
                }
                else
                {                   
                    // zet switch No. 0 uit
                    //WebRequest webRequest = WebRequest.Create(url + "/sw/0/off");
                    //webRequest.Method = "GET";
                    //WebResponse webResp = webRequest.GetResponse();

                    // current label
                    main_settings_current.Text = "Auto (UIT)";

                    // status
                    main_status.BackColor = Color.DarkRed;
                    main_status.Text = "Radio UIT";

                    //break;
                }

                // clear de console
                Thread.Sleep(wachttijd);
            }
        }

        /// <summary>
        /// zet de radio aan
        /// </summary>
        public void radio_aan()
        {
            // stop auto thread
            try
            {
                thread.Abort();
                main_laatsterun.Text = "";
                main_laatsterun_time.Text = "";
            }
            catch
            {

            }

            // AAN button
            main_mode_on.BackColor = Color.DodgerBlue;
            main_mode_on.ForeColor = Color.White;
            main_mode_on.Enabled = false;

            // zet radio aan
            //WebRequest webRequest = WebRequest.Create(url + "/sw/0/on");
            //webRequest.Method = "GET";
            //WebResponse webResp = webRequest.GetResponse();
            synthesizer.Speak("Radio aan");

            // current label
            main_settings_current.Text = "AAN";
            main_settings_current.ForeColor = Color.Green;

            // UIT button
            main_mode_off.Enabled = true;
            main_mode_off.BackColor = Color.White;
            main_mode_off.ForeColor = Color.Black;

            // AUTO button
            main_mode_auto.Enabled = true;
            main_mode_auto.BackColor = Color.White;
            main_mode_auto.ForeColor = Color.Black;

            // status
            main_status.BackColor = Color.Green;
            main_status.Text = "Radio on";
        }

        /// <summary>
        /// zet de radio uit
        /// </summary>
        public void radio_uit()
        {
            // stop auto thread
            try
            {
                thread.Abort();
                main_laatsterun.Text = "";
                main_laatsterun_time.Text = "";
            }
            catch
            {

            }

            // UIT button
            main_mode_off.BackColor = Color.DodgerBlue;
            main_mode_off.ForeColor = Color.White;
            main_mode_off.Enabled = false;

            //WebRequest webRequest = WebRequest.Create(url + "/sw/0/off");
            //webRequest.Method = "GET";
            //WebResponse webResp = webRequest.GetResponse();
            synthesizer.Speak("Radio off");

            // current label
            main_settings_current.Text = "UIT";
            main_settings_current.ForeColor = Color.DarkRed;

            // AAN button
            main_mode_on.Enabled = true;
            main_mode_on.BackColor = Color.White;
            main_mode_on.ForeColor = Color.Black;

            // AUTO button
            main_mode_auto.Enabled = true;
            main_mode_auto.BackColor = Color.White;
            main_mode_auto.ForeColor = Color.Black;

            // status
            main_status.BackColor = Color.DarkRed;
            main_status.Text = "Radio UIT";

        }

        /// <summary>
        /// start de auto thread
        /// </summary>
        public void radio_auto()
        {
            // AUTO button
            main_mode_auto.BackColor = Color.DodgerBlue;
            main_mode_auto.ForeColor = Color.White;
            main_mode_auto.Enabled = false;

            // AAN button
            main_mode_on.Enabled = true;
            main_mode_on.BackColor = Color.White;
            main_mode_on.ForeColor = Color.Black;

            // UIT button
            main_mode_off.Enabled = true;
            main_mode_off.BackColor = Color.White;
            main_mode_off.ForeColor = Color.Black;

            // current label
            main_settings_current.Text = "AUTO";
            main_settings_current.ForeColor = Color.Gray;

            maakFoto1 = true;
            Thread.Sleep(500);
            maakFoto2 = true;

            // start auto thread
            thread = new Thread(new ThreadStart(constantCheck));
            thread.Start();  
        }

        /// <summary>
        /// stelt de starttijd in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_starttijd_button_Click(object sender, EventArgs e)
        {
            int uur = Convert.ToInt32(main_starttijd_picker.Value.ToString("HH"));
            int min = Convert.ToInt32(main_starttijd_picker.Value.ToString("mm"));
            int sec = Convert.ToInt32(main_starttijd_picker.Value.ToString("ss"));
            start = new TimeSpan(uur, min, sec);
            main_starttijd_current.Text = start.ToString();
        }

        /// <summary>
        /// stelt de eindtijd in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_eindtijd_button_Click(object sender, EventArgs e)
        {
            int uur = Convert.ToInt32(main_eindtijd_picker.Value.ToString("HH"));
            int min = Convert.ToInt32(main_eindtijd_picker.Value.ToString("mm"));
            int sec = Convert.ToInt32(main_eindtijd_picker.Value.ToString("ss"));
            eind = new TimeSpan(uur, min, sec);
            main_eindtijd_current.Text = eind.ToString();
        }

        /// <summary>
        /// stelt de tussentijd in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_tussentijd_button_Click(object sender, EventArgs e)
        {
            wachttijd = Convert.ToInt32(main_tussentijd_picker.Value);
            main_tussentijd_current.Text = wachttijd.ToString() + " ms";
        }

        private void main_mode_on_Click(object sender, EventArgs e)
        {
            radio_aan();
        }

        private void main_mode_off_Click(object sender, EventArgs e)
        {
            radio_uit();
        }

        private void main_mode_auto_Click(object sender, EventArgs e)
        {
            radio_auto();
        }

        /// <summary>
        /// code dat wordt uitgevoerd voor het sluiten van het from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            radio_uit();
        }

        /// <summary>
        /// code bij een klik op de foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_groeppic_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }
    }
}
