using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    class BusinessClient : Client
    {
        #region Fields
        private string taxNumber;
        private string businessName;
        private List<BusinessClientEmployees> employees;
        #endregion

        #region Properties
        public string TaxNumber { get => taxNumber; set => taxNumber = value; }
        public string BusinessName { get => businessName; set => businessName = value; }
        //a business client has serveral employees which will be contacting PSS
        internal List<BusinessClientEmployees> Employees { get => employees; set => employees = value; }
        #endregion

        #region Constructors
        //default constructor
        public BusinessClient()
        {
        }
        //constructor with all the fields, inheriting from base class Client
        public BusinessClient(string id, Address address, string contactnr, DateTime date, string taxNr, string bname, bool active) :
        base(id, address, contactnr, date, active)
        {
            this.taxNumber = taxNr;
            this.businessName = bname;
        }
        //constructor without ID field, inheriting from base class Client
        public BusinessClient(Address address, string contactnr, DateTime date, string taxNr, string bname, bool active) :
        base(address, contactnr, date, active)
        {
            this.taxNumber = taxNr;
            this.businessName = bname;
        }
        #endregion

        #region Methods
        //Update the BusinessClient, take in a BusinessClient from PL
        public void UpdateBusinessClient(BusinessClient BC)
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            businessClientDH.Update(BC);
        }

        //to insert a new BusinessClient into the database
        public void InsertBusinessClient(BusinessClient BC)
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            businessClientDH.Insert(BC);
        }

        public List<BusinessClient> SelectBusinessClients()
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            return businessClientDH.SelectAllBusinessClients();
        }
        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Client clientFromPL)
        {
            ClientFactory clientFactory = new ClientFactory();
            //make use of method in factory to create a new instance of a CalLCenterEmployee
            BusinessClient myClient = (BusinessClient)clientFactory.GetEntity("B");
            myClient = (BusinessClient)clientFromPL;
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
    }
}
