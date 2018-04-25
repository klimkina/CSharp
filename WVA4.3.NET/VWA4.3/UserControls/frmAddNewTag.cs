using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VWA4Common.DAO;
using VWA4Common.DataObject;

namespace UserControls
{
	public partial class frmAddNewTag : System.Windows.Forms.Form
	{
		bool bdoneclicked = false;
		/// 
		/// Class Properties
		/// 
		private Tag _tag = new Tag();
		public Tag TagNew
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public frmAddNewTag()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			bDone.Enabled = false;	// Can't be done until a Tracker is chosen
			updateProductUI();
		}

		/// <summary>
		/// Update the Product UI based on global settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void updateProductUI()
		{
			///***********
			/// Product Type
			///***********
			// Task background
			this.BackColor = VWA4Common.GlobalSettings.ProductTaskBackgroundColor;
			// Task header
			pFormHdr.BackColor = VWA4Common.GlobalSettings.ProductTaskHeaderBackgroundColor;
			lFormTitle.ForeColor = VWA4Common.GlobalSettings.ProductTaskHeaderFontColor;
			// Other stuff
			this.Icon = VWA4Common.GlobalSettings.ProductIcon;
		}

		private void tTagName_KeyPress(object sender, KeyPressEventArgs e)
		{
			bDone.Enabled = readytoSave();
		}

		private bool readytoSave()
		{
			if (tTagName.TextLength > 0) return true;
			return false;
		}

		private void bDone_Click(object sender, EventArgs e)
		{
			_tag.ID = 0;
			_tag.TagName = tTagName.Text;
			_tag.TagDescription = tTagDescription.Text;
			// First, check whether the TagName already exists
			if (TagsDAO.DAO.Exists(_tag.TagName))
			{
				// Tag Name already exists
				MessageBox.Show("Tag Name " + _tag.TagName + " already exists!", "Add New Tag Error");
				return;
			}
			// It doesn't, so let's add it
			if (SaveTag(_tag))
				DialogResult = DialogResult.OK;
			else
			MessageBox.Show("Error encountered attempting to save the new tag.", "Add New Tag Error");
		}

		private bool SaveTag(Tag tagnew)
		{
				tagnew.ID = TagsDAO.DAO.Insert(tagnew);
				if (tagnew.ID > 0) return true;
				return false;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			_tag.ID = 0;
			_tag.TagName = String.Empty;
			_tag.TagDescription = string.Empty;
			DialogResult = DialogResult.Cancel;
		}

	}
}
