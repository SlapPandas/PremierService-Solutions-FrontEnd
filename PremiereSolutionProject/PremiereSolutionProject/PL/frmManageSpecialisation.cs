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
        #region Fields
        Specialisation SP = new Specialisation();
        List<Specialisation> lstspecial = new List<Specialisation>();
        BindingSource bindingSource = new BindingSource();
        #endregion

        public frmManageSpecialisation()
        {
            InitializeComponent();
        }

        #region Function buttons
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            rtbDescription.Clear();
            txtName.Focus();
        }
        #endregion

        #region Load and methods
        private void frmAddSpecialisation_Load(object sender, EventArgs e)
        {
            lstspecial = SP.SelectSpecialisationList();
            dgvAddSpecial.DataSource = lstspecial;
            txtName.Focus();
        }

        private void WhatToUpdate()
        {
<<<<<<< Updated upstream
            MessageBox.Show($"{txtID.Text}");
            SR.SpecialisationID = int.Parse(txtID.Text);
            SR.SpecialisationName = txtName.Text;
            SR.Description = rtbDescription.Text;
=======
            SP.SpecialisationID = int.Parse(txtID.Text);
            SP.SpecialisationName = txtName.Text;
            SP.Description = rtbDescription.Text;
        }

        private void RefreshDGV()
        {
            lstspecial = SP.SelectSpecialisationList();
            List<Specialisation> bindList = lstspecial;
            bindingSource = new BindingSource(bindList, null);
            dgvAddSpecial.DataSource = bindingSource;
>>>>>>> Stashed changes
        }
        #endregion

        #region Cell clicking
        private void dgvAddSpecial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAddSpecial.Rows[e.RowIndex];

                txtID.Text = row.Cells["SpecialisationID"].Value.ToString();
                txtName.Text = row.Cells["SpecialisationName"].Value.ToString();
                rtbDescription.Text = row.Cells["Description"].Value.ToString();
<<<<<<< Updated upstream
                //SR.SpecialisationID =  Place;//int.Parse(row.Cells["SpecialisationID"].Value.ToString());
=======
>>>>>>> Stashed changes
            }
        }
        #endregion

        #region Insert Client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            SR.SpecialisationName = txtName.Text;
            SR.Description = rtbDescription.Text;
            SR.InsertSpecialisation(SR);
            MessageBox.Show("The specialisation has been inserted.","Information",MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
=======
            if (!(String.IsNullOrEmpty(txtName.Text) && String.IsNullOrEmpty(rtbDescription.Text)))
            {
                WhatToUpdate();
                SP.InsertSpecialisation(SP);
                MessageBox.Show("The specialisation has been inserted.", "Information", MessageBoxButtons.OK);
                txtName.Clear();
                rtbDescription.Clear();
                RefreshDGV();
            }          
>>>>>>> Stashed changes
        }
        #endregion

        #region Update Client
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WhatToUpdate();
            DialogResult dr = MessageBox.Show("Are you sure to update the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SP.UpdateSpecialisation(SP);
            }
            MessageBox.Show("The specialisation has been updated.", "Information", MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
            RefreshDGV();
        }
    
        #endregion

        #region Delete Client
        private void btnDelete_Click(object sender, EventArgs e)
        {
            WhatToUpdate();
            DialogResult dr = MessageBox.Show("Are you sure to delete the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SP.DeleteSpecialisation(SP);
            }
            MessageBox.Show("The specialisation has been deleted.", "Information", MessageBoxButtons.OK);
            txtName.Clear();
            rtbDescription.Clear();
            RefreshDGV();
    }
}
        #endregion
}
