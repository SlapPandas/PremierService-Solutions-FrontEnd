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
    public partial class FrmServiceRequest : Form
    {
        public FrmServiceRequest()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<Specialisation> spec;
        private void FrmServiceRequest_Load(object sender, EventArgs e)
        {
            spec = new Specialisation().SelectSpecialisationList();
            foreach (Specialisation item in spec)
            {
                cbxSpecialisation.Items.Add(item.SpecialisationName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          

            try
            {
                
                if (nudNumberOfPeople.Value == 0)
                {
                    throw new FormatException("Number of employees cant be 0");
                }

                else
                {
                    lbxSpecialisations.Items.Add(cbxSpecialisation.SelectedItem.ToString() + "," + nudNumberOfPeople.Value.ToString());


                    
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

        private void button1_Click(object sender, EventArgs e)
        {
            lbxSpecialisations.Items.RemoveAt(lbxSpecialisations.SelectedIndex);
        }
    }
}
