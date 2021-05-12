using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public class ServiceManager : Employee
    {
        #region Constructors
        public ServiceManager() // default constructor
        {
        }
        // constructor using base class
        public ServiceManager(string id, string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Service Manager")
        : base(id, fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
        }
        // constuctor without ID using base class
        public ServiceManager(string fname, string sname, Address address, string contactnr, string email, string natID, DateTime date, bool employed, string department = "Service Manager")
        : base(fname, sname, address, contactnr, email, natID, date, employed, department)
        {
            Department = department;
        }
        #endregion

        #region Interface Methods
        public override IEntity RegisterEntity(Employee employeeFromPL)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            //make use of method in factory to create a new instance of a ServiceManager
            ServiceManager myEmployee = (ServiceManager)employeeFactory.GetEntity("S");
            myEmployee = (ServiceManager)employeeFromPL;
            return myEmployee;
        }
        public override List<Employee> CreateList()
        {
            List<Employee> myEmployeeList = new List<Employee>();

            return myEmployeeList;
        }
        #endregion

        #region Methods
        public void UpdateJob(Job job) //updates a job based on its ID
        {
            JobDH jDH = new JobDH();
            jDH.Update(job);
        }

        public void UpdateJobState(int id, int state)
        {
            JobDH jobDH = new JobDH();
            JobState s = new JobState();
            switch (state)
            {
                case 0:
                    s = JobState.Pending;
                    break;
                case 1:
                    s = JobState.InProgress;
                    break;
                case 2:
                    s = JobState.Finished;
                    break;
            }
            jobDH.UpdateState(id, s);
        }

        public void UpdateEmployeestate(string id, bool state)
        {
            EmployeeDH employeeDH = new EmployeeDH();
            employeeDH.UpdateEmployeeState(id, state);
        }

        public void UpdateServiceRequest(ServiceRequest servReq) // updates a service request
        {
            ServiceRequestDH sDH = new ServiceRequestDH();
            sDH.Update(servReq);
        }

        public void UpdateJobEmployeeList(Job job) //updates the employees on a job
        {
            JobDH jDH = new JobDH();
            jDH.UpdateJobEmployeeList(job);
        }

        public void UpdateNumberOfEmployeesForJob(int id, int emps) //updates the number of employees on a job
        {
            JobDH jDH = new JobDH();
            jDH.UpdateAmountOfEmployeesRequired(id, emps);
        }

        public void ManuallyAssignJobs(Job job, List<MaintenanceEmployee> chosenEmployees)
        {
            JobDH jobDH = new JobDH();

            jobDH.UpdateState(job.JobID, JobState.InProgress);  //update state of the job

            foreach (MaintenanceEmployee emp in chosenEmployees)
            {
                jobDH.InsertSingleEmployeeToJob(job.JobID, emp.Id);
            }
        }

        public List<MaintenanceEmployee> SelectAllMaintenanceEmployeesWithGivenSpecialization(int id)
        {
            EmployeeDH employeeDH = new EmployeeDH();
            return employeeDH.SelectAllMaintenanceEmployeesWithGivenSpecilization(id);
        }

        public void EscalateServiceRequest(int newResponseDays, ServiceRequest sr) 
        {
            // used to create a special prio level. SPE = special
            string newPrio = "SPE" + newResponseDays.ToString();
            sr.PriorityLevel = newPrio;
            ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            serviceRequestDH.Update(sr);
        }

        public void ReAssignJob(int Jobid, List<MaintenanceEmployee> employees)
        {
            JobDH jobDH = new JobDH();
            Job job = jobDH.SelectJobById(Jobid);
            job.Employee = employees;   //assigns new employee list (taken in as parameter) to employee
            jobDH.UpdateJobEmployeeList(job);   //updates in database
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
