using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeW_WF_21._08._2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripComboBox1.SelectedIndex = 0;
        }
        bool IsSaved = false;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            fontDialog.ShowColor = true;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                    richTextBox1.SelectionColor = fontDialog.Color;
                }
                else
                {
                    richTextBox1.Font = fontDialog.Font;
                    richTextBox1.ForeColor = fontDialog.Color;
                }
            }
            IsSaved = false;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveDialog.FileName) == ".txt")
                {
                    richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                    IsSaved = true;
                }
                else
                {
                    richTextBox1.SaveFile(saveDialog.FileName);
                    IsSaved = true;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openDialog.Filter = "All files|*.*|Text documents|*.txt|RTF|*.rtf";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openDialog.FileName);
            }
            IsSaved = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                if (richTextBox1.SelectionFont.Italic)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                }
            }
            else
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
            }
            IsSaved = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var boldBtn = (sender as ToolStripButton);
            boldBtn.Checked = !boldBtn.Checked;

            if (richTextBox1.SelectedText.Length > 0)
            {
                if (richTextBox1.SelectionFont.Bold)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
                }
            }
            else
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
            }
            IsSaved = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                this.Close();
            }
            else
            {
                var msg = MessageBox.Show("Your project is unsaved , do you want to save it ?", "Do you want to save project ?", MessageBoxButtons.YesNo);
                switch (msg)
                {

                    case DialogResult.Yes:
                        var saveDialog = new SaveFileDialog();
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (Path.GetExtension(saveDialog.FileName) == ".txt")
                            {
                                richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                                IsSaved = true;
                            }
                            else
                            {
                                richTextBox1.SaveFile(saveDialog.FileName);
                                IsSaved = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        this.Close();

                        break;

                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                this.Close();
            }
            else
            {
                var msg = MessageBox.Show("Your project is unsaved , do you want to save it ?", "Do you want to save project ?", MessageBoxButtons.YesNo);
                switch (msg)
                {

                    case DialogResult.Yes:
                        var saveDialog = new SaveFileDialog();
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (Path.GetExtension(saveDialog.FileName) == ".txt")
                            {
                                richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                                IsSaved = true;
                            }
                            else
                            {
                                richTextBox1.SaveFile(saveDialog.FileName);
                                IsSaved = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        richTextBox1.Clear();
                        break;

                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            IsSaved = false;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(toolStripComboBox1.SelectedItem);

            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.Font = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
            }
            IsSaved = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveDialog.FileName) == ".txt")
                {
                    richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                    IsSaved = true;
                }
                else
                {
                    richTextBox1.SaveFile(saveDialog.FileName);
                    IsSaved = true;
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                var openDialog = new OpenFileDialog();
                openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openDialog.Filter = "All files|*.*|Text documents|*.txt|RTF|*.rtf";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(openDialog.FileName);
                }
                IsSaved = false;
            }
            else
            {
                var msg = MessageBox.Show("Your project is unsaved , do you want to save it ?", "Do you want to save project ?", MessageBoxButtons.YesNo);
                switch (msg)
                {

                    case DialogResult.Yes:
                        var saveDialog = new SaveFileDialog();
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (Path.GetExtension(saveDialog.FileName) == ".txt")
                            {
                                richTextBox1.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                                IsSaved = true;
                            }
                            else
                            {
                                richTextBox1.SaveFile(saveDialog.FileName);
                                IsSaved = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        var openDialog = new OpenFileDialog();
                        openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        openDialog.Filter = "All files|*.*|Text documents|*.txt|RTF|*.rtf";
                        if (openDialog.ShowDialog() == DialogResult.OK)
                        {
                            richTextBox1.LoadFile(openDialog.FileName);
                        }
                        IsSaved = false;
                        break;

                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);

            IsSaved = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size+1, richTextBox1.SelectionFont.Style);
            IsSaved = false;

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size-1, richTextBox1.SelectionFont.Style);
            IsSaved = false;

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;        
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsSaved = false;

            richTextBox1.SelectedText = richTextBox1.SelectedText + Clipboard.GetText();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            richTextBox1.SelectAll();
            richTextBox1.SelectedText = "";

        }
    }
}

        