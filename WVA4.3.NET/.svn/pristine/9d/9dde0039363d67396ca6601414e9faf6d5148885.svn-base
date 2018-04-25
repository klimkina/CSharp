using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Infragistics.Win.UltraWinGrid;
using UserControls;

namespace Reports
{
    public partial class ReportDetails : Form
    {
        public ReportDetails()
        {
            InitializeComponent();
        }

        private int CalculateLevel(DataTable v_DataTable) 
        { 
            
            int highestLevel = 0;
            
            // pass all rows in DataTable 
            foreach (DataRow thisRow in v_DataTable.Rows)
            {
                int intLevel = 0; 
                // recursively look up the tree and count the levels 
                int parentID = int.Parse(thisRow["ParentCatID"].ToString()); 
                while (!(parentID == 0)) { 
                    
                    // find parent 
                    DataRow parentRow; 
                    object[] strFind = new object[1]; 
                    strFind[0] = parentID; 
                    parentRow = v_DataTable.Rows.Find(strFind); 
                    
                    // set to look for parent or throw error if no parent found 
                    if (parentRow == null) { 
                        MessageBox.Show("No Parent Found for " + parentID.ToString()); 
                        parentID = 0; 
                    } 
                    else { 
                        parentID = int.Parse(parentRow["ParentCatID"].ToString()); 
                        intLevel = intLevel + 1; 
                    } 
                    
                } 
                
                // apply level to this row and set Highest Level 
                thisRow["Level"] = intLevel; 
                if (intLevel > highestLevel) 
                    highestLevel = intLevel; 
                
            }        
            // return Highest Level to caller 
            return highestLevel; 
            
        }

        private DataSet CreateHierarchicalDataSet(DataTable v_DataTable, int v_highestLevel, DataTable subDataTable) 
        { 
            
            // declare a new DataSet 
            DataSet hierarchicalDataSet = new DataSet("HierarchicalDataSet");
            
            // pass DataTable for each hierarchical level 
            for (int intLevel = 0; intLevel <= v_highestLevel; intLevel++) { 
                
                // pass DataTable and extract rows for this level 
                DataRow[] levelDataRows; 
                levelDataRows = v_DataTable.Select("Level=" + intLevel.ToString()); 
                
                // test to see if any rows were selected 
                if ((levelDataRows != null)) { 
                    
                    // create a new data table and add the rows and columns 
                    DataTable levelDataTable = new DataTable(); 
                    levelDataTable = v_DataTable.Clone(); 
                    levelDataTable.TableName = "Level" + intLevel.ToString(); 
                    
                    foreach (DataRow dataRow in levelDataRows) { 
                        
                        DataRow newDataRow = levelDataTable.NewRow();
                        foreach (DataColumn dataColumn in v_DataTable.Columns)
                        { 
                            newDataRow[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName]; 
                        } 
                        levelDataTable.Rows.Add(newDataRow); 
                    } 
                    
                    // create a primary key and add to the data table 
                    DataColumn[] Keys = new DataColumn[1]; 
                    Keys[0] = levelDataTable.Columns["CatID"]; 
                    levelDataTable.PrimaryKey = Keys; 
                    
                    // add table to DataSet 
                    hierarchicalDataSet.Tables.Add(levelDataTable);
                    ///////////////////////// Add leaves  ////////////////////////////////////////////////
                    DataTable detailsDataTable = new DataTable();
                    detailsDataTable = subDataTable.Clone();
                    detailsDataTable.TableName = "Type" + intLevel.ToString();
                    string cats = "";
                    foreach (DataRow dataRow in levelDataRows)
                    {
                        if (cats == "")
                            cats = "CatID=" + dataRow.ItemArray[0];
                        else
                            cats += "OR CatID=" + dataRow.ItemArray[0];
                    }
                    DataRow[] detailsDataRows;
                    detailsDataRows = subDataTable.Select(cats);
                    foreach (DataRow dataRow in detailsDataRows)
                    {

                        DataRow newDataRow = detailsDataTable.NewRow();
                        foreach (DataColumn dataColumn in subDataTable.Columns)
                        {
                            newDataRow[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                        }
                        detailsDataTable.Rows.Add(newDataRow);
                    }

                    hierarchicalDataSet.Tables.Add(detailsDataTable);
                    hierarchicalDataSet.Relations.Add("Type" + intLevel, levelDataTable.Columns["CatID"], detailsDataTable.Columns["CatID"]);
                    ///////////////////////// End Add leaves  ////////////////////////////////////////////////
                    // if this is >= level 1 then create and add relationship 
                    if (intLevel >= 1) { 
                        int intParentLevel = intLevel - 1; 
                        string strThisLevel = "Level" + intLevel.ToString(); 
                        string strParentLevel = "Level" + intParentLevel.ToString(); 
                        DataRelation relLevel = new DataRelation(strThisLevel, hierarchicalDataSet.Tables[strParentLevel].Columns["CatID"], 
                            hierarchicalDataSet.Tables[strThisLevel].Columns["ParentCatID"]); 
                        hierarchicalDataSet.Relations.Add(relLevel); 
                    }
                    
                }            
            }
            
            return hierarchicalDataSet;          
        }

        private string currTypeCatalog;
        private string currReportType;
        private void LoadTree(string name)
        {
            currReportType = name; //remember what radiobutton was checked
            // create and populate original DataTable 
            //Dataset to hold data
            DataTable typeDataTable = new DataTable();
            DataTable catDataTable = new DataTable();

            string select = 
                @"SELECT CInt(CatID) as CatID, CInt(ParentCatID) as ParentCatID, CatName, SpanishCatName FROM " 
                + name + "Category;";
            
            catDataTable= VWA4Common.DB.Retrieve(select);

            if((currTypeCatalog == "0")||(currTypeCatalog == ""))
                select = @"SELECT CInt(CatID) as CatID, TypeID, TypeName, SpanishTypeName, "
                +"ReportTypeName FROM " + name + "Type;";
            else
                select = @"SELECT CInt(CatID) as CatID, " + name + "SubTypes.TypeID, TypeName, SpanishTypeName, "
                + " ReportTypeName FROM " + name + "SubTypes "
                + " INNER JOIN " + name + "Type ON " + name + "SubTypes.TypeID = " + name + "Type.TypeID"
                + " WHERE TypeCatalogID = " + currTypeCatalog
                + " AND " + name + "SubTypes.Enabled = true;";
            typeDataTable = VWA4Common.DB.Retrieve(select);
            
            DataColumn[] catkeys = new DataColumn[1];
            catkeys[0] = catDataTable.Columns["CatID"];
            catDataTable.PrimaryKey = catkeys;
            DataTable originalDataTable = catDataTable;

            // add "level" column to originalDataTable 
            DataColumn levelColumn = new DataColumn("Level");
            levelColumn.DataType = typeof(int);
            originalDataTable.Columns.Add(levelColumn);

            // calculate hierarchy level 
            int highestLevel = CalculateLevel(originalDataTable);

            // build Hierarchical DataSet 
            DataSet hierarchicalDataSet = CreateHierarchicalDataSet(originalDataTable, highestLevel, typeDataTable);

            // bind Hierarchical DataSet to Tree UltraGrid 
            ultraGrid1.DataSource = hierarchicalDataSet;
            ultraGrid1.Text = "Select " + name + " Type:";
            
        }

        private void UnloadTree()
        {
            this.ultraGrid1.DataSource = null;
            ultraGrid1.Text = "";
            //this.ultraGrid1.ResetDisplayLayout();
            this.ultraGrid1.Layouts.Clear();
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // set band properties 
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.CaptionAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = FilterUIType.HeaderIcons;
 
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand aBand in e.Layout.Bands)
            {
                aBand.Columns["CatID"].Hidden = true;
                if (!Regex.IsMatch(aBand.Key, "Type"))
                {
                    aBand.Columns["ParentCatID"].Hidden = true;
                    aBand.Columns["Level"].Hidden = true;
                    aBand.ColHeadersVisible = false;
                    aBand.Override.RowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    aBand.Override.RowAppearance.BackColor = Color.LightBlue;
                }
                else
                {
                    aBand.Columns["TypeID"].Hidden = true;
                    aBand.Override.RowAlternateAppearance.BackColor = Color.LightCyan;
                }
            }
            
            // set other layout properties 
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False; 
            e.Layout.Override.CellAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.RowAppearance.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent; 
        }

        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            // attempt to turn off expansion indicator 
            if (e.Row.HasChild() == false)
            {
                e.Row.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never;
            }
            else
            {
                e.Row.ExpandAll();
            }
        }

