namespace S7ServerDemo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label1;
            this.gboxBlockReadWrite = new System.Windows.Forms.GroupBox();
            this.BtnUpdateMonitor = new System.Windows.Forms.Button();
            this.BtnUpdateData = new System.Windows.Forms.Button();
            this.BtnDelMonitor = new System.Windows.Forms.Button();
            this.BtnAddMonitor = new System.Windows.Forms.Button();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.cboxDataType = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtStringLength = new System.Windows.Forms.TextBox();
            this.txtOffsetBit = new System.Windows.Forms.TextBox();
            this.txtOffsetByte = new System.Windows.Forms.TextBox();
            this.gboxBlockAdd = new System.Windows.Forms.GroupBox();
            this.BtnBlockDel = new System.Windows.Forms.Button();
            this.BtnBlockAdd = new System.Windows.Forms.Button();
            this.cboxBlockType = new System.Windows.Forms.ComboBox();
            this.txtBlockSize = new System.Windows.Forms.TextBox();
            this.txtBlockIndex = new System.Windows.Forms.TextBox();
            this.BtnStopServer = new System.Windows.Forms.Button();
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.txtNetworkHost = new System.Windows.Forms.TextBox();
            this.tabDisplay = new System.Windows.Forms.TabControl();
            this.lvMonitor = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.UpdateLogTimer = new System.Windows.Forms.Timer(this.components);
            panel1 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            this.gboxBlockReadWrite.SuspendLayout();
            this.gboxBlockAdd.SuspendLayout();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(this.gboxBlockReadWrite);
            panel1.Controls.Add(this.gboxBlockAdd);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(5, 5);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(3);
            panel1.Size = new System.Drawing.Size(246, 521);
            panel1.TabIndex = 0;
            // 
            // gboxBlockReadWrite
            // 
            this.gboxBlockReadWrite.Controls.Add(this.BtnUpdateMonitor);
            this.gboxBlockReadWrite.Controls.Add(this.BtnUpdateData);
            this.gboxBlockReadWrite.Controls.Add(this.BtnDelMonitor);
            this.gboxBlockReadWrite.Controls.Add(this.BtnAddMonitor);
            this.gboxBlockReadWrite.Controls.Add(this.BtnWrite);
            this.gboxBlockReadWrite.Controls.Add(this.BtnRead);
            this.gboxBlockReadWrite.Controls.Add(this.cboxDataType);
            this.gboxBlockReadWrite.Controls.Add(this.txtValue);
            this.gboxBlockReadWrite.Controls.Add(label7);
            this.gboxBlockReadWrite.Controls.Add(this.txtStringLength);
            this.gboxBlockReadWrite.Controls.Add(label9);
            this.gboxBlockReadWrite.Controls.Add(this.txtOffsetBit);
            this.gboxBlockReadWrite.Controls.Add(label6);
            this.gboxBlockReadWrite.Controls.Add(label8);
            this.gboxBlockReadWrite.Controls.Add(this.txtOffsetByte);
            this.gboxBlockReadWrite.Controls.Add(label5);
            this.gboxBlockReadWrite.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxBlockReadWrite.Enabled = false;
            this.gboxBlockReadWrite.Location = new System.Drawing.Point(3, 223);
            this.gboxBlockReadWrite.Name = "gboxBlockReadWrite";
            this.gboxBlockReadWrite.Size = new System.Drawing.Size(238, 290);
            this.gboxBlockReadWrite.TabIndex = 2;
            this.gboxBlockReadWrite.TabStop = false;
            this.gboxBlockReadWrite.Text = "块读写";
            // 
            // BtnUpdateMonitor
            // 
            this.BtnUpdateMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateMonitor.Location = new System.Drawing.Point(127, 259);
            this.BtnUpdateMonitor.Name = "BtnUpdateMonitor";
            this.BtnUpdateMonitor.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdateMonitor.TabIndex = 5;
            this.BtnUpdateMonitor.Text = "更新监视";
            this.BtnUpdateMonitor.UseVisualStyleBackColor = true;
            this.BtnUpdateMonitor.Click += new System.EventHandler(this.BtnUpdateMonitor_Click);
            // 
            // BtnUpdateData
            // 
            this.BtnUpdateData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateData.Location = new System.Drawing.Point(29, 259);
            this.BtnUpdateData.Name = "BtnUpdateData";
            this.BtnUpdateData.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdateData.TabIndex = 6;
            this.BtnUpdateData.Text = "更新数据";
            this.BtnUpdateData.UseVisualStyleBackColor = true;
            this.BtnUpdateData.Click += new System.EventHandler(this.BtnUpdateData_Click);
            // 
            // BtnDelMonitor
            // 
            this.BtnDelMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelMonitor.Location = new System.Drawing.Point(127, 230);
            this.BtnDelMonitor.Name = "BtnDelMonitor";
            this.BtnDelMonitor.Size = new System.Drawing.Size(75, 23);
            this.BtnDelMonitor.TabIndex = 3;
            this.BtnDelMonitor.Text = "删除监视";
            this.BtnDelMonitor.UseVisualStyleBackColor = true;
            this.BtnDelMonitor.Click += new System.EventHandler(this.BtnDelMonitor_Click);
            // 
            // BtnAddMonitor
            // 
            this.BtnAddMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMonitor.Location = new System.Drawing.Point(29, 230);
            this.BtnAddMonitor.Name = "BtnAddMonitor";
            this.BtnAddMonitor.Size = new System.Drawing.Size(75, 23);
            this.BtnAddMonitor.TabIndex = 4;
            this.BtnAddMonitor.Text = "增加监视";
            this.BtnAddMonitor.UseVisualStyleBackColor = true;
            this.BtnAddMonitor.Click += new System.EventHandler(this.BtnAddMonitor_Click);
            // 
            // BtnWrite
            // 
            this.BtnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnWrite.Location = new System.Drawing.Point(127, 201);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(75, 23);
            this.BtnWrite.TabIndex = 2;
            this.BtnWrite.Text = "写";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRead.Location = new System.Drawing.Point(29, 201);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(75, 23);
            this.BtnRead.TabIndex = 2;
            this.BtnRead.Text = "读";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // cboxDataType
            // 
            this.cboxDataType.BackColor = System.Drawing.SystemColors.Control;
            this.cboxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDataType.FormattingEnabled = true;
            this.cboxDataType.Location = new System.Drawing.Point(99, 46);
            this.cboxDataType.Name = "cboxDataType";
            this.cboxDataType.Size = new System.Drawing.Size(125, 20);
            this.cboxDataType.TabIndex = 1;
            this.cboxDataType.SelectedIndexChanged += new System.EventHandler(this.cboxDataType_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValue.Location = new System.Drawing.Point(99, 124);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(125, 67);
            this.txtValue.TabIndex = 1;
            // 
            // label7
            // 
            label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label7.Location = new System.Drawing.Point(15, 124);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(75, 21);
            label7.TabIndex = 0;
            label7.Text = "值:";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStringLength
            // 
            this.txtStringLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStringLength.Enabled = false;
            this.txtStringLength.Location = new System.Drawing.Point(99, 98);
            this.txtStringLength.Name = "txtStringLength";
            this.txtStringLength.Size = new System.Drawing.Size(125, 21);
            this.txtStringLength.TabIndex = 1;
            this.txtStringLength.Text = "1";
            // 
            // label9
            // 
            label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label9.Location = new System.Drawing.Point(15, 98);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(75, 21);
            label9.TabIndex = 0;
            label9.Text = "字符串长度:";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOffsetBit
            // 
            this.txtOffsetBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOffsetBit.Enabled = false;
            this.txtOffsetBit.Location = new System.Drawing.Point(99, 72);
            this.txtOffsetBit.Name = "txtOffsetBit";
            this.txtOffsetBit.Size = new System.Drawing.Size(125, 21);
            this.txtOffsetBit.TabIndex = 1;
            this.txtOffsetBit.Text = "0";
            // 
            // label6
            // 
            label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label6.Location = new System.Drawing.Point(15, 72);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(75, 21);
            label6.TabIndex = 0;
            label6.Text = "位偏移量:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label8.Location = new System.Drawing.Point(15, 46);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(75, 21);
            label8.TabIndex = 0;
            label8.Text = "数据类型:";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOffsetByte
            // 
            this.txtOffsetByte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOffsetByte.Location = new System.Drawing.Point(99, 20);
            this.txtOffsetByte.Name = "txtOffsetByte";
            this.txtOffsetByte.Size = new System.Drawing.Size(125, 21);
            this.txtOffsetByte.TabIndex = 1;
            this.txtOffsetByte.Text = "0";
            // 
            // label5
            // 
            label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label5.Location = new System.Drawing.Point(15, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 21);
            label5.TabIndex = 0;
            label5.Text = "字节偏移量:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxBlockAdd
            // 
            this.gboxBlockAdd.Controls.Add(this.BtnBlockDel);
            this.gboxBlockAdd.Controls.Add(this.BtnBlockAdd);
            this.gboxBlockAdd.Controls.Add(this.cboxBlockType);
            this.gboxBlockAdd.Controls.Add(label4);
            this.gboxBlockAdd.Controls.Add(label3);
            this.gboxBlockAdd.Controls.Add(this.txtBlockSize);
            this.gboxBlockAdd.Controls.Add(this.txtBlockIndex);
            this.gboxBlockAdd.Controls.Add(label2);
            this.gboxBlockAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxBlockAdd.Enabled = false;
            this.gboxBlockAdd.Location = new System.Drawing.Point(3, 87);
            this.gboxBlockAdd.Name = "gboxBlockAdd";
            this.gboxBlockAdd.Size = new System.Drawing.Size(238, 136);
            this.gboxBlockAdd.TabIndex = 1;
            this.gboxBlockAdd.TabStop = false;
            this.gboxBlockAdd.Text = "增加共享块";
            // 
            // BtnBlockDel
            // 
            this.BtnBlockDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBlockDel.Location = new System.Drawing.Point(127, 103);
            this.BtnBlockDel.Name = "BtnBlockDel";
            this.BtnBlockDel.Size = new System.Drawing.Size(75, 23);
            this.BtnBlockDel.TabIndex = 2;
            this.BtnBlockDel.Text = "删除";
            this.BtnBlockDel.UseVisualStyleBackColor = true;
            this.BtnBlockDel.Click += new System.EventHandler(this.BtnBlockDel_Click);
            // 
            // BtnBlockAdd
            // 
            this.BtnBlockAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBlockAdd.Location = new System.Drawing.Point(29, 103);
            this.BtnBlockAdd.Name = "BtnBlockAdd";
            this.BtnBlockAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnBlockAdd.TabIndex = 2;
            this.BtnBlockAdd.Text = "增加";
            this.BtnBlockAdd.UseVisualStyleBackColor = true;
            this.BtnBlockAdd.Click += new System.EventHandler(this.BtnBlockAdd_Click);
            // 
            // cboxBlockType
            // 
            this.cboxBlockType.BackColor = System.Drawing.SystemColors.Control;
            this.cboxBlockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBlockType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxBlockType.FormattingEnabled = true;
            this.cboxBlockType.Location = new System.Drawing.Point(99, 20);
            this.cboxBlockType.Name = "cboxBlockType";
            this.cboxBlockType.Size = new System.Drawing.Size(125, 20);
            this.cboxBlockType.TabIndex = 1;
            this.cboxBlockType.SelectedIndexChanged += new System.EventHandler(this.cboxBlockType_SelectedIndexChanged);
            // 
            // label4
            // 
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Location = new System.Drawing.Point(15, 72);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 21);
            label4.TabIndex = 0;
            label4.Text = "块大小:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label3.Location = new System.Drawing.Point(15, 46);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 21);
            label3.TabIndex = 0;
            label3.Text = "块索引:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBlockSize
            // 
            this.txtBlockSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBlockSize.Location = new System.Drawing.Point(99, 72);
            this.txtBlockSize.Name = "txtBlockSize";
            this.txtBlockSize.Size = new System.Drawing.Size(125, 21);
            this.txtBlockSize.TabIndex = 1;
            this.txtBlockSize.Text = "512";
            // 
            // txtBlockIndex
            // 
            this.txtBlockIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBlockIndex.Enabled = false;
            this.txtBlockIndex.Location = new System.Drawing.Point(99, 46);
            this.txtBlockIndex.Name = "txtBlockIndex";
            this.txtBlockIndex.Size = new System.Drawing.Size(125, 21);
            this.txtBlockIndex.TabIndex = 1;
            this.txtBlockIndex.Text = "0";
            // 
            // label2
            // 
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Location = new System.Drawing.Point(15, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 21);
            label2.TabIndex = 0;
            label2.Text = "块类型:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.BtnStopServer);
            groupBox1.Controls.Add(this.BtnStartServer);
            groupBox1.Controls.Add(this.txtNetworkHost);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(238, 84);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务器参数";
            // 
            // BtnStopServer
            // 
            this.BtnStopServer.Enabled = false;
            this.BtnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStopServer.Location = new System.Drawing.Point(127, 51);
            this.BtnStopServer.Name = "BtnStopServer";
            this.BtnStopServer.Size = new System.Drawing.Size(75, 23);
            this.BtnStopServer.TabIndex = 2;
            this.BtnStopServer.Text = "停止";
            this.BtnStopServer.UseVisualStyleBackColor = true;
            this.BtnStopServer.Click += new System.EventHandler(this.BtnStopServer_Click);
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartServer.Location = new System.Drawing.Point(29, 51);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(75, 23);
            this.BtnStartServer.TabIndex = 2;
            this.BtnStartServer.Text = "启动";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // txtNetworkHost
            // 
            this.txtNetworkHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetworkHost.Location = new System.Drawing.Point(99, 20);
            this.txtNetworkHost.Name = "txtNetworkHost";
            this.txtNetworkHost.Size = new System.Drawing.Size(125, 21);
            this.txtNetworkHost.TabIndex = 1;
            this.txtNetworkHost.Text = "0.0.0.0";
            // 
            // label1
            // 
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Location = new System.Drawing.Point(15, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 21);
            label1.TabIndex = 0;
            label1.Text = "地址:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDisplay.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabDisplay.Location = new System.Drawing.Point(251, 5);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.SelectedIndex = 0;
            this.tabDisplay.Size = new System.Drawing.Size(619, 521);
            this.tabDisplay.TabIndex = 1;
            // 
            // lvMonitor
            // 
            this.lvMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colType,
            this.colValue});
            this.lvMonitor.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvMonitor.FullRowSelect = true;
            this.lvMonitor.GridLines = true;
            this.lvMonitor.HideSelection = false;
            this.lvMonitor.LabelWrap = false;
            this.lvMonitor.Location = new System.Drawing.Point(873, 5);
            this.lvMonitor.MultiSelect = false;
            this.lvMonitor.Name = "lvMonitor";
            this.lvMonitor.Size = new System.Drawing.Size(213, 521);
            this.lvMonitor.TabIndex = 2;
            this.lvMonitor.UseCompatibleStateImageBehavior = false;
            this.lvMonitor.View = System.Windows.Forms.View.Details;
            // 
            // colAddress
            // 
            this.colAddress.Text = "地址";
            this.colAddress.Width = 70;
            // 
            // colType
            // 
            this.colType.Text = "类型";
            this.colType.Width = 69;
            // 
            // colValue
            // 
            this.colValue.Text = "值";
            this.colValue.Width = 106;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(870, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 521);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // UpdateLogTimer
            // 
            this.UpdateLogTimer.Enabled = true;
            this.UpdateLogTimer.Interval = 500;
            this.UpdateLogTimer.Tick += new System.EventHandler(this.UpdateLogTimer_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 531);
            this.Controls.Add(this.tabDisplay);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lvMonitor);
            this.Controls.Add(panel1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "S7 Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            panel1.ResumeLayout(false);
            this.gboxBlockReadWrite.ResumeLayout(false);
            this.gboxBlockReadWrite.PerformLayout();
            this.gboxBlockAdd.ResumeLayout(false);
            this.gboxBlockAdd.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxBlockReadWrite;
        private System.Windows.Forms.ComboBox cboxDataType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtOffsetBit;
        private System.Windows.Forms.TextBox txtOffsetByte;
        private System.Windows.Forms.GroupBox gboxBlockAdd;
        private System.Windows.Forms.ComboBox cboxBlockType;
        private System.Windows.Forms.TextBox txtBlockSize;
        private System.Windows.Forms.TextBox txtBlockIndex;
        private System.Windows.Forms.Button BtnStopServer;
        private System.Windows.Forms.Button BtnStartServer;
        private System.Windows.Forms.TextBox txtNetworkHost;
        private System.Windows.Forms.TabControl tabDisplay;
        private System.Windows.Forms.Button BtnWrite;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Button BtnBlockDel;
        private System.Windows.Forms.Button BtnBlockAdd;
        private System.Windows.Forms.TextBox txtStringLength;
        private System.Windows.Forms.Button BtnDelMonitor;
        private System.Windows.Forms.Button BtnAddMonitor;
        private System.Windows.Forms.ListView lvMonitor;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button BtnUpdateMonitor;
        private System.Windows.Forms.Button BtnUpdateData;
        private System.Windows.Forms.Timer UpdateLogTimer;
    }
}

