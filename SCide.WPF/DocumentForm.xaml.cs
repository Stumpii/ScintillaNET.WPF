using System;
using System.Windows.Controls;
using ScintillaNET.WPF;
using System.IO;
using System.ComponentModel;
using ScintillaNET;
using System.Globalization;
using System.Windows;
using System.Diagnostics;
using ScintillaNET_FindReplaceDialog;
using Xceed.Wpf.AvalonDock.Layout;

namespace SCide.WPF
{
    /// <summary>
    /// Interaction logic for DocumentForm.xaml
    /// </summary>
    public partial class DocumentForm : LayoutDocument
    {
        public FindReplace FindReplace { get; set; }

        public DocumentForm()
        {
            InitializeComponent();
            this.Title = "";
            this.Closing += new EventHandler<CancelEventArgs>(DocumentForm_Closing);
            Scintilla.MouseDown += Scintilla_MouseDown;
            Scintilla.SavePointLeft += Scintilla_SavePointLeft;
        }

        private void Scintilla_SavePointLeft(object sender, EventArgs e)
        {
            AddOrRemoveAsteric();
        }

        private void Scintilla_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            {
                switch (e.Button)
                {
                    case System.Windows.Forms.MouseButtons.Left:
                        if (FindReplace == null) break;

                        //Clear current highlights
                        FindReplace.ClearAllHighlights();

                        //Highlight identical text
                        string sWord = Scintilla.GetWordFromPosition(Scintilla.CurrentPosition);
                        if (!string.IsNullOrEmpty(sWord))
                            FindReplace.FindAll(sWord, false, true);

                        break;

                    default:
                        break;
                }
            }
        }

        public ScintillaWPF Scintilla
        {
            get { return scintilla; }
        }

        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private void AddOrRemoveAsteric()
        {
            if (scintilla.Modified)
            {
                if (!Title.EndsWith(" *", StringComparison.InvariantCulture))
                    Title += " *";
            }
            else
            {
                if (Title.EndsWith(" *", StringComparison.InvariantCulture))
                    Title = Title.Substring(0, Title.Length - 2);
            }
        }

        private void DocumentForm_Closing(object sender, CancelEventArgs e)
        {
            if (Scintilla.Modified)
            {
                // Prompt if not saved
                string message = String.Format(CultureInfo.CurrentCulture, "The _text in the {0} file has changed.{1}{2}Do you want to save the changes?", Title.TrimEnd(' ', '*'), Environment.NewLine, Environment.NewLine);

                MessageBoxResult dr = MessageBox.Show(message, Program.Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
                if (dr == MessageBoxResult.Cancel)
                {
                    // Stop closing
                    e.Cancel = true;
                    return;
                }
                else if (dr == MessageBoxResult.Yes)
                {
                    // Try to save before closing
                    e.Cancel = !Save();
                    return;
                }
            }

            // Close as normal
        }

        public bool ExportAsHtml()
        {
            // TODO - Implement ExportAsHtml feature

            //SaveFileDialog dialog = new SaveFileDialog();
            //string fileName = (Title.EndsWith(" *") ? Title.Substring(0, Title.Length - 2) : Title);
            //dialog.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm|All Files (*.*)|*.*";
            //dialog.FileName = fileName + ".html";
            //bool? res = dialog.ShowDialog();
            //if (res != null && (bool)res)
            //{
            //	scintilla.Lexing.Colorize(); // Make sure the document is current
            //	using (StreamWriter sw = new StreamWriter(dialog.FileName))
            //		scintilla.ExportHtml(sw, fileName, false);

            //	return true;
            //}

            return false;
        }

        public bool Save()
        {
            if (String.IsNullOrEmpty(_filePath))
                return SaveAs();

            return Save(_filePath);
        }

        public bool Save(string filePath)
        {
            using (FileStream fs = File.Create(filePath))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                    bw.Write(scintilla.Text.ToCharArray(), 0, scintilla.Text.Length - 1); // Omit trailing NULL
            }
            this.Title = Path.GetFileName(filePath);

            scintilla.SetSavePoint();
            return true;
        }

        public bool SaveAs()
        {
            bool? res = saveFileDialog.ShowDialog();
            if (res != null && (bool)res)
            {
                _filePath = saveFileDialog.FileName;
                return Save(_filePath);
            }

            return false;
        }
    }
}