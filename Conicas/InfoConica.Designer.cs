namespace Conicas
{
    partial class InfoConica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDetalhes = new System.Windows.Forms.Label();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblTextoClassificacao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDetalhes
            // 
            this.lblDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalhes.Location = new System.Drawing.Point(30, 158);
            this.lblDetalhes.Name = "lblDetalhes";
            this.lblDetalhes.Size = new System.Drawing.Size(760, 357);
            this.lblDetalhes.TabIndex = 0;
            this.lblDetalhes.Text = "  ";
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.BackColor = System.Drawing.SystemColors.Control;
            this.lblClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificacao.Location = new System.Drawing.Point(206, 82);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(584, 26);
            this.lblClassificacao.TabIndex = 1;
            this.lblClassificacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextoClassificacao
            // 
            this.lblTextoClassificacao.AutoSize = true;
            this.lblTextoClassificacao.BackColor = System.Drawing.Color.White;
            this.lblTextoClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoClassificacao.Location = new System.Drawing.Point(30, 83);
            this.lblTextoClassificacao.Name = "lblTextoClassificacao";
            this.lblTextoClassificacao.Size = new System.Drawing.Size(137, 24);
            this.lblTextoClassificacao.TabIndex = 2;
            this.lblTextoClassificacao.Text = "Classificação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elementos Geométricos:";
            // 
            // InfoConica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 539);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTextoClassificacao);
            this.Controls.Add(this.lblClassificacao);
            this.Controls.Add(this.lblDetalhes);
            this.Name = "InfoConica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações Adicionais Sobre a Cônica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoConica_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetalhes;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblTextoClassificacao;
        private System.Windows.Forms.Label label1;
    }
}