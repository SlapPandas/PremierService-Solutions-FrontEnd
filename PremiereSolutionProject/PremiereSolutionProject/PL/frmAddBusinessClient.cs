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

namespace PremiereSolutionProject.Presentation_Layer
{
    public partial class frmAddBusinessClient : Form
    {
        public frmAddBusinessClient()
        {
            InitializeComponent();
        }

        private void frmAddBusinessClient_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusinessName.Text))
                {
                    throw new FormatException("No business name");
                }
                if (string.IsNullOrWhiteSpace(txtTaxNum.Text))
                {
                    throw new FormatException("No tax number");
                }
                if (string.IsNullOrWhiteSpace(txtStreetName.Text))
                {
                    throw new FormatException("No street name");
                }
                if (string.IsNullOrWhiteSpace(txtSuburb.Text))
                {
                    throw new FormatException("No suburb");
                }
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    throw new FormatException("No city");
                }
                if (string.IsNullOrWhiteSpace(txtProvince.Text))
                {
                    throw new FormatException("No provinfce");
                }
                if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
                {
                    throw new FormatException("No postal code");
                }
                if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
                {
                    throw new FormatException("No contact number");
                }

                else
                {
                    string address = txtStreetName.Text + "," + txtSuburb.Text + "," + txtCity.Text + "," + txtProvince.Text + "," + txtPostalCode.Text;

                    BusinessClient bc = new BusinessClient(address,txtContactNumber.Text,DateTime.Now,txtTaxNum.Text,txtBusinessName.Text,true);
                    bc.InsertBusinessClient(bc);

                    MessageBox.Show("Successfully created client", "Yay");
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
