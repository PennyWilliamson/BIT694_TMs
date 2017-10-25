namespace BIT694_TM2_3431274
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.SelectFolder = new System.Windows.Forms.TextBox();
            this.SelectBut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchTerms = new System.Windows.Forms.TextBox();
            this.IncludeSynonyms = new System.Windows.Forms.CheckBox();
            this.Searchbut = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.newWordsFullDataSet = new BIT694_TM2_3431274.NewWordsFullDataSet();
            this.wordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wordsTableAdapter = new BIT694_TM2_3431274.NewWordsFullDataSetTableAdapters.WordsTableAdapter();
            this.tableAdapterManager = new BIT694_TM2_3431274.NewWordsFullDataSetTableAdapters.TableAdapterManager();
            this.wordsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wordsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.wordsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddEntryBut = new System.Windows.Forms.Button();
            this.AddSynonym = new System.Windows.Forms.TextBox();
            this.AddWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteWord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeleteWordBut = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UpdateWord = new System.Windows.Forms.TextBox();
            this.UpdateSynonym = new System.Windows.Forms.TextBox();
            this.UpdateEntryBut = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.QueryWord = new System.Windows.Forms.TextBox();
            this.QuerySynonym = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.QueryEntryBut = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FliesFound = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.QueryTermFreq = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Found = new System.Windows.Forms.Label();
            this.commonWord = new System.Windows.Forms.TextBox();
            this.FilePathOutput = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AverageTime = new System.Windows.Forms.Label();
            this.SearchTime = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.newWordsFullDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingNavigator)).BeginInit();
            this.wordsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a folder:";
            // 
            // SelectFolder
            // 
            this.SelectFolder.Location = new System.Drawing.Point(67, 200);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(294, 22);
            this.SelectFolder.TabIndex = 1;

            // 
            // SelectBut
            // 
            this.SelectBut.Location = new System.Drawing.Point(380, 199);
            this.SelectBut.Name = "SelectBut";
            this.SelectBut.Size = new System.Drawing.Size(75, 23);
            this.SelectBut.TabIndex = 2;
            this.SelectBut.Text = "Select";
            this.SelectBut.UseVisualStyleBackColor = true;
            this.SelectBut.Click += new System.EventHandler(this.SelectBut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search terms:";
            // 
            // SearchTerms
            // 
            this.SearchTerms.Location = new System.Drawing.Point(156, 232);
            this.SearchTerms.Name = "SearchTerms";
            this.SearchTerms.Size = new System.Drawing.Size(157, 22);
            this.SearchTerms.TabIndex = 4;
            // 
            // IncludeSynonyms
            // 
            this.IncludeSynonyms.AutoSize = true;
            this.IncludeSynonyms.Checked = true;
            this.IncludeSynonyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeSynonyms.Location = new System.Drawing.Point(333, 233);
            this.IncludeSynonyms.Name = "IncludeSynonyms";
            this.IncludeSynonyms.Size = new System.Drawing.Size(142, 21);
            this.IncludeSynonyms.TabIndex = 5;
            this.IncludeSynonyms.Text = "Include synonyms";
            this.IncludeSynonyms.UseVisualStyleBackColor = true;
            // 
            // Searchbut
            // 
            this.Searchbut.Location = new System.Drawing.Point(67, 270);
            this.Searchbut.Name = "Searchbut";
            this.Searchbut.Size = new System.Drawing.Size(408, 23);
            this.Searchbut.TabIndex = 6;
            this.Searchbut.Text = "Search";
            this.Searchbut.UseVisualStyleBackColor = true;
            this.Searchbut.Click += new System.EventHandler(this.Searchbut_Click);
            // 
            // newWordsFullDataSet
            // 
            this.newWordsFullDataSet.DataSetName = "NewWordsDataSet";
            this.newWordsFullDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordsBindingSource
            // 
            this.wordsBindingSource.DataMember = "Words";
            this.wordsBindingSource.DataSource = this.newWordsFullDataSet;
            // 
            // wordsTableAdapter
            // 
            this.wordsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = BIT694_TM2_3431274.NewWordsFullDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WordsTableAdapter = this.wordsTableAdapter;
            // 
            // wordsBindingNavigator
            // 
            this.wordsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wordsBindingNavigator.BindingSource = this.wordsBindingSource;
            this.wordsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wordsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.wordsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wordsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.wordsBindingNavigatorSaveItem});
            this.wordsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.wordsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wordsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wordsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wordsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wordsBindingNavigator.Name = "wordsBindingNavigator";
            this.wordsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wordsBindingNavigator.Size = new System.Drawing.Size(937, 27);
            this.wordsBindingNavigator.TabIndex = 8;
            this.wordsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // wordsBindingNavigatorSaveItem
            // 
            this.wordsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wordsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wordsBindingNavigatorSaveItem.Image")));
            this.wordsBindingNavigatorSaveItem.Name = "wordsBindingNavigatorSaveItem";
            this.wordsBindingNavigatorSaveItem.Size = new System.Drawing.Size(24, 24);
            this.wordsBindingNavigatorSaveItem.Text = "Save Data";
            this.wordsBindingNavigatorSaveItem.Click += new System.EventHandler(this.wordsBindingNavigatorSaveItem_Click);
            // 
            // wordsDataGridView
            // 
            this.wordsDataGridView.AutoGenerateColumns = false;
            this.wordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.wordsDataGridView.DataSource = this.wordsBindingSource;
            this.wordsDataGridView.Location = new System.Drawing.Point(67, 30);
            this.wordsDataGridView.Name = "wordsDataGridView";
            this.wordsDataGridView.RowTemplate.Height = 24;
            this.wordsDataGridView.ShowCellToolTips = false;
            this.wordsDataGridView.Size = new System.Drawing.Size(388, 120);
            this.wordsDataGridView.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn1.HeaderText = "Word";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Synonyms";
            this.dataGridViewTextBoxColumn2.HeaderText = "Synonyms";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // AddEntryBut
            // 
            this.AddEntryBut.Location = new System.Drawing.Point(9, 88);
            this.AddEntryBut.Name = "AddEntryBut";
            this.AddEntryBut.Size = new System.Drawing.Size(211, 32);
            this.AddEntryBut.TabIndex = 10;
            this.AddEntryBut.Text = "Add Entry";
            this.AddEntryBut.UseVisualStyleBackColor = true;
            this.AddEntryBut.Click += new System.EventHandler(this.AddEntryBut_Click);
            // 
            // AddSynonym
            // 
            this.AddSynonym.Location = new System.Drawing.Point(89, 58);
            this.AddSynonym.Name = "AddSynonym";
            this.AddSynonym.Size = new System.Drawing.Size(113, 22);
            this.AddSynonym.TabIndex = 11;
            // 
            // AddWord
            // 
            this.AddWord.Location = new System.Drawing.Point(89, 24);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(113, 22);
            this.AddWord.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Word:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Synonyms:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AddWord);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AddEntryBut);
            this.groupBox1.Controls.Add(this.AddSynonym);
            this.groupBox1.Location = new System.Drawing.Point(665, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 126);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Entry:";
            // 
            // DeleteWord
            // 
            this.DeleteWord.Location = new System.Drawing.Point(81, 28);
            this.DeleteWord.Name = "DeleteWord";
            this.DeleteWord.Size = new System.Drawing.Size(121, 22);
            this.DeleteWord.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Word:";
            // 
            // DeleteWordBut
            // 
            this.DeleteWordBut.Location = new System.Drawing.Point(6, 64);
            this.DeleteWordBut.Name = "DeleteWordBut";
            this.DeleteWordBut.Size = new System.Drawing.Size(211, 30);
            this.DeleteWordBut.TabIndex = 18;
            this.DeleteWordBut.Text = "Delete Entry";
            this.DeleteWordBut.UseVisualStyleBackColor = true;
            this.DeleteWordBut.Click += new System.EventHandler(this.DeleteWordBut_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteWordBut);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DeleteWord);
            this.groupBox2.Location = new System.Drawing.Point(665, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Entry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Word:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(683, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Synonyms:";
            // 
            // UpdateWord
            // 
            this.UpdateWord.Location = new System.Drawing.Point(767, 289);
            this.UpdateWord.Name = "UpdateWord";
            this.UpdateWord.Size = new System.Drawing.Size(100, 22);
            this.UpdateWord.TabIndex = 22;
            // 
            // UpdateSynonym
            // 
            this.UpdateSynonym.Location = new System.Drawing.Point(767, 325);
            this.UpdateSynonym.Name = "UpdateSynonym";
            this.UpdateSynonym.Size = new System.Drawing.Size(100, 22);
            this.UpdateSynonym.TabIndex = 23;
            // 
            // UpdateEntryBut
            // 
            this.UpdateEntryBut.Location = new System.Drawing.Point(674, 354);
            this.UpdateEntryBut.Name = "UpdateEntryBut";
            this.UpdateEntryBut.Size = new System.Drawing.Size(208, 26);
            this.UpdateEntryBut.TabIndex = 24;
            this.UpdateEntryBut.Text = "Update Entry";
            this.UpdateEntryBut.UseVisualStyleBackColor = true;
            this.UpdateEntryBut.Click += new System.EventHandler(this.UpdateEntryBut_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(667, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 116);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Entry";
            // 
            // QueryWord
            // 
            this.QueryWord.Location = new System.Drawing.Point(767, 416);
            this.QueryWord.Name = "QueryWord";
            this.QueryWord.Size = new System.Drawing.Size(100, 22);
            this.QueryWord.TabIndex = 26;
            // 
            // QuerySynonym
            // 
            this.QuerySynonym.Location = new System.Drawing.Point(99, 62);
            this.QuerySynonym.Multiline = true;
            this.QuerySynonym.Name = "QuerySynonym";
            this.QuerySynonym.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QuerySynonym.Size = new System.Drawing.Size(101, 83);
            this.QuerySynonym.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(683, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Word:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(683, 454);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Synonyms:";
            // 
            // QueryEntryBut
            // 
            this.QueryEntryBut.Location = new System.Drawing.Point(4, 161);
            this.QueryEntryBut.Name = "QueryEntryBut";
            this.QueryEntryBut.Size = new System.Drawing.Size(211, 34);
            this.QueryEntryBut.TabIndex = 30;
            this.QueryEntryBut.Text = "Query Entry";
            this.QueryEntryBut.UseVisualStyleBackColor = true;
            this.QueryEntryBut.Click += new System.EventHandler(this.QueryEntryBut_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.QueryEntryBut);
            this.groupBox4.Controls.Add(this.QuerySynonym);
            this.groupBox4.Location = new System.Drawing.Point(667, 392);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 201);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Query Entry";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 497);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Files found: ";
            // 
            // FliesFound
            // 
            this.FliesFound.AutoSize = true;
            this.FliesFound.Location = new System.Drawing.Point(411, 497);
            this.FliesFound.Name = "FliesFound";
            this.FliesFound.Size = new System.Drawing.Size(0, 17);
            this.FliesFound.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 533);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Query Term frequency:";
            // 
            // QueryTermFreq
            // 
            this.QueryTermFreq.Location = new System.Drawing.Point(471, 530);
            this.QueryTermFreq.Multiline = true;
            this.QueryTermFreq.Name = "QueryTermFreq";
            this.QueryTermFreq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTermFreq.Size = new System.Drawing.Size(180, 72);
            this.QueryTermFreq.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 533);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Most common word:";
            // 
            // Found
            // 
            this.Found.AutoSize = true;
            this.Found.Location = new System.Drawing.Point(444, 497);
            this.Found.Name = "Found";
            this.Found.Size = new System.Drawing.Size(0, 17);
            this.Found.TabIndex = 38;
            // 
            // commonWord
            // 
            this.commonWord.Location = new System.Drawing.Point(134, 533);
            this.commonWord.Multiline = true;
            this.commonWord.Name = "commonWord";
            this.commonWord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commonWord.Size = new System.Drawing.Size(179, 54);
            this.commonWord.TabIndex = 39;
            // 
            // FilePathOutput
            // 
            this.FilePathOutput.FormattingEnabled = true;
            this.FilePathOutput.ItemHeight = 16;
            this.FilePathOutput.Location = new System.Drawing.Point(67, 307);
            this.FilePathOutput.Name = "FilePathOutput";
            this.FilePathOutput.ScrollAlwaysVisible = true;
            this.FilePathOutput.Size = new System.Drawing.Size(408, 180);
            this.FilePathOutput.TabIndex = 42;
            this.FilePathOutput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilePathOutput_MouseDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 497);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 17);
            this.label13.TabIndex = 43;
            this.label13.Text = "Average Time: ";
            // 
            // AverageTime
            // 
            this.AverageTime.AutoSize = true;
            this.AverageTime.Location = new System.Drawing.Point(110, 497);
            this.AverageTime.MinimumSize = new System.Drawing.Size(60, 10);
            this.AverageTime.Name = "AverageTime";
            this.AverageTime.Size = new System.Drawing.Size(60, 17);
            this.AverageTime.TabIndex = 44;
            // 
            // SearchTime
            // 
            this.SearchTime.AutoSize = true;
            this.SearchTime.Location = new System.Drawing.Point(274, 497);
            this.SearchTime.MinimumSize = new System.Drawing.Size(60, 10);
            this.SearchTime.Name = "SearchTime";
            this.SearchTime.Size = new System.Drawing.Size(60, 17);
            this.SearchTime.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(176, 497);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 46;
            this.label16.Text = " Search Time: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 606);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.SearchTime);
            this.Controls.Add(this.AverageTime);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.FilePathOutput);
            this.Controls.Add(this.commonWord);
            this.Controls.Add(this.Found);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.QueryTermFreq);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FliesFound);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.QueryWord);
            this.Controls.Add(this.UpdateEntryBut);
            this.Controls.Add(this.UpdateSynonym);
            this.Controls.Add(this.UpdateWord);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.wordsDataGridView);
            this.Controls.Add(this.wordsBindingNavigator);
            this.Controls.Add(this.Searchbut);
            this.Controls.Add(this.IncludeSynonyms);
            this.Controls.Add(this.SearchTerms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectBut);
            this.Controls.Add(this.SelectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Add Entry";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newWordsFullDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingNavigator)).EndInit();
            this.wordsBindingNavigator.ResumeLayout(false);
            this.wordsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SelectFolder;
        private System.Windows.Forms.Button SelectBut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchTerms;
        private System.Windows.Forms.CheckBox IncludeSynonyms;
        private System.Windows.Forms.Button Searchbut;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private NewWordsFullDataSet newWordsFullDataSet;
        private System.Windows.Forms.BindingSource wordsBindingSource;
        private NewWordsFullDataSetTableAdapters.WordsTableAdapter wordsTableAdapter;
        private NewWordsFullDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator wordsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton wordsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView wordsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button AddEntryBut;
        private System.Windows.Forms.TextBox AddSynonym;
        private System.Windows.Forms.TextBox AddWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DeleteWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeleteWordBut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UpdateWord;
        private System.Windows.Forms.TextBox UpdateSynonym;
        private System.Windows.Forms.Button UpdateEntryBut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox QueryWord;
        private System.Windows.Forms.TextBox QuerySynonym;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button QueryEntryBut;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label FliesFound;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox QueryTermFreq;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Found;
        private System.Windows.Forms.TextBox commonWord;
        private System.Windows.Forms.ListBox FilePathOutput;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label AverageTime;
        private System.Windows.Forms.Label SearchTime;
        private System.Windows.Forms.Label label16;
    }
}

