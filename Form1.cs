using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Jogo_Plataforma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butJogar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void butComoJogar_Click(object sender, EventArgs e)
        {
            txtComoJogar.Text = "O objetivo do jogo é apanhar todas as moedas e no final passar a porta, os bonecos rosa são inimigos e o azul és tu, usa as teclas W, A e D ou as setas, para jogar. Diverte-te!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
