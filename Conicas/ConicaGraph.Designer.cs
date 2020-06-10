using System;

namespace Conicas
{
    partial class ConicaGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConicaGraph));
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipoDeGrafico = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(0, 0);
            this.picGraph.Margin = new System.Windows.Forms.Padding(4);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(508, 460);
            this.picGraph.TabIndex = 15;
            this.picGraph.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.picGraph);
            this.panel1.Location = new System.Drawing.Point(13, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 460);
            this.panel1.TabIndex = 16;
            // 
            // lblTipoDeGrafico
            // 
            this.lblTipoDeGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblTipoDeGrafico.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeGrafico.ForeColor = System.Drawing.Color.White;
            this.lblTipoDeGrafico.Location = new System.Drawing.Point(122, 39);
            this.lblTipoDeGrafico.Name = "lblTipoDeGrafico";
            this.lblTipoDeGrafico.Size = new System.Drawing.Size(351, 25);
            this.lblTipoDeGrafico.TabIndex = 17;
            // 
            // ConicaGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 549);
            this.Controls.Add(this.lblTipoDeGrafico);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConicaGraph";
            this.Text = "Gráfico da ";
            this.Load += new System.EventHandler(this.ConicaGraph_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTipoDeGrafico;
    }
}