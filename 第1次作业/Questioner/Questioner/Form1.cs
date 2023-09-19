using System.Timers;

namespace Questioner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int answer;
        private const int MAX_NUMBER = 5;
        private const int MAX_TIME = 5;
        private static System.Timers.Timer aTimer;

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUpQuestion();
            SetTimer();
            label9.Text = MAX_TIME.ToString();
            label10.Text = 0.ToString();
            label11.Text = MAX_NUMBER.ToString();
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            label9.Text = (int.Parse(label9.Text) - 1).ToString();
            if (int.Parse(label9.Text) == 0)
            {
                HandleButton1Click();
                label9.Text = MAX_TIME.ToString();
            }
        }

        private void SetUpQuestion()
        {
            Random rd = new Random();
            label1.Text = rd.Next(1, 10).ToString();
            label3.Text = rd.Next(1, 10).ToString();
            int number1 = int.Parse(label1.Text);
            int number2 = int.Parse(label3.Text);
            if (rd.Next(0, 2) == 0)
            {
                label2.Text = "+";
                answer = number1 + number2;
            }
            else
            {
                label2.Text = "-";
                answer = number1 - number2;
            }
        }

        private void CheckAnswer()
        {
            if (textBox1.Text == answer.ToString())
            {
                MessageBox.Show("Correct!");
                label10.Text = (int.Parse(label10.Text) + 20).ToString();
            }
            else
            {
                MessageBox.Show("Incorrect!");
            }
            label9.Text = MAX_TIME.ToString();
        }

        private void NextQuestion()
        {
            SetUpQuestion();
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void HandleButton1Click()
        {
            aTimer.Stop();
            CheckAnswer();
            aTimer.Start();
            label11.Text = (int.Parse(label11.Text) - 1).ToString();
            if (int.Parse(label11.Text) == 0)
            {
                aTimer.Stop();
                MessageBox.Show("Your score is " + label10.Text);
                Close();
            }
            NextQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandleButton1Click();
        }
    }
}