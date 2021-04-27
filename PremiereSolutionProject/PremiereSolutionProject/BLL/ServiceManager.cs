using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL
{
    class ServiceManager : Employee
    {
        #region Constructors
        public ServiceManager() // default constructor
        {
        }
        // constructor using base class
        public ServiceManager(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Service Manager")
        : base(id, fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
        }
        // constuctor without ID using base class
        public ServiceManager(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Service Manager")
        : base(fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
        }
        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Employee employeeFromPL)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            //make use of method in factory to create a new instance of a ServiceManager
            ServiceManager myEmployee = (ServiceManager)employeeFactory.GetEntity("S");
            myEmployee = (ServiceManager)employeeFromPL;
            return myEmployee;
        }
        public override List<Employee> CreateList()
        {
            List<Employee> myEmployeeList = new List<Employee>();

            return myEmployeeList;
        }
        #endregion

        #region Methods
        public void UpdateJob(Job job) //updates a job based on its ID
        {
            JobDH jDH = new JobDH();
            jDH.Update(job);
        }
        public void UpdateServiceRequest(ServiceRequest servReq) // updates a service request
        {
            ServiceRequestDH sDH = new ServiceRequestDH();
            sDH.Update(servReq);
        }
        public void UpdateJobEmployeeList(Job job) //updates the employees on a job
        {
            JobDH jDH = new JobDH();
            jDH.UpdateJobEmployeeList(job);
        }
        public void UpdateNumberOfEmployeesForJob(int id, int emps) //updates the number of employees on a job
        {
            JobDH jDH = new JobDH();
            jDH.UpdateAmountOfEmployeesRequired(id, emps);
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
