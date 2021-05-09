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
    public partial class frmViewServiceRequests : Form
    {
        public frmViewServiceRequests()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<ServiceRequest> sr;
        BindingSource bs = new BindingSource();
        private void frmViewServiceRequests_Load(object sender, EventArgs e)
        {
            sr = new ServiceRequest().SelectAllServiceRequests();
            RefreshDGV();
        }
        private void RefreshDGV()
        {
            bs.DataSource = sr;
            dgvViewAllServiceReq.DataSource = null;
            dgvViewAllServiceReq.DataSource = bs;
        }
    }
}