        private void CheckedChanged(bool isChecked, string name)
        {
            if (isChecked)
                LoadTree(name);
            else
                UnloadTree();

        }
        private void radioStation_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged (radioStation.Checked, "Station");
        }

        private void radioFood_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioFood.Checked, "Food");
        }

        private void radioLoss_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioLoss.Checked, "Loss");
        }

        private void radioDisposition_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioDisposition.Checked, "Disposition");
        }

        private void radioDayPart_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(radioDayPart.Checked, "Daypart");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.ultraGrid1.ActiveRow.Band.Key, "Type"))
            {
                ReportViewer frm = new ReportViewer();//currReportType, this.ultraGrid1.ActiveRow.Cells["TypeID"].Value.ToString(), 
                //    this.ultraGrid1.ActiveRow.Cells["TypeName"].Value.ToString());
                frm.Show();
            }
            else
                MessageBox.Show("No data was selected for the report " );
            this.Close();
        }

        private void ReportDetails_Load(object sender, EventArgs e)
        {
            currTypeCatalog = "0"; // Master by Default
            // create and populate original DataTable 
            //Dataset to hold data
            DataTable siteDataTable = new DataTable();
            string select =
                @"SELECT ID, LicensedSite, TypeCatalogID FROM Sites WHERE Active = true;";
            siteDataTable = VWA4Common.DB.Retrieve(select);
            cboSites.Items.Add(new VWA4Common.VWACommon.MyListBoxItem("Master", "0"));
            cboSites.SelectedIndex = 0;
            foreach (DataRow row in siteDataTable.Rows)
            {
                cboSites.Items.Add(new VWA4Common.VWACommon.MyListBoxItem(row.ItemArray[1].ToString(), row.ItemArray[2].ToString()));
            }
        }

        private void cboSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            VWA4Common.VWACommon.MyListBoxItem mli = (VWA4Common.VWACommon.MyListBoxItem)cboSites.SelectedItem;
            if (mli.ItemData != currTypeCatalog)
            {
                currTypeCatalog = mli.ItemData;
                UnloadTree();
                LoadTree(currReportType);
            }
        }
    }
}
