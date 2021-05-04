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
        List<Service> services;
        BindingSource bs = new BindingSource();
        ServicePackage selectedP;
        private void frmServicePackageManagement_Load(object sender, EventArgs e)
        {
            services = new Service().SelectAllServices();
            sp = new ServicePackage().SelectAllServicePackage();
            RefreshDGV();
            lbxAvailable.Items.Add(services);
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
            lbxAdded.Items.Add(selectedP.ServiceList);

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
            lbxAdded.Items.Add(lbxAvailable.SelectedItem.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lbxAdded.Items.RemoveAt(lbxAdded.SelectedIndex);
        }
        bool promotion;
        private void btnCreatePackage_Click(object sender, EventArgs e)
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
                    
                    ServicePackage sp = new ServicePackage(txtPackageName.Text,ser,promotion,dtpPromotionStart.Value,dtpPromotionEnd.Value,(double)numUDPercentage.Value,0);
                    sp.InsertServicePackage(sp);
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
