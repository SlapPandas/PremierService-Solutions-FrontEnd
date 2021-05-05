using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class Job
    {
        #region Fields
        private int jobID;
        private Address jobAddress;
        private JobState jobState;
        private string jobNotes;
        private Specialisation specialisation;
        private List<MaintenanceEmployee> employee;
        private int serviceRequestID;
        private int employeesNeeded;
        private string priorityLevel;
        #endregion

        #region Properties
        public int JobID { get => jobID; set => jobID = value; }
        public Address JobAddress { get => jobAddress; set => jobAddress = value; }
        public string JobNotes { get => jobNotes; set => jobNotes = value; }
        internal JobState JobState { get => jobState; set => jobState = JobState.Pending; }
        internal List<MaintenanceEmployee> Employee { get => employee; set => employee = value; }
        public int ServiceRequestID { get => serviceRequestID; set => serviceRequestID = value; }
        internal Specialisation Specialisation { get => specialisation; set => specialisation = value; }
        public int EmployeesNeeded { get => employeesNeeded; set => employeesNeeded = value; }
        public string PriorityLevel { get => priorityLevel; set => priorityLevel = value; }
        #endregion

        #region Constructors
        public Job() // defualt constructor
        {

        }

        //constructor with all fields
        public Job(int id, Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, int empsNeeded) // normal constructor
        {
            this.jobID = id;
            this.jobAddress = jAddress;
            this.JobState = js;
            this.jobNotes = jNotes;
            this.employee = mE;
            this.serviceRequestID = sReqID;
            this.specialisation = spec;
            this.employeesNeeded = empsNeeded;
        }

        //constructor without ID (for Insert)
        public Job(Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, int emps)
        {
            this.jobAddress = jAddress;
            this.JobState = js;
            this.jobNotes = jNotes;
            this.employee = mE;
            this.serviceRequestID = sReqID;
            this.specialisation = spec;
            this.employeesNeeded = emps;
        }
        public Job(Address jAddress, JobState js, string jNotes, Specialisation spec, int sReqID, int emps)
        {
            this.jobAddress = jAddress;
            this.JobState = js;
            this.jobNotes = jNotes;
            this.serviceRequestID = sReqID;
            this.specialisation = spec;
            this.employeesNeeded = emps;
        }

        //public Job(Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID)
        //{
        //    this.jobAddress = jAddress;
        //    this.JobState = js;
        //    this.jobNotes = jNotes;
        //    this.employee = mE;
        //    this.serviceRequestID = sReqID;
        //    this.specialisation = spec;
        //}

        //constructor with priority level - for assigning jobs
        public Job(Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, string priority, int empsNeeded)
        {
            this.jobAddress = jAddress;
            this.JobState = js;
            this.jobNotes = jNotes;
            this.employee = mE;
            this.serviceRequestID = sReqID;
            this.specialisation = spec;
            this.priorityLevel = priority;
            this.employeesNeeded = empsNeeded;
        }
        public Job(int id, Address jAddress, JobState js, string jNotes, List<MaintenanceEmployee> mE, Specialisation spec, int sReqID, string priority, int empsNeeded) // normal constructor
        {
            this.jobID = id;
            this.jobAddress = jAddress;
            this.JobState = js;
            this.jobNotes = jNotes;
            this.employee = mE;
            this.serviceRequestID = sReqID;
            this.specialisation = spec;
            this.priorityLevel = priority;
            this.employeesNeeded = empsNeeded;
        }
        #endregion

        #region Methods

        public List<Job> SelectAllJobs() // get a list of all jobs
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectAllJobsWithPriority();
        }
        public List<Job> SelectAllPendingJobsWithPriorityLevel() // get a list of all jobs
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectAllPendingJobsWithPriority();
        }

        public List<Job> SelectPendngJobs() // get a list of all pending jobs
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectAllPendingJobs();
        }

        public List<Job> SelectInProgressJobs() // get a list of all in progress jobs
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectAllInProgressJobs();
        }

        public List<Job> SelectFinishedJobs() // get a list of all finished jobs
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectAllFinishedJobs();
        }

        public List<Job> SelectAllFinishedJobsForClient(string ID)
        {
            JobDH jobDH = new JobDH();
            List<Job> jobList = ID[0] == 'A' ? jobDH.SelectAllFinishedJobsByIndividualClientID(ID) : ID[0] == 'B' ? jobDH.SelectAllFinishedJobsByBusinessClientID(ID) : null;
            return jobList;
        }

        public Job SelectJobByID(int id)
        {
            JobDH jobDH = new JobDH();
            return jobDH.SelectJobById(id);
        }

        public void UpdateJob(Job job) // update job
        {
            JobDH jobDH = new JobDH();
            jobDH.Update(job);
        }
        public void InsertJob(Job job) // insert a job
        {
            JobDH jobDH = new JobDH();
            jobDH.Insert(job);
        }
        public void InsertJobWithEmployeeList(Job job) // insert a job with an employee list
        {
            JobDH jobDH = new JobDH();
            jobDH.InsertWithEmployeeList(job);
        }
        public void DeleteJob(Job job)
        {
            JobDH jobDH = new JobDH();
            jobDH.Delete(job);
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
    public enum JobState
    {
        //we added Pending and made it the default JobState. When the job has been assigned it will change to InProgress
        Pending,
        InProgress,
        Finished
    }
}
