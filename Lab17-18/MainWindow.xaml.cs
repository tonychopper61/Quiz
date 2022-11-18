using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Lab17_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private int start = new int();
        private int CheckPosition = 0;
        private bool ButtonStateCheck = false;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }
        private void StartStopBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (ButtonStateCheck == false)
            {
                if (CheckPosition == 0)
                {
                    start = Properties.Settings.Default.TimerStart;
                    MessageBox.Show("Начнём!");
                }
                else if (CheckPosition != 0)
                {
                    start = CheckPosition; 
                }
                timer.Start();
                StartTheQuiz();
                ButtonStateCheck = true;

            }
            else if (ButtonStateCheck == true)
            {
                CheckPosition = start;
                ButtonStateCheck = false;
                CheckAswer();
                timer.Stop();
            }
           

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (start > 0)
            {
                start--;
                Time.Text = Convert.ToString(start);
            }
            else if (start <= 0)
            {
                timer.Stop();
                CheckPosition = 0;
                ButtonStateCheck = false;
                Time.Text = "Время вышло";
            }
            
        }
        private void timerTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex InputChecker = new System.Text.RegularExpressions.Regex("[^0-59]+");
            e.Handled = InputChecker.IsMatch(e.Text);
        }
        private void SetTimeBtn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.TimerStart = Int32.Parse(Time.Text);
            this.Close();
        }
        public void CheckAswer()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int sum1 = Convert.ToInt32(SumNumberOne.Text);
            int sum2 =  Convert.ToInt32(SumNumberTwo.Text);
            double sumAns = Convert.ToDouble(SumNumberAnswer.Text);
            sumAns = Math.Round(sumAns, 2);
            int min1 = Convert.ToInt32(MinNumberOne.Text);
            int min2 = Convert.ToInt32(MinNumberTwo.Text);
            double minAns = Convert.ToDouble(MinNumberAnswer.Text);
            minAns = Math.Round(minAns, 2);
            int mul1 = Convert.ToInt32(MulNumberOne.Text);
            int mul2 = Convert.ToInt32(MulNumberTwo.Text);
            double mulAns = Convert.ToDouble(MulNumberAnswer.Text);
            mulAns = Math.Round(mulAns, 2);
            int dev1 = Convert.ToInt32(DevNumberOne.Text);
            int dev2 = Convert.ToInt32(DevNumberTwo.Text);
            double devAns = Convert.ToDouble(DevNumberAnswer.Text);
            devAns = Math.Round(devAns, 2);
            if (sum1 + sum2 == sumAns && min1 - min2 == minAns && mul1 * mul2 == mulAns && dev1 / dev2 == devAns)
            {
                MessageBox.Show("Ответы верны, поздравляю!");
            }
            else
            {
                MessageBox.Show("Проверь себя ты где-то ошибся!");
            }
            sw.Stop();
        }
        public void StartTheQuiz()
        {
            
            Random random = new Random();

            SumNumberOne.Text = random.Next(0, 20).ToString();
            SumNumberTwo.Text = random.Next(0, 20).ToString();

            MinNumberOne.Text = random.Next(0, 20).ToString();
            MinNumberTwo.Text = random.Next(0, 20).ToString();

            MulNumberOne.Text = random.Next(0, 20).ToString();
            MulNumberTwo.Text = random.Next(0, 20).ToString();

            DevNumberOne.Text = random.Next(0, 20).ToString();
            DevNumberTwo.Text = random.Next(1, 20).ToString();
            
        }
    }
}
