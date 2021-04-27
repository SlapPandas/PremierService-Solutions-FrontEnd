using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    class MaintenanceEmployee : Employee
    {
        #region Fields
        private List<Specialisation> specialisations;
        private Boolean available;
        #endregion

        #region Properties
        public List<Specialisation> Specialisations { get => specialisations; set => specialisations = value; }
        public bool Available { get => available; set => available = value; }
        #endregion

        #region Constructors
        public MaintenanceEmployee() // defualt constructor
        {
        }
        // normal constuctor using base class
        public MaintenanceEmployee(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, List<Specialisation> spec, bool employed, string department = "Maintenance")
        : base(id, fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
            this.Specialisations = spec;
        }
        // constructor without ID using base class
        public MaintenanceEmployee(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, List<Specialisation> spec, bool employed, string department = "Maintenance")
        : base(fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
            this.Specialisations = spec;
        }
        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Employee employeeFromPL)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            //make use of method in factory to create a new instance of a MaintenanceEmployee
            MaintenanceEmployee myEmployee = (MaintenanceEmployee)employeeFactory.GetEntity("M");
            myEmployee = (MaintenanceEmployee)employeeFromPL;
            return myEmployee;
        }
        public override List<Employee> CreateList()
        {
            List<Employee> myEmployeeList = new List<Employee>();

            return myEmployeeList;
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
