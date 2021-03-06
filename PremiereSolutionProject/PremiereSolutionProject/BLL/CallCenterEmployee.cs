using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public class CallCenterEmployee : Employee
    {
        //inherits all fields and properties from Employee

        #region Constructors
        //default constructor
        public CallCenterEmployee()
        {
        }

        //constructor with all fields, inheriting from base class Employee
        //set department to preset value - "Call Center"
        public CallCenterEmployee(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Call Center")
        : base(id, fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
        }

        public CallCenterEmployee(string id, string fname, string sname): base(id, fname, sname)
        {
        }

        //contructor without ID field
        public CallCenterEmployee(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Call Center")
        : base(fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department; ;
        }

        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Employee employeeFromPL)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            //make use of method in factory to create a new instance of a CalLCenterEmployee
            CallCenterEmployee myEmployee = (CallCenterEmployee)employeeFactory.GetEntity("C");
            myEmployee = (CallCenterEmployee)employeeFromPL;
            return myEmployee;
        }

        public override List<Employee> CreateList()
        {
            List<Employee> myEmployeeList = new List<Employee>();

            return myEmployeeList;
        }

        #endregion

        #region Methods
        public void Update(CallCenterEmployee CCE)
        {
            EmployeeDH employeeDH = new EmployeeDH();
            employeeDH.UpdateCallCenterEmployee(CCE);
        }
        #endregion
    }
}
