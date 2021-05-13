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
    public partial class frmServicePackageManagement : Form
    {
        List<Service> services;
        public frmServicePackageManagement()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<ServicePackage> sp;
        ServicePackage sp2;       
        BindingSource bs = new BindingSource();
        ServicePackage selectedP;
        private void frmServicePackageManagement_Load(object sender, EventArgs e)
        {
            dgvCurrentServicePackages.ForeColor = Color.Black;
            services = new Service().SelectAllServices();
            
            sp = new ServicePackage().SelectAllServicePackage();
            RefreshDGV();
            foreach (Service item in services)
            {
                lbxAvailable.Items.Add(item.ServiceName.ToString());
            }
            
        }

        private void RefreshDGV()
        {
            bs.DataSource = sp;
            dgvCurrentServicePackages.DataSource = null;
            dgvCurrentServicePackages.DataSource = bs;

        }

        private void UpdateData()
        {
            //selectedProduct
            if (selectedP.OnPromotion == true)
            {
                cbxPromotionYes.Checked = true;
                cbxPromotionNo.Checked = false;
            }
            else
            {
                cbxPromotionNo.Checked = true;
                cbxPromotionYes.Checked = false;
            }
            lbxAdded.Items.Clear();
            lbxAvailable.Items.Clear();
            foreach (Service item in services)
            {
                lbxAvailable.Items.Add(item.ServiceName.ToString());
            }
            
            foreach (var item in selectedP.ServiceList)
            {
                lbxAdded.Items.Add(item.ServiceName);
                lbxAvailable.Items.Remove(item.ServiceName);
            }

            txtPackageName.Text = selectedP.PackageName;

            dtpPromotionEnd.Value = selectedP.PromotionEndDate;
            dtpPromotionStart.Value = selectedP.PromotionStartDate;
           // numUDPercentage.Value = selectedP.PromotionPercentage;

        }

        private void dgvCurrentServicePackages_SelectionChanged(object sender, EventArgs e)
        {
            selectedP = (ServicePackage)bs.Current;
            UpdateData();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (lbxAvailable.SelectedItem != null)
            {
                lbxAdded.Items.Add(lbxAvailable.SelectedItem.ToString());
                lbxAvailable.Items.Remove(lbxAvailable.SelectedItem);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxAdded.SelectedItem != null)
            {
                lbxAvailable.Items.Add(lbxAdded.SelectedItem);
                lbxAdded.Items.RemoveAt(lbxAdded.SelectedIndex);                
            }            
        }
        bool promotion;
        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            List<Service> services = new List<Service>();
            if (!string.IsNullOrWhiteSpace(txtPackageName.Text) && !string.IsNullOrWhiteSpace(lbxAdded.Text) && !IsInt(txtPrice.Text) && ((cbxPromotionYes.Checked == true && cbxPromotionNo.Checked == true) || (cbxPromotionYes.Checked == false) && (cbxPromotionNo.Checked == false)) && (numUDPercentage.Value < 0))
            {
                MessageBox.Show("Please fill in all the field correctly");
            }
            else
            {
                // fix this im tired 
                foreach (Service item in lbxAdded.Items)
                {
                    services.Add(item);
                }
                if (cbxPromotionYes.Checked == true)
                {
                    promotion = true;
                }
                else
                {
                    promotion = false;
                }
                ServicePackage sp = new ServicePackage(txtPackageName.Text, services, promotion, dtpPromotionStart.Value, dtpPromotionEnd.Value, (double)numUDPercentage.Value, int.Parse(txtPrice.Text));
            }
        }

        public bool IsInt(string numCheck)
        {
            int temp;
            try
            {
                temp = int.Parse(numCheck);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnUpdatePackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPackageName.Text))
                {
                    throw new FormatException("No business id");
                }
                if (string.IsNullOrWhiteSpace(lbxAdded.Text))
                {
                    throw new FormatException("No added services");
                }
                if ((cbxPromotionYes.Checked == true) && (cbxPromotionNo.Checked == true))
                {
                    throw new FormatException("only one promotion check box can be ticked");
                }
                if ((cbxPromotionYes.Checked == false) && (cbxPromotionNo.Checked == false))
                {
                    throw new FormatException("One promotion check box has to be ticked");
                }
                if ((numUDPercentage.Value < 0))
                {
                    throw new FormatException("Promotion percentage cant be smaller than 0");
                }


                else
                {
                    List<Service> ser = new List<Service>();
                    foreach (Service item in lbxAdded.Items)
                    {
                        ser.Add(item);
                    }
                    if (cbxPromotionYes.Checked == true)
                    {
                        promotion = true;
                    }
                    else
                    {
                        promotion = false;
                    }

                    ServicePackage sp = new ServicePackage(txtPackageName.Text, ser, promotion, dtpPromotionStart.Value, dtpPromotionEnd.Value, (double)numUDPercentage.Value, 0);
                    sp.UpdateServicePackage(sp);
                    MessageBox.Show("Successfully updated service package", "Yay");
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPackageName.Text))
                {
                    throw new FormatException("No business id");
                }
                if (string.IsNullOrWhiteSpace(lbxAdded.Text))
                {
                    throw new FormatException("No added services");
                }
                if ((cbxPromotionYes.Checked == true) && (cbxPromotionNo.Checked == true))
                {
                    throw new FormatException("only one promotion check box can be ticked");
                }
                if ((cbxPromotionYes.Checked == false) && (cbxPromotionNo.Checked == false))
                {
                    throw new FormatException("One promotion check box has to be ticked");
                }
                if ((numUDPercentage.Value < 0))
                {
                    throw new FormatException("Promotion percentage cant be smaller than 0");
                }


                else
                {
                    List<Service> ser = new List<Service>();
                    foreach (Service item in lbxAdded.Items)
                    {
                        ser.Add(item);
                    }
                    if (cbxPromotionYes.Checked == true)
                    {
                        promotion = true;
                    }
                    else
                    {
                        promotion = false;
                    }

                    ServicePackage sp = new ServicePackage(txtPackageName.Text, ser, promotion, dtpPromotionStart.Value, dtpPromotionEnd.Value, (double)numUDPercentage.Value, 0);
                    sp.DeleteServicePackage(sp);
                    MessageBox.Show("Successfully updated service package", "Yay");
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "user input error");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, (ee.InnerException != null) ? (ee.InnerException.ToString()) : ("Error"));
            }
        }
    }
}
