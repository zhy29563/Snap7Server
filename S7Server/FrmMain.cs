using Snap7;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace S7ServerDemo
{
    public partial class FrmMain : Form
    {
        private readonly Dictionary<string, byte[]>  m_BlockDict   = new Dictionary<string, byte[]>();
        private readonly List<MonitorInfo> m_InfoList = new List<MonitorInfo>();
        private readonly S7Server m_Server = new S7Server();

        public FrmMain()
        {
            InitializeComponent();
            this.m_Server.LogMask = 0xFFFFFFFF;
        }

        public void AddDisplayPage(string name)
        {
            var txt = new TextBox
            {
                BackColor = Color.FromKnownColor(KnownColor.Control),
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Multiline = true,
                WordWrap = false,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)))
            };

            var page = new TabPage
            {
                Padding = new Padding(5),
                Text = name,
                Name = name
            };
            page.Controls.Add(txt);

            this.tabDisplay.TabPages.Add(page);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            AddDisplayPage("Log");

            this.cboxBlockType.DataSource = Enum.GetValues(typeof(BlockType));
            this.cboxDataType.DataSource = Enum.GetValues(typeof(DataType));
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                if(System.Net.IPAddress.TryParse(this.txtNetworkHost.Text, out _))
                {
                    if (this.m_Server.StartTo(this.txtNetworkHost.Text) == 0)
                    {
                        this.txtNetworkHost.Enabled = false;
                        this.BtnStartServer.Enabled = false;
                        this.BtnStopServer.Enabled = true;
                        this.gboxBlockAdd.Enabled = true;
                        this.gboxBlockReadWrite.Enabled = true;
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Net.IPAddress.TryParse(this.txtNetworkHost.Text, out _))
                {
                    if (this.m_Server.Stop() == 0)
                    {
                        this.txtNetworkHost.Enabled     = true;
                        this.BtnStartServer.Enabled     = true;
                        this.BtnStopServer.Enabled      = false;
                        this.gboxBlockAdd.Enabled       = false;
                        this.gboxBlockReadWrite.Enabled = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboxBlockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDataType = (BlockType)Enum.Parse(typeof(BlockType), this.cboxBlockType.SelectedItem.ToString());
            this.txtBlockIndex.Enabled = selectedDataType == BlockType.Db;
        }

        private bool DisplayIsContainsNamedPage(string starts, out string pageName)
        {
            pageName = string.Empty;
            foreach (TabPage page in this.tabDisplay.TabPages)
                if (page.Name.StartsWith(starts))
                {
                    pageName = page.Name;
                    return true;
                }
            return false;
        }

        private void HexDump(TextBoxBase box, IReadOnlyList<byte> bytes, int size)
        {
            if (bytes == null)
                return;

            var bytesLength = size;
            const int bytesPerLine = 16;

            var hexChars = "0123456789ABCDEF".ToCharArray();

            var firstHexColumn = 8 + 3;                  // 8 characters for the address + 3 spaces

            var firstCharColumn = firstHexColumn
                                  + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                                  + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                                  + 2;                  // 2 spaces 

            var lineLength = firstCharColumn
                             + bytesPerLine           // - characters to show the ascii value
                             + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            var line = (new string(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            var expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            var result = new StringBuilder(expectedLines * lineLength);

            box.Clear();

            for (var i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = hexChars[(i >> 28) & 0xF];
                line[1] = hexChars[(i >> 24) & 0xF];
                line[2] = hexChars[(i >> 20) & 0xF];
                line[3] = hexChars[(i >> 16) & 0xF];
                line[4] = hexChars[(i >> 12) & 0xF];
                line[5] = hexChars[(i >> 8) & 0xF];
                line[6] = hexChars[(i >> 4) & 0xF];
                line[7] = hexChars[(i >> 0) & 0xF];

                var hexColumn = firstHexColumn;
                var charColumn = firstCharColumn;

                for (var j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        var b = bytes[i + j];
                        line[hexColumn] = hexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = hexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            box.Text = result.ToString();
        }

        private void AddBlock(byte[] block, int blockType, int blockSize, int blockIndex, string name, string prefix)
        {
            if (this.DisplayIsContainsNamedPage(prefix, out var key))
            {
                if (MessageBox.Show(@"指定块，是否进行替换", @"警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.m_Server.UnregisterArea(blockType, blockIndex) != 0)
                        throw new Exception(@"块取消失败");
                    this.m_BlockDict.Remove(key);
                    this.tabDisplay.TabPages.RemoveByKey(key);
                }
            }

            prefix += name;
            if (this.m_Server.RegisterArea(blockType, blockIndex, ref block, blockSize) == 0)
            {
                this.m_BlockDict.Add(prefix, block);
                AddDisplayPage(prefix);
            }
            else
                throw new Exception(@"块注册失败");
        }

        private void BtnBlockAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboxBlockType.SelectedIndex < 0)
                    throw new Exception(@"请选择正确的块类型");

                if (!int.TryParse(this.txtBlockSize.Text, out var blockSize))
                    throw new Exception(@"块大小格式输入不正确");
                if (blockSize <= 0)
                    throw new Exception(@"块大小必须是正整数");
                if (blockSize % 16 != 0)
                    throw new Exception(@"块大小不是16的倍数");

                if(!int.TryParse(this.txtBlockIndex.Text, out var blockIndex))
                    throw new Exception(@"块索引格式输入不正确");
                if(blockIndex < 0)
                    throw new Exception(@"块索引必须大于等于零");

                var name  = $"{blockIndex}_{blockSize}";
                var block = new byte[blockSize];

                var selectedDataType = (BlockType)Enum.Parse(typeof(BlockType), this.cboxBlockType.SelectedItem.ToString());

                switch (selectedDataType)
                {
                    case BlockType.In:
                        this.AddBlock(block, S7Server.srvAreaPE, blockSize, blockIndex, name, "IN_");
                        break;
                    case BlockType.Out:
                        this.AddBlock(block, S7Server.srvAreaPA, blockSize, blockIndex, name, "OUT_");
                        break;
                    case BlockType.Db:
                        this.AddBlock(block, S7Server.srvAreaDB, blockSize, blockIndex, name, "DB_");
                        break;
                    case BlockType.Merker:
                        this.AddBlock(block, S7Server.srvAreaMK, blockSize, blockIndex, name, "MK_");
                        break;
                    case BlockType.Timers:
                        this.AddBlock(block, S7Server.srvAreaTM, blockSize, blockIndex, name, "TM_");
                        break;
                    case BlockType.Counters:
                        this.AddBlock(block, S7Server.srvAreaCT, blockSize, blockIndex, name, "CT_");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBlockDel_Click(object sender, EventArgs e)
        {
            try
            {
                var index = this.tabDisplay.SelectedIndex;
                if (index < 1)
                    return;

                var name = this.tabDisplay.TabPages[index].Name;

                var type = -1;
                if (name.StartsWith("IN_"))
                    type = S7Server.srvAreaPE;
                else if (name.StartsWith("OUT_"))
                    type = S7Server.srvAreaPA;
                else if (name.StartsWith("DB_"))
                    type = S7Server.srvAreaDB;
                else if (name.StartsWith("MK_"))
                    type = S7Server.srvAreaMK;
                else if (name.StartsWith("TM_"))
                    type = S7Server.srvAreaTM;
                else if (name.StartsWith("CT_"))
                    type = S7Server.srvAreaCT;
                var blockIndex = int.Parse(name.Split('_')[1]);
                if (m_Server.UnregisterArea(type, blockIndex) != 0)
                    throw new Exception(@"块取消失败");
                this.m_BlockDict.Remove(name);
                this.tabDisplay.TabPages.RemoveByKey(name);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
            this.txtOffsetBit.Enabled    = selectedDataType == DataType.Bit;
            this.txtStringLength.Enabled = selectedDataType == DataType.String;
            this.txtStringLength.Text    = selectedDataType == DataType.String ? "1" : "0";
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                #region 数据类型
                if (this.cboxDataType.SelectedIndex < 0)
                    throw new Exception("请选择正确的数据类型");
                #endregion

                #region 字节偏移量
                if (!int.TryParse(this.txtOffsetByte.Text, out var offsetByte))
                    throw new Exception(@"字节偏移量格式不正确，请重新输入");

                if (offsetByte < 0)
                    throw new Exception(@"字节偏移量必须大于等于零，请重新输入");
                #endregion

                #region 位偏移量
                if (!int.TryParse(this.txtOffsetBit.Text, out var offsetBit))
                    throw new Exception(@"位偏移量格式不正确，请重新输入");

                if (offsetBit < 0 || offsetBit > 7)
                    throw new Exception(@"位偏移量超出范围[0,7]，请重新输入");
                #endregion

                #region 字符串长度
                if (!int.TryParse(this.txtStringLength.Text, out var stringLength))
                    throw new Exception(@"字符串长度格式不正确，请重新输入");

                var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                if (selectedDataType == DataType.String)
                {
                    if (stringLength <= 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                else
                {
                    if (stringLength < 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                #endregion

                #region 字节溢出
                var name = this.tabDisplay.SelectedTab.Name;
                var block = this.m_BlockDict[name];
                if (offsetByte + stringLength >= block.Length)
                    throw new Exception(@"字节偏移量 + 字符串长度必须小于块大小，请重新输入");
                #endregion

                //var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                switch (selectedDataType)
                {
                    case DataType.Bit:
                        this.txtValue.Text = S7.GetBitAt(block, offsetByte, offsetBit).ToString();
                        break;
                    case DataType.Byte:
                        this.txtValue.Text = S7.GetUSIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Ushort:
                        this.txtValue.Text = S7.GetUIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Uint:
                        this.txtValue.Text = S7.GetUDIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Ulong:
                        this.txtValue.Text = S7.GetULIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Sbyte:
                        this.txtValue.Text = S7.GetSIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Short:
                        this.txtValue.Text = S7.GetIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Int:
                        this.txtValue.Text = S7.GetDIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Long:
                        this.txtValue.Text = S7.GetLIntAt(block, offsetByte).ToString();
                        break;
                    case DataType.Float:
                        this.txtValue.Text = S7.GetRealAt(block, offsetByte).ToString(CultureInfo.InvariantCulture);
                        break;
                    case DataType.Double:
                        this.txtValue.Text = S7.GetLRealAt(block, offsetByte).ToString(CultureInfo.InvariantCulture);
                        break;
                    case DataType.String:
                        var byteArr = new byte[stringLength];
                        Array.Copy(block, offsetByte, byteArr, 0, stringLength);
                        this.txtValue.Text = System.Text.Encoding.ASCII.GetString(byteArr);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                #region 数据类型
                if (this.cboxDataType.SelectedIndex < 0)
                    throw new Exception("请选择正确的数据类型");
                #endregion

                #region 字节偏移量
                if (!int.TryParse(this.txtOffsetByte.Text, out var offsetByte))
                    throw new Exception(@"字节偏移量格式不正确，请重新输入");

                if (offsetByte < 0)
                    throw new Exception(@"字节偏移量必须大于等于零，请重新输入");
                #endregion

                #region 位偏移量
                if (!int.TryParse(this.txtOffsetBit.Text, out var offsetBit))
                    throw new Exception(@"位偏移量格式不正确，请重新输入");

                if (offsetBit < 0 || offsetBit > 7)
                    throw new Exception(@"位偏移量超出范围[0,7]，请重新输入");
                #endregion

                #region 字符串长度
                if (!int.TryParse(this.txtStringLength.Text, out var stringLength))
                    throw new Exception(@"字符串长度格式不正确，请重新输入");

                var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                if (selectedDataType == DataType.String)
                {
                    if (stringLength <= 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                else
                {
                    if (stringLength < 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                #endregion

                #region 字节溢出
                var name = this.tabDisplay.SelectedTab.Name;
                var block = this.m_BlockDict[name];
                if (offsetByte + stringLength >= block.Length)
                    throw new Exception(@"字节偏移量 + 字符串长度必须小于块大小，请重新输入");
                #endregion

                //var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                switch (selectedDataType)
                {
                    case DataType.Bit:
                        if (bool.TryParse(this.txtValue.Text, out var boolValue))
                            S7.SetBitAt(ref block, offsetByte, offsetBit, boolValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Byte:
                        if (byte.TryParse(this.txtValue.Text, out var byteValue))
                            S7.SetUSIntAt(block, offsetByte, byteValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Ushort:
                        if (ushort.TryParse(this.txtValue.Text, out var ushortValue))
                            S7.SetUIntAt(block, offsetByte, ushortValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Uint:
                        if (uint.TryParse(this.txtValue.Text, out var uintValue))
                            S7.SetUDIntAt(block, offsetByte, uintValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Ulong:
                        if (ulong.TryParse(this.txtValue.Text, out var ulongValue))
                            S7.SetULintAt(block, offsetByte, ulongValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Sbyte:
                        if (sbyte.TryParse(this.txtValue.Text, out var sbyteValue))
                            S7.SetSIntAt(block, offsetByte, sbyteValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Short:
                        if (short.TryParse(this.txtValue.Text, out var shortValue))
                            S7.SetIntAt(block, offsetByte, shortValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Int:
                        if (int.TryParse(this.txtValue.Text, out var intValue))
                            S7.SetDIntAt(block, offsetByte, intValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Long:
                        if (long.TryParse(this.txtValue.Text, out var longValue))
                            S7.SetLIntAt(block, offsetByte, longValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;  

                    case DataType.Float:
                        if (float.TryParse(this.txtValue.Text, out var floatValue))
                            S7.SetRealAt(block, offsetByte, floatValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.Double:
                        if (double.TryParse(this.txtValue.Text, out var doubleValue))
                            S7.SetLRealAt(block, offsetByte, doubleValue);
                        else
                            throw new Exception("值的格式不正确");
                        break;

                    case DataType.String:
                        S7.SetCharsAt(block, offsetByte, this.txtValue.Text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var form = (TextBox)this.tabDisplay.SelectedTab.Controls[0];
                HexDump(form, block, block.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLogTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var form = (TextBox)this.tabDisplay.TabPages[0].Controls[0];
                if (form.Lines.Count() > 200)
                    form.Clear();

                var eventLog = new S7Server.USrvEvent();
                if (this.m_Server.PickEvent(ref eventLog))
                {
                    form.AppendText(this.m_Server.EventText(ref eventLog) + Environment.NewLine);
                    //var evtTime = Event.EvtTime;
                    //var evtSender = Event.EvtSender;
                    //var evtCode = Event.EvtCode;
                    //var cvtRetCode = Event.EvtRetCode;
                    //var evtParam1 = Event.EvtParam1;
                    //var evtParam2 = Event.EvtParam2;
                    //var evtParam3 = Event.EvtParam3;
                    //var evtParam4 = Event.EvtParam4;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                #region 数据类型
                if (this.cboxDataType.SelectedIndex < 0)
                    throw new Exception("请选择正确的数据类型");
                #endregion

                #region 字节偏移量
                if (!int.TryParse(this.txtOffsetByte.Text, out var offsetByte))
                    throw new Exception(@"字节偏移量格式不正确，请重新输入");

                if (offsetByte < 0)
                    throw new Exception(@"字节偏移量必须大于等于零，请重新输入");
                #endregion

                #region 位偏移量
                if (!int.TryParse(this.txtOffsetBit.Text, out var offsetBit))
                    throw new Exception(@"位偏移量格式不正确，请重新输入");

                if (offsetBit < 0 || offsetBit > 7)
                    throw new Exception(@"位偏移量超出范围[0,7]，请重新输入");
                #endregion

                #region 字符串长度
                if (!int.TryParse(this.txtStringLength.Text, out var stringLength))
                    throw new Exception(@"字符串长度格式不正确，请重新输入");

                var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                if (selectedDataType == DataType.String)
                {
                    if (stringLength <= 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                else
                {
                    if (stringLength < 0)
                        throw new Exception(@"字符串长度必须大于等，请重新输入");
                }
                #endregion

                #region 字节溢出
                var name = this.tabDisplay.SelectedTab.Name;
                var block = this.m_BlockDict[name];
                if (offsetByte + stringLength >= block.Length)
                    throw new Exception(@"字节偏移量 + 字符串长度必须小于块大小，请重新输入");
                #endregion

                // 增加到检测集合
                //var selectedDataType = (DataType)Enum.Parse(typeof(DataType), this.cboxDataType.SelectedItem.ToString());
                var info = new MonitorInfo() { BlockName = name, DataType = selectedDataType, OffsetByte = offsetByte, OffsetBit = offsetBit, StringLength = stringLength };
                if (!this.m_InfoList.Contains(info))
                {
                    this.m_InfoList.Add(info);
                    this.lvMonitor.Items.Add(new ListViewItem(new string[]
                        {$"{name}_{offsetByte}_{offsetBit}_{stringLength}", selectedDataType.ToString(), string.Empty}));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.lvMonitor.SelectedIndices.Count == 0)
                    throw new Exception(@"请选择需要删除的监视");

                var index = this.lvMonitor.SelectedIndices[0];
                this.lvMonitor.Items.RemoveAt(index);
                this.m_InfoList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdateData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboxDataType.SelectedIndex < 0)
                    throw new Exception("请选择正确的数据类型");

                var name = this.tabDisplay.SelectedTab.Name;
                var block = this.m_BlockDict[name];

                var form = (TextBox)this.tabDisplay.SelectedTab.Controls[0];
                HexDump(form, block, block.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdateMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_InfoList.Count < 0)
                    throw new Exception(@"不存在正在监视的变量");

                for (var index = 0; index < this.m_InfoList.Count; index++)
                {
                    var block = this.m_BlockDict[this.m_InfoList[index].BlockName];
                    var offsetByte = this.m_InfoList[index].OffsetByte;
                    var offsetBit = this.m_InfoList[index].OffsetBit;
                    var stringLength = this.m_InfoList[index].StringLength;
                    var dataType = this.m_InfoList[index].DataType;
                    string strValue;
                    switch (dataType)
                    {
                        case DataType.Bit: strValue = S7.GetBitAt(block, offsetByte, offsetBit).ToString(); break;
                        case DataType.Byte: strValue = S7.GetUSIntAt(block, offsetByte).ToString(); break;
                        case DataType.Ushort: strValue = S7.GetUIntAt(block, offsetByte).ToString(); break;
                        case DataType.Uint: strValue = S7.GetUDIntAt(block, offsetByte).ToString(); break;
                        case DataType.Ulong: strValue = S7.GetULIntAt(block, offsetByte).ToString(); break;
                        case DataType.Sbyte: strValue = S7.GetSIntAt(block, offsetByte).ToString(); break;
                        case DataType.Short: strValue = S7.GetIntAt(block, offsetByte).ToString(); break;
                        case DataType.Int: strValue = S7.GetDIntAt(block, offsetByte).ToString(); break;
                        case DataType.Long: strValue = S7.GetLIntAt(block, offsetByte).ToString(); break;
                        case DataType.Float: strValue = S7.GetRealAt(block, offsetByte).ToString(CultureInfo.InvariantCulture); break;
                        case DataType.Double: strValue = S7.GetLRealAt(block, offsetByte).ToString(CultureInfo.InvariantCulture); break;
                        case DataType.String:
                            var byteArr = new byte[stringLength];
                            Array.Copy(block, offsetByte, byteArr, 0, stringLength);
                            strValue = System.Text.Encoding.ASCII.GetString(byteArr);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    this.lvMonitor.Items[index].SubItems[2].Text = strValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class MonitorInfo
    {
        public string BlockName { get; set; }

        public DataType DataType { get; set; }

        public int OffsetByte { get; set; }

        public int OffsetBit { get; set; }

        public int StringLength { get; set; }
    }

    public enum DataType
    {
        Bit,
        Byte,
        Ushort,
        Uint,
        Ulong,
        Sbyte,
        Short,
        Int,
        Long,
        Float,
        Double,
        String
    }

    public enum BlockType
    {
        In,
        Out,
        Db,
        Merker,
        Timers,
        Counters
    }
}
