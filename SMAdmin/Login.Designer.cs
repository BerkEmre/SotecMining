namespace SMAdmin
{
    partial class Login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.gv_urunler = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_ismi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasifmi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_kapat = new System.Windows.Forms.Button();
            this.btn_simge_durumu = new System.Windows.Forms.Button();
            this.btn_yeni_urun = new System.Windows.Forms.Button();
            this.btn_servis_debug = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_sql = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_debug = new System.Windows.Forms.ProgressBar();
            this.bw_debug = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gv_veriler = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.urun_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pazar_yeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_barkodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ismi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_urunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_veriler)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_urunler
            // 
            this.gv_urunler.AllowUserToAddRows = false;
            this.gv_urunler.AllowUserToDeleteRows = false;
            this.gv_urunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_urunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_urunler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.barkod,
            this.urun_ismi,
            this.urun_kodu,
            this.pasifmi});
            this.gv_urunler.Location = new System.Drawing.Point(3, 3);
            this.gv_urunler.Name = "gv_urunler";
            this.gv_urunler.ReadOnly = true;
            this.gv_urunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_urunler.Size = new System.Drawing.Size(715, 408);
            this.gv_urunler.TabIndex = 0;
            this.gv_urunler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_urunler_KeyDown);
            this.gv_urunler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gv_urunler_MouseDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.Width = 50;
            // 
            // barkod
            // 
            this.barkod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.barkod.DataPropertyName = "barkod";
            this.barkod.HeaderText = "Barkod";
            this.barkod.Name = "barkod";
            this.barkod.ReadOnly = true;
            // 
            // urun_ismi
            // 
            this.urun_ismi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urun_ismi.DataPropertyName = "urunismi";
            this.urun_ismi.HeaderText = "Ürün İsmi";
            this.urun_ismi.Name = "urun_ismi";
            this.urun_ismi.ReadOnly = true;
            // 
            // urun_kodu
            // 
            this.urun_kodu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urun_kodu.DataPropertyName = "urunkodu";
            this.urun_kodu.HeaderText = "Ürün Kodu";
            this.urun_kodu.Name = "urun_kodu";
            this.urun_kodu.ReadOnly = true;
            // 
            // pasifmi
            // 
            this.pasifmi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pasifmi.DataPropertyName = "pasifmi";
            this.pasifmi.HeaderText = "Pasif mi?";
            this.pasifmi.Name = "pasifmi";
            this.pasifmi.ReadOnly = true;
            this.pasifmi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pasifmi.Width = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(48, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sotec Mining Admin";
            // 
            // btn_kapat
            // 
            this.btn_kapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kapat.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_kapat.FlatAppearance.BorderSize = 2;
            this.btn_kapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kapat.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kapat.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_kapat.Location = new System.Drawing.Point(714, 12);
            this.btn_kapat.Name = "btn_kapat";
            this.btn_kapat.Size = new System.Drawing.Size(30, 30);
            this.btn_kapat.TabIndex = 2;
            this.btn_kapat.Text = "X";
            this.btn_kapat.UseVisualStyleBackColor = true;
            this.btn_kapat.Click += new System.EventHandler(this.btn_kapat_Click);
            // 
            // btn_simge_durumu
            // 
            this.btn_simge_durumu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_simge_durumu.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_simge_durumu.FlatAppearance.BorderSize = 2;
            this.btn_simge_durumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_simge_durumu.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_simge_durumu.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_simge_durumu.Location = new System.Drawing.Point(642, 12);
            this.btn_simge_durumu.Name = "btn_simge_durumu";
            this.btn_simge_durumu.Size = new System.Drawing.Size(30, 30);
            this.btn_simge_durumu.TabIndex = 3;
            this.btn_simge_durumu.Text = "-";
            this.btn_simge_durumu.UseVisualStyleBackColor = true;
            this.btn_simge_durumu.Click += new System.EventHandler(this.btn_simge_durumu_Click);
            // 
            // btn_yeni_urun
            // 
            this.btn_yeni_urun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_yeni_urun.BackColor = System.Drawing.Color.DimGray;
            this.btn_yeni_urun.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_yeni_urun.FlatAppearance.BorderSize = 2;
            this.btn_yeni_urun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yeni_urun.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yeni_urun.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_yeni_urun.Location = new System.Drawing.Point(3, 413);
            this.btn_yeni_urun.Name = "btn_yeni_urun";
            this.btn_yeni_urun.Size = new System.Drawing.Size(123, 27);
            this.btn_yeni_urun.TabIndex = 5;
            this.btn_yeni_urun.Text = "Yeni Ürün Ekle";
            this.btn_yeni_urun.UseVisualStyleBackColor = false;
            this.btn_yeni_urun.Click += new System.EventHandler(this.btn_yeni_urun_Click);
            // 
            // btn_servis_debug
            // 
            this.btn_servis_debug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_servis_debug.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_servis_debug.FlatAppearance.BorderSize = 2;
            this.btn_servis_debug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_servis_debug.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_servis_debug.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_servis_debug.Location = new System.Drawing.Point(535, 12);
            this.btn_servis_debug.Name = "btn_servis_debug";
            this.btn_servis_debug.Size = new System.Drawing.Size(101, 30);
            this.btn_servis_debug.TabIndex = 6;
            this.btn_servis_debug.Text = "SERVİS DEBUG";
            this.btn_servis_debug.UseVisualStyleBackColor = true;
            this.btn_servis_debug.Visible = false;
            this.btn_servis_debug.Click += new System.EventHandler(this.btn_servis_debug_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(678, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "#";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_sql
            // 
            this.btn_sql.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_sql.FlatAppearance.BorderSize = 2;
            this.btn_sql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sql.Font = new System.Drawing.Font("Corbel", 5.25F);
            this.btn_sql.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_sql.Location = new System.Drawing.Point(12, 12);
            this.btn_sql.Name = "btn_sql";
            this.btn_sql.Size = new System.Drawing.Size(30, 30);
            this.btn_sql.TabIndex = 8;
            this.btn_sql.Text = "SQL";
            this.btn_sql.UseVisualStyleBackColor = true;
            this.btn_sql.Click += new System.EventHandler(this.btn_sql_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SMAdmin.Properties.Resources.sm_logo_light;
            this.pictureBox1.Location = new System.Drawing.Point(535, 523);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pb_debug
            // 
            this.pb_debug.AccessibleDescription = "";
            this.pb_debug.AccessibleName = "";
            this.pb_debug.Location = new System.Drawing.Point(12, 523);
            this.pb_debug.Name = "pb_debug";
            this.pb_debug.Size = new System.Drawing.Size(449, 43);
            this.pb_debug.Step = 1;
            this.pb_debug.TabIndex = 9;
            this.pb_debug.Tag = "";
            // 
            // bw_debug
            // 
            this.bw_debug.WorkerReportsProgress = true;
            this.bw_debug.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_debug_DoWork);
            this.bw_debug.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_debug_ProgressChanged);
            this.bw_debug.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_debug_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Location = new System.Drawing.Point(467, 523);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 43);
            this.button2.TabIndex = 10;
            this.button2.Text = "VERİ ÇEK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 469);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gv_urunler);
            this.tabPage1.Controls.Add(this.btn_yeni_urun);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ürünler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.gv_veriler);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Veriler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gv_veriler
            // 
            this.gv_veriler.AllowUserToAddRows = false;
            this.gv_veriler.AllowUserToDeleteRows = false;
            this.gv_veriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_veriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_veriler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urun_id,
            this.urun_adi,
            this.pazar_yeri,
            this.kod,
            this.urun_barkodu,
            this.ismi});
            this.gv_veriler.Location = new System.Drawing.Point(3, 3);
            this.gv_veriler.Name = "gv_veriler";
            this.gv_veriler.ReadOnly = true;
            this.gv_veriler.Size = new System.Drawing.Size(715, 408);
            this.gv_veriler.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.GreenYellow;
            this.button3.Location = new System.Drawing.Point(3, 413);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 27);
            this.button3.TabIndex = 6;
            this.button3.Text = "Verileri Getir";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // urun_id
            // 
            this.urun_id.DataPropertyName = "urun_id";
            this.urun_id.HeaderText = "Ürün ID";
            this.urun_id.Name = "urun_id";
            this.urun_id.ReadOnly = true;
            this.urun_id.Width = 75;
            // 
            // urun_adi
            // 
            this.urun_adi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urun_adi.DataPropertyName = "urun_adi";
            this.urun_adi.HeaderText = "Ürün Adı";
            this.urun_adi.Name = "urun_adi";
            this.urun_adi.ReadOnly = true;
            // 
            // pazar_yeri
            // 
            this.pazar_yeri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pazar_yeri.DataPropertyName = "pazar_yeri";
            this.pazar_yeri.HeaderText = "Pazar Yeri";
            this.pazar_yeri.Name = "pazar_yeri";
            this.pazar_yeri.ReadOnly = true;
            // 
            // kod
            // 
            this.kod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kod.DataPropertyName = "kod";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kod.DefaultCellStyle = dataGridViewCellStyle1;
            this.kod.HeaderText = "Ürün Kodu";
            this.kod.Name = "kod";
            this.kod.ReadOnly = true;
            // 
            // urun_barkodu
            // 
            this.urun_barkodu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.urun_barkodu.DataPropertyName = "barkod";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urun_barkodu.DefaultCellStyle = dataGridViewCellStyle2;
            this.urun_barkodu.HeaderText = "Barkod";
            this.urun_barkodu.Name = "urun_barkodu";
            this.urun_barkodu.ReadOnly = true;
            // 
            // ismi
            // 
            this.ismi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ismi.DataPropertyName = "isim";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ismi.DefaultCellStyle = dataGridViewCellStyle3;
            this.ismi.HeaderText = "Ürün İsmi";
            this.ismi.Name = "ismi";
            this.ismi.ReadOnly = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(756, 578);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pb_debug);
            this.Controls.Add(this.btn_sql);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_servis_debug);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_simge_durumu);
            this.Controls.Add(this.btn_kapat);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sotec Mining Admin";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.gv_urunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_veriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_urunler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_kapat;
        private System.Windows.Forms.Button btn_simge_durumu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_yeni_urun;
        private System.Windows.Forms.Button btn_servis_debug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_sql;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_ismi;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_kodu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pasifmi;
        private System.Windows.Forms.ProgressBar pb_debug;
        private System.ComponentModel.BackgroundWorker bw_debug;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView gv_veriler;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn pazar_yeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_barkodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ismi;
    }
}

