using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace MHLootTracker
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class GUITimer : UserControl
    {
        Timer t;
        int milliseconds, seconds, minutes, hours;
        bool firstStart;
        bool timerOn;

        public GUITimer()
        {
            InitializeComponent();

            seconds = minutes = hours = 0;
            timerOn = false;
            firstStart = true;
        }

        public void startTimer()
        {
            t = new Timer(25);
            t.Elapsed += new ElapsedEventHandler(incrementTime);
            t.Enabled = true;
            timerOn = true;
            firstStart = false;
            StartBtn.Content = "Pause";

            ResetBtn.IsEnabled = true;
        }

        public void pauseTimer()
        {
            if (!firstStart && timerOn)
            {
                t.Stop();
                timerOn = false;
                StartBtn.Content = "Resume";
            }
        }

        public void resumeTimer()
        {
            if (!firstStart && !timerOn)
            {
                t.Start();
                timerOn = true;
                StartBtn.Content = "Pause";
            }
        }

        protected void incrementTime(object sender, ElapsedEventArgs e)
        {
            milliseconds += 25;

            if (milliseconds >= 1000)
            {
                seconds += milliseconds / 1000;
                milliseconds = milliseconds % 1000;

                // This nested if structure is used as an optimization
                // i.e. seconds only needs to be checked if it is over 60 if
                // it has changed this iteration
                if (seconds >= 60)
                {
                    minutes += seconds / 60;
                    seconds = seconds % 60;

                    if (minutes >= 60)
                    {
                        hours += minutes / 60;
                        minutes = minutes % 60;
                    }
                }
            }
           
            updateGUI();
        }

        public void reset()
        {
            seconds = minutes = hours = 0;
            updateGUI();
            firstStart = true;
            ResetBtn.IsEnabled = false;
            StartBtn.Content = "Start";
            timerOn = false;
            t.Stop();
            t = null;

        }

        private void updateGUI()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                TimeLbl.Text = formatTime(hours, minutes, seconds);
            }));
        }

        private string formatTime(int h, int m, int s)
        {
            string time = "";

            time += h + ":";

            if (m < 10)
            {
                time += "0";
            }
            time += m + ":";

            if (s < 10)
            {
                time += "0";
            }
            time += s;

            return time;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (timerOn)
            {
                pauseTimer();
            }
            else
            {
                if (firstStart)
                {
                    startTimer();
                }
                else
                {
                    resumeTimer();
                }
            }
        }

        public string getTime()
        {
            return TimeLbl.Text;
        }

        public int getSecondsInt()
        {
            return seconds;
        }

        public int getMinutesInt()
        {
            return minutes;
        }

        public int getHoursInt()
        {
            return hours;
        }

        public string getSecondsStr()
        {
            string sec = "";
            if (seconds < 10)
            {
                sec = "0";
            }
            sec += seconds;

            return sec;
        }
    }
}
