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
            this.tipoConica = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tipoConica
            // 
            this.tipoConica.AutoSize = true;
            this.tipoConica.Location = new System.Drawing.Point(12, 27);
            this.tipoConica.Name = "tipoConica";
            this.tipoConica.Size = new System.Drawing.Size(107, 17);
            this.tipoConica.TabIndex = 0;
            this.tipoConica.Text = "Tipo de Cônica:";
            // 
            // InfoConica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 398);
            this.Controls.Add(this.tipoConica);
            this.Name = "InfoConica";
            this.Text = "Informações Adicionais Sobre a Cônica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tipoConica;
    }
}