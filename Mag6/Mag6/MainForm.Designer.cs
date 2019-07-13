namespace Mag6
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMusicPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSearchNext = new System.Windows.Forms.Button();
            this.cbSearchSongs = new System.Windows.Forms.CheckBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.tSearch = new System.Windows.Forms.TextBox();
            this.bAddMusic = new System.Windows.Forms.Button();
            this.bUpload = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bRefresh = new System.Windows.Forms.Button();
            this.dsDvds = new System.Data.DataSet();
            this.tDvds = new System.Data.DataTable();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dsSongs = new System.Data.DataSet();
            this.tSongs = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pAddMusic = new System.Windows.Forms.Panel();
            this.bDoAddMusic = new System.Windows.Forms.Button();
            this.tDvdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tSource = new System.Windows.Forms.TextBox();
            this.pUploadPanel = new System.Windows.Forms.Panel();
            this.bDoUpload = new System.Windows.Forms.Button();
            this.tVolume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tDestination = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dwDvds = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlwAlbums = new BrightIdeasSoftware.TreeListView();
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvDuration = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBitrate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pbAlbum = new System.Windows.Forms.PictureBox();
            this.dwSongs = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VBR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagesBig = new System.Windows.Forms.ImageList(this.components);
            this.mAlbums = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.miHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDvds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDvds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSongs)).BeginInit();
            this.panel3.SuspendLayout();
            this.pAddMusic.SuspendLayout();
            this.pUploadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwDvds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlwAlbums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwSongs)).BeginInit();
            this.mAlbums.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMusicPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 28);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMusicPath.Location = new System.Drawing.Point(627, 3);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.Size = new System.Drawing.Size(173, 20);
            this.txtMusicPath.TabIndex = 0;
            this.txtMusicPath.TextChanged += new System.EventHandler(this.txtMusicPath_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bSearchNext);
            this.panel2.Controls.Add(this.cbSearchSongs);
            this.panel2.Controls.Add(this.bSearch);
            this.panel2.Controls.Add(this.tSearch);
            this.panel2.Controls.Add(this.bAddMusic);
            this.panel2.Controls.Add(this.bUpload);
            this.panel2.Controls.Add(this.bStop);
            this.panel2.Controls.Add(this.bRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 27);
            this.panel2.TabIndex = 1;
            // 
            // bSearchNext
            // 
            this.bSearchNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("bSearchNext.Image")));
            this.bSearchNext.Location = new System.Drawing.Point(327, 1);
            this.bSearchNext.Name = "bSearchNext";
            this.bSearchNext.Size = new System.Drawing.Size(25, 25);
            this.bSearchNext.TabIndex = 9;
            this.toolTip1.SetToolTip(this.bSearchNext, "Найти следующий");
            this.bSearchNext.UseVisualStyleBackColor = true;
            this.bSearchNext.Click += new System.EventHandler(this.bSearchNext_Click);
            // 
            // cbSearchSongs
            // 
            this.cbSearchSongs.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSearchSongs.AutoSize = true;
            this.cbSearchSongs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cbSearchSongs.BackgroundImage")));
            this.cbSearchSongs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbSearchSongs.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.cbSearchSongs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.cbSearchSongs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSearchSongs.Location = new System.Drawing.Point(354, 2);
            this.cbSearchSongs.Name = "cbSearchSongs";
            this.cbSearchSongs.Size = new System.Drawing.Size(73, 23);
            this.cbSearchSongs.TabIndex = 8;
            this.cbSearchSongs.Text = "    в песнях";
            this.cbSearchSongs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cbSearchSongs, "Искать в названиях песен и именах файлов");
            this.cbSearchSongs.UseVisualStyleBackColor = true;
            // 
            // bSearch
            // 
            this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSearch.Image = ((System.Drawing.Image)(resources.GetObject("bSearch.Image")));
            this.bSearch.Location = new System.Drawing.Point(300, 1);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(25, 25);
            this.bSearch.TabIndex = 7;
            this.toolTip1.SetToolTip(this.bSearch, "Поиск");
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tSearch
            // 
            this.tSearch.Location = new System.Drawing.Point(156, 4);
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(141, 20);
            this.tSearch.TabIndex = 6;
            this.toolTip1.SetToolTip(this.tSearch, "Строка поиска");
            this.tSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tSearch_KeyDown);
            // 
            // bAddMusic
            // 
            this.bAddMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddMusic.Image = ((System.Drawing.Image)(resources.GetObject("bAddMusic.Image")));
            this.bAddMusic.Location = new System.Drawing.Point(99, 0);
            this.bAddMusic.Name = "bAddMusic";
            this.bAddMusic.Size = new System.Drawing.Size(25, 25);
            this.bAddMusic.TabIndex = 5;
            this.toolTip1.SetToolTip(this.bAddMusic, "Добавить музыку");
            this.bAddMusic.UseVisualStyleBackColor = true;
            this.bAddMusic.Click += new System.EventHandler(this.bAddMusic_Click);
            // 
            // bUpload
            // 
            this.bUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUpload.Image = ((System.Drawing.Image)(resources.GetObject("bUpload.Image")));
            this.bUpload.Location = new System.Drawing.Point(61, 0);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(25, 25);
            this.bUpload.TabIndex = 4;
            this.toolTip1.SetToolTip(this.bUpload, "Чего послушать");
            this.bUpload.UseVisualStyleBackColor = true;
            this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStop.Image = ((System.Drawing.Image)(resources.GetObject("bStop.Image")));
            this.bStop.Location = new System.Drawing.Point(27, 0);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(25, 25);
            this.bStop.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bStop, "Остановить обновление");
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bRefresh
            // 
            this.bRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRefresh.Image = ((System.Drawing.Image)(resources.GetObject("bRefresh.Image")));
            this.bRefresh.Location = new System.Drawing.Point(0, 0);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(25, 25);
            this.bRefresh.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bRefresh, "Обновить данные о файлах");
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // dsDvds
            // 
            this.dsDvds.DataSetName = "NewDataSet";
            this.dsDvds.Tables.AddRange(new System.Data.DataTable[] {
            this.tDvds});
            // 
            // tDvds
            // 
            this.tDvds.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn6});
            this.tDvds.TableName = "Dvds";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "Name";
            this.dataColumn6.ColumnName = "Name";
            // 
            // dsSongs
            // 
            this.dsSongs.DataSetName = "SongsDataSet";
            this.dsSongs.Tables.AddRange(new System.Data.DataTable[] {
            this.tSongs});
            // 
            // tSongs
            // 
            this.tSongs.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn7});
            this.tSongs.TableName = "Songs";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Name";
            this.dataColumn1.ColumnName = "Name";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "FileName";
            this.dataColumn2.ColumnName = "FileName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Size";
            this.dataColumn3.ColumnName = "Size";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Bitrate";
            this.dataColumn4.ColumnName = "Bitrate";
            this.dataColumn4.DataType = typeof(short);
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "Duration";
            this.dataColumn5.ColumnName = "Duration";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "VBR";
            this.dataColumn7.ColumnName = "VBR";
            this.dataColumn7.DataType = typeof(bool);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pAddMusic);
            this.panel3.Controls.Add(this.pUploadPanel);
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 437);
            this.panel3.TabIndex = 5;
            // 
            // pAddMusic
            // 
            this.pAddMusic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pAddMusic.Controls.Add(this.bDoAddMusic);
            this.pAddMusic.Controls.Add(this.tDvdName);
            this.pAddMusic.Controls.Add(this.label4);
            this.pAddMusic.Controls.Add(this.label5);
            this.pAddMusic.Controls.Add(this.tSource);
            this.pAddMusic.Location = new System.Drawing.Point(99, 0);
            this.pAddMusic.Name = "pAddMusic";
            this.pAddMusic.Size = new System.Drawing.Size(233, 88);
            this.pAddMusic.TabIndex = 9;
            this.pAddMusic.Visible = false;
            // 
            // bDoAddMusic
            // 
            this.bDoAddMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDoAddMusic.Image = ((System.Drawing.Image)(resources.GetObject("bDoAddMusic.Image")));
            this.bDoAddMusic.Location = new System.Drawing.Point(199, 54);
            this.bDoAddMusic.Name = "bDoAddMusic";
            this.bDoAddMusic.Size = new System.Drawing.Size(25, 25);
            this.bDoAddMusic.TabIndex = 8;
            this.bDoAddMusic.UseVisualStyleBackColor = true;
            this.bDoAddMusic.Click += new System.EventHandler(this.bDoAddMusic_Click);
            // 
            // tDvdName
            // 
            this.tDvdName.Location = new System.Drawing.Point(3, 57);
            this.tDvdName.Name = "tDvdName";
            this.tDvdName.Size = new System.Drawing.Size(190, 20);
            this.tDvdName.TabIndex = 7;
            this.tDvdName.TextChanged += new System.EventHandler(this.tDvdName_TextChanged);
            this.tDvdName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tDvdName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Название DVD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Откуда";
            // 
            // tSource
            // 
            this.tSource.Location = new System.Drawing.Point(3, 18);
            this.tSource.Name = "tSource";
            this.tSource.Size = new System.Drawing.Size(190, 20);
            this.tSource.TabIndex = 4;
            this.tSource.TextChanged += new System.EventHandler(this.tSource_TextChanged);
            this.tSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tSource_KeyDown);
            // 
            // pUploadPanel
            // 
            this.pUploadPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pUploadPanel.Controls.Add(this.bDoUpload);
            this.pUploadPanel.Controls.Add(this.tVolume);
            this.pUploadPanel.Controls.Add(this.label3);
            this.pUploadPanel.Controls.Add(this.label2);
            this.pUploadPanel.Controls.Add(this.tDestination);
            this.pUploadPanel.Location = new System.Drawing.Point(61, 0);
            this.pUploadPanel.Name = "pUploadPanel";
            this.pUploadPanel.Size = new System.Drawing.Size(236, 88);
            this.pUploadPanel.TabIndex = 8;
            this.pUploadPanel.Visible = false;
            // 
            // bDoUpload
            // 
            this.bDoUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDoUpload.Image = ((System.Drawing.Image)(resources.GetObject("bDoUpload.Image")));
            this.bDoUpload.Location = new System.Drawing.Point(199, 52);
            this.bDoUpload.Name = "bDoUpload";
            this.bDoUpload.Size = new System.Drawing.Size(25, 25);
            this.bDoUpload.TabIndex = 4;
            this.bDoUpload.UseVisualStyleBackColor = true;
            this.bDoUpload.Click += new System.EventHandler(this.bDoUpload_Click);
            // 
            // tVolume
            // 
            this.tVolume.Location = new System.Drawing.Point(3, 55);
            this.tVolume.Name = "tVolume";
            this.tVolume.Size = new System.Drawing.Size(190, 20);
            this.tVolume.TabIndex = 3;
            this.tVolume.TextChanged += new System.EventHandler(this.tVolume_TextChanged);
            this.tVolume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tVolume_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сколько (КБ)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Куда";
            // 
            // tDestination
            // 
            this.tDestination.Location = new System.Drawing.Point(3, 16);
            this.tDestination.Name = "tDestination";
            this.tDestination.Size = new System.Drawing.Size(190, 20);
            this.tDestination.TabIndex = 0;
            this.tDestination.TextChanged += new System.EventHandler(this.tDestination_TextChanged);
            this.tDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tDestination_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbAlbum);
            this.splitContainer1.Panel2.Controls.Add(this.dwSongs);
            this.splitContainer1.Size = new System.Drawing.Size(814, 437);
            this.splitContainer1.SplitterDistance = 447;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dwDvds);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tlwAlbums);
            this.splitContainer2.Size = new System.Drawing.Size(447, 437);
            this.splitContainer2.SplitterDistance = 86;
            this.splitContainer2.TabIndex = 4;
            // 
            // dwDvds
            // 
            this.dwDvds.AllowUserToAddRows = false;
            this.dwDvds.AllowUserToDeleteRows = false;
            this.dwDvds.AutoGenerateColumns = false;
            this.dwDvds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwDvds.ColumnHeadersVisible = false;
            this.dwDvds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1});
            this.dwDvds.DataMember = "Dvds";
            this.dwDvds.DataSource = this.dsDvds;
            this.dwDvds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwDvds.Location = new System.Drawing.Point(0, 0);
            this.dwDvds.Name = "dwDvds";
            this.dwDvds.ReadOnly = true;
            this.dwDvds.RowHeadersVisible = false;
            this.dwDvds.RowTemplate.Height = 18;
            this.dwDvds.Size = new System.Drawing.Size(86, 437);
            this.dwDvds.TabIndex = 0;
            this.dwDvds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dwDvds_CellClick);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tlwAlbums
            // 
            this.tlwAlbums.AllColumns.Add(this.olvName);
            this.tlwAlbums.AllColumns.Add(this.olvDuration);
            this.tlwAlbums.AllColumns.Add(this.olvBitrate);
            this.tlwAlbums.AllColumns.Add(this.olvSize);
            this.tlwAlbums.CellEditUseWholeCell = false;
            this.tlwAlbums.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvDuration,
            this.olvBitrate,
            this.olvSize});
            this.tlwAlbums.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlwAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlwAlbums.FullRowSelect = true;
            this.tlwAlbums.HideSelection = false;
            this.tlwAlbums.Location = new System.Drawing.Point(0, 0);
            this.tlwAlbums.Name = "tlwAlbums";
            this.tlwAlbums.ShowGroups = false;
            this.tlwAlbums.Size = new System.Drawing.Size(357, 437);
            this.tlwAlbums.SmallImageList = this.imageList1;
            this.tlwAlbums.TabIndex = 6;
            this.tlwAlbums.UseCompatibleStateImageBehavior = false;
            this.tlwAlbums.View = System.Windows.Forms.View.Details;
            this.tlwAlbums.VirtualMode = true;
            this.tlwAlbums.Expanded += new System.EventHandler<BrightIdeasSoftware.TreeBranchExpandedEventArgs>(this.tlwAlbums_Expanded);
            this.tlwAlbums.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.tlwAlbums_CellRightClick);
            this.tlwAlbums.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.tlwAlbums_FormatRow);
            this.tlwAlbums.SelectionChanged += new System.EventHandler(this.tlwAlbums_SelectionChanged);
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.FillsFreeSpace = true;
            this.olvName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvName.IsTileViewColumn = true;
            this.olvName.Text = "Name";
            // 
            // olvDuration
            // 
            this.olvDuration.AspectName = "Duration";
            this.olvDuration.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvDuration.Text = "Duration";
            this.olvDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvDuration.Width = 80;
            // 
            // olvBitrate
            // 
            this.olvBitrate.AspectName = "Bitrate";
            this.olvBitrate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBitrate.Text = "Bitrate";
            this.olvBitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvSize
            // 
            this.olvSize.AspectName = "Size";
            this.olvSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvSize.Text = "Size";
            this.olvSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbAlbum
            // 
            this.pbAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAlbum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbAlbum.Location = new System.Drawing.Point(0, 237);
            this.pbAlbum.Name = "pbAlbum";
            this.pbAlbum.Size = new System.Drawing.Size(363, 200);
            this.pbAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAlbum.TabIndex = 5;
            this.pbAlbum.TabStop = false;
            this.pbAlbum.Visible = false;
            // 
            // dwSongs
            // 
            this.dwSongs.AllowUserToAddRows = false;
            this.dwSongs.AllowUserToDeleteRows = false;
            this.dwSongs.AutoGenerateColumns = false;
            this.dwSongs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dwSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.nameDataGridViewTextBoxColumn,
            this.FileSize,
            this.Bitrate,
            this.VBR,
            this.Duration});
            this.dwSongs.DataMember = "Songs";
            this.dwSongs.DataSource = this.dsSongs;
            this.dwSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwSongs.Location = new System.Drawing.Point(0, 0);
            this.dwSongs.Name = "dwSongs";
            this.dwSongs.ReadOnly = true;
            this.dwSongs.RowHeadersVisible = false;
            this.dwSongs.RowTemplate.Height = 18;
            this.dwSongs.Size = new System.Drawing.Size(363, 437);
            this.dwSongs.TabIndex = 4;
            this.dwSongs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dwSongs_CellFormatting);
            this.dwSongs.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dwSongs_RowPrePaint);
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 58;
            // 
            // FileSize
            // 
            this.FileSize.DataPropertyName = "Size";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.FileSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.FileSize.HeaderText = "Size";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            this.FileSize.Width = 70;
            // 
            // Bitrate
            // 
            this.Bitrate.DataPropertyName = "Bitrate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Bitrate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Bitrate.HeaderText = "Bitrate";
            this.Bitrate.Name = "Bitrate";
            this.Bitrate.ReadOnly = true;
            this.Bitrate.Width = 40;
            // 
            // VBR
            // 
            this.VBR.DataPropertyName = "VBR";
            this.VBR.HeaderText = "VBR";
            this.VBR.Name = "VBR";
            this.VBR.ReadOnly = true;
            this.VBR.Width = 30;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Duration.DefaultCellStyle = dataGridViewCellStyle3;
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 50;
            // 
            // imagesBig
            // 
            this.imagesBig.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imagesBig.ImageSize = new System.Drawing.Size(200, 200);
            this.imagesBig.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mAlbums
            // 
            this.mAlbums.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miToFolder,
            this.miHidden});
            this.mAlbums.Name = "mAlbums";
            this.mAlbums.Size = new System.Drawing.Size(157, 48);
            // 
            // miToFolder
            // 
            this.miToFolder.Name = "miToFolder";
            this.miToFolder.Size = new System.Drawing.Size(156, 22);
            this.miToFolder.Text = "Открыть папку";
            this.miToFolder.Click += new System.EventHandler(this.miToFolder_Click);
            // 
            // miHidden
            // 
            this.miHidden.Name = "miHidden";
            this.miHidden.Size = new System.Drawing.Size(156, 22);
            this.miHidden.Text = "Скрыть";
            this.miHidden.Click += new System.EventHandler(this.miHidden_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Mag6";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDvds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDvds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSongs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pAddMusic.ResumeLayout(false);
            this.pAddMusic.PerformLayout();
            this.pUploadPanel.ResumeLayout(false);
            this.pUploadPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dwDvds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlwAlbums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwSongs)).EndInit();
            this.mAlbums.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMusicPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bRefresh;
        private System.Data.DataSet dsSongs;
        private System.Data.DataTable tSongs;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStop;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataSet dsDvds;
        private System.Data.DataTable tDvds;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dwDvds;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dwSongs;
        private System.Windows.Forms.Panel pUploadPanel;
        private System.Windows.Forms.TextBox tVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tDestination;
        private System.Windows.Forms.Button bDoUpload;
        private BrightIdeasSoftware.TreeListView tlwAlbums;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvDuration;
        private BrightIdeasSoftware.OLVColumn olvBitrate;
        private BrightIdeasSoftware.OLVColumn olvSize;
        private System.Windows.Forms.Panel pAddMusic;
        private System.Windows.Forms.Button bAddMusic;
        private System.Windows.Forms.TextBox tDvdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tSource;
        private System.Windows.Forms.Button bDoAddMusic;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imagesBig;
        private System.Windows.Forms.PictureBox pbAlbum;
        private System.Windows.Forms.TextBox tSearch;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.CheckBox cbSearchSongs;
        private System.Windows.Forms.Button bSearchNext;
        private System.Windows.Forms.ContextMenuStrip mAlbums;
        private System.Windows.Forms.ToolStripMenuItem miToFolder;
        private System.Windows.Forms.ToolStripMenuItem miHidden;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Data.DataColumn dataColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bitrate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    }
}