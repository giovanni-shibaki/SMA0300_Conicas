namespace Conicas
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.lvlF = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.TextBox();
            this.lblE = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.lblD = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.lblC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalcula = new System.Windows.Forms.Button();
            this.lblEquacaoAtualTexto = new System.Windows.Forms.Label();
            this.lblEquacaoReduzidaText = new System.Windows.Forms.Label();
            this.lblEquacaoAtual = new System.Windows.Forms.Label();
            this.lblEquacaoReduzida = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btWebPlot = new System.Windows.Forms.Button();
            this.grpCoeficients = new System.Windows.Forms.GroupBox();
            this.grpresults = new System.Windows.Forms.GroupBox();
            this.grpCoeficients.SuspendLayout();
            this.grpresults.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "x²";
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(158, 41);
            this.txtA.Margin = new System.Windows.Forms.Padding(4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(35, 27);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "0";
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(250, 41);
            this.txtB.Margin = new System.Windows.Forms.Padding(4);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(35, 27);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "0";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.BackColor = System.Drawing.Color.White;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.Location = new System.Drawing.Point(290, 43);
            this.lblB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(34, 25);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "xy";
            // 
            // txtF
            // 
            this.txtF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtF.Location = new System.Drawing.Point(628, 41);
            this.txtF.Margin = new System.Windows.Forms.Padding(4);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(35, 27);
            this.txtF.TabIndex = 6;
            this.txtF.Text = "0";
            // 
            // lvlF
            // 
            this.lvlF.AutoSize = true;
            this.lvlF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlF.Location = new System.Drawing.Point(668, 44);
            this.lvlF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lvlF.Name = "lvlF";
            this.lvlF.Size = new System.Drawing.Size(168, 20);
            this.lvlF.TabIndex = 6;
            this.lvlF.Text = "(termo independente)";
            // 
            // txtE
            // 
            this.txtE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtE.Location = new System.Drawing.Point(530, 41);
            this.txtE.Margin = new System.Windows.Forms.Padding(4);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(35, 27);
            this.txtE.TabIndex = 5;
            this.txtE.Text = "0";
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.BackColor = System.Drawing.Color.White;
            this.lblE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblE.Location = new System.Drawing.Point(568, 43);
            this.lblE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(23, 25);
            this.lblE.TabIndex = 8;
            this.lblE.Text = "y";
            // 
            // txtD
            // 
            this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.Location = new System.Drawing.Point(438, 41);
            this.txtD.Margin = new System.Windows.Forms.Padding(4);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(35, 27);
            this.txtD.TabIndex = 4;
            this.txtD.Text = "0";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.BackColor = System.Drawing.Color.White;
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD.Location = new System.Drawing.Point(476, 43);
            this.lblD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(23, 25);
            this.lblD.TabIndex = 10;
            this.lblD.Text = "x";
            // 
            // txtC
            // 
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(344, 41);
            this.txtC.Margin = new System.Windows.Forms.Padding(4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(35, 27);
            this.txtC.TabIndex = 3;
            this.txtC.Text = "0";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.BackColor = System.Drawing.Color.White;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC.Location = new System.Drawing.Point(383, 43);
            this.lblC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(31, 25);
            this.lblC.TabIndex = 12;
            this.lblC.Text = "y²";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(741, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Insira abaixo os termos da Equação Geral da Cônica Desejada";
            // 
            // btnCalcula
            // 
            this.btnCalcula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCalcula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcula.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCalcula.Location = new System.Drawing.Point(401, 404);
            this.btnCalcula.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcula.Name = "btnCalcula";
            this.btnCalcula.Size = new System.Drawing.Size(123, 49);
            this.btnCalcula.TabIndex = 7;
            this.btnCalcula.Text = "&Calcular";
            this.btnCalcula.UseVisualStyleBackColor = false;
            this.btnCalcula.Click += new System.EventHandler(this.btnCalcula_Click);
            // 
            // lblEquacaoAtualTexto
            // 
            this.lblEquacaoAtualTexto.AutoSize = true;
            this.lblEquacaoAtualTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquacaoAtualTexto.Location = new System.Drawing.Point(54, 28);
            this.lblEquacaoAtualTexto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquacaoAtualTexto.Name = "lblEquacaoAtualTexto";
            this.lblEquacaoAtualTexto.Size = new System.Drawing.Size(146, 25);
            this.lblEquacaoAtualTexto.TabIndex = 17;
            this.lblEquacaoAtualTexto.Text = "Equação Atual:";
            // 
            // lblEquacaoReduzidaText
            // 
            this.lblEquacaoReduzidaText.AutoSize = true;
            this.lblEquacaoReduzidaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquacaoReduzidaText.Location = new System.Drawing.Point(54, 81);
            this.lblEquacaoReduzidaText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquacaoReduzidaText.Name = "lblEquacaoReduzidaText";
            this.lblEquacaoReduzidaText.Size = new System.Drawing.Size(176, 25);
            this.lblEquacaoReduzidaText.TabIndex = 18;
            this.lblEquacaoReduzidaText.Text = "Equação reduzida:";
            // 
            // lblEquacaoAtual
            // 
            this.lblEquacaoAtual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblEquacaoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquacaoAtual.Location = new System.Drawing.Point(247, 29);
            this.lblEquacaoAtual.Name = "lblEquacaoAtual";
            this.lblEquacaoAtual.Size = new System.Drawing.Size(586, 26);
            this.lblEquacaoAtual.TabIndex = 19;
            this.lblEquacaoAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEquacaoReduzida
            // 
            this.lblEquacaoReduzida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblEquacaoReduzida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquacaoReduzida.Location = new System.Drawing.Point(247, 82);
            this.lblEquacaoReduzida.Name = "lblEquacaoReduzida";
            this.lblEquacaoReduzida.Size = new System.Drawing.Size(586, 26);
            this.lblEquacaoReduzida.TabIndex = 21;
            this.lblEquacaoReduzida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(62, 31);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 49);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "&Limpar";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnLimpar);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInfo.Location = new System.Drawing.Point(809, 414);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(79, 32);
            this.btnInfo.TabIndex = 10;
            this.btnInfo.Text = "&Sobre";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btWebPlot
            // 
            this.btWebPlot.BackColor = System.Drawing.Color.Coral;
            this.btWebPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btWebPlot.ForeColor = System.Drawing.Color.White;
            this.btWebPlot.Location = new System.Drawing.Point(16, 407);
            this.btWebPlot.Margin = new System.Windows.Forms.Padding(4);
            this.btWebPlot.Name = "btWebPlot";
            this.btWebPlot.Size = new System.Drawing.Size(121, 39);
            this.btWebPlot.TabIndex = 9;
            this.btWebPlot.Text = "&Plotar Web";
            this.btWebPlot.UseVisualStyleBackColor = false;
            this.btWebPlot.Click += new System.EventHandler(this.btWebPlot_Click);
            // 
            // grpCoeficients
            // 
            this.grpCoeficients.Controls.Add(this.btnClear);
            this.grpCoeficients.Controls.Add(this.txtC);
            this.grpCoeficients.Controls.Add(this.lblC);
            this.grpCoeficients.Controls.Add(this.txtD);
            this.grpCoeficients.Controls.Add(this.lblD);
            this.grpCoeficients.Controls.Add(this.txtE);
            this.grpCoeficients.Controls.Add(this.lblE);
            this.grpCoeficients.Controls.Add(this.txtF);
            this.grpCoeficients.Controls.Add(this.lvlF);
            this.grpCoeficients.Controls.Add(this.txtB);
            this.grpCoeficients.Controls.Add(this.lblB);
            this.grpCoeficients.Controls.Add(this.txtA);
            this.grpCoeficients.Controls.Add(this.label1);
            this.grpCoeficients.Location = new System.Drawing.Point(16, 132);
            this.grpCoeficients.Name = "grpCoeficients";
            this.grpCoeficients.Size = new System.Drawing.Size(873, 103);
            this.grpCoeficients.TabIndex = 25;
            this.grpCoeficients.TabStop = false;
            this.grpCoeficients.Text = "Coeficientes";
            // 
            // grpresults
            // 
            this.grpresults.Controls.Add(this.lblEquacaoReduzida);
            this.grpresults.Controls.Add(this.lblEquacaoAtual);
            this.grpresults.Controls.Add(this.lblEquacaoReduzidaText);
            this.grpresults.Controls.Add(this.lblEquacaoAtualTexto);
            this.grpresults.Location = new System.Drawing.Point(19, 250);
            this.grpresults.Name = "grpresults";
            this.grpresults.Size = new System.Drawing.Size(869, 135);
            this.grpresults.TabIndex = 26;
            this.grpresults.TabStop = false;
            this.grpresults.Text = "Resultados";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 471);
            this.Controls.Add(this.grpresults);
            this.Controls.Add(this.grpCoeficients);
            this.Controls.Add(this.btWebPlot);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnCalcula);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conic Section Simplifier 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.grpCoeficients.ResumeLayout(false);
            this.grpCoeficients.PerformLayout();
            this.grpresults.ResumeLayout(false);
            this.grpresults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.Label lvlF;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalcula;
        private System.Windows.Forms.Label lblEquacaoAtualTexto;
        private System.Windows.Forms.Label lblEquacaoReduzidaText;
        private System.Windows.Forms.Label lblEquacaoAtual;
        private System.Windows.Forms.Label lblEquacaoReduzida;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btWebPlot;
        private System.Windows.Forms.GroupBox grpCoeficients;
        private System.Windows.Forms.GroupBox grpresults;
    }
}

