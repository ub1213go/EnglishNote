using EnglishNoteUI.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public EnglishModel englishModel { get; set; }
        public List<EnglishData> englishDatas { get; set; }
        public int[] testList { get; set; }
        public int testCount { get; set; }
        public int answer { get; set; }
        public FrmTest(SingleWordManager _englishModel)
        {
            InitializeComponent();
            if(_englishModel != null)
            englishModel = _englishModel;
            englishDatas = englishModel.GetAll();
            randomTest();
            refreshTest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == answer.ToString())
            {
                MessageBox.Show("答對了");
                textBox2.Text = "";
                textBox2.Focus();
                refreshTest();
            }
            else
            {
                MessageBox.Show("答錯了");
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        public void refreshTest()
        {
            if(testCount >= englishDatas.Count)
            {
                MessageBox.Show("您已全數作答完畢");
                // todo: 正確率、答題數 key在textbox1
                return;
            }


            Random rdm = new Random();
            List<int> rdmPick = new List<int>();
            rdmPick.Add(testList[testCount]);
            for (int i = 0; i < 2; i++)
            {
                var rdmVal = rdm.Next(englishDatas.Count);
                while (rdmPick.Contains(rdmVal))
                {
                    rdmVal = rdm.Next(englishDatas.Count);
                }
                rdmPick.Add(rdmVal);
            }

            List<int> sort = new List<int>();
            textBox1.Text = $"{englishDatas[rdmPick[0]].EnglishName}\r\n";
            for (int i = 0; i < rdmPick.Count; i++)
            {
                var rdmVal = rdm.Next(rdmPick.Count);
                while (sort.Contains(rdmVal))
                {
                    rdmVal = rdm.Next(rdmPick.Count);
                }
                sort.Add(rdmVal);

                if(rdmVal == 0)
                    answer = i + 1;

                textBox1.Text += $"{i + 1}. {englishDatas[rdmPick[rdmVal]].Translate}\r\n";
            }
            testCount++;
        }
    
        public void randomTest()
        {
            Random rdm = new Random();

            testList = new int[englishDatas.Count];
            for(int i = 0; i < testList.Length; i++)
            {
                testList[i] = i;
            }

            for (int i = 0; i < testList.Length; i++)
            {
                var rdmVal = rdm.Next(testList.Length);
                while(i == rdmVal) {
                    rdmVal = rdm.Next(testList.Length);
                }
                testList[i] ^= testList[rdmVal];
                testList[rdmVal] ^= testList[i];
                testList[i] ^= testList[rdmVal];
            }

        }

        public void translateChoise()
        {

        }
    }

    /// <summary>
    /// 單字收集做處理
    /// </summary>
    public class SingleWordManager
    {
        private readonly EnglishModel _englishModel;
        public SingleWordManager()
        {
            
        }

        public EnglishModel getOne()
        {

        }
    }

    /// <summary>
    /// 相同單字單字指向相同翻譯集合
    /// </summary>
    public class translateCollection
    {

    }

    public class InjectionException : Exception
    {
        public override string Message { get; }
        public InjectionException(object obj) : base()
        {
            Message = $"{obj.GetType().Name} 注入無實體";
        }
    }
}
