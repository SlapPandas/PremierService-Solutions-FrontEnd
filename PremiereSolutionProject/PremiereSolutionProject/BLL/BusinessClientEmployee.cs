using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL
{
    class BusinessClientEmployees
    {
        #region Fields
        private int id;
        private string firstName;
        private string surname;
        private string department;
        private string contactnumber;
        private string email;
        private string businessName;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Department { get => department; set => department = value; }
        public string Contactnumber { get => contactnumber; set => contactnumber = value; }
        public string Email { get => email; set => email = value; }
        public string BusinessName { get => businessName; set => businessName = value; }
        #endregion

        #region Constructors
        //default constructor
        public BusinessClientEmployees()
        {

        }

        //constructor with all fields
        public BusinessClientEmployees(int id, string fname, string sname, string depart, string contact, string email, string businessName)
        {
            this.id = id;
            this.firstName = fname;
            this.surname = sname;
            this.department = depart;
            this.contactnumber = contact;
            this.email = email;
            this.businessName = businessName;
        }

        //constructor without ID field
        public BusinessClientEmployees(string fname, string sname, string depart, string contact, string email, string businessName)
        {
            this.firstName = fname;
            this.surname = sname;
            this.department = depart;
            this.contactnumber = contact;
            this.email = email;
            this.businessName = businessName;
        }
        #endregion

        #region Methods

        //get list of all BusinessClientEmployees
        public List<BusinessClientEmployees> SelectAllBusinessClientEmployees()
        {
            BusinessClientEmployeesDH businessClientEmpsDH = new BusinessClientEmployeesDH();
            return businessClientEmpsDH.SelectAllBusinessClientEmployees();
        }

        //get list of all BusinessClientEmployees from a specific business
        public List<BusinessClientEmployees> SelectAllBusinessClientEmployeesByBusinessName(string businessID)
        {
            BusinessClientEmployeesDH businessClientEmpsDH = new BusinessClientEmployeesDH();
            return businessClientEmpsDH.SelectAllBusinessClientEmployeesByBusinessId(businessID);
        }

        public void UpdateBusinessClientEmployee(BusinessClientEmployees businessClientEmployees)
        {
            BusinessClientEmployeesDH businessClientEmployeesDH = new BusinessClientEmployeesDH();
            businessClientEmployeesDH.Update(businessClientEmployees);
        }

        public void InsertBusinessClientEmployee(BusinessClientEmployees businessClientEmployees)
        {
            BusinessClientEmployeesDH businessClientEmployeesDH = new BusinessClientEmployeesDH();
            businessClientEmployeesDH.Insert(businessClientEmployees);
        }

        public void DeleteBusinessClientEmployee(BusinessClientEmployees businessClientEmployee)
        {
            BusinessClientEmployeesDH businessClientEmployeesDH = new BusinessClientEmployeesDH();
            businessClientEmployeesDH.Delete(businessClientEmployee);
        }

        #endregion

    }
}
