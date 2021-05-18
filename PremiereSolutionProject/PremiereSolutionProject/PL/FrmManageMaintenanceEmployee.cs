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
    public partial class FrmManageMaintenanceEmployee : Form
    {
        List<MaintenanceEmployee> mEmployees = new List<MaintenanceEmployee>();
        List<Specialisation> specialisationsAvailable = new List<Specialisation>();
        List<Specialisation> specialisationsHave = new List<Specialisation>();
        MaintenanceEmployee mEmployee = new MaintenanceEmployee();
        Specialisation specialisation = new Specialisation();
        BindingSource bindingSource = new BindingSource();

        public FrmManageMaintenanceEmployee()
        {
            InitializeComponent();
        }

        private void RefreshDGVAndList()
        {
            mEmployees = mEmployee.SelectAllMaintenaceEmpployees();
            List<MaintenanceEmployee> bindList = mEmployees;
            bindingSource = new BindingSource(bindList, null);
            dgvEmployee.DataSource = bindingSource;
        }
        private void RefreshDGVBoxHave(int index)
        {
            if (dgvHave.Rows.Count != 0)
            {
                dgvHave.Rows.Clear();
            }
            foreach (var item in mEmployees[index].Specialisations)
            {
                string[] row = { item.SpecialisationID.ToString(), item.SpecialisationName };
                dgvHave.Rows.Add(row);
            }
        }
        private void RefreshDGVAvailable()
        {
            specialisationsAvailable = specialisation.SelectSpecialisationList();
            foreach (var item in specialisationsAvailable)
            {
                string[] row = { item.SpecialisationID.ToString(), item.SpecialisationName };
                dgvAvailable.Rows.Add(row);
            }
        }
        private void GenerateDGV()
        {
            dgvAvailable.ColumnCount = 2;
            dgvAvailable.Columns[0].Name = "ID";
            dgvAvailable.Columns[1].Name = "Name";

            dgvHave.ColumnCount = 2;
            dgvHave.Columns[0].Name = "ID";
            dgvHave.Columns[1].Name = "Name";

            dgvEmployee.ForeColor = Color.Black;
            dgvAvailable.ForeColor = Color.Black;
            dgvHave.ForeColor = Color.Black;

            dgvAvailable.Columns[0].Width = 50;
            dgvHave.Columns[0].Width = 50;
        }

        private void FrmManageMaintenanceEmployee_Load(object sender, EventArgs e)
        {
            GenerateDGV();
            RefreshDGVAndList();
            RefreshDGVAvailable();
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDGVBoxHave(dgvEmployee.CurrentCell.RowIndex);
            specialisationsHave = mEmployees[dgvEmployee.CurrentCell.RowIndex].Specialisations;
        }

        private void dgvAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAvailable.CurrentCell.RowIndex <= dgvAvailable.RowCount - 2)
            {
                txtDescription.Text = specialisationsAvailable[dgvAvailable.CurrentCell.RowIndex].Description;
            }
        }

        private void btnGive_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < specialisationsHave.Count; i++)
            {
                if (specialisationsHave[i].SpecialisationID.ToString().Contains(specialisationsAvailable[dgvAvailable.CurrentCell.RowIndex].SpecialisationID.ToString()))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                string[] row = { specialisationsAvailable[dgvAvailable.CurrentCell.RowIndex].SpecialisationID.ToString(), specialisationsAvailable[dgvAvailable.CurrentCell.RowIndex].SpecialisationName };
                dgvHave.Rows.Add(row);
                specialisationsHave.Add(specialisationsAvailable[dgvAvailable.CurrentCell.RowIndex]);
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            if (dgvHave.Rows.Count > 1)
            {
                for (int i = 0; i < specialisationsHave.Count; i++)
                {
                    if (specialisationsHave[i].SpecialisationID.ToString().Contains(dgvHave.Rows[dgvHave.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                    {
                        specialisationsHave.RemoveAt(i);
                        break;
                    }
                }
                dgvHave.Rows.RemoveAt(dgvHave.CurrentCell.RowIndex);
            }
            else
            {
                MessageBox.Show("Please insure that the list of specilizations is not zero");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Update EmployeeList?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (specialisationsHave.Count > 0)
                {
                    mEmployees[dgvEmployee.CurrentCell.RowIndex].Specialisations = specialisationsHave;
                    mEmployee.UpdateSpecialisationOfMaintenanceEmployee(mEmployees[dgvEmployee.CurrentCell.RowIndex]);
                }
                else
                {
                    MessageBox.Show("Please insure that the list of specilizations is not zero");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
