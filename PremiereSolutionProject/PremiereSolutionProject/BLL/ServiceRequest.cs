using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    class ServiceRequest
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
            List<ServiceRequest> clientServiceRequests = ID[0] == 'I' ? serviceRequestDH.SelectAllServiceRequestsByIndividualClient(ID) : ID[0] == 'B' ? serviceRequestDH.SelectAllServiceRequestsByBusinessClient(ID) : null;
            return clientServiceRequests;
        }

        public void CreateServiceRequest(ServiceRequest s)
        {
            s.closed = false;
            ServiceRequest serviceRequest = new ServiceRequest(s.closed, s.description, s.callID, GenerateSpecialisationList(s.spesialisationRequiredNumberEmployees), s.priorityLevel);

            InsertServiceRequest(serviceRequest); //insert new service request directly into DB
        }

        private List<Specialisation> GenerateSpecialisationList(List<string> specialisationEmpList)
        {
            List<string> specNames = new List<string>();

            Regex r = new Regex("[^a-z]", RegexOptions.IgnoreCase); //returns only the letters

            //taking the numbers out and adding the letters only to a list of string to match the name
            for (int i = 0; i < specialisationEmpList.Count; i++)
            {
                specNames.Add(r.Replace(specialisationEmpList[i], @""));
            }
            List<Specialisation> allSpecialisations = new List<Specialisation>(); //get list of all specialisations
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

            Regex r = new Regex(@"[^0 - 9]", RegexOptions.IgnoreCase); //returns only the numbers

            //taking the numbers out and adding the letters only to a list of string to match the name
            for (int i = 0; i < specialisationEmpList.Count; i++)
            {
                specialisationEmpList[i] = r.Replace(specialisationEmpList[i], @"");
                specEmployees[i] = int.Parse(specialisationEmpList[i]);
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

        public void CreateJobs(ServiceRequest sr) //creates all the jobs from a call
        {
            List<Job> jobList = new List<Job>();
            Call c = new Call();    //from DAL where SELECTing a call according to call ID --> sr.CallID
            List<int> employeesPerJob = GetNumEmployeesForJob(this.spesialisationRequiredNumberEmployees);  //getting corresponding number of employees

            List<Specialisation> specialisationList = sr.specialisationRequiredList;
            //to generate all the jobs for the service request according to the specialisations required

            //create all jobs for a service request
            for (int i = 0; i < specialisationList.Count; i++) //iterating thru the specialisations in the list
            {
                jobList.Add(new Job(c.Client.Address, JobState.Pending, c.CallNotes, null, specialisationList[i], this.ServiceRequestID, employeesPerJob[i]));
                //Maintenance employee will be null since it has not been assigned yet
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
            List<MaintenanceEmployee> maintenanceEmployeesList = SelectAllAvailabeEmployees(); //get the list of available employees
            List<Job> jobList = OrderJobList(jobDH.SelectAllJobsWithPriority()); // ordered list of all unassigned (pending) jobs
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
                            if (job.Specialisation.Equals(maintenanceEmployeesList[k].Specialisations[n])) //match the emplpoyee specialisation to the specialisation needed
                            {
                                job.JobState = JobState.InProgress;
                                job.Employee.Add(maintenanceEmployeesList[k]); //add employee to list of Employees for a job

                                jobDH.UpdateState(job.JobID, job.JobState);  //to update the job in the db                              
                                jobDH.InsertSingleEmployeeToJob(job.JobID, maintenanceEmployeesList[k].Id); //insert into EmployeeJobLink table

                                maintenanceEmployeesList.RemoveAt(k);   //employee is no longer available

                                empsAssigned++;

                                n = maintenanceEmployeesList[k].Specialisations.Count;  //to break out of n-for loop if correct employee was found & job was created
                            }
                        }

                        jobAssigned = empsAssigned == job.EmployeesNeeded ? true : false;   //for when all employees of the job has been assigned

                        if (jobAssigned)
                        {
                            k = maintenanceEmployeesList.Count; //to get back to foreach to go to next job 
                        }
                    }
                }
            }
        }

        private List<MaintenanceEmployee> SelectAllAvailabeEmployees()
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllAvailableMaintenanceEmployees();
        }

        public List<Job> OrderJobList(List<Job> unorderedJoblistWithPrio)  //order list according to date & priorityLevel
        {
            CallDH callDH = new CallDH();
            List<Call> callRequests = new List<Call>(); // used to access the dates, try match the ID's
            List<Job> highestPrioList = new List<Job>();
            bool unchanged = false;
            string currentPrio;
            string nextPrio;
            int currentPrioLevel = 0;
            int nextPrioLevel = 0;
            DateTime currentTime = DateTime.Now;
            Job tempJob = new Job(); // used for swapping in bubble sort
            while (!unchanged) // this is a bubble sort. uses the prio string to change the order of the 2 lists so they stay linked. results in unordered job list to be sorted by prio. NOT DATE
            {
                unchanged = true;
                for (int i = 0; i <= unorderedJoblistWithPrio.Count - 1; i++)  // unorderedPrioLevel.Count-1 so that it does go out of bounds
                {
                    currentPrio = unorderedJoblistWithPrio[i].PriorityLevel; // compairing current item with next item
                    nextPrio = unorderedJoblistWithPrio[i + 1].PriorityLevel;
                    switch (currentPrio) // assigning prio level to comparible number for current item
                    {
                        case "PLA1":
                            currentPrioLevel = 4;
                            break;
                        case "GLO2":
                            currentPrioLevel = 3;
                            break;
                        case "SIL3":
                            currentPrioLevel = 2;
                            break;
                        case "BRO4":
                            currentPrioLevel = 1;
                            break;
                        default:
                            break;
                    }
                    switch (nextPrio) // assigning prio level to comparible number for next item
                    {
                        case "PLA1":
                            nextPrioLevel = 4;
                            break;
                        case "GLO2":
                            nextPrioLevel = 3;
                            break;
                        case "SIL3":
                            nextPrioLevel = 2;
                            break;
                        case "BRO4":
                            nextPrioLevel = 1;
                            break;
                        default:
                            break;
                    }
                    if (nextPrioLevel > currentPrioLevel) // switch items based on prio level
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
                if ((currentTime - callRequests[i].EndTime).TotalDays > 1 && unorderedJoblistWithPrio[i].PriorityLevel == "PLA1")
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 2 && unorderedJoblistWithPrio[i].PriorityLevel == "GLO2")
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 3 && unorderedJoblistWithPrio[i].PriorityLevel == "SLI3")
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
                if ((currentTime - callRequests[i].EndTime).TotalDays > 4 && unorderedJoblistWithPrio[i].PriorityLevel == "BRO4")
                {
                    highestPrioList.Add(unorderedJoblistWithPrio[i]);
                }
            }
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
