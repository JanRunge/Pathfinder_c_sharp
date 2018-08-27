namespace Pathfinder_c_sharp
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.panelStart = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStopSolving = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonRedraw = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.textBoxDensity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSizeY = new System.Windows.Forms.TextBox();
            this.textBoxSizeX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStartingpoints = new System.Windows.Forms.TextBox();
            this.panelStart.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(0, 125);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(96, 26);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(0, 27);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(96, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Delay";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(41, 1);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(33, 20);
            this.textBoxDelay.TabIndex = 3;
            this.textBoxDelay.Text = "1000";
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.label5);
            this.panelStart.Controls.Add(this.buttonStopSolving);
            this.panelStart.Controls.Add(this.buttonStart);
            this.panelStart.Controls.Add(this.textBoxDelay);
            this.panelStart.Controls.Add(this.label1);
            this.panelStart.Location = new System.Drawing.Point(28, 268);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(96, 94);
            this.panelStart.TabIndex = 4;
            this.panelStart.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ms";
            // 
            // buttonStopSolving
            // 
            this.buttonStopSolving.Location = new System.Drawing.Point(0, 56);
            this.buttonStopSolving.Name = "buttonStopSolving";
            this.buttonStopSolving.Size = new System.Drawing.Size(96, 23);
            this.buttonStopSolving.TabIndex = 0;
            this.buttonStopSolving.Text = "Stop Solving";
            this.buttonStopSolving.UseVisualStyleBackColor = true;
            this.buttonStopSolving.Click += new System.EventHandler(this.buttonStopSolving_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxStartingpoints);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Controls.Add(this.buttonRedraw);
            this.panel2.Controls.Add(this.buttonDefault);
            this.panel2.Controls.Add(this.textBoxDensity);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxSizeY);
            this.panel2.Controls.Add(this.textBoxSizeX);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonGenerate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(27, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 225);
            this.panel2.TabIndex = 5;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(0, 157);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(96, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRedraw
            // 
            this.buttonRedraw.Location = new System.Drawing.Point(-3, 186);
            this.buttonRedraw.Name = "buttonRedraw";
            this.buttonRedraw.Size = new System.Drawing.Size(96, 23);
            this.buttonRedraw.TabIndex = 10;
            this.buttonRedraw.Text = "Redraw";
            this.buttonRedraw.UseVisualStyleBackColor = true;
            this.buttonRedraw.Click += new System.EventHandler(this.buttonRedraw_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(42, 96);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(55, 23);
            this.buttonDefault.TabIndex = 9;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxDensity
            // 
            this.textBoxDensity.Location = new System.Drawing.Point(41, 51);
            this.textBoxDensity.Name = "textBoxDensity";
            this.textBoxDensity.Size = new System.Drawing.Size(55, 20);
            this.textBoxDensity.TabIndex = 6;
            this.textBoxDensity.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Density";
            // 
            // textBoxSizeY
            // 
            this.textBoxSizeY.Location = new System.Drawing.Point(41, 27);
            this.textBoxSizeY.Name = "textBoxSizeY";
            this.textBoxSizeY.Size = new System.Drawing.Size(55, 20);
            this.textBoxSizeY.TabIndex = 8;
            this.textBoxSizeY.Text = "20";
            // 
            // textBoxSizeX
            // 
            this.textBoxSizeX.Location = new System.Drawing.Point(41, 0);
            this.textBoxSizeX.Name = "textBoxSizeX";
            this.textBoxSizeX.Size = new System.Drawing.Size(55, 20);
            this.textBoxSizeX.TabIndex = 7;
            this.textBoxSizeX.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Size Y";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Size X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Entries";
            // 
            // textBoxStartingpoints
            // 
            this.textBoxStartingpoints.Location = new System.Drawing.Point(41, 75);
            this.textBoxStartingpoints.Name = "textBoxStartingpoints";
            this.textBoxStartingpoints.Size = new System.Drawing.Size(55, 20);
            this.textBoxStartingpoints.TabIndex = 13;
            this.textBoxStartingpoints.Text = "1";
            this.textBoxStartingpoints.TextChanged += new System.EventHandler(this.textBoxStartingpoints_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSizeX;
        private System.Windows.Forms.TextBox textBoxDensity;
        private System.Windows.Forms.TextBox textBoxSizeY;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Button buttonRedraw;
        private System.Windows.Forms.Button buttonStopSolving;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxStartingpoints;
        private System.Windows.Forms.Label label6;
    }
}

