using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class ServiceRequest
    {

        #region Fields
        private int serviceRequestID;
        private int callID;
        private Boolean closed;
        private string description;
        private List<Specialisation> specialisationRequiredList;
        private List<string> spesialisationRequiredNumberEmployees;     //Gardening4
        private string priorityLevel;
        #endregion

        #region Properties
        public int ServiceRequestID { get => serviceRequestID; set => serviceRequestID = value; }
        public bool Closed { get => closed; set => closed = value; }
        public string Description { get => description; set => description = value; }
        public int CallID { get => callID; set => callID = value; }
        internal List<Specialisation> SpecialisationRequiredList { get => specialisationRequiredList; set => specialisationRequiredList = value; }
        public List<string> SpesialisationRequiredNumberEmployees { get => spesialisationRequiredNumberEmployees; set => spesialisationRequiredNumberEmployees = value; }
        public string PriorityLevel { get => priorityLevel; set => priorityLevel = value; }
        #endregion

        #region Constructors

        public event Action OnInitialization;

        //default constructor
        public ServiceRequest()
        {

        }

        //constructor with all fields
        public ServiceRequest(int sRequestID, bool c, string desc, int callID, List<Specialisation> specRequired, string priority)
        {
            this.serviceRequestID = sRequestID;
            this.closed = c;
            this.description = desc;
            this.callID = callID;
            this.specialisationRequiredList = specRequired;
            this.priorityLevel = priority;
        }

        //constructor with all fields except ID
        public ServiceRequest(bool c, string desc, int callID, List<Specialisation> specRequired, string priority)
        {
            this.closed = c;
            this.description = desc;
            this.callID = callID;
            this.specialisationRequiredList = specRequired;
            this.priorityLevel = priority;
        }
        public ServiceRequest(string desc, int callID, List<string> specRequired, Action callback)
        {
            this.OnInitialization += callback;
            callback = service_OnInitialization;
            this.description = desc;
            this.callID = callID;
            this.spesialisationRequiredNumberEmployees = specRequired;
            if (OnInitialization != null) OnInitialization();
        }
        public ServiceRequest(string desc, int callID, List<string> specRequired)
        {
            this.description = desc;
            this.callID = callID;
            this.spesialisationRequiredNumberEmployees = specRequired;
            if (OnInitialization != null) OnInitialization();
        }

        public void service_OnInitialization()
        {
            Console.WriteLine("Service request has been instantiated");
            
            //CreateJobs(this);
        }

        //constructor with all fields except ID
        public ServiceRequest(bool c, string desc, int callID, List<string> specRequiredNumEmp, string priority)
        {
            this.closed = c;
            this.description = desc;
            this.callID = callID;
            this.spesialisationRequiredNumberEmployees = specRequiredNumEmp;
            this.priorityLevel = priority;
        }

        public ServiceRequest(string desc, int callID, List<Specialisation> specRequired, string priority)
        {
            this.closed = false;
            this.description = desc;
            this.callID = callID;
            this.specialisationRequiredList = specRequired;
            this.priorityLevel = priority;
        }
        public ServiceRequest(int callID, bool closed, string desc, string priority)
        {
            this.closed = closed;
            this.description = desc;
            this.callID = callID;
            this.priorityLevel = priority;
        }
        public ServiceRequest(int ID, bool closed)
        {
            this.closed = closed;
            this.serviceRequestID = ID;
        }
        public ServiceRequest(int ID, string desc, string prio)
        {
            this.serviceRequestID = ID;
            this.description = desc;
            this.priorityLevel = prio;
        }
        #endregion

        #region Methods

        public List<ServiceRequest> SelectAllServiceRequests()
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            return serviceRequestDH.SelectAllServiceRequests();
        }

        public List<ServiceRequest> SelectAllServiceRequestsForClient(string ID)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            List<ServiceRequest> clientServiceRequests = ID[0] == 'A' ? serviceRequestDH.SelectAllServiceRequestsByIndividualClient(ID) : ID[0] == 'B' ? serviceRequestDH.SelectAllServiceRequestsByBusinessClient(ID) : null;
            return clientServiceRequests;
        }

        public void CreateServiceRequest(ServiceRequest s)
        {
            CallDH callDH = new CallDH();
            ContractDH contractDH = new ContractDH();
            string clientId = "-1", proirity = "";
            Call call = callDH.SelectCallById(s.callID);
            if (call.Busclient != null)
            {
                clientId = call.Busclient.Id;
                proirity = contractDH.SelectContractByBusinessClientIdCurrentlyActive(clientId).PriorityLevel;
            }
            if (call.Indclient != null)
            {
                clientId = call.Indclient.Id;
                proirity = contractDH.SelectContractByIndividualClientIdCurrentlyActive(clientId).PriorityLevel;
            }
            InsertServiceRequestWithSpecialisation(new ServiceRequest(false, s.description, s.callID, GenerateSpecialisationList(s.spesialisationRequiredNumberEmployees), proirity)); //insert new service request directly into DB
        }

        private List<Specialisation> GenerateSpecialisationList(List<string> specialisationEmpList)
        {
            List<string> specNames = new List<string>();
            SpecializationDH specializationDH = new SpecializationDH();
            Regex r = new Regex("[^a-z]", RegexOptions.IgnoreCase); //returns only the letters

            //taking the numbers out and adding the letters only to a list of string to match the name
            for (int i = 0; i < specialisationEmpList.Count; i++)
            {
                string[] stringList = specialisationEmpList[i].Split(',');

                specNames.Add(stringList[0]);


                //specNames.Add(r.Replace(specialisationEmpList[i], @""));
            }
            List<Specialisation> allSpecialisations = specializationDH.SelectAllSpecialisations(); //get list of all specialisations
            List<Specialisation> specList = new List<Specialisation>();

            for (int i = 0; i < specialisationEmpList.Count; i++)
            {
                specList.Add(MatchSpecialisation(specNames[i], allSpecialisations));
            }

            return specList;
            //returns a list of Specialisations
        }

        private List<int> GetNumEmployeesForJob(List<string> specialisationEmpList)
        {
            List<int> specEmployees = new List<int>();
            //taking the numbers out and adding the letters only to a list of string to match the name
            for (int i = 0; i < specialisationEmpList.Count; i++)
            {
                specEmployees.Add(int.Parse(Regex.Replace(specialisationEmpList[i], @"[^\d]", "")));
            }
            return specEmployees;
        }

        private Specialisation MatchSpecialisation(string specName, List<Specialisation> specList)
        {
            foreach (Specialisation spec in specList)
            {
                if (spec.SpecialisationName == specName)
                {
                    return spec;
                }
            }

            return null;
        }

        private int InsertServiceRequestReturnID (ServiceRequest sr)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            sr.specialisationRequiredList = GenerateSpecialisationList(sr.spesialisationRequiredNumberEmployees);
            return serviceRequestDH.InsertWithSpecilizationListWithReturnedId(sr);
        }

        public void CreateJobs(ServiceRequest sr) //creates all the jobs from a call
        {
            sr.closed = false;
            List<Job> jobList = new List<Job>();
            CallDH callDH = new CallDH();
            sr.serviceRequestID = InsertServiceRequestReturnID(sr); // insert the SR into database and return the SR ID
            Call c = callDH.SelectCallById(sr.callID);    //select call using SR ID
            ContractDH contractDH = new ContractDH();
            if (c.Indclient.Id != null)
            {
                Contract contract = contractDH.SelectContractByIndividualClientIdCurrentlyActive(c.Indclient.Id);
                sr.priorityLevel = contract.PriorityLevel;
            }
            else if(c.Busclient.Id != null)
            {
                Contract contract = contractDH.SelectContractByBusinessClientIdCurrentlyActive(c.Busclient.Id);
                sr.priorityLevel = contract.PriorityLevel;
            }
            
            List<int> employeesPerJob = GetNumEmployeesForJob(sr.spesialisationRequiredNumberEmployees);  //getting corresponding number of employees            
            //to generate all the jobs for the service request according to the specialisations required
            //create all jobs for a service request
            if (c.Indclient == null)
            {
                for (int i = 0; i < sr.specialisationRequiredList.Count; i++) //iterating thru the specialisations in the list
                {
                    jobList.Add(new Job(c.Busclient.Address, JobState.Pending, c.CallNotes, null, sr.specialisationRequiredList[i], sr.serviceRequestID, employeesPerJob[i]));
                    //Maintenance employee will be null since it has not been assigned yet
                }
            }
            if (c.Busclient == null)
            {
                for (int i = 0; i < sr.specialisationRequiredList.Count; i++) //iterating thru the specialisations in the list
                {
                    jobList.Add(new Job(c.Indclient.Address, JobState.Pending, c.CallNotes, null, sr.specialisationRequiredList[i], sr.serviceRequestID, employeesPerJob[i]));
                    //Maintenance employee will be null since it has not been assigned yet
                }
            }
            
            //need to add jobs to database after being created from a service request
            JobDH jobDH = new JobDH();
            foreach (Job jobitem in jobList)
            {
                jobDH.Insert(jobitem);
            }            
        }

        public void AssignPendingJobs()
        {
            //this method is to be called whenever new jobs have been created
            //need to use the full list of jobs, according to priority level - no hanging jobs

            // declaration
            JobDH jobDH = new JobDH();
            List<MaintenanceEmployee> maintenanceEmployeesList = SelectAllAvailabeEmployees(); //get the list of available employees, WORKING
            List<Job> jobList = OrderJobList(jobDH.SelectAllPendingJobsWithPriority()); // ordered list of all unassigned (pending) jobs, WORKING
            bool jobAssigned = false;
            int empsAssigned = 0;
            int employeecount = 0;

            foreach (Job job in jobList)
            {
                //initializing
                jobAssigned = false;
                empsAssigned = 0;
                employeecount = maintenanceEmployeesList.Count; //to prevent out of bounds in list - dynamically change after employees have been removed

                for (int i = 0; i < job.EmployeesNeeded; i++)   //to assign all employees needed for the job
                {
                    for (int k = 0; k < employeecount; k++) //iterating thru the list from DAL with available employees in it
                    {
                        for (int n = 0; n < maintenanceEmployeesList[k].Specialisations.Count; n++) //go thru list of the specialisations of the employee
                        {
                            if (job.Specialisation.SpecialisationID == maintenanceEmployeesList[k].Specialisations[n].SpecialisationID) //match the emplpoyee specialisation to the specialisation needed
                            {                                
                                job.Employee.Add(maintenanceEmployeesList[k]); //add employee to list of Employees for a job                          
                                jobDH.InsertSingleEmployeeToJob(job.JobID, maintenanceEmployeesList[k].Id); //insert into EmployeeJobLink table
                                maintenanceEmployeesList.RemoveAt(k);   //employee is no longer available
                                empsAssigned++; // increase the count of employees assigned to the job, used to check if the job is filled
                                n = maintenanceEmployeesList[k-1].Specialisations.Count;  //to break out of n-for loop if correct employee was found & job was created
                            }
                        }
                        jobAssigned = empsAssigned == job.EmployeesNeeded ? true : false;   //for when all employees of the job has been assigned
                        if (jobAssigned)
                        {
                            job.JobState = JobState.InProgress; // job only goes to inProgress if job is full
                            k = maintenanceEmployeesList.Count; //to get back to foreach to go to next job when the job is full.
                        }
                    }
                }
            }
        }

        public List<MaintenanceEmployee> SelectAllAvailabeEmployees()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllAvailableMaintenanceEmployees();
        }

        private int ExtractNumber(string s)
        {
            //Regex r = new Regex(@"[^0 - 9]", RegexOptions.IgnoreCase); //returns only the numbers
            //return Int32.Parse(r.Replace(s, @""));
            return int.Parse(Regex.Replace(s, @"[^\d]", ""));
        }

        public List<Job> OrderJobList(List<Job> unorderedJoblistWithPrio)  //order list according to date & priorityLevel
        {
            CallDH callDH = new CallDH();
            List<Call> callRequests = new List<Call>(); // used to access the dates, try match the ID's
            List<Job> highestPrioList = new List<Job>();
            bool unchanged = false;
            int currentPrioLevel = 0;
            int nextPrioLevel = 0;
            DateTime currentTime = DateTime.Now;
            Job tempJob = new Job(); // used for swapping in bubble sort
            int unorderedList = unorderedJoblistWithPrio.Count - 2;
            while (!unchanged) // this is a bubble sort. uses the prio string to change the order of the 2 lists so they stay linked. results in unordered job list to be sorted by prio. NOT DATE
            {
                unchanged = true;
                for (int i = 0; i <= unorderedList; i++)  // unorderedPrioLevel.Count-1 so that it does go out of bounds
                {
                    currentPrioLevel = ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel); // compairing current item with next item
                    nextPrioLevel = ExtractNumber(unorderedJoblistWithPrio[i + 1].PriorityLevel);
                    if (nextPrioLevel < currentPrioLevel) // switch items based on prio level
                    {
                        unchanged = false;
                        tempJob = unorderedJoblistWithPrio[i];
                        unorderedJoblistWithPrio[i] = unorderedJoblistWithPrio[i + 1];
                        unorderedJoblistWithPrio[i + 1] = tempJob;
                    }
                }
            }
            foreach (Job item in unorderedJoblistWithPrio) // gets calls for time comparison.
            {
                callRequests.Add(callDH.SelectCallByJobId(item.JobID));
            }

            for (int i = 0; i < callRequests.Count; i++) // these days are  just place holders, can be changed to fit a range or otherwise
            {
                if ((currentTime - callRequests[i].EndTime).TotalDays > 2 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) <= 2)
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 4 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) <= 4 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) > 2)
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 6 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) <= 6 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) > 4)
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 8 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) <= 8 && ExtractNumber(unorderedJoblistWithPrio[i].PriorityLevel) > 6)
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
            }
            // sort the higher prio stuff to the top of the list.
            unchanged = false;
            while (!unchanged) // this is a bubble sort. uses the prio string to change the order of the 2 lists so they stay linked. results in unordered job list to be sorted by prio. NOT DATE
            {
                unchanged = true;
                for (int i = 0; i <= unorderedList; i++)  // unorderedPrioLevel.Count-1 so that it does go out of bounds
                {
                    currentPrioLevel = ExtractNumber(highestPrioList[i].PriorityLevel); // compairing current item with next item
                    nextPrioLevel = ExtractNumber(highestPrioList[i + 1].PriorityLevel);
                    if (nextPrioLevel > currentPrioLevel) // switch items based on prio level
                    {
                        unchanged = false;
                        tempJob = highestPrioList[i];
                        highestPrioList[i] = highestPrioList[i + 1];
                        highestPrioList[i + 1] = tempJob;
                    }
                }
            }
            // end sort
            int jobListLength = unorderedJoblistWithPrio.Count;
            for (int i = 0; i < highestPrioList.Count; i++)
            {
                for (int k = 0; k < jobListLength; k++)
                {
                    if (unorderedJoblistWithPrio[k] == highestPrioList[i])
                    {
                        unorderedJoblistWithPrio.RemoveAt(k);
                        unorderedJoblistWithPrio.Insert(0, highestPrioList[i]);
                    }
                }
            }
            return unorderedJoblistWithPrio; // has been ordered by prio level, with the date being applied if the job has been pending for longer than allowed per contract prio level.
        }

        public void UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.Update(serviceRequest);
        }

        public void InsertServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.Insert(serviceRequest);
        }

        public void InsertServiceRequestWithSpecialisation(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.InsertWithSpecilizationList(serviceRequest);
        }

        public void DeleteServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.Delete(serviceRequest);
        }

        public void UpdateSpecilizationListForServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.UpdateSpecializationList(serviceRequest);
        }

        public void UpdateStateOfServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.UpdateState(serviceRequest);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
