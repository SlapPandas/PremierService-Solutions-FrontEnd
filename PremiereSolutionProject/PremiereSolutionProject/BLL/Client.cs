using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public abstract class Client : IEntity
    {
        #region Fields
        private string id;
        private Address address;
        private string contactNumber;
        private DateTime registrationDate;
        private bool active;
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }
        public Address Address { get => address; set => address = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public bool Active { get => active; set => active = value; }
        #endregion

        #region Constructors 
        //default constructor
        public Client()
        {
        }

        //constructor with all fields
        public Client(string id, Address address, string contactnr, DateTime date, bool active)
        {
            this.id = id;
            this.address = address;
            this.contactNumber = contactnr;
            this.registrationDate = date;
            this.active = active;
        }

        //constructor without the ID field
        public Client(Address address, string contactnr, DateTime date, bool active)
        {
            this.address = address;
            this.contactNumber = contactnr;
            this.registrationDate = date;
            this.active = active;
        }
        #endregion

        #region Interface Methods
        public abstract List<Client> CreateList();
        public abstract IEntity RegisterEntity(Client c);
        #endregion

        #region Methods

        public bool VerifyClientContract(string clientID)
        {
            ContractDH contractDH = new ContractDH();

            List<Contract> contractList = clientID[0] == 'A' ? contractDH.SelectAllContractsByIndividualClientId(clientID) :  clientID[0] == 'B' ? contractDH.SelectAllContractsByBusinessClientId(clientID) : null;
            //get contracts for a specific client

            foreach (Contract contract in contractList)
            {
                if (contract.Active)
                {
                    return false;       //returns false if client has an active contract --> cannot get a new contract
                }
            }

            return true;     //if no contract has been found to be active the client can get a new contract
        }

        public List<Client> SelectAllClients()
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            List<BusinessClient> businessClients = businessClientDH.SelectAllBusinessClients();

            IndividualClientDH individualClientDH = new IndividualClientDH();
            List<IndividualClient> individualClients = individualClientDH.SelectAllIndividualClients();

            List<Client> allClients = new List<Client>();

            foreach (IndividualClient item in individualClients)
            {
                allClients.Add(item);
            }

            foreach (BusinessClient item in businessClients)
            {
                allClients.Add(item);
            }

            return allClients;
        }

        public List<IndividualClient> SelectAllIndividualClients()
        {
            IndividualClientDH individualClientDH = new IndividualClientDH();
            List<IndividualClient> individualClients = individualClientDH.SelectAllIndividualClients();
            return individualClients;
        }
        public IndividualClient SelectAllIndividualClientByThereId(string id)
        {
            IndividualClientDH individualClientDH = new IndividualClientDH();
            IndividualClient individualClients = individualClientDH.SelectAllIndividualClientByID(id);
            return individualClients;
        }

        public List<BusinessClient> SelectAllBusinessClients()
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            List<BusinessClient> businessClients = businessClientDH.SelectAllBusinessClients();
            return businessClients;
        }
        public BusinessClient SelectAllBusinessClientsByThereId(string id)
        {
            BusinessClientDH businessClientDH = new BusinessClientDH();
            BusinessClient businessClients = businessClientDH.SelectAllBusinessClientsById(id);
            return businessClients;
        }

        public void UpdateClient(Client c)
        {
            IndividualClientDH individualClientDH = new IndividualClientDH();
            BusinessClientDH businessClientDH = new BusinessClientDH();

            if (c.id[0] == 'A')
            {
                individualClientDH.Update((IndividualClient)c);
            }
            else if (c.id[0] == 'B')
            {
                businessClientDH.Update((BusinessClient)c);
            }
        }

        //to change a client state to INACTIVE
        public void RemoveClient(Client c)
        {
            IndividualClientDH individualClientDH = new IndividualClientDH();
            BusinessClientDH businessClientDH = new BusinessClientDH();

            if (c.id[0] == 'A')
            {
                individualClientDH.ChangeClientState(c.id, false);
            }
            else if (c.id[0] == 'B')
            {
                businessClientDH.UpdateState(c.id, false);
            }
        }

        //Client myclient;
        public string GetClientType(Client client)
        {
            return client.GetType().Name;
        }

        #endregion
    }
}
