namespace test1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backBufferPanel = new System.Windows.Forms.Panel();
            this.labelSuggestion = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.backBufferPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            
            // 
            // backBufferPanel
            // 
            this.backBufferPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backBufferPanel.Controls.Add(this.labelSuggestion);
            this.backBufferPanel.Controls.Add(this.labelScore);
            this.backBufferPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backBufferPanel.Location = new System.Drawing.Point(0, 0);
            this.backBufferPanel.MaximumSize = new System.Drawing.Size(516, 713);
            this.backBufferPanel.MinimumSize = new System.Drawing.Size(516, 713);
            this.backBufferPanel.Name = "backBufferPanel";
            this.backBufferPanel.Size = new System.Drawing.Size(516, 713);
            this.backBufferPanel.TabIndex = 0;
            this.backBufferPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backBufferPanel_Paint);
            // 
            // labelSuggestion
            // 
            this.labelSuggestion.AutoSize = true;
            this.labelSuggestion.BackColor = System.Drawing.Color.Transparent;
            this.labelSuggestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuggestion.ForeColor = System.Drawing.Color.Black;
            this.labelSuggestion.Location = new System.Drawing.Point(46, 424);
            this.labelSuggestion.Name = "labelSuggestion";
            this.labelSuggestion.Size = new System.Drawing.Size(124, 25);
            this.labelSuggestion.TabIndex = 1;
            this.labelSuggestion.Text = "Press Space";
            this.labelSuggestion.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.Red;
            this.labelScore.Location = new System.Drawing.Point(221, 48);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(34, 35);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 610);
            this.Controls.Add(this.backBufferPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlappyBird";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.backBufferPanel.ResumeLayout(false);
            this.backBufferPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel backBufferPanel;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelSuggestion;

    }
}

 