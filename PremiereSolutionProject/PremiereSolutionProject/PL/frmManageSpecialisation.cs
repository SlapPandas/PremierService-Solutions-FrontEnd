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

        private void WhatToUpdate()
        {
            SR.SpecialisationID = int.Parse(txtID.Text);
            SR.SpecialisationName = txtName.Text;
            SR.Description = rtbDescription.Text;
        }

        #region Cell clicking
        private void dgvAddSpecial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Place;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAddSpecial.Rows[e.RowIndex];

                txtID.Text = row.Cells["SpecialisationID"].Value.ToString();
                Place = int.Parse(txtID.Text);
                txtName.Text = row.Cells["SpecialisationName"].Value.ToString();
                rtbDescription.Text = row.Cells["Description"].Value.ToString();
                SR.SpecialisationID =  Place;//int.Parse(row.Cells["SpecialisationID"].Value.ToString());
            }
        }
        #endregion

        #region Insert Client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            WhatToUpdate();
            SR.InsertSpecialisation(SR);
            MessageBox.Show("The specialisation has been inserted.","Information",MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
        }
        #endregion

        #region Update Client
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WhatToUpdate();
            DialogResult dr = MessageBox.Show("Are you sure to update the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SR.UpdateSpecialisation(SR);
            }
            MessageBox.Show("The specialisation has been updated.", "Information", MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
        }
        #endregion

        #region Delete Client
        private void btnDelete_Click(object sender, EventArgs e)
        {
            WhatToUpdate();
            DialogResult dr = MessageBox.Show("Are you sure to delete the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SR.DeleteSpecialisation(SR);
            }
            MessageBox.Show("The specialisation has been deleted.", "Information", MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
        }
        #endregion
    }
}
