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
    public partial class frmServiceManagement : Form
    {
        public frmServiceManagement()
        {
            InitializeComponent();
        }

        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServiceName.Text))
                {
                    throw new FormatException("No service name");
                }
                if (string.IsNullOrWhiteSpace(rtbServiceDescription.Text))
                {
                    throw new FormatException("No service description");
                }
                

                else
                {
                    Service service = new Service(txtServiceName.Text, rtbServiceDescription.Text);
                    MessageBox.Show("Successfully created service", "Yay");
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
