using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class Service
    {
        #region Fields
        private int serviceID;
        private string serviceName;
        private string serviceDescription;
        #endregion

        #region Properties
        public int ServiceID { get => serviceID; set => serviceID = value; }
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public string ServiceDescription { get => serviceDescription; set => serviceDescription = value; }
        #endregion

        #region Constructors
        public Service() // defualt constructor
        {

        }

        public Service(int id, string sName, string sDescription) // normal constructor
        {
            this.serviceID = id;
            this.serviceName = sName;
            this.ServiceDescription = sDescription;

        }

        public Service(string sName, string sDescription) // constructor without ID
        {
            this.serviceName = sName;
            this.ServiceDescription = sDescription;

        }
        #endregion

        #region Methods

        public List<Service> SelectAllServices() // get a list of all services 
        {
            ServiceDH serviceDH = new ServiceDH();
            return serviceDH.SelectAllServices();
        }

        public List<Service> SelectServiceListInServicePackage(ServicePackage sp) // get a list of all services within a service package
        {
            ServiceDH serviceDH = new ServiceDH();
            return serviceDH.SelectAllServiceInPackage(sp.PackageID);
        }

        public List<Service> SelectServiceListInServicePackageState(ServicePackage sp)
        {
            ServiceDH serviceDH = new ServiceDH();
            return serviceDH.SelectAllServiceInPackageState(sp.PackageID);
        }

        // get a list of all services within a service package STATE
        // this refers to all the services in contracts that have been taken out - i.e. PERMANENT records
        public List<Service> SelectServiceListbyState()
        {
            ServiceDH serviceDH = new ServiceDH();
            return serviceDH.SelectAllServicesWithState();
        }

        public void UpdateService(Service service) // update the service package
        {
            ServiceDH serviceDH = new ServiceDH();
            serviceDH.Update(service);
        }

        public void InsertService(Service service) // insert a new service package
        {
            ServiceDH serviceDH = new ServiceDH();
            serviceDH.Insert(service);
        }

        public void DeleteService(Service service) // insert a new service package
        {
            ServiceDH serviceDH = new ServiceDH();
            serviceDH.Delete(service);
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
