using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using DXLog.net;

namespace DXLog.net
{
    public partial class ExtraInfoMulti : KForm
    {
        public static String CusWinName
        {
            get { return "ExtraInfoMulti"; }
        }

        public static Int32 CusFormID
        {
            get { return 20223; }
        }
        
        private ContestData _cdata = null;
        private Font _windowFont = new Font("Courier New", 10, FontStyle.Regular);
        private FrmMain mainForm = null;

        private List<EdiEntry>m_allEntries = new List<EdiEntry>();

        public ExtraInfoMulti()
        {
            InitializeComponent();
            
            dataGridViewFoundCalls.RowTemplate.Height = 15;
            dataGridViewFoundCalls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewFoundCalls.RowHeadersVisible = false;
            //dataGridViewFoundCalls.Columns[0].Name = "CALL";
            //dataGridViewFoundCalls.Columns[0].DataPropertyName = "CALL";
            //dataGridViewFoundCalls.Columns[1].Name = "LOC";
            //dataGridViewFoundCalls.Columns[1].DataPropertyName = "LOC";

        }

        public ExtraInfoMulti(ContestData cdata)
        {
            InitializeComponent();
            ColorSetTypes = new String[] { "Background", "Color", "Header back color", "Header color", "Footer back color", "Footer color", "Final score color", "Selection back color", "Selection color" };
            DefaultColors = new Color[] { Color.Turquoise, Color.Black, Color.Gray, Color.Black, Color.Silver, Color.Black, Color.Blue, Color.SteelBlue, Color.White };
            _cdata = cdata;
            this.FormLayoutChangeEvent += new FormLayoutChange(handle_FormLayoutChangeEvent);

        }

        private void handle_FormLayoutChangeEvent()
        {
            InitializeLayout();
        }

        public override void InitializeLayout()
        {
            /* attach to callsign input event from DXLOG */
            base.InitializeLayout(_windowFont);
            if (base.FormLayout.FontName.Contains("Courier"))
                _windowFont = new Font(base.FormLayout.FontName, base.FormLayout.FontSize, FontStyle.Regular);
            else
                _windowFont = Helper.GetSpecialFont(FontStyle.Regular, base.FormLayout.FontSize);

            if (mainForm == null)
            {
                mainForm = (FrmMain)(this.ParentForm == null ? this.Owner : this.ParentForm);
                if (mainForm != null) { 
                    mainForm.CallsignInfoRefreshed += callsigninfoRefreshEvent;

                }
            }

        }

        public void callsigninfoRefreshEvent(string callsign)
        {

            //List<EdiEntry> result = m_allEntries.FindAll(x => x.CALL.Contains(callsign));
                lock (dataGridViewFoundCalls) {
                    if (dataGridViewFoundCalls.InvokeRequired)
                    {
                        dataGridViewFoundCalls.Invoke(new MethodInvoker(() => 
                        dataGridViewFoundCalls.DataSource = m_allEntries.Where(x => x.CALL.Contains(callsign)).ToList().GroupBy(x => x.LOC).Select(x => x.First()).ToList()

                        ));
                    }
                    else
                    {
                        dataGridViewFoundCalls.DataSource = m_allEntries.Where(x => x.CALL.Contains(callsign)).ToList().GroupBy(x => x.LOC).Select(x => x.First()).ToList();

                    }
                }


            }




        //HELPERS

        private void parseEdiLogs(string root) {
            DirectoryInfo d = new DirectoryInfo(root); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.edi"); //Getting Text files
            string str = "";

            m_allEntries.Clear();

            foreach (FileInfo file in Files)
            {
                m_allEntries.AddRange(ediToCallSignList(file.FullName));
            }
            labelEdiEntryCount.Text = "Count: " + m_allEntries.Count.ToString();
            dataGridViewFoundCalls.DataSource = null;
            dataGridViewFoundCalls.DataSource = m_allEntries;
           // (dataGridViewFoundCalls.DataSource as DataTable).DefaultView.RowFilter = string.Format("CALL LIKE %{0}%", "OE1W");
            //dataGridViewFoundCalls.DataMember = "CALL";
            //dataGridViewFoundCalls.DataMember = "LOC";

        }
        public List<EdiEntry> ediToCallSignList(string path)
        {
            List<EdiEntry> list = new List<EdiEntry>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    try
                    {
                        var split = line.Split(';');
                        if (split.Length == 15)
                        {
                            var callsign = split[2];
                            var locator = split[9];
                            list.Add(new EdiEntry(callsign,locator));
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception exc) { }

            return list;
        }

        private void textBoxEdiLogFolder_TextChanged(object sender, EventArgs e)
        {
            try { 
                parseEdiLogs(textBoxEdiLogFolder.Text);
            }catch(Exception exc) { }
        }

        private void textBoxEdiLogFolder_DragEnter(object sender, DragEventArgs e)
        {
            //Console.WriteLine("DragEnter!");
            e.Effect = DragDropEffects.Copy;
        }

        private void buttonPasteEdiLogs_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                textBoxEdiLogFolder.Text = clipboardText;
                // Do whatever you need to do with clipboardText
            }
            else {
                mainForm.Invoke(new MethodInvoker(() =>
                    MessageBox.Show("No text in clipboard")
                ));
            }
        }

        private void buttonPasteEdiLogs_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show("Paste from Clipboard", buttonPasteEdiLogs, 0, 0, 1000);
        }

        private void buttonPasteEdiLogs_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPasteEdiLogs_Click(null, null);
        }
        private void buttonBrowseEdiLogs_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select Current Folder.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                textBoxEdiLogFolder.Text = folderPath;
                parseEdiLogs(folderPath);
            }

        }
        private void buttonBrowseEdiLogs_MouseDown(object sender, MouseEventArgs e)
        {
            buttonBrowseEdiLogs_Click(null,null);
        }
    }
}

public class EdiEntry {
    private string _CALL;
    private string _LOC;
    public string CALL { get { return _CALL; } }
    public string LOC { get { return _LOC; } }
    public EdiEntry(string call, string loc)
    {


        _CALL = call;
        _LOC = loc;
    }


}
