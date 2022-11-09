using EnglishNoteService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishNoteUI
{
    public partial class FrmTest : Form
    {
        public readonly ITestDataConvertService testDataConvertService;
        public readonly IRandomTestService randomTestService;
        public readonly IMyRandomService myRandomService;
        public EnglishDataViewModel englishDataViewModel;

        public List<TestData[]> quizs;
        public int quizIndex;

        public delegate void QuizDataChange(object sender, EventArgs e);

        private event QuizDataChange _quizsDataChangeEvent;
        public event QuizDataChange quizsDataChangeEvent
        {
            add => _quizsDataChangeEvent += value;
            remove => _quizsDataChangeEvent -= value;
        }

        public FrmTest(EnglishDataViewModel _englishDataViewModel)
        {
            InitializeComponent();
            testDataConvertService = FullService.GetService<ITestDataConvertService>();
            randomTestService = FullService.GetService<IRandomTestService>();
            myRandomService = FullService.GetService<IMyRandomService>();

            englishDataViewModel = _englishDataViewModel;
            quizs = new List<TestData[]>();
            quizsDataChangeEvent += quizsDataChange;
            quizIndex = 0;

            this.Resize += formResize;

            initTestData();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int inputQuizIndex = Convert.ToInt32(tb_inputBox.Text);

                if(quizs[quizIndex][0].Equals(quizs[quizIndex][inputQuizIndex]))
                {
                    MessageBox.Show("恭喜你答對了！");
                    nextQuiz();
                }
                else
                {
                    MessageBox.Show("答錯了！");
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show("輸入不正確，請重新輸入");
            }

            tb_inputBox.Text = "";
            tb_inputBox.Focus();
        }

        private void initTestData()
        {
            testDataConvertService.englishData = englishDataViewModel.GetAll(); ;
            var testData = testDataConvertService.getTestData();
            var testNumber = randomTestService.GetTestNumber(testData.Count, 5);
            foreach(var num in testNumber)
            {
                TestData[] quiz = new TestData[num.Length];
                int answer = num[0];
                quiz[0] = testData[answer];
                for (int i = 1; i < num.Length; i++)
                {
                    quiz[i] = testData[num[i]];
                }
                quizs.Add(quiz);
            }

            _quizsDataChangeEvent?.Invoke(this, EventArgs.Empty);
        }

        private void nextQuiz()
        {
            quizIndex++;
            _quizsDataChangeEvent?.Invoke(this, EventArgs.Empty);
        }

        private void showQuizToBoard()
        {
            if (quizIndex < quizs.Count - 1)
            {
                string res = "";
                for (int i = 0; i < quizs[quizIndex].Length; i++)
                {
                    if (i == 0)
                    {
                        res += $"題目 {quizs[quizIndex][0].EnglishName} {String.Join(", ", quizs[quizIndex][0].Pronounce)}" + Environment.NewLine;
                    }
                    else
                    {
                        var someOne = myRandomService.Next(quizs[0][i].Translate.Count);
                        res += $"{i}. {quizs[quizIndex][i].Translate[someOne]}" + Environment.NewLine;
                    }
                }
                tb_quizsBoard.Text = res;
            }
            else
            {
                MessageBox.Show("題目已全數回答完畢！");
                tb_quizsBoard.Text = "";
            }
        }

        private void quizsDataChange(object sender, EventArgs e)
        {
            showQuizToBoard();
        }

        private void tb_inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(sender, e);
            }
        }

        private void formResize(object sender, EventArgs e)
        {
            var size = new Size();
            size.Width = this.Width - 50;
            size.Height = this.Height - tb_inputBox.Height - btn_Submit.Height - 100;
            tb_quizsBoard.Size = size;

            var point = new Point();
            point.X = tb_quizsBoard.Right - tb_inputBox.Width;
            point.Y = tb_quizsBoard.Bottom + 10;
            tb_inputBox.Location = point;

            point = new Point();
            point.X = tb_quizsBoard.Right - btn_Submit.Width;
            point.Y = tb_quizsBoard.Bottom + tb_inputBox.Height + 10;
            btn_Submit.Location = point;
        }
    }

  
}
