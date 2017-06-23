using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using Win32 = Microsoft.Win32;

namespace SCide.WPF
{
	public partial class OpenFileDialog : UserControl
	{
		private readonly Win32.OpenFileDialog mInnerDialog = new Win32.OpenFileDialog();

		public OpenFileDialog()
		{
			InitializeComponent();
		}

		public bool AddExtenstion
		{
			get { return mInnerDialog.AddExtension; }
			set { mInnerDialog.AddExtension = value; }
		}
		public bool CheckFileExists
		{
			get { return mInnerDialog.CheckFileExists; }
			set { mInnerDialog.CheckFileExists = value; }
		}
		public bool CheckPathExists
		{
			get { return mInnerDialog.CheckPathExists; }
			set { mInnerDialog.CheckPathExists = value; }
		}
		public IList<Win32.FileDialogCustomPlace> CustomPlaces
		{
			get { return mInnerDialog.CustomPlaces; }
			set { mInnerDialog.CustomPlaces = value; }
		}
		public string DefaultExt
		{
			get { return mInnerDialog.DefaultExt; }
			set { mInnerDialog.DefaultExt = value; }
		}
		public bool DereferenceLinks
		{
			get { return mInnerDialog.DereferenceLinks; }
			set { mInnerDialog.DereferenceLinks = value; }
		}
		public string FileName
		{
			get { return mInnerDialog.FileName; }
			set { mInnerDialog.FileName = value; }
		}
		public string[] FileNames { get { return mInnerDialog.FileNames; } }
		public string Filter
		{
			get { return mInnerDialog.Filter; }
			set { mInnerDialog.Filter = value; }
		}
		public int FilterIndex
		{
			get { return mInnerDialog.FilterIndex; }
			set { mInnerDialog.FilterIndex = value; }
		}
		public string InitialDirectory 
		{
			get { return mInnerDialog.InitialDirectory; }
			set { mInnerDialog.InitialDirectory = value; }
		}
		public bool Multiselect
		{
			get { return mInnerDialog.Multiselect; }
			set { mInnerDialog.Multiselect = value; }
		}
		public bool ReadOnlyChecked
		{
			get { return mInnerDialog.ReadOnlyChecked; }
			set { mInnerDialog.ReadOnlyChecked = value; }
		}
		public string SafeFileName { get { return mInnerDialog.SafeFileName; } }
		public string[] SafeFileNames { get { return mInnerDialog.SafeFileNames; } }
		public bool ShowReadOnly
		{
			get { return mInnerDialog.ShowReadOnly; }
			set { mInnerDialog.ShowReadOnly = value; }
		}
		new public object Tag 
		{
			get { return mInnerDialog.Tag; }
			set { mInnerDialog.Tag = value; }
		}
		public string Title
		{
			get { return mInnerDialog.Title; }
			set { mInnerDialog.Title = value; }
		}
		public bool ValidateNames
		{
			get { return mInnerDialog.ValidateNames; }
			set { mInnerDialog.ValidateNames = value; }
		}

		public Stream OpenFile() { return mInnerDialog.OpenFile(); }
		public Stream[] OpenFiles() { return mInnerDialog.OpenFiles(); }
		public void Reset() { mInnerDialog.Reset(); }
		public bool? ShowDialog() { return mInnerDialog.ShowDialog(); }
		public bool? ShowDialog(Window w) { return mInnerDialog.ShowDialog(w); }

		public override string ToString() { return mInnerDialog.ToString(); }
	}
}
