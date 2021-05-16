using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class JobDH : DatabaseConnection
    {
        EmployeeDH employeeDH = new EmployeeDH();
        SpecializationDH specializationDH = new SpecializationDH();
        AddressDH addressDH = new AddressDH();
        #region Delete
        public void Delete(Job job)
        {
            DeleteCommand($"EXEC DeleteJob @id = '{job.JobID}'");
        }
        #endregion

        #region Update
        public void UpdateState(int jobId, JobState jobState)
        {
            UpdateCommand($"EXEC UpdateJobState @id = '{jobId}', @currentstate = '{((int)jobState).ToString()}'");
        }
        public void UpdateAmountOfEmployeesRequired(int jobId, int amountOfEmployees)
        {
            UpdateCommand($"EXEC UpdateJobEmployeesRequired @id = '{jobId}', @amount = '{amountOfEmployees}'");
        }
        public void Update(Job job)
        {
            UpdateCommand($"EXEC UpdateJob @id ='{job.JobID}', @notes ='{job.JobNotes}',@state ='{((int)job.JobState).ToString()}', @needed ='{job.EmployeesNeeded}'");
        }
        public void UpdateJobEmployeeList(Job job)
        {
            employeeDH.InsertAllEmployeesOfJob(job);
            UpdateCommand($"EXEC UpdateJobEmployeeList @id = '{job.JobID}'");
        }
        #endregion

        #region Insert
        public void Insert(Job job)
        {
            InsertCommand($"EXEC InsertJob @addressId = '{job.JobAddress.AddressID}', @ServiceRequestID = '{job.ServiceRequestID}', @notes = '{job.JobNotes}', @currentState = '{((int)job.JobState).ToString()}', @specialization = '{job.Specialisation.SpecialisationID}', @amountOfEmployees = '{job.EmployeesNeeded}'");
        }
        public void InsertWithEmployeeList(Job job)
        {
            employeeDH.InsertAllEmployeesOfNewJob(job);
            InsertCommand($"EXEC InsertJobWithEmployeeList @addressId = '{job.JobAddress.AddressID}', @ServiceRequestID = '{job.ServiceRequestID}', @notes = '{job.JobNotes}', @currentState = '{((int)job.JobState).ToString()}', @specialization = '{job.Specialisation.SpecialisationID}', @amountOfEmployees = '{job.EmployeesNeeded}'");
        }
        public void InsertSingleEmployeeToJob(int jobId, string employeeId)
        {
            InsertCommand($"EXEC InsertJobEmployeeLink @employeeID = '{employeeId}', @jobID = '{jobId}'");
        }

        #endregion

        #region Select
        public List<Job> SelectAllJobs()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllJobs";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectJobsNotCurrentlyFinished()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectJobsNotFinished";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return jobList;
        }
        public Job SelectJobById(int id)
        {
            Job job = new Job();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectJobByJobId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        job = new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return job;
        }
        public List<Job> SelectAllJobsWithPriority()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllJobsWithPriority";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (string)reader["priorityLevel"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectAllPendingJobsWithPriority()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllPendingJobsWithPriority";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"],(string)reader["priorityLevel"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return jobList;
        }
        public List<Job> SelectAllPendingJobs()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllPendingJobs";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectAllInProgressJobs()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllInProgressJobs";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectAllFinishedJobs()
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllFinishedJobs";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectAllFinishedJobsByIndividualClientID(string id)
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllFinishedJobsByIndividualClientID @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        public List<Job> SelectAllFinishedJobsByBusinessClientID(string id)
        {
            List<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllFinishedJobsByBusinessClientID @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobList.Add(new Job((int)reader["jobID"], addressDH.GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], employeeDH.GetMaintenanceEmployeeByJobId((int)reader["jobID"]), specializationDH.GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return jobList;
        }
        #endregion

        #region SeperateMethods
        private JobState GetJobState(string input)
        {
            JobState jobState = (JobState)1;

            switch (input)
            {
                case "0":
                    jobState = (JobState)0;
                    break;
                case "1":
                    jobState = (JobState)1;
                    break;
                case "2":
                    jobState = (JobState)2;
                    break;
                default:
                    jobState = (JobState)1;
                    break;
            }
            return jobState;
        }
        #endregion
    }
}
