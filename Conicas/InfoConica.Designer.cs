﻿namespace Conicas
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
            this.SuspendLayout();
            // 
            // lblDetalhes
            // 
            this.lblDetalhes.Location = new System.Drawing.Point(12, 80);
            this.lblDetalhes.Name = "lblDetalhes";
            this.lblDetalhes.Size = new System.Drawing.Size(653, 302);
            this.lblDetalhes.TabIndex = 0;
            this.lblDetalhes.Text = "  ";
            // 
            // InfoConica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 398);
            this.Controls.Add(this.lblDetalhes);
            this.Name = "InfoConica";
            this.Text = "Informações Adicionais Sobre a Cônica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoConica_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDetalhes;
    }
}