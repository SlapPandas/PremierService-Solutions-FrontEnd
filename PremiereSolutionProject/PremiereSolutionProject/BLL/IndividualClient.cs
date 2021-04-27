using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL
{
    class IndividualClient : Client
    {
        #region Fields
        private string firstName;
        private string surname;
        private string nationalIDnumber;
        private string email;
        #endregion

        #region Properties
        public string FirstName { get => firstName; set => firstName = value; }
        public string Surname { get => surname; set => surname = value; }
        public string NationalIDnumber { get => nationalIDnumber; set => nationalIDnumber = value; }
        public string Email { get => email; set => email = value; }
        #endregion

        #region Constructors
        //default constructor
        public IndividualClient()
        {
        }

        //constructor with all fields, inheriting from base class Client
        public IndividualClient(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool active) :
            base(id, address, contactnr, date, active)
        {
            this.firstName = fname;
            this.surname = sname;
            this.nationalIDnumber = natID;
            this.email = email;
        }

        //constructor without ID field
        public IndividualClient(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool active) :
            base(address, contactnr, date, active)
        {
            this.firstName = fname;
            this.surname = sname;
            this.nationalIDnumber = natID;
            this.email = email;
        }
        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Client clientFromPL)
        {
            ClientFactory clientFactory = new ClientFactory();
            //make use of method in factory to create a new instance of a CalLCenterEmployee
            IndividualClient myClient = (IndividualClient)clientFactory.GetEntity("I");
            myClient = (IndividualClient)clientFromPL;
            return myClient;
        }
        public override List<Client> CreateList()
        {
            List<Client> myClientList = new List<Client>();
            //to get all business clients from the database (DAL)
            //might need a cast
            return myClientList;
        }
        #endregion

        #region Methods
        public void InsertIndividualClient(IndividualClient ic)
        {
            IndividualClientDH indClientDH = new IndividualClientDH();
            indClientDH.Insert(ic);
        }
        public List<IndividualClient> SelectIndividualClients()
        {
            IndividualClientDH indClientDH = new IndividualClientDH();
            return indClientDH.SelectAllIndividualClients();  //this name should change .. 
        }

        public void UpdateIndividualClient(IndividualClient ic)
        {
            IndividualClientDH indClientDH = new IndividualClientDH();
            indClientDH.Update(ic);
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
