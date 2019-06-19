namespace CsTech
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clueLbl = new System.Windows.Forms.Label();
            this.empty2Lbl = new System.Windows.Forms.Label();
            this.empty1Lbl = new System.Windows.Forms.Label();
            this.estimationGbox = new System.Windows.Forms.GroupBox();
            this.warningLbl = new System.Windows.Forms.Label();
            this.approveEstimationBtn = new System.Windows.Forms.Button();
            this.playerEstimationTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clueGbox = new System.Windows.Forms.GroupBox();
            this.minusClueTxt = new System.Windows.Forms.TextBox();
            this.plusClueTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.approveClueBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.estimationGbox.SuspendLayout();
            this.clueGbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.clueLbl);
            this.groupBox2.Controls.Add(this.empty2Lbl);
            this.groupBox2.Controls.Add(this.empty1Lbl);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // clueLbl
            // 
            this.clueLbl.AutoSize = true;
            this.clueLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clueLbl.Location = new System.Drawing.Point(27, 16);
            this.clueLbl.Name = "clueLbl";
            this.clueLbl.Size = new System.Drawing.Size(383, 13);
            this.clueLbl.TabIndex = 0;
            this.clueLbl.Text = "Ben rakamları farklı 4 basamaklı bir sayı tuttum, sen de bir sayı tut.";
            // 
            // empty2Lbl
            // 
            this.empty2Lbl.AutoSize = true;
            this.empty2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.empty2Lbl.Location = new System.Drawing.Point(27, 70);
            this.empty2Lbl.Name = "empty2Lbl";
            this.empty2Lbl.Size = new System.Drawing.Size(379, 13);
            this.empty2Lbl.TabIndex = 4;
            this.empty2Lbl.Text = "rakamın basamağı doğruysa +1, basamağı yanlış ise -1 vereceğim.";
            // 
            // empty1Lbl
            // 
            this.empty1Lbl.AutoSize = true;
            this.empty1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.empty1Lbl.Location = new System.Drawing.Point(27, 42);
            this.empty1Lbl.Name = "empty1Lbl";
            this.empty1Lbl.Size = new System.Drawing.Size(367, 13);
            this.empty1Lbl.TabIndex = 1;
            this.empty1Lbl.Text = "Burada sana ipucu vereceğim.Tahmininde bir rakam doğruyken;";
            // 
            // estimationGbox
            // 
            this.estimationGbox.BackColor = System.Drawing.Color.LightCyan;
            this.estimationGbox.Controls.Add(this.warningLbl);
            this.estimationGbox.Controls.Add(this.approveEstimationBtn);
            this.estimationGbox.Controls.Add(this.playerEstimationTxt);
            this.estimationGbox.Controls.Add(this.label4);
            this.estimationGbox.Location = new System.Drawing.Point(12, 136);
            this.estimationGbox.Name = "estimationGbox";
            this.estimationGbox.Size = new System.Drawing.Size(427, 100);
            this.estimationGbox.TabIndex = 1;
            this.estimationGbox.TabStop = false;
            this.estimationGbox.Text = "Yapacağın Tahmin";
            // 
            // warningLbl
            // 
            this.warningLbl.AutoSize = true;
            this.warningLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.warningLbl.ForeColor = System.Drawing.Color.Red;
            this.warningLbl.Location = new System.Drawing.Point(27, 67);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(289, 13);
            this.warningLbl.TabIndex = 5;
            this.warningLbl.Text = "Sadece 4 basamaklı, rakamları farklı sayı girilebilir.";
            // 
            // approveEstimationBtn
            // 
            this.approveEstimationBtn.Enabled = false;
            this.approveEstimationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.approveEstimationBtn.Location = new System.Drawing.Point(270, 23);
            this.approveEstimationBtn.Name = "approveEstimationBtn";
            this.approveEstimationBtn.Size = new System.Drawing.Size(124, 23);
            this.approveEstimationBtn.TabIndex = 2;
            this.approveEstimationBtn.Text = "Tahminini Onayla";
            this.approveEstimationBtn.UseVisualStyleBackColor = true;
            this.approveEstimationBtn.Click += new System.EventHandler(this.ApproveEstimationBtn_Click);
            // 
            // playerEstimationTxt
            // 
            this.playerEstimationTxt.Location = new System.Drawing.Point(137, 25);
            this.playerEstimationTxt.MaxLength = 4;
            this.playerEstimationTxt.Name = "playerEstimationTxt";
            this.playerEstimationTxt.Size = new System.Drawing.Size(102, 20);
            this.playerEstimationTxt.TabIndex = 1;
            this.playerEstimationTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EstimationTxt_KeyPress);
            this.playerEstimationTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EstimationTxt_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(27, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tahminini Gir:";
            // 
            // clueGbox
            // 
            this.clueGbox.BackColor = System.Drawing.Color.LightCyan;
            this.clueGbox.Controls.Add(this.minusClueTxt);
            this.clueGbox.Controls.Add(this.plusClueTxt);
            this.clueGbox.Controls.Add(this.label1);
            this.clueGbox.Controls.Add(this.approveClueBtn);
            this.clueGbox.Controls.Add(this.label5);
            this.clueGbox.Controls.Add(this.label6);
            this.clueGbox.Location = new System.Drawing.Point(12, 136);
            this.clueGbox.Name = "clueGbox";
            this.clueGbox.Size = new System.Drawing.Size(427, 100);
            this.clueGbox.TabIndex = 2;
            this.clueGbox.TabStop = false;
            this.clueGbox.Text = "Vereceğin İpucu";
            this.clueGbox.Visible = false;
            // 
            // minusClueTxt
            // 
            this.minusClueTxt.Location = new System.Drawing.Point(212, 23);
            this.minusClueTxt.MaxLength = 1;
            this.minusClueTxt.Name = "minusClueTxt";
            this.minusClueTxt.Size = new System.Drawing.Size(25, 20);
            this.minusClueTxt.TabIndex = 7;
            this.minusClueTxt.Text = "0";
            this.minusClueTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MinusClueTxt_KeyPress);
            this.minusClueTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MinusClueTxt_KeyUp);
            // 
            // plusClueTxt
            // 
            this.plusClueTxt.Location = new System.Drawing.Point(87, 23);
            this.plusClueTxt.MaxLength = 1;
            this.plusClueTxt.Name = "plusClueTxt";
            this.plusClueTxt.Size = new System.Drawing.Size(25, 20);
            this.plusClueTxt.TabIndex = 6;
            this.plusClueTxt.Text = "0";
            this.plusClueTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlusClueTxt_KeyPress);
            this.plusClueTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlusClueTxt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "4 basamak olduğundan ipuçları toplamı 4\'ü geçemez.";
            // 
            // approveClueBtn
            // 
            this.approveClueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.approveClueBtn.Location = new System.Drawing.Point(270, 21);
            this.approveClueBtn.Name = "approveClueBtn";
            this.approveClueBtn.Size = new System.Drawing.Size(124, 23);
            this.approveClueBtn.TabIndex = 3;
            this.approveClueBtn.Text = "İpucunu Onayla";
            this.approveClueBtn.UseVisualStyleBackColor = true;
            this.approveClueBtn.Click += new System.EventHandler(this.ApproveClueBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(27, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "+ İpucu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(155, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "- İpucu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(456, 257);
            this.Controls.Add(this.clueGbox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.estimationGbox);
            this.Name = "Form1";
            this.Text = "Sayı Tahmin Oyunu";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.estimationGbox.ResumeLayout(false);
            this.estimationGbox.PerformLayout();
            this.clueGbox.ResumeLayout(false);
            this.clueGbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label clueLbl;
        private System.Windows.Forms.Label empty2Lbl;
        private System.Windows.Forms.Label empty1Lbl;
        private System.Windows.Forms.GroupBox estimationGbox;
        private System.Windows.Forms.Button approveEstimationBtn;
        private System.Windows.Forms.TextBox playerEstimationTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox clueGbox;
        private System.Windows.Forms.Button approveClueBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label warningLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minusClueTxt;
        private System.Windows.Forms.TextBox plusClueTxt;
    }
}

