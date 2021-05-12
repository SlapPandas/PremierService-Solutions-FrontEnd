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

        private void frmErrorsHandling_Load(object sender, EventArgs e)
        {
            GenerateListColumns();
            DatabaseOperation databaseOperation = new DatabaseOperation();
            List<DatabaseOperation> databaseOperations = databaseOperation.SelectAllErrors();
            foreach (var item in databaseOperations)
            {
            }
        }
        private void GenerateListColumns() 
        {
            lstErrors.Columns.Add("Error Id");
            lstErrors.Columns.Add("Date and Time Occured");
            lstErrors.Columns.Add("Successful");
        }
    }
}
