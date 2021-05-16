using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PremiereSolutionProject.BLL;

namespace PremiereSolutionProject.PL
{
    public partial class frmErrorHandling : Form
    {

        public frmErrorHandling()
        {
            InitializeComponent();
        }

        #region Declarations

        DatabaseOperation databaseOperation = new DatabaseOperation();
        List<DatabaseOperation> databaseOperations = new List<DatabaseOperation>();

        #endregion

        #region Events
        private void frmErrorsHandling_Load(object sender, EventArgs e)
        {
            databaseOperations = databaseOperation.SelectAllErrors();
            GenerateListColumns();
            FillListView();
        }

        private void lstErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescription.Text = databaseOperations[lstErrors.FocusedItem.Index].Description;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods
        private void GenerateListColumns()
        {
            ColumnHeader idHeader, dateHeared, successHeader, descriptionHeader;
            idHeader = new ColumnHeader();
            dateHeared = new ColumnHeader();
            successHeader = new ColumnHeader();
            descriptionHeader = new ColumnHeader();
            
            idHeader.Text = "Error Id";
            idHeader.TextAlign = HorizontalAlignment.Left;
            idHeader.Width = 70;

            dateHeared.Text = "Date and Time Occured";
            dateHeared.TextAlign = HorizontalAlignment.Left;
            dateHeared.Width = 150;

            successHeader.Text = "Successful";
            successHeader.TextAlign = HorizontalAlignment.Left;
            successHeader.Width = 200;

            descriptionHeader.Text = "Successful";
            descriptionHeader.TextAlign = HorizontalAlignment.Left;
            descriptionHeader.Width = 200;

            lstErrors.Columns.Add(idHeader);
            lstErrors.Columns.Add(dateHeared);
            lstErrors.Columns.Add(successHeader);
            lstErrors.Columns.Add(descriptionHeader);

            lstErrors.FullRowSelect = true;
        }

        private void FillListView()
        {
            foreach (var item in databaseOperations)
            {
                lstErrors.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.DateAndTime.ToString(), item.Success.ToString(), item.Description.ToString() }));
            }
        }
        #endregion
    }
}
