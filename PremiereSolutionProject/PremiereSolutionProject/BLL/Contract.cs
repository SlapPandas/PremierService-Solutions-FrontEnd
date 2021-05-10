using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class Contract
    {
        #region Fields
        private string contractID;
        private DateTime startDate;
        private DateTime endDate;
        private List<ServicePackage> packageList;
        private Client client;
        private IndividualClient indclient;
        private BusinessClient busclient;
        private bool active;
        private double price;
        private string priorityLevel;   //the code -- i.e. PLA2
        private bool helpLine;
        private int responseTime;
        private string contractType;    //recurring or non-recurring
        private int useCount;
        #endregion

        #region Properties
        public string ContractID { get => contractID; set => contractID = value; }
        public DateTime StartTime { get => startDate; set => startDate = value; }
        public DateTime EndTime { get => endDate; set => endDate = value; }
        internal Client Client { get => client; set => client = value; }
        internal List<ServicePackage> PackageList { get => packageList; set => packageList = value; }
        public bool Active { get => active; set => active = value; }
        public string PriorityLevel { get => priorityLevel; set => priorityLevel = value; }
        public bool HelpLine { get => helpLine; set => helpLine = value; }
        public int ResponseTime { get => responseTime; set => responseTime = value; }
        public double Price { get => price; set => price = value; }
        internal IndividualClient Indclient { get => indclient; set => indclient = value; }
        internal BusinessClient Busclient { get => busclient; set => busclient = value; }
        public string ContractType { get => contractType; set => contractType = value; }
        public int UseCount { get => useCount; set => useCount = value; }
        #endregion

        #region Constructors

        //default constructor
        public Contract()
        {

        }

        public Contract(string id, int useCount)
        {
            this.contractID = id;
            this.useCount = useCount;
        }

        //constructor with all the fields
        public Contract(string id, DateTime start, DateTime end, Client client, List<ServicePackage> packList, bool acti, string priorityLevel, double price, string type)
        {
            this.contractID = id;
            this.startDate = start;
            this.endDate = end;
            this.client = client;
            this.packageList = packList;
            this.active = acti;
            this.priorityLevel = priorityLevel;
            this.price = price;
            this.contractType = type;
        }

        //constructor without ID field
        public Contract(DateTime start, DateTime end, Client client, List<ServicePackage> packList, bool acti, string priorityLevel, double price, string type)
        {
            this.startDate = start;
            this.endDate = end;
            this.client = client;
            this.packageList = packList;
            this.active = acti;
            this.priorityLevel = priorityLevel;
            this.price = price;
            this.contractType = type;
        }

        //constructor with Individual Client object
        public Contract(string id, DateTime start, DateTime end, IndividualClient client, List<ServicePackage> packList, bool acti, string priorityLevel, double price, string type)
        {
            this.contractID = id;
            this.startDate = start;
            this.endDate = end;
            this.indclient = client;
            this.packageList = packList;
            this.active = acti;
            this.priorityLevel = priorityLevel;
            this.price = price;
            this.contractType = type;
        }

        //constructor with Business Client object
        public Contract(string id, DateTime start, DateTime end, BusinessClient client, List<ServicePackage> packList, bool acti, string priorityLevel, double price, string type)
        {
            this.contractID = id;
            this.startDate = start;
            this.endDate = end;
            this.busclient = client;
            this.packageList = packList;
            this.active = acti;
            this.priorityLevel = priorityLevel;
            this.price = price;
            this.contractType = type;
        }

        //constructor for adding a contract that is available to choose from (no clients assigned yet)
        public Contract(string id, DateTime start, DateTime end, List<ServicePackage> packList, string priorityLevel, double price, string type)
        {
            this.contractID = id;
            this.startDate = start;
            this.endDate = end;
            this.packageList = packList;
            this.contractType = type;
            this.priorityLevel = priorityLevel;
            this.price = price;
        }

        // no client with active parameter
        public Contract(string id, bool acti, DateTime start, DateTime end, List<ServicePackage> packList, string priorityLevel, double price, string type)
        {
            this.contractID = id;
            this.startDate = start;
            this.endDate = end;
            this.packageList = packList;
            this.active = acti;
            this.priorityLevel = priorityLevel;
            this.price = price;
            this.contractType = type;
        }
        // constuctor without ID and Price for use in PL
        public Contract(DateTime start, DateTime end, Client client, List<ServicePackage> packList, bool acti, string priorityLevel, string type)
        {

        }
        #endregion

        #region Methods
        //to display what clients can choose from
        public List<Contract> SelectAllContracts()
        {
            CheckContractEndDates();
            ContractDH contractDH = new ContractDH();
            return contractDH.SelectAllContracts();
        }
        //from contractState table - contracts that client already has
        public List<Contract> SelectAllContractOfClient(string ID)
        {
            ContractDH contractDH = new ContractDH();
            List<Contract> clientContracts = ID[0] == 'A' ? contractDH.SelectAllContractsByIndividualClientId(ID) : ID[0] == 'B' ? contractDH.SelectAllContractsByBusinessClientId(ID) : null;
            return clientContracts;
        }

        public Contract GetOfferedContractByID(string id)
        {
            ContractDH contractDH = new ContractDH();
            return contractDH.SelectOfferedContractById(id);
        }

        public Contract GetContractByIDandClient(string clientID, string contractID)
        {
            ContractDH contractDH = new ContractDH();
            Contract clientContract = clientID[0] == 'A' ? contractDH.SelectAssignedContractByIdAndIndividualClientId(clientID, contractID) : clientID[0] == 'B' ? contractDH.SelectAssignedContractByIdAndBusinessClientId(clientID, contractID) : null;
            return clientContract;
        }

        public void UpdateContract(Contract contract)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.Update(contract);
        }

        public void ChangeActiveStateOfOfferedContract(string contractID, bool active)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.UpdateOfferedContractIfActive(contractID, active);
        }

        public void ChangeActiveStateOfClientContract(string contractID, bool active)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.UpdateClientContractIfActive(contractID, active);
        }

        public void ChangeActiveStateAndDateRangeofContact(string contractID, DateTime newStartDate, DateTime newEndDate, bool active)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.UpdateActiveAndDateRangeOfOfferedContract(contractID, newStartDate, newEndDate, active);
        }

        public void UpdatePackagesInContract(Contract contract)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.UpdateContractPackageList(contract);
        }

        public void DeleteContract(Contract contract)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.Delete(contract);
        }
        
        public void InsertContract(Contract contract)
        {
            //inserts all servicePackages and inserts contracts into DB
            ContractDH contractDH = new ContractDH();
            contractDH.InsertWithPackedge(contract);
        }

        public void InsertSingleServicePackage(string contractID, int serviceRequestID)
        {
            ContractDH contractDH = new ContractDH();
            contractDH.InsertSingleServicePackedgeToContract(contractID, serviceRequestID);
        }

        public void LinkClientToContract(Contract contract)
        {
            ContractDH contractDH = new ContractDH();

            if (contract.client.Id[0] == 'A')
            {
                contractDH.InsertNewlyAssignedContractToIndividualClient(contract);
            }
            if (contract.client.Id[0] == 'B')
            {
                contractDH.InsertNewlyAssignedContractToBusinessClient(contract);
            }
        }

        //this method needs to be tested. I am not sure how it will work taking in a Client
        public void CreateNewContract(Client c, Contract contract)
        {
            //should the method maybe take in a ClientID and then just find the client according that from a list? 
            //or will PL be able to enter a client object as a parameter?
            if (c.VerifyClientContract(c.Id))
            {
                InsertContract(new Contract(contract.startDate, contract.endDate, c, contract.packageList, true, contract.priorityLevel, CalculateContractPrice(this), contract.contractType));
            }
        }
        
        public double CalculateContractPrice(Contract contract)
        {
            int daysChosen = DetermineDaysChosen(contract.priorityLevel);
            string priority = DeterminePriorityLevel(contract.priorityLevel);

            StaticVariables sv = new StaticVariables();
            ServicePackage package = new ServicePackage();
            List<ServicePackage> servicePackageList = contract.packageList; //get list of service packages in the contract

            //get sum of prices of service packages in contract
            double servicePackagePrice = 0;
            for (int i = 0; i < servicePackageList.Count; i++)
            {
                servicePackagePrice += package.CalculatePromotion(servicePackageList[i]);
            }
            switch (priority.ToLower())
            {                
                case "platinum":
                    return price = (sv.PlatinumPrice + servicePackagePrice)*(1 + (1 - ((double)daysChosen) / 8));
                case "gold":
                    return price = (sv.GoldPrice + servicePackagePrice) * (1 + (1 - ((double)daysChosen) / 8));
                case "silver":
                    return price = (sv.SilverPrice + servicePackagePrice) * (1 + (1 - ((double)daysChosen) / 8));
                case "bronze":                    
                    return price = (sv.BronzePrice + servicePackagePrice) * (1 + (1 - ((double)daysChosen) / 8));
                default:
                    return price = 0;
            }
        }

        public string DeterminePriorityLevel(string code)
        {
            string s = code.Substring(0, 3); //get first 3 letters

            switch (s.ToLower())
            {
                case "pla":
                    return "Platinum";
                case "gol":
                    return "Gold";
                case "sil":
                    return "Silver";
                case "bro":
                    return "Bronze";
                default:
                    break;
            }

            return s;
        }

        public int DetermineDaysChosen(string code)
        {
            return int.Parse(Regex.Replace(code, @"[^\d]", ""));
        }

        public List<string> GetContractPerformance()
        {
            List<string> contractPerformanceList = new List<string>();

            //get list of all contracts with the number of times they were taken out by clients from DAL
            ContractDH contractDH = new ContractDH();
            List<Contract> allContracts = contractDH.SelectAllContractsAssignedToClientWithThereUses();

            foreach (Contract item in allContracts)
            {
                contractPerformanceList.Add(item.ToString());
            }

            return contractPerformanceList;
        }

        public List<Contract> OrderContractList(List<Contract> allContracts) //takes in all contracts for the client
        {
            //sort the contracts according to date, newest first
            allContracts.Sort((p, q) => p.startDate.CompareTo(q.startDate));
            allContracts.Reverse();

            //to place active contract at the top
            int oldIndex = allContracts.Count; //for if there isnt an active contract
            for (int i = 0; i < allContracts.Count; i++)
            {
                if (allContracts[i].active)
                {
                    oldIndex = i;
                    break;
                }
            }

            Contract c = allContracts[oldIndex];
            allContracts.RemoveAt(oldIndex);
            if (oldIndex != allContracts.Count)
            {
                allContracts.Insert(0, c);
            }

            //returns list with active on top and rest sorted newest to oldest
            return allContracts;
        }

        public List<Contract> SelectActiveContracts()
        {
            ContractDH contractDH = new ContractDH();
            return contractDH.SelectAllActiveContracts();
        }

        private void CheckContractEndDates()
        {
            ContractDH contractDH = new ContractDH();
            List<Contract> allContractsOffered = contractDH.SelectAllContracts();

            foreach (Contract item in allContractsOffered)
            {
                if (item.endDate <= DateTime.Now  && item.active)
                {
                    ChangeActiveStateOfOfferedContract(item.contractID, false);
                }
            }
        }

        #endregion

        #region Overrides

        //to display contract details :) for those client can sign up for
        public override string ToString()
        {
            return contractID + "was taken out " + useCount + " times.";
        }

        public override bool Equals(object obj)
        {
            var item = obj as Contract;

            if (item == null)
            {
                return false;
            }

            return this.contractID.Equals(item.contractID);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
