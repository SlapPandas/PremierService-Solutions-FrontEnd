using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class Call
    {
        #region Fields
        private int callID;
        private DateTime startTime;
        private DateTime endTime;
        private Client client;
        private IndividualClient indclient;
        private BusinessClient busclient;
        private CallCenterEmployee employee;
        private string callNotes;
        private List<string> specialisationList;
        #endregion

        #region Properties
        public int CallID { get => callID; set => callID = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        internal Client Client { get => client; set => client = value; }
        internal CallCenterEmployee Employee { get => employee; set => employee = value; }
        public string CallNotes { get => callNotes; set => callNotes = value; }
        public List<string> SpecialisationList { get => specialisationList; set => specialisationList = value; }
        internal IndividualClient Indclient { get => indclient; set => indclient = value; }
        internal BusinessClient Busclient { get => busclient; set => busclient = value; }
        #endregion

        #region Constructors
        //default constructor
         public Call()
        {
        }

        //constructor with all fields
        public Call(int id, DateTime start, DateTime end, Client c, CallCenterEmployee ccEmp, string cNotes)
        {
            this.callID = id;
            this.startTime = start;
            this.endTime = end;
            this.client = c;
            this.employee = ccEmp;
            this.callNotes = cNotes;
        }

        public Call(int id, DateTime start, DateTime end, IndividualClient c, CallCenterEmployee ccEmp, string cNotes)
        {
            this.callID = id;
            this.startTime = start;
            this.endTime = end;
            this.Indclient = c;
            this.employee = ccEmp;
            this.callNotes = cNotes;
        }

        public Call(int id, DateTime start, DateTime end, BusinessClient c, CallCenterEmployee ccEmp, string cNotes)
        {
            this.callID = id;
            this.startTime = start;
            this.endTime = end;
            this.Busclient = c;
            this.employee = ccEmp;
            this.callNotes = cNotes;
        }

        //constructor without ID field
        public Call(DateTime start, DateTime end, Client c, CallCenterEmployee ccEmp, string cNotes)
        {
            this.startTime = start;
            this.endTime = end;
            this.client = c;
            this.employee = ccEmp;
            this.callNotes = cNotes;
        }

        public Call(int id, DateTime start, DateTime end, CallCenterEmployee ccEmp, string cNotes)
        {
            this.callID = id;
            this.startTime = start;
            this.endTime = end;
            this.employee = ccEmp;
            this.callNotes = cNotes;
        }

        public Call(int id, DateTime start, CallCenterEmployee ccEmp)
        {
            this.callID = id;
            this.startTime = start;
            this.employee = ccEmp;
        }
        #endregion

        #region Methods

        public List<string> PopulateSpecialisationList(List<string> listFromCombobox)
        {
            //from a combobox they select the specialisation(s) gathered from the call and add it to the list as the call is recorded
            //this can be passed on to service request to generate a job with the appropriate employee
            //also need the number of employees concatenated with the specialisation name

            this.specialisationList = listFromCombobox;

            return this.specialisationList;
        }

        //Generate a random CallCenterEmployee to be assigned to an incoming call
         public CallCenterEmployee GenerateRandomEmployee()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            List<CallCenterEmployee> ccEmpList = employeeDH.SelectAllCallCenterEmployeesForCall(); //list of all call center employees

            Random random = new Random();

            return ccEmpList[random.Next(ccEmpList.Count)];
        }

        public void UpdateCallNotes(int callid, string callnotes)
        {
            CallDH callDH = new CallDH();
            callDH.UpdateNotes(callid, callnotes);
        }

        public Call CreateCall()
        {
            //passes the current datetime to DAL
            //this is to initially log a call
            CallDH callDH = new CallDH();
            CallCenterEmployee c = GenerateRandomEmployee();
            int callID = callDH.Insert(DateTime.Now, c.Id);
            Call call = new Call(callID, DateTime.Now, c);
            return call;
        }

        public void LogClientToCall(int callID, string clientID)
        {
            CallDH callDH = new CallDH();

            if (clientID[0] == 'A')
            {
                callDH.InsertIndividualClientToCall(callID, clientID);
            }
            else if (clientID[0] == 'B')
            {
                callDH.InsertBusinessClientToCall(callID, clientID);
            }
            // do I need to make something here to show if it did not work?
            //there is no return value, so i cannot retun null.
        }

        public void LogEndTimeOfCall(int callID, string notes)
        {
            CallDH callDH = new CallDH();
            callDH.UpdateNotes(callID, notes);
            callDH.InsertEndTime(callID, DateTime.Now);
        }
        
        //To select all the calls of a specific client according to ID
        public List<Call> SelectAllCallsOfClient(string ID)
        {
            CallDH callDH = new CallDH();
            List<Call> clientCalls = ID[0] == 'A' ? callDH.SelectAllCallByIndividualClientById(ID) : ID[0] == 'B' ? callDH.SelectAllCallByBusinessClientById(ID) : null;
            return clientCalls;
        }
        #endregion

        #region Overloads
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
