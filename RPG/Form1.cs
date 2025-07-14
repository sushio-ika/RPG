using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class Form1 : Form
    {
        private string outchar= "やあ！　こんにちは！" ;
        private int i;
        private int SPACE_INTERVAL = 500; // スペースの間隔（ミリ秒）
        private int NORMAL_INTERVAL = 100; // 通常の間隔（ミリ秒）
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < outchar.Length)
            {
                if (char.IsWhiteSpace(outchar[i])) // または currentChar == ' ' でも可
                {
                    timer1.Interval = SPACE_INTERVAL; // 一時的に間隔を長くする
                }
                else
                {
                    timer1.Interval = NORMAL_INTERVAL; // 通常の間隔に戻す
                }
                // 1文字ずつ追加して表示
                label1.Text += outchar[i];
                System.Media.SoundPlayer player= new System.Media.SoundPlayer("se_select_003.wav");
                player.Play();
                i++;
            }
            else
            {
                // 全ての文字が表示されたらタイマーを停止
                timer1.Stop();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0; // インデックスをリセット
            label1.Text = ""; // ラベルをクリア

            // 表示する文字列が空でなければタイマーを開始
            if (!string.IsNullOrEmpty(outchar))
            {
                timer1.Start();
            }
        }
    }
}
