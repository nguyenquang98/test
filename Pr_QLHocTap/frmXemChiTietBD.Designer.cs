namespace Pr_QLHocTap
{
    partial class frmXemChiTietBD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaSVct = new System.Windows.Forms.ComboBox();
            this.cbTenSVct = new System.Windows.Forms.ComboBox();
            this.dgvXemdiem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_hp_hoclai = new System.Windows.Forms.Button();
            this.btn_hp_chuahoc = new System.Windows.Forms.Button();
            this.btnInCTBD = new System.Windows.Forms.Button();
            this.btnGoiY = new System.Windows.Forms.Button();
            this.btnXemDiemCT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXemdiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ma SV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ten SV:";
            // 
            // cbMaSVct
            // 
            this.cbMaSVct.FormattingEnabled = true;
            this.cbMaSVct.Location = new System.Drawing.Point(115, 34);
            this.cbMaSVct.Margin = new System.Windows.Forms.Padding(6);
            this.cbMaSVct.Name = "cbMaSVct";
            this.cbMaSVct.Size = new System.Drawing.Size(254, 33);
            this.cbMaSVct.TabIndex = 2;
            this.cbMaSVct.SelectedIndexChanged += new System.EventHandler(this.cbMaSVct_SelectedIndexChanged);
            // 
            // cbTenSVct
            // 
            this.cbTenSVct.FormattingEnabled = true;
            this.cbTenSVct.Location = new System.Drawing.Point(484, 34);
            this.cbTenSVct.Margin = new System.Windows.Forms.Padding(6);
            this.cbTenSVct.Name = "cbTenSVct";
            this.cbTenSVct.Size = new System.Drawing.Size(220, 33);
            this.cbTenSVct.TabIndex = 3;
            this.cbTenSVct.SelectedIndexChanged += new System.EventHandler(this.cbTenSVct_SelectedIndexChanged);
            // 
            // dgvXemdiem
            // 
            this.dgvXemdiem.AllowUserToAddRows = false;
            this.dgvXemdiem.AllowUserToDeleteRows = false;
            this.dgvXemdiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXemdiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvXemdiem.Location = new System.Drawing.Point(0, -84);
            this.dgvXemdiem.Margin = new System.Windows.Forms.Padding(6);
            this.dgvXemdiem.Name = "dgvXemdiem";
            this.dgvXemdiem.ReadOnly = true;
            this.dgvXemdiem.Size = new System.Drawing.Size(1031, 553);
            this.dgvXemdiem.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_hp_hoclai);
            this.groupBox1.Controls.Add(this.btn_hp_chuahoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInCTBD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMaSVct);
            this.groupBox1.Controls.Add(this.btnGoiY);
            this.groupBox1.Controls.Add(this.cbTenSVct);
            this.groupBox1.Controls.Add(this.btnXemDiemCT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 128);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sinh viên cụ thể:";
            // 
            // btn_hp_hoclai
            // 
            this.btn_hp_hoclai.Image = global::Pr_QLHocTap.Properties.Resources.suggest;
            this.btn_hp_hoclai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hp_hoclai.Location = new System.Drawing.Point(716, 27);
            this.btn_hp_hoclai.Margin = new System.Windows.Forms.Padding(6);
            this.btn_hp_hoclai.Name = "btn_hp_hoclai";
            this.btn_hp_hoclai.Size = new System.Drawing.Size(277, 44);
            this.btn_hp_hoclai.TabIndex = 10;
            this.btn_hp_hoclai.Text = "D/s HP học lại và cải thiện";
            this.btn_hp_hoclai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_hp_hoclai.UseVisualStyleBackColor = true;
            this.btn_hp_hoclai.Click += new System.EventHandler(this.btn_hp_hoclai_Click);
            // 
            // btn_hp_chuahoc
            // 
            this.btn_hp_chuahoc.Image = global::Pr_QLHocTap.Properties.Resources.suggest;
            this.btn_hp_chuahoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hp_chuahoc.Location = new System.Drawing.Point(716, 79);
            this.btn_hp_chuahoc.Margin = new System.Windows.Forms.Padding(6);
            this.btn_hp_chuahoc.Name = "btn_hp_chuahoc";
            this.btn_hp_chuahoc.Size = new System.Drawing.Size(277, 44);
            this.btn_hp_chuahoc.TabIndex = 9;
            this.btn_hp_chuahoc.Text = "D/s học phần chưa học";
            this.btn_hp_chuahoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_hp_chuahoc.UseVisualStyleBackColor = true;
            this.btn_hp_chuahoc.Click += new System.EventHandler(this.btn_hp_chuahoc_Click);
            // 
            // btnInCTBD
            // 
            this.btnInCTBD.Image = global::Pr_QLHocTap.Properties.Resources.icon_print;
            this.btnInCTBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInCTBD.Location = new System.Drawing.Point(199, 79);
            this.btnInCTBD.Margin = new System.Windows.Forms.Padding(6);
            this.btnInCTBD.Name = "btnInCTBD";
            this.btnInCTBD.Size = new System.Drawing.Size(170, 44);
            this.btnInCTBD.TabIndex = 8;
            this.btnInCTBD.Text = "In Bảng Điểm";
            this.btnInCTBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInCTBD.UseVisualStyleBackColor = true;
            this.btnInCTBD.Click += new System.EventHandler(this.btnInCTBD_Click);
            // 
            // btnGoiY
            // 
            this.btnGoiY.Image = global::Pr_QLHocTap.Properties.Resources.suggest;
            this.btnGoiY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoiY.Location = new System.Drawing.Point(398, 79);
            this.btnGoiY.Margin = new System.Windows.Forms.Padding(6);
            this.btnGoiY.Name = "btnGoiY";
            this.btnGoiY.Size = new System.Drawing.Size(306, 44);
            this.btnGoiY.TabIndex = 6;
            this.btnGoiY.Text = "D/s HP mà SV được đký mới";
            this.btnGoiY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoiY.UseVisualStyleBackColor = true;
            this.btnGoiY.Click += new System.EventHandler(this.btnGoiY_Click);
            // 
            // btnXemDiemCT
            // 
            this.btnXemDiemCT.Image = global::Pr_QLHocTap.Properties.Resources.xem2;
            this.btnXemDiemCT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDiemCT.Location = new System.Drawing.Point(36, 79);
            this.btnXemDiemCT.Margin = new System.Windows.Forms.Padding(6);
            this.btnXemDiemCT.Name = "btnXemDiemCT";
            this.btnXemDiemCT.Size = new System.Drawing.Size(151, 44);
            this.btnXemDiemCT.TabIndex = 5;
            this.btnXemDiemCT.Text = "Xem Diem";
            this.btnXemDiemCT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemDiemCT.UseVisualStyleBackColor = true;
            this.btnXemDiemCT.Click += new System.EventHandler(this.btnXemDiemCT_Click);
            // 
            // frmXemChiTietBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1031, 469);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvXemdiem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmXemChiTietBD";
            this.Text = "frmXemChiTietBD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemChiTietBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXemdiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTenSVct;
        private System.Windows.Forms.Button btnXemDiemCT;
        private System.Windows.Forms.Button btnGoiY;
        private System.Windows.Forms.DataGridView dgvXemdiem;
        private System.Windows.Forms.Button btnInCTBD;
        public System.Windows.Forms.ComboBox cbMaSVct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_hp_chuahoc;
        private System.Windows.Forms.Button btn_hp_hoclai;
    }
}