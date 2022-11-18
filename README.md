# Математический тест

Программа содержит четыре случайных арифметических примера, которые игрок должен решить в течение определенного времени.

## Начало работы

Для работы с проектом необходимо перейти по ссылке и скачать либо zip архив, либо клонировать репозиторий себе на компьютер. Если вы скачали zip архивом его необходимо распаковать и внутри папки проекта запустить sln файл.

### Необходимые условия

Для установки необходима Visual Studio.
<br>
Данную программу можно скачать с 
[Visual Studio downloading](https://visualstudio.microsoft.com/ru/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) (Перейдя по ссылке сразу начнётся установка exe файла)

### Установка

1. Шаг<br>
Проверить, есть ли на компьютере программное обеспечение в ввиде Visual Studio. Если нет, то необходимо перейти к предыдущему пункту. 
2. Шаг<br>
После необходимо перейти на проект [Quiz](https://github.com/AnnaKorotkikh/Quiz)
3. Шаг<br>
Перейдя на проект необходимо нажать на зелёную кнопку Code
![image](https://user-images.githubusercontent.com/112888311/202671403-d6471f56-2d0b-4562-8eeb-2a0171cfaf30.png)
4. Шаг<br>
Далее откроется меню, где возможно выбрать один из нескольких вариантов:
![image](https://user-images.githubusercontent.com/112888311/202671686-5ec5127d-1b97-469f-bb48-bcd8731b3861.png)
    * Нажав на Open with Visual Studio, то вам откроеться программа Visual Studio и начнётся процесс переноса проекта на ваш компьютер;
    * Нажав на Dowload ZIP вы скачаете zip архив, который вам надо будет разорхивировать на компьютере. А после открыть внутри sln файл.
5. Шаг<br>
Вам необходимо будет нажать на кнопку Quiz. После этого запуститься программа.
![image](https://user-images.githubusercontent.com/112888311/202672110-20577450-1a46-4f95-b6ad-960fef22850c.png)
6. Шаг<br>
Программа запущена!
![image](https://user-images.githubusercontent.com/112888311/202672595-18478497-6d2f-422c-b684-0c872d623122.png)

## Код

``` C#
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
```

## Авторы

* **Коротких Анна** - *Основная работа* - [AnnaKorotkikh](https://github.com/AnnaKorotkikh)

See also the list of [Quiz](https://github.com/AnnaKorotkikh/Quiz) who participated in this project.
