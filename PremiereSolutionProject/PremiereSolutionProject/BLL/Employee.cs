using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.BLL.Interfaces;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    abstract class Employee : IEntity
    {
        #region Fields
        private string id;
        private string firstName;
        private string surname;
        private Address address;
        private string contactNumber;
        private string email;
        private string nationalIDnumber;
        private DateTime registrationDate;
        private bool employed;
        private string department;
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }
        public Address Address { get => address; set => address = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Email { get => email; set => email = value; }
        public string NationalIDnumber { get => nationalIDnumber; set => nationalIDnumber = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public bool Employed { get => employed; set => employed = value; }
        public string Department { get => department; set => department = value; }
        #endregion

        #region Constructors
        //default constructor
        public Employee()
        {
        }

        //constructor with all the fields
        public Employee(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department)
        {
            this.id = id;
            this.firstName = fname;
            this.surname = sname;
            this.address = address;
            this.contactNumber = contactnr;
            this.email = email;
            this.nationalIDnumber = natID;
            this.registrationDate = date;
            this.employed = employed;
            this.department = department;
        }

        //copnstructor with all fields except ID
        public Employee(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department)
        {
            this.firstName = fname;
            this.surname = sname;
            this.address = address;
            this.contactNumber = contactnr;
            this.email = email;
            this.nationalIDnumber = natID;
            this.registrationDate = date;
            this.employed = employed;
            this.department = department;
        }
        #endregion

        #region Interface Methods
        public abstract List<Employee> CreateList();
        public abstract IEntity RegisterEntity(Employee e);
        #endregion

        #region Methods

        public void UpdateEmployee(Employee employee)
        {
            //might need to have a cast??? Will need to check when testing
            EmployeeDH employeeDH = new EmployeeDH();
            employeeDH.Update(employee);
        }

        public void InsertEmployee(Employee employee)
        {
            EmployeeDH employeeDH = new EmployeeDH();
            employeeDH.Insert(employee);
        }

        public List<Employee> SelectAllEmpployees()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            List<Employee> allEmployees = new List<Employee>();

            foreach (CallCenterEmployee callCenterEmployee in SelectAllCallCentreEmployees())
            {
                allEmployees.Add(callCenterEmployee);
            }

            foreach (MaintenanceEmployee maintenanceEmployees in SelectAllMaintenaceEmpployees())
            {
                allEmployees.Add(maintenanceEmployees);
            }

            foreach (ServiceManager serviceManager in SelectAllServiceManagers())
            {
                allEmployees.Add(serviceManager);
            }

            return allEmployees;
        }


        public List<CallCenterEmployee> SelectAllCallCentreEmployees()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllCallCenterEmployees();
        }

        public List<ServiceManager> SelectAllServiceManagers()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllServiceManagers();
        }

        public List<MaintenanceEmployee> SelectAllMaintenaceEmpployees()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllMaintenanceEmployees();
        }

        #endregion
    }
}
