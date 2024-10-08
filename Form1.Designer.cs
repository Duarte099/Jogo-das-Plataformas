namespace Jogo_Plataforma
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.titulo = new System.Windows.Forms.Label();
            this.butJogar = new System.Windows.Forms.Button();
            this.butComoJogar = new System.Windows.Forms.Button();
            this.txtComoJogar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Impact", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.Khaki;
            this.titulo.Location = new System.Drawing.Point(82, 33);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(485, 59);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "JOGO DAS PLATAFORMAS";
            this.titulo.UseMnemonic = false;
            // 
            // butJogar
            // 
            this.butJogar.BackColor = System.Drawing.Color.Salmon;
            this.butJogar.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butJogar.Location = new System.Drawing.Point(214, 311);
            this.butJogar.Name = "butJogar";
            this.butJogar.Size = new System.Drawing.Size(214, 55);
            this.butJogar.TabIndex = 1;
            this.butJogar.Text = "JOGAR";
            this.butJogar.UseVisualStyleBackColor = false;
            this.butJogar.Click += new System.EventHandler(this.butJogar_Click);
            // 
            // butComoJogar
            // 
            this.butComoJogar.BackColor = System.Drawing.Color.Salmon;
            this.butComoJogar.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butComoJogar.Location = new System.Drawing.Point(190, 175);
            this.butComoJogar.Name = "butComoJogar";
            this.butComoJogar.Size = new System.Drawing.Size(260, 55);
            this.butComoJogar.TabIndex = 2;
            this.butComoJogar.Text = "COMO JOGAR";
            this.butComoJogar.UseVisualStyleBackColor = false;
            this.butComoJogar.Click += new System.EventHandler(this.butComoJogar_Click);
            // 
            // txtComoJogar
            // 
            this.txtComoJogar.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComoJogar.Location = new System.Drawing.Point(88, 496);
            this.txtComoJogar.Name = "txtComoJogar";
            this.txtComoJogar.Size = new System.Drawing.Size(479, 156);
            this.txtComoJogar.TabIndex = 4;
            this.txtComoJogar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(545, 695);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "SAIR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(654, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtComoJogar);
            this.Controls.Add(this.butComoJogar);
            this.Controls.Add(this.butJogar);
            this.Controls.Add(this.titulo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Plataforma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button butJogar;
        private System.Windows.Forms.Button butComoJogar;
        private System.Windows.Forms.Label txtComoJogar;
        private System.Windows.Forms.Button button1;
    }
}

