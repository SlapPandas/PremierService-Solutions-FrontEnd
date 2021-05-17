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
        Specialisation SP = new Specialisation();
        List<Specialisation> lstspecial = new List<Specialisation>();
        BindingSource bindingSource;

        public frmManageSpecialisation()
        {
            InitializeComponent();
        }

        #region Assisting buttons
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

        #region Form Load And Methods
        private void frmAddSpecialisation_Load(object sender, EventArgs e)
        {
            lstspecial = SP.SelectSpecialisationList();
            dgvAddSpecial.DataSource = lstspecial;
            txtName.Focus();
        }

        //private void WhatToUpdate()
        //{
        //    SP.SpecialisationID = int.Parse(txtID.Text);
        //    SP.SpecialisationName = txtName.Text;
        //    SP.Description = rtbDescription.Text;
        //}

        private void RefreshDGV()
        {
            lstspecial = SP.SelectSpecialisationList();
            List<Specialisation> bindList = lstspecial;
            bindingSource = new BindingSource(bindList, null);
            dgvAddSpecial.DataSource = bindingSource;
        }

        private void Updatefields(int index)
        {
            if (index >= lstspecial.Count)
            {
                index = 0;
            }
            if (index <= dgvAddSpecial.RowCount - 2)
            {
                txtID.Text = lstspecial[index].SpecialisationID.ToString();
                txtName.Text = lstspecial[index].SpecialisationName;
                rtbDescription.Text = lstspecial[index].Description;
            }
        }
        #endregion

        

        #region Insert Client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to insert the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                

                lstspecial.Add(new Specialisation(txtName.Text, rtbDescription.Text));
                SP.InsertSpecialisation(lstspecial[lstspecial.Count - 1]);

                MessageBox.Show("The specialisation has been inserted.", "Information", MessageBoxButtons.OK);
                txtName.Clear();
                rtbDescription.Clear();
                RefreshDGV();
            }
        }
        #endregion

        #region Update Client
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Are you sure to update the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                
                lstspecial[dgvAddSpecial.CurrentCell.RowIndex] = new Specialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex].SpecialisationID,txtName.Text,rtbDescription.Text);
                SP.UpdateSpecialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex]);
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);
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
            //WhatToUpdate();
            DialogResult dr = MessageBox.Show("Are you sure to delete the specialisation?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                
                lstspecial[dgvAddSpecial.CurrentCell.RowIndex] = new Specialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex].SpecialisationID, txtName.Text, rtbDescription.Text);
                SP.DeleteSpecialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex]);
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);

                MessageBox.Show("The specialisation has been deleted.", "Information", MessageBoxButtons.OK);
                txtName.Clear();
                rtbDescription.Clear();
                RefreshDGV();
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);
            }     
        }

        #endregion

        private void dgvAddSpecial_SelectionChanged(object sender, EventArgs e)
        {
            Updatefields(dgvAddSpecial.CurrentCell.RowIndex);
        }
    }
}
