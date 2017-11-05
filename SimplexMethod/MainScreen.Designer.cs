namespace SimplexMethod
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.nOfContraintsTextBox = new System.Windows.Forms.TextBox();
            this.nOfVariablesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.constraintsGridView = new System.Windows.Forms.DataGridView();
            this.functionGridView = new System.Windows.Forms.DataGridView();
            this.extrComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            this.goBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.resultsLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.constraintsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nOfContraintsTextBox
            // 
            this.nOfContraintsTextBox.Location = new System.Drawing.Point(149, 23);
            this.nOfContraintsTextBox.Name = "nOfContraintsTextBox";
            this.nOfContraintsTextBox.Size = new System.Drawing.Size(34, 29);
            this.nOfContraintsTextBox.TabIndex = 0;
            // 
            // nOfVariablesTextBox
            // 
            this.nOfVariablesTextBox.Location = new System.Drawing.Point(309, 23);
            this.nOfVariablesTextBox.Name = "nOfVariablesTextBox";
            this.nOfVariablesTextBox.Size = new System.Drawing.Size(34, 29);
            this.nOfVariablesTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "N. of constraints";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(732, 23);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 36);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // constraintsGridView
            // 
            this.constraintsGridView.BackgroundColor = System.Drawing.Color.White;
            this.constraintsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.constraintsGridView.Location = new System.Drawing.Point(24, 67);
            this.constraintsGridView.Name = "constraintsGridView";
            this.constraintsGridView.Size = new System.Drawing.Size(777, 123);
            this.constraintsGridView.TabIndex = 5;
            // 
            // functionGridView
            // 
            this.functionGridView.BackgroundColor = System.Drawing.Color.White;
            this.functionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.functionGridView.Location = new System.Drawing.Point(24, 213);
            this.functionGridView.Name = "functionGridView";
            this.functionGridView.Size = new System.Drawing.Size(686, 62);
            this.functionGridView.TabIndex = 6;
            // 
            // extrComboBox
            // 
            this.extrComboBox.AllowDrop = true;
            this.extrComboBox.FormattingEnabled = true;
            this.extrComboBox.Items.AddRange(new object[] {
            "Max",
            "Min"});
            this.extrComboBox.Location = new System.Drawing.Point(732, 246);
            this.extrComboBox.Name = "extrComboBox";
            this.extrComboBox.Size = new System.Drawing.Size(69, 29);
            this.extrComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "N. of variables";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(728, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Extr";
            // 
            // resultsGridView
            // 
            this.resultsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGridView.BackgroundColor = System.Drawing.Color.White;
            this.resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGridView.Location = new System.Drawing.Point(24, 354);
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.Size = new System.Drawing.Size(777, 287);
            this.resultsGridView.TabIndex = 9;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(24, 291);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(686, 34);
            this.goBtn.TabIndex = 10;
            this.goBtn.Text = "GO";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(732, 291);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(69, 34);
            this.clearBtn.TabIndex = 11;
            this.clearBtn.Text = "CLEAR";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // defaultBtn
            // 
            this.defaultBtn.Location = new System.Drawing.Point(592, 23);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(118, 36);
            this.defaultBtn.TabIndex = 12;
            this.defaultBtn.Text = "Default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // resultsLbl
            // 
            this.resultsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultsLbl.AutoSize = true;
            this.resultsLbl.Location = new System.Drawing.Point(20, 657);
            this.resultsLbl.Name = "resultsLbl";
            this.resultsLbl.Size = new System.Drawing.Size(0, 21);
            this.resultsLbl.TabIndex = 13;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 697);
            this.Controls.Add(this.resultsLbl);
            this.Controls.Add(this.defaultBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.resultsGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.extrComboBox);
            this.Controls.Add(this.functionGridView);
            this.Controls.Add(this.constraintsGridView);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nOfVariablesTextBox);
            this.Controls.Add(this.nOfContraintsTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainScreen";
            this.Text = "Simplex Method";
            ((System.ComponentModel.ISupportInitialize)(this.constraintsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nOfContraintsTextBox;
        private System.Windows.Forms.TextBox nOfVariablesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.DataGridView constraintsGridView;
        private System.Windows.Forms.DataGridView functionGridView;
        private System.Windows.Forms.ComboBox extrComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView resultsGridView;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.Label resultsLbl;
    }
}

