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

        #region Declarations

        List<Service> services; 
        List<ServicePackage> sp;
        ServicePackage sp2;
        BindingSource bs = new BindingSource();
        ServicePackage selectedP;

        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void frmServicePackageManagement_Load(object sender, EventArgs e)
        {
            dgvCurrentServicePackages.ForeColor = Color.Black;
            services = new Service().SelectAllServices();                        
            RefreshDGV();
            foreach (Service item in services)
            {
                lbxAvailable.Items.Add(item.ServiceName.ToString());
            }
            
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
        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            bool promotion;
            List<string> serviceNames = lbxAdded.Items.Cast<string>().ToList();
            ServicePackage servicePackage = new ServicePackage();
            List<ServicePackage> servicePackages = servicePackage.SelectAllServicePackage();
            bool nameMatch = false;
            if (!string.IsNullOrWhiteSpace(txtPackageName.Text) && !string.IsNullOrWhiteSpace(lbxAdded.Text) && !IsInt(txtPrice.Text) && ((cbxPromotionYes.Checked == true && cbxPromotionNo.Checked == true) || (cbxPromotionYes.Checked == false) && (cbxPromotionNo.Checked == false)) && (numUDPercentage.Value < 0) && (dtpPromotionStart.Value < dtpPromotionEnd.Value))
            {
                MessageBox.Show("Please fill in all the fields correctly");
            }
            else
            {
                foreach (var item in servicePackages)
                {
                    if (item.PackageName == txtPackageName.Text)
                    {
                        nameMatch = true;
                        MessageBox.Show("This package already exists");
                        break;
                    }
                }
                if (!nameMatch)
                {
                    List<Service> servicesTemp = new List<Service>();
                    foreach (Service item in services)
                    {
                        for (int i = 0; i < lbxAdded.Items.Count; i++)
                        {
                            if (item.ServiceName == serviceNames[i])
                            {
                                servicesTemp.Add(item);
                                break;
                            }
                        }
                    }
                    if (cbxPromotionYes.Checked == true)
                    {
                        promotion = true;
                    }
                    else
                    {
                        promotion = false;
                    }
                    servicePackage = new ServicePackage(txtPackageName.Text, servicesTemp, promotion, dtpPromotionStart.Value, dtpPromotionEnd.Value, (double)numUDPercentage.Value, int.Parse(txtPrice.Text));
                }               
            }
            servicePackage.InsertServicePackage(servicePackage);
            RefreshDGV();
            UpdateData();
        }

        private void btnUpdatePackage_Click(object sender, EventArgs e)
        {
            bool promotion;
            List<string> serviceNames = lbxAdded.Items.Cast<string>().ToList();
            Service service = new Service();
            List<Service> services = service.SelectAllServices();
            if (!string.IsNullOrWhiteSpace(txtPackageName.Text) && !string.IsNullOrWhiteSpace(lbxAdded.Text) && !IsInt(txtPrice.Text) && ((cbxPromotionYes.Checked == true && cbxPromotionNo.Checked == true) || (cbxPromotionYes.Checked == false) && (cbxPromotionNo.Checked == false)) && (numUDPercentage.Value < 0) && (dtpPromotionStart.Value < dtpPromotionEnd.Value))
            {
                MessageBox.Show("Please fill in all the fields correctly");
            }
            else
            {
                if (lbxAdded.Items.Count == 0)
                {
                    MessageBox.Show("There must be at least 1 service in the service package");
                }
                else
                {
                    List<Service> servicesTemp = new List<Service>();
                    foreach (Service item in services)
                    {
                        for (int i = 0; i < lbxAdded.Items.Count; i++)
                        {
                            if (item.ServiceName == serviceNames[i])
                            {
                                servicesTemp.Add(item);
                            }
                        }
                    }
                    if (cbxPromotionYes.Checked)
                    {
                        promotion = true;
                    }
                    else
                    {
                        promotion = false;
                    }
                    ServicePackage sp = new ServicePackage(selectedP.PackageID, txtPackageName.Text, servicesTemp, promotion, dtpPromotionStart.Value, dtpPromotionEnd.Value, (double)numUDPercentage.Value, int.Parse(txtPrice.Text));
                    sp.UpdateServicePackage(sp);
                    sp.UpdateListOfServices(sp);
                    sp.UpdatePromotionStateOfPackage(selectedP.PackageID, promotion);                    
                    RefreshDGV();
                    UpdateData();
                }                
            }            
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            // get the service packed selected in the DGV, obtain its ID and then delete it.
            ServicePackage servicePackage = new ServicePackage();
            List<ServicePackage> servicePackages = servicePackage.SelectAllServicePackage();
            string SPName = txtPackageName.Text;
            for (int i = 0; i < servicePackages.Count; i++)
            {
                if (servicePackages[i].PackageName == SPName)
                {
                    servicePackage.DeleteServicePackage(servicePackages[i]);
                    break;
                }
            }
            RefreshDGV();
            UpdateData();
        }

        #endregion

        #region Methods

        private void RefreshDGV()
        {
            sp = new ServicePackage().SelectAllServicePackage();
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
            txtPrice.Text = selectedP.ServicePrice.ToString();
            dtpPromotionEnd.Value = selectedP.PromotionEndDate;
            dtpPromotionStart.Value = selectedP.PromotionStartDate;
            numUDPercentage.Value = (decimal)selectedP.PromotionPercentage;

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

        #endregion

        private void cbxPromotionYes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPromotionYes.Checked)
            {
                cbxPromotionNo.Checked = false;
            }
        }

        private void cbxPromotionNo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPromotionNo.Checked)
            {
                cbxPromotionYes.Checked = false;
            }
        }
    }
}
