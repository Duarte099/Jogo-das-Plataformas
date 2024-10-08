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

namespace Jogo_Plataforma
{
    public partial class Form2 : Form
    {
        public Form1 form1Instance;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            form1Instance = form1;
        }

        //Cria variàveis para deslocamento do player e para guardar o estado do jogo 
        bool goLeft, goRight, jumping, isGameOver;

        //Cria variáveis para guardar a velocidade de salto, reduzir a força do salto, criando assim gravidade quando o player salta,
        //guardar o numero de tentativas, guardar o score, ou seja, as moedas que apanha e a velocidade a que o player anda.
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;
        int tentativas = 1;
        int aux = 0;

        //Cria variàveis para guardar a velocidade das plataformas que se movem
        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        

        

        //Cria variáveis para guardar a velocidade dos dois inimigos
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;

        //Cria função para iniciar os componentes visuais do forms
        public Form2()
        {
            InitializeComponent();
        }
    

        //Cria função para controlar o jogo com o timer
        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();

            //Mostra pontuação, numero de coins apanhadas.
            txtScore.Text = "Pontuação: " + score;

            //Atualiza a posição vertical do player de acordo com a velocidade do salto
            player.Top += jumpSpeed;

            //Verifica se o player esta a pressionar a tecla de movimento para a direita e move o jogador para a direita
            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }

            //Verifica se o player esta a pressionar a tecla de movimento para a direita e move o jogador para a direita
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }

            //Verifica se o jogador está a saltar e se a força do salto é menor que zero, se forem verdadeiras, interrompe o salto e define-o como falso
            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            //Verifica se o jogador está a saltar, se estiver ajusta a velocidade de salto para um valor negativo,
            //movendo assim o player para cima e tira um valor à força do pulo para representar a gravidade
            if (jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            //Se não estiver a saltar, ajusta a velocidade de salto para um valor positivo, movendo assim o jogador para baixo
            else
            {
                jumpSpeed = 10;
            }

            //Atualiza o score
            txtScore.Text = "Pontuação: " + score + Environment.NewLine + "Coleta todas as moedas";

            //Percorre todos os controlos presentes no forms
            foreach (Control x in this.Controls)
            {
                //Verifica se o controlo é do tipo PictureBox
                if (x is PictureBox)
                {
                    //Verifica se a PictureBox possui a tag "platform"
                    if ((string)x.Tag == "platform")
                    {
                        //Verifica se o jogador bateu em uma plataforma
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            //Ajusta a força do salto e a posição vertical do player
                            force = 8;
                            player.Top = x.Top - player.Height;

                            //Se a plataforma onde ele tiver for a horizontal e o player não se estiver a mover para a esquerda ou direita,
                            //ajusta a posição horizontal do player, fazendo assim com que se move junto com a plataforma
                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }
                        // Coloca a PictureBox à frente dos outros elementos
                        x.BringToFront();
                    }

                    //Verifica se a PictureBox possui a tag "coin"
                    if ((string)x.Tag == "coin")
                    {
                        //Verifica se o jogador bateu com uma moeda e se ela está visível
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            //Se o player bater com uma moeda, esconde a moeda para simular que a pegaram e aumenta 1 no score
                            x.Visible = false;
                            score++;
                        }
                    }

                    //Verifica se a PictureBox possui a tag "enemy"
                    if ((string)x.Tag == "enemy")
                    {
                        //Verificar se o jogador bateu com um inimigo
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            //Zera a velocidade vertical do salto, exibe a mensagem que o player morreu, pára o timer do jogo e define o jogo como encerrado
                            jumpSpeed = 0;
                            txtScore.Text = "Pontuação: " + score + Environment.NewLine + "Morreste, pressiona ENTER para regressar ao menu!";
                            Console.ReadLine();
                            gameTimer.Stop();
                            isGameOver = true;
                            form1.Show();
                            this.Hide();
                        }
                    }

                }
            }

            //Atualiza a posição horizontal da plataforma horizontal
            horizontalPlatform.Left -= horizontalSpeed;

            //Verifica se a plataforma horizontal bateu nas bordas do formulario, se sim inverte a direção
            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            //Atualiza a posição vertical da plataforma vertical
            verticalPlatform.Top += verticalSpeed;

            //Verifica se a plataforma vertical bateu nas bordas estipuladas, se sim inverte a direção
            if (verticalPlatform.Top < 230 || verticalPlatform.Top > 581)
            {
                verticalSpeed = -verticalSpeed;
            }

            //Atualiza a posição horizontal do inimigo 1 com base na velocidade
            enemyOne.Left -= enemyOneSpeed;

            //Verifica se o inimigo 1 bateu nas bordas da plataforma onde se move e inverte a direção
            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            //Atualiza a posição horizontal do inimigo 2 com base na velocidade
            enemyTwo.Left += enemyTwoSpeed;

            //Verifica se o inimigo 2 bateu nas bordas da plataforma onde se move e inverte a direção
            if (enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            //Não deixa o player cair nas bordas do forms
            if (player.Left < 0)
            {
                player.Left = 0;
            }
            else if (player.Left > this.ClientSize.Width - player.Width)
            {
                player.Left = this.ClientSize.Width - player.Width;
            }

            //Verifica se o jogador caiu abaixo da tela e acaba o jogo
            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                jumpSpeed = 0;
                txtScore.Text = "Pontuação: " + score + Environment.NewLine + "Caíste do mapa, pressiona ENTER para regressar ao menu!";
                Console.ReadLine();
                gameTimer.Stop();
                isGameOver = true;
                form1.Show();
                this.Hide();
            }

            //Verifica se o jogador tocou na casa verde de vitoria e apanhou as moedas todas
            //senão alerta o player que precisa de as apanhar todas para terminar o jogo
            if (player.Bounds.IntersectsWith(door.Bounds) && score == 24)
            {
                aux++;
                jumpSpeed = 0;
                txtScore.Text = "Pontuação: " + score + Environment.NewLine + "Completaste o jogo em " + tentativas + " tentativas, pressiona ENTER para regressar ao menu!";
                //ConsoleHelper.WaitForKey();
                gameTimer.Stop();
                isGameOver = true;
                form1.Show();
                this.Hide();
            }
            else if (player.Bounds.IntersectsWith(door.Bounds) && score < 24)
            {
                txtScore.Text = "Pontuação: " + score + Environment.NewLine + "Tens de apanhar todas as moedas para conseguir terminar!! ";
            }
        }

        //Função para movimentar o player quando estiver a pressionar as teclas de movimentação
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W && jumping == false)
            {
                jumping = true;
            }
        }

        //Função para não movimentar o player quando não estiver a pressionar as teclas de movimentação
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }

        //Função apra resetar o jogo
        private void RestartGame()
        {
            //Verificar se o jogador completou o jogo com auxilio da variavel aux que é encrementada quando o player passa a porta com 24 coins,
            //se for verdade reseta as tentativas se não aumenta uma
            if (aux == 1)
            {
                tentativas = 0;
            }
            else
            {
                tentativas++;
            }
            //Resetar todas as variáveis para o valor default
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            //Mostrar score
            txtScore.Text = "Pontuação: " + score;

            //Mostrar novamente todas as moedas
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            //Resetar a posição do player, plataformas e inimigos
            player.Left = 72;
            player.Top = 656;

            enemyOne.Left = 471;
            enemyTwo.Left = 360;

            horizontalPlatform.Left = 275;
            verticalPlatform.Top = 581;

            //Reiniciar o timer do jogo
            gameTimer.Start();

        }
    }
}
