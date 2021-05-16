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
    public partial class frmManageSpecialisation : Form
    {
        Specialisation SR = new Specialisation();
        List<Specialisation> lstspecial = new List<Specialisation>();

        public frmManageSpecialisation()
        {
            InitializeComponent();
        }

       
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSpecialisation_Load(object sender, EventArgs e)
        {
            lstspecial = SR.SelectSpecialisationList();
            dgvAddSpecial.DataSource = lstspecial;
            txtName.Focus();
        }

        private void dgvAddSpecial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAddSpecial.Rows[e.RowIndex];

                txtName.Text = row.Cells["SpecialisationName"].Value.ToString();
                rtbDescription.Text = row.Cells["Description"].Value.ToString();
                SR.SpecialisationID = int.Parse(row.Cells["SpecialisationID"].Value.ToString());
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            SR.SpecialisationName = txtName.Text;
            SR.Description = rtbDescription.Text;
            SR.UpdateSpecialisation(SR);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SR.UpdateSpecialisation(SR);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SR.DeleteSpecialisation(SR);
        }
    }
}
