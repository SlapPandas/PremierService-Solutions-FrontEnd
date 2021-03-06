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
        #region Declarations
        Specialisation SP = new Specialisation();
        List<Specialisation> lstspecial = new List<Specialisation>();
        BindingSource bindingSource;

        public frmManageSpecialisation()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void frmAddSpecialisation_Load(object sender, EventArgs e)
        {
            lstspecial = SP.SelectSpecialisationList();
            dgvAddSpecial.DataSource = lstspecial;
            txtName.Focus();
            dgvAddSpecial.AutoResizeColumns();
            dgvAddSpecial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

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

        private void dgvAddSpecial_SelectionChanged(object sender, EventArgs e)
        {
            Updatefields(dgvAddSpecial.CurrentCell.RowIndex);
        }
        #endregion

        #region Methods


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
            if (index <= dgvAddSpecial.RowCount - 1)
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
            if (txtName.Text == "" || rtbDescription.Text == "" || txtName.Text == "" && rtbDescription.Text == "")
            {
                MessageBox.Show("Please enter data!", "Insert Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure to insert the specialisation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = 0; i < dgvAddSpecial.Rows.Count; i++)
                {
                    if (txtName.Text == dgvAddSpecial.Rows[i].Cells[1].Value.ToString() && rtbDescription.Text == dgvAddSpecial.Rows[i].Cells[2].Value.ToString())
                    {
                        MessageBox.Show("This is a duplicate. Please enter new data.","Insert Error",MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        txtName.Clear();
                        rtbDescription.Clear();
                        txtName.Focus();
                        return;
                    } 
                };
                    lstspecial.Add(new Specialisation(txtName.Text, rtbDescription.Text));
                    SP.InsertSpecialisation(lstspecial[lstspecial.Count - 1]);

                    MessageBox.Show("The specialisation has been inserted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    rtbDescription.Clear();
                    RefreshDGV();
            }
        }
        #endregion

        #region Update Client
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || rtbDescription.Text == "" || txtName.Text == "" && rtbDescription.Text == "")
            {
                MessageBox.Show("Please select data to update!", "Insert Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to update the specialisation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {                
                lstspecial[dgvAddSpecial.CurrentCell.RowIndex] = new Specialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex].SpecialisationID,txtName.Text,rtbDescription.Text);
                SP.UpdateSpecialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex]);
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);

                MessageBox.Show("The specialisation has been updated.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtName.Clear();
                rtbDescription.Clear();
                txtName.Focus();
                RefreshDGV();
            }            
        }
        #endregion

        #region Delete Client
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || rtbDescription.Text == "" || txtName.Text == "" && rtbDescription.Text == "")
            {
                MessageBox.Show("Please select data to delete!", "Insert Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure to delete the specialisation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                
                lstspecial[dgvAddSpecial.CurrentCell.RowIndex] = new Specialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex].SpecialisationID, txtName.Text, rtbDescription.Text);
                SP.DeleteSpecialisation(lstspecial[dgvAddSpecial.CurrentCell.RowIndex]);
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);

                MessageBox.Show("The specialisation has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                rtbDescription.Clear();
                txtName.Focus();
                RefreshDGV();
                Updatefields(dgvAddSpecial.CurrentCell.RowIndex);
            }     
        }

        #endregion
      
    }
}
