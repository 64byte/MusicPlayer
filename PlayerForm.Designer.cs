namespace MusicPlayer
{
    partial class PlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.listView_MusicList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagelist_Album = new System.Windows.Forms.ImageList(this.components);
            this.btn_PlayToggle = new System.Windows.Forms.Button();
            this.backgroundWorker_UpdatepBar = new System.ComponentModel.BackgroundWorker();
            this.label_MusicName = new System.Windows.Forms.Label();
            this.btn_PlayPrev = new System.Windows.Forms.Button();
            this.btn_PlayNext = new System.Windows.Forms.Button();
            this.picBox_AlbumThumnail = new System.Windows.Forms.PictureBox();
            this.label_CurrentPos = new System.Windows.Forms.Label();
            this.label_Duration = new System.Windows.Forms.Label();
            this.btn_Favorate = new System.Windows.Forms.Button();
            this.label_Album = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Repeate = new System.Windows.Forms.Button();
            this.btn_Shuffle = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_Playlist = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_Music = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView_Favorate = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label_SearchResult = new System.Windows.Forms.Label();
            this.listView_Search = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBox_Search = new System.Windows.Forms.TextBox();
            this.label_Hello = new System.Windows.Forms.Label();
            this.notifyIcon_Hide = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox_Config = new System.Windows.Forms.GroupBox();
            this.label_ConfigName = new System.Windows.Forms.Label();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_ConfigPass = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.groupBox_PlayerConfig = new System.Windows.Forms.GroupBox();
            this.checkBox_Shuffle = new System.Windows.Forms.CheckBox();
            this.radioButton_OneTime = new System.Windows.Forms.RadioButton();
            this.radioButton_Repeat = new System.Windows.Forms.RadioButton();
            this.radioButton_RepeatOne = new System.Windows.Forms.RadioButton();
            this.pBar_Media = new MusicPlayer.Control.SeekBar();
            this.trackBar1 = new MusicPlayer.Control.MediaTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_AlbumThumnail)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip_Music.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox_Config.SuspendLayout();
            this.groupBox_PlayerConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_MusicList
            // 
            this.listView_MusicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_MusicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_MusicList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_MusicList.FullRowSelect = true;
            this.listView_MusicList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_MusicList.HoverSelection = true;
            this.listView_MusicList.Location = new System.Drawing.Point(3, 3);
            this.listView_MusicList.Name = "listView_MusicList";
            this.listView_MusicList.OwnerDraw = true;
            this.listView_MusicList.Size = new System.Drawing.Size(568, 418);
            this.listView_MusicList.StateImageList = this.imagelist_Album;
            this.listView_MusicList.TabIndex = 0;
            this.listView_MusicList.UseCompatibleStateImageBehavior = false;
            this.listView_MusicList.View = System.Windows.Forms.View.Details;
            this.listView_MusicList.VirtualListSize = 1;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 20;
            // 
            // imagelist_Album
            // 
            this.imagelist_Album.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagelist_Album.ImageSize = new System.Drawing.Size(50, 50);
            this.imagelist_Album.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_PlayToggle
            // 
            this.btn_PlayToggle.BackColor = System.Drawing.Color.Transparent;
            this.btn_PlayToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlayToggle.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_PlayToggle.FlatAppearance.BorderSize = 0;
            this.btn_PlayToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_PlayToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_PlayToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlayToggle.Image = ((System.Drawing.Image)(resources.GetObject("btn_PlayToggle.Image")));
            this.btn_PlayToggle.Location = new System.Drawing.Point(110, 225);
            this.btn_PlayToggle.Name = "btn_PlayToggle";
            this.btn_PlayToggle.Size = new System.Drawing.Size(70, 70);
            this.btn_PlayToggle.TabIndex = 1;
            this.btn_PlayToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_PlayToggle.UseVisualStyleBackColor = false;
            this.btn_PlayToggle.Click += new System.EventHandler(this.btn_PlayToggle_Click);
            // 
            // backgroundWorker_UpdatepBar
            // 
            this.backgroundWorker_UpdatepBar.WorkerReportsProgress = true;
            // 
            // label_MusicName
            // 
            this.label_MusicName.AutoEllipsis = true;
            this.label_MusicName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MusicName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_MusicName.Location = new System.Drawing.Point(75, 50);
            this.label_MusicName.Name = "label_MusicName";
            this.label_MusicName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_MusicName.Size = new System.Drawing.Size(150, 15);
            this.label_MusicName.TabIndex = 6;
            this.label_MusicName.Text = "Music - Artist";
            this.label_MusicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PlayPrev
            // 
            this.btn_PlayPrev.BackColor = System.Drawing.Color.Transparent;
            this.btn_PlayPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlayPrev.FlatAppearance.BorderSize = 0;
            this.btn_PlayPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlayPrev.Image = ((System.Drawing.Image)(resources.GetObject("btn_PlayPrev.Image")));
            this.btn_PlayPrev.Location = new System.Drawing.Point(35, 225);
            this.btn_PlayPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btn_PlayPrev.Name = "btn_PlayPrev";
            this.btn_PlayPrev.Size = new System.Drawing.Size(70, 70);
            this.btn_PlayPrev.TabIndex = 7;
            this.btn_PlayPrev.UseVisualStyleBackColor = false;
            this.btn_PlayPrev.Click += new System.EventHandler(this.btn_PlayPrev_Click);
            // 
            // btn_PlayNext
            // 
            this.btn_PlayNext.BackColor = System.Drawing.Color.Transparent;
            this.btn_PlayNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_PlayNext.FlatAppearance.BorderSize = 0;
            this.btn_PlayNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlayNext.Image = ((System.Drawing.Image)(resources.GetObject("btn_PlayNext.Image")));
            this.btn_PlayNext.Location = new System.Drawing.Point(180, 225);
            this.btn_PlayNext.Margin = new System.Windows.Forms.Padding(0);
            this.btn_PlayNext.Name = "btn_PlayNext";
            this.btn_PlayNext.Size = new System.Drawing.Size(70, 70);
            this.btn_PlayNext.TabIndex = 8;
            this.btn_PlayNext.UseVisualStyleBackColor = false;
            this.btn_PlayNext.Click += new System.EventHandler(this.btn_PlayNext_Click);
            // 
            // picBox_AlbumThumnail
            // 
            this.picBox_AlbumThumnail.ErrorImage = null;
            this.picBox_AlbumThumnail.Image = ((System.Drawing.Image)(resources.GetObject("picBox_AlbumThumnail.Image")));
            this.picBox_AlbumThumnail.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBox_AlbumThumnail.InitialImage")));
            this.picBox_AlbumThumnail.Location = new System.Drawing.Point(0, 30);
            this.picBox_AlbumThumnail.Name = "picBox_AlbumThumnail";
            this.picBox_AlbumThumnail.Size = new System.Drawing.Size(300, 300);
            this.picBox_AlbumThumnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_AlbumThumnail.TabIndex = 9;
            this.picBox_AlbumThumnail.TabStop = false;
            // 
            // label_CurrentPos
            // 
            this.label_CurrentPos.AutoSize = true;
            this.label_CurrentPos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_CurrentPos.Location = new System.Drawing.Point(12, 355);
            this.label_CurrentPos.Name = "label_CurrentPos";
            this.label_CurrentPos.Size = new System.Drawing.Size(44, 15);
            this.label_CurrentPos.TabIndex = 10;
            this.label_CurrentPos.Text = "00:00";
            // 
            // label_Duration
            // 
            this.label_Duration.AutoSize = true;
            this.label_Duration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Duration.Location = new System.Drawing.Point(526, 355);
            this.label_Duration.Name = "label_Duration";
            this.label_Duration.Size = new System.Drawing.Size(44, 15);
            this.label_Duration.TabIndex = 11;
            this.label_Duration.Text = "00:00";
            // 
            // btn_Favorate
            // 
            this.btn_Favorate.BackColor = System.Drawing.Color.Transparent;
            this.btn_Favorate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Favorate.FlatAppearance.BorderSize = 0;
            this.btn_Favorate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Favorate.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Favorate.Image = ((System.Drawing.Image)(resources.GetObject("btn_Favorate.Image")));
            this.btn_Favorate.Location = new System.Drawing.Point(130, 150);
            this.btn_Favorate.Name = "btn_Favorate";
            this.btn_Favorate.Size = new System.Drawing.Size(35, 35);
            this.btn_Favorate.TabIndex = 12;
            this.btn_Favorate.UseVisualStyleBackColor = false;
            // 
            // label_Album
            // 
            this.label_Album.Location = new System.Drawing.Point(75, 80);
            this.label_Album.Name = "label_Album";
            this.label_Album.Size = new System.Drawing.Size(150, 15);
            this.label_Album.TabIndex = 13;
            this.label_Album.Text = "Album";
            this.label_Album.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Repeate);
            this.panel1.Controls.Add(this.btn_Shuffle);
            this.panel1.Controls.Add(this.label_MusicName);
            this.panel1.Controls.Add(this.btn_Favorate);
            this.panel1.Controls.Add(this.label_Album);
            this.panel1.Controls.Add(this.btn_PlayPrev);
            this.panel1.Controls.Add(this.btn_PlayToggle);
            this.panel1.Controls.Add(this.btn_PlayNext);
            this.panel1.Location = new System.Drawing.Point(297, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 300);
            this.panel1.TabIndex = 14;
            // 
            // btn_Repeate
            // 
            this.btn_Repeate.BackColor = System.Drawing.Color.Transparent;
            this.btn_Repeate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Repeate.FlatAppearance.BorderSize = 0;
            this.btn_Repeate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Repeate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Repeate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Repeate.Image = ((System.Drawing.Image)(resources.GetObject("btn_Repeate.Image")));
            this.btn_Repeate.Location = new System.Drawing.Point(225, 150);
            this.btn_Repeate.Name = "btn_Repeate";
            this.btn_Repeate.Size = new System.Drawing.Size(35, 35);
            this.btn_Repeate.TabIndex = 15;
            this.btn_Repeate.UseVisualStyleBackColor = false;
            // 
            // btn_Shuffle
            // 
            this.btn_Shuffle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Shuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Shuffle.FlatAppearance.BorderSize = 0;
            this.btn_Shuffle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Shuffle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Shuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Shuffle.Image = ((System.Drawing.Image)(resources.GetObject("btn_Shuffle.Image")));
            this.btn_Shuffle.Location = new System.Drawing.Point(25, 150);
            this.btn_Shuffle.Name = "btn_Shuffle";
            this.btn_Shuffle.Size = new System.Drawing.Size(35, 35);
            this.btn_Shuffle.TabIndex = 14;
            this.btn_Shuffle.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 36);
            this.tabControl1.Location = new System.Drawing.Point(0, 385);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(3, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 468);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 18;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.listView_MusicList);
            this.tabPage1.ForeColor = System.Drawing.Color.Transparent;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(574, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_Playlist);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_Playlist
            // 
            this.listView_Playlist.AllowDrop = true;
            this.listView_Playlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Playlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView_Playlist.ContextMenuStrip = this.contextMenuStrip_Music;
            this.listView_Playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Playlist.FullRowSelect = true;
            this.listView_Playlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Playlist.Location = new System.Drawing.Point(3, 3);
            this.listView_Playlist.Name = "listView_Playlist";
            this.listView_Playlist.OwnerDraw = true;
            this.listView_Playlist.Size = new System.Drawing.Size(568, 418);
            this.listView_Playlist.StateImageList = this.imagelist_Album;
            this.listView_Playlist.TabIndex = 1;
            this.listView_Playlist.UseCompatibleStateImageBehavior = false;
            this.listView_Playlist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 50;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 125;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Width = 125;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Width = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Width = 20;
            // 
            // contextMenuStrip_Music
            // 
            this.contextMenuStrip_Music.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Music.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Play,
            this.toolStripMenuItem_Delete});
            this.contextMenuStrip_Music.Name = "contextMenuStrip_Music";
            this.contextMenuStrip_Music.Size = new System.Drawing.Size(115, 56);
            // 
            // toolStripMenuItem_Play
            // 
            this.toolStripMenuItem_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_Play.Name = "toolStripMenuItem_Play";
            this.toolStripMenuItem_Play.Size = new System.Drawing.Size(114, 26);
            this.toolStripMenuItem_Play.Text = "듣기";
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(114, 26);
            this.toolStripMenuItem_Delete.Text = "삭제";
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(568, 418);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
            this.tabControl2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView_Favorate);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(574, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView_Favorate
            // 
            this.listView_Favorate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Favorate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView_Favorate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Favorate.FullRowSelect = true;
            this.listView_Favorate.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Favorate.Location = new System.Drawing.Point(0, 0);
            this.listView_Favorate.Name = "listView_Favorate";
            this.listView_Favorate.OwnerDraw = true;
            this.listView_Favorate.Size = new System.Drawing.Size(574, 424);
            this.listView_Favorate.StateImageList = this.imagelist_Album;
            this.listView_Favorate.TabIndex = 0;
            this.listView_Favorate.UseCompatibleStateImageBehavior = false;
            this.listView_Favorate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 20;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label_SearchResult);
            this.tabPage4.Controls.Add(this.listView_Search);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(574, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label_SearchResult
            // 
            this.label_SearchResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_SearchResult.Location = new System.Drawing.Point(0, 0);
            this.label_SearchResult.Name = "label_SearchResult";
            this.label_SearchResult.Size = new System.Drawing.Size(574, 25);
            this.label_SearchResult.TabIndex = 2;
            this.label_SearchResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView_Search
            // 
            this.listView_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.listView_Search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView_Search.FullRowSelect = true;
            this.listView_Search.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Search.HoverSelection = true;
            this.listView_Search.Location = new System.Drawing.Point(0, 28);
            this.listView_Search.Name = "listView_Search";
            this.listView_Search.OwnerDraw = true;
            this.listView_Search.Size = new System.Drawing.Size(574, 396);
            this.listView_Search.StateImageList = this.imagelist_Album;
            this.listView_Search.TabIndex = 1;
            this.listView_Search.UseCompatibleStateImageBehavior = false;
            this.listView_Search.View = System.Windows.Forms.View.Details;
            this.listView_Search.VirtualListSize = 1;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "";
            this.columnHeader16.Width = 50;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 125;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "";
            this.columnHeader18.Width = 125;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Width = 20;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox_PlayerConfig);
            this.tabPage5.Controls.Add(this.groupBox_Config);
            this.tabPage5.ImageIndex = 4;
            this.tabPage5.Location = new System.Drawing.Point(4, 40);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(574, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ic_audiotrack_black_18dp_2x.png");
            this.imageList1.Images.SetKeyName(1, "ic_queue_music_black_18dp_2x.png");
            this.imageList1.Images.SetKeyName(2, "ic_favorite_black_18dp_2x.png");
            this.imageList1.Images.SetKeyName(3, "ic_search_black_18dp_2x.png");
            this.imageList1.Images.SetKeyName(4, "ic_settings_black_18dp_2x.png");
            // 
            // txtBox_Search
            // 
            this.txtBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_Search.Location = new System.Drawing.Point(415, 3);
            this.txtBox_Search.Margin = new System.Windows.Forms.Padding(0);
            this.txtBox_Search.Name = "txtBox_Search";
            this.txtBox_Search.Size = new System.Drawing.Size(167, 25);
            this.txtBox_Search.TabIndex = 19;
            this.txtBox_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Hello
            // 
            this.label_Hello.Location = new System.Drawing.Point(4, 5);
            this.label_Hello.Name = "label_Hello";
            this.label_Hello.Size = new System.Drawing.Size(175, 23);
            this.label_Hello.TabIndex = 20;
            // 
            // notifyIcon_Hide
            // 
            this.notifyIcon_Hide.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Hide.Icon")));
            // 
            // groupBox_Config
            // 
            this.groupBox_Config.Controls.Add(this.label_Password);
            this.groupBox_Config.Controls.Add(this.label_ConfigPass);
            this.groupBox_Config.Controls.Add(this.label_Username);
            this.groupBox_Config.Controls.Add(this.label_ConfigName);
            this.groupBox_Config.Location = new System.Drawing.Point(4, 4);
            this.groupBox_Config.Name = "groupBox_Config";
            this.groupBox_Config.Size = new System.Drawing.Size(562, 141);
            this.groupBox_Config.TabIndex = 0;
            this.groupBox_Config.TabStop = false;
            this.groupBox_Config.Text = "회원정보";
            // 
            // label_ConfigName
            // 
            this.label_ConfigName.AutoSize = true;
            this.label_ConfigName.Location = new System.Drawing.Point(31, 70);
            this.label_ConfigName.Name = "label_ConfigName";
            this.label_ConfigName.Size = new System.Drawing.Size(72, 15);
            this.label_ConfigName.TabIndex = 0;
            this.label_ConfigName.Text = "Username";
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(126, 70);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(43, 15);
            this.label_Username.TabIndex = 1;
            this.label_Username.Text = "Name";
            // 
            // label_ConfigPass
            // 
            this.label_ConfigPass.AutoSize = true;
            this.label_ConfigPass.Location = new System.Drawing.Point(247, 70);
            this.label_ConfigPass.Name = "label_ConfigPass";
            this.label_ConfigPass.Size = new System.Drawing.Size(72, 15);
            this.label_ConfigPass.TabIndex = 2;
            this.label_ConfigPass.Text = "Password";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(349, 70);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(72, 15);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Password";
            // 
            // groupBox_PlayerConfig
            // 
            this.groupBox_PlayerConfig.Controls.Add(this.radioButton_RepeatOne);
            this.groupBox_PlayerConfig.Controls.Add(this.radioButton_Repeat);
            this.groupBox_PlayerConfig.Controls.Add(this.radioButton_OneTime);
            this.groupBox_PlayerConfig.Controls.Add(this.checkBox_Shuffle);
            this.groupBox_PlayerConfig.Location = new System.Drawing.Point(4, 151);
            this.groupBox_PlayerConfig.Name = "groupBox_PlayerConfig";
            this.groupBox_PlayerConfig.Size = new System.Drawing.Size(562, 273);
            this.groupBox_PlayerConfig.TabIndex = 1;
            this.groupBox_PlayerConfig.TabStop = false;
            this.groupBox_PlayerConfig.Text = "플레이어 설정";
            // 
            // checkBox_Shuffle
            // 
            this.checkBox_Shuffle.AutoSize = true;
            this.checkBox_Shuffle.Location = new System.Drawing.Point(35, 50);
            this.checkBox_Shuffle.Name = "checkBox_Shuffle";
            this.checkBox_Shuffle.Size = new System.Drawing.Size(94, 19);
            this.checkBox_Shuffle.TabIndex = 0;
            this.checkBox_Shuffle.Text = "랜덤 재생";
            this.checkBox_Shuffle.UseVisualStyleBackColor = true;
            // 
            // radioButton_OneTime
            // 
            this.radioButton_OneTime.AutoSize = true;
            this.radioButton_OneTime.Location = new System.Drawing.Point(35, 116);
            this.radioButton_OneTime.Name = "radioButton_OneTime";
            this.radioButton_OneTime.Size = new System.Drawing.Size(93, 19);
            this.radioButton_OneTime.TabIndex = 1;
            this.radioButton_OneTime.TabStop = true;
            this.radioButton_OneTime.Text = "순차 재생";
            this.radioButton_OneTime.UseVisualStyleBackColor = true;
            // 
            // radioButton_Repeat
            // 
            this.radioButton_Repeat.AutoSize = true;
            this.radioButton_Repeat.Location = new System.Drawing.Point(181, 116);
            this.radioButton_Repeat.Name = "radioButton_Repeat";
            this.radioButton_Repeat.Size = new System.Drawing.Size(93, 19);
            this.radioButton_Repeat.TabIndex = 2;
            this.radioButton_Repeat.TabStop = true;
            this.radioButton_Repeat.Text = "반복 재생";
            this.radioButton_Repeat.UseVisualStyleBackColor = true;
            // 
            // radioButton_RepeatOne
            // 
            this.radioButton_RepeatOne.AutoSize = true;
            this.radioButton_RepeatOne.Location = new System.Drawing.Point(314, 116);
            this.radioButton_RepeatOne.Name = "radioButton_RepeatOne";
            this.radioButton_RepeatOne.Size = new System.Drawing.Size(93, 19);
            this.radioButton_RepeatOne.TabIndex = 3;
            this.radioButton_RepeatOne.TabStop = true;
            this.radioButton_RepeatOne.Text = "한곡 재생";
            this.radioButton_RepeatOne.UseVisualStyleBackColor = true;
            // 
            // pBar_Media
            // 
            this.pBar_Media.BackColor = System.Drawing.Color.White;
            this.pBar_Media.ForeColor = System.Drawing.Color.Transparent;
            this.pBar_Media.Location = new System.Drawing.Point(0, 330);
            this.pBar_Media.Name = "pBar_Media";
            this.pBar_Media.Size = new System.Drawing.Size(582, 10);
            this.pBar_Media.Step = 20;
            this.pBar_Media.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar_Media.TabIndex = 15;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(0, 355);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(583, 56);
            this.trackBar1.TabIndex = 16;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 853);
            this.Controls.Add(this.label_Hello);
            this.Controls.Add(this.txtBox_Search);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pBar_Media);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_Duration);
            this.Controls.Add(this.label_CurrentPos);
            this.Controls.Add(this.picBox_AlbumThumnail);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "PlayerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerForm";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_AlbumThumnail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip_Music.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox_Config.ResumeLayout(false);
            this.groupBox_Config.PerformLayout();
            this.groupBox_PlayerConfig.ResumeLayout(false);
            this.groupBox_PlayerConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_MusicList;
        public System.ComponentModel.BackgroundWorker backgroundWorker_UpdatepBar;
        public System.Windows.Forms.Label label_MusicName;
        private System.Windows.Forms.Button btn_PlayPrev;
        private System.Windows.Forms.Button btn_PlayNext;
        public System.Windows.Forms.PictureBox picBox_AlbumThumnail;
        public System.Windows.Forms.Label label_CurrentPos;
        public System.Windows.Forms.Label label_Duration;
        private System.Windows.Forms.Button btn_Favorate;
        public System.Windows.Forms.Label label_Album;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imagelist_Album;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public Control.SeekBar pBar_Media;
        private System.Windows.Forms.Button btn_Repeate;
        private System.Windows.Forms.Button btn_Shuffle;
        public System.Windows.Forms.Button btn_PlayToggle;
        public Control.MediaTrackBar trackBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView_Favorate;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ListView listView_Playlist;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.TextBox txtBox_Search;
        private System.Windows.Forms.Label label_Hello;
        private System.Windows.Forms.ListView listView_Search;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Label label_SearchResult;
        private System.Windows.Forms.NotifyIcon notifyIcon_Hide;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Music;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Play;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.GroupBox groupBox_PlayerConfig;
        private System.Windows.Forms.RadioButton radioButton_RepeatOne;
        private System.Windows.Forms.RadioButton radioButton_Repeat;
        private System.Windows.Forms.RadioButton radioButton_OneTime;
        private System.Windows.Forms.CheckBox checkBox_Shuffle;
        private System.Windows.Forms.GroupBox groupBox_Config;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_ConfigPass;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_ConfigName;
    }
}