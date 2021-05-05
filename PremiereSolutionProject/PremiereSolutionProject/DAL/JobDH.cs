using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class JobDH : DatabaseConnection
    {
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
            UpdateCommand($"EXEC UpdateJob @id = {job.JobID}, @notes = '{job.JobNotes}', @specialisationId = {job.Specialisation.SpecialisationID}, @adressid = {job.JobAddress.AddressID}, @streetName = '{job.JobAddress.StreetName}', @suburb = '{job.JobAddress.Suburb}', @province = '{((int)job.JobAddress.Province).ToString()}', @postalcode = '{job.JobAddress.Postalcode}',@city = '{job.JobAddress.City}'");
        }
        public void UpdateJobEmployeeList(Job job)
        {
            InsertAllEmployeesOfJob(job);
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
            InsertAllEmployeesOfNewJob(job);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally {}

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
                        job = new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]);
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (string)reader["priorityLevel"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"],(string)reader["priorityLevel"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
                        jobList.Add(new Job((int)reader["jobID"], GetAddressById((int)reader["addressId"]), GetJobState((string)reader["currentState"]), (string)reader["notes"], GetMaintenanceEmployeeByJobId((int)reader["jobID"]), GetSpecialisationById((int)reader["specialisationId"]), (int)reader["ServiceRequestID"], (int)reader["amountOfEmployeesNeeded"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally {}

            return jobList;
        }
        #endregion

        #region SeperateMethods
        private void InsertAllEmployeesOfJob(Job job)
        {
            for (int i = 0; i < job.Employee.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPJobEmployee @jobId = '{job.JobID}', @employeeId = '{job.Employee[i].Id}'");
            }
        }
        private void InsertAllEmployeesOfNewJob(Job job)
        {
            for (int i = 0; i < job.Employee.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewJobEmployee @employeeId = '{job.Employee[i].Id}'");
            }

        }
        private Specialisation GetSpecialisationById(int specialisationID)
        {
            Specialisation specialisation = new Specialisation();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectSpecialisationById @id = '{specialisationID}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisation = new Specialisation((int)reader["specialisationID"], (string)reader["name"], (string)reader["description"]);
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }
            return specialisation;
        }
        public Address GetAddressById(int addressId)
        {
            Address address = new Address();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAddressById @id = '{addressId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        address = new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]);
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }
            return address;
        }
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
        private List<MaintenanceEmployee> GetMaintenanceEmployeeByJobId(int jobId)
        {
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC GetMaintenanceEmployeeByJobId @id = '{jobId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], GetAddressById((int)reader["addressId"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetSpecialisationOfEmployeeById((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }
            return maintenanceEmployeeList;
        }
        private List<Specialisation> GetSpecialisationOfEmployeeById(int employeeID)
        {
            List<Specialisation> specialisationList = new List<Specialisation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC GetSpecialisationOfEmployeeByEmployeeId @id = '{employeeID}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisationList.Add(new Specialisation((int)reader["specialisationID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }
            return specialisationList;
        }
        private Province GetProvince(string input)
        {
            Province province = (Province)1;

            switch (input)
            {
                case "0":
                    province = (Province)0;
                    break;
                case "1":
                    province = (Province)1;
                    break;
                case "2":
                    province = (Province)2;
                    break;
                case "3":
                    province = (Province)3;
                    break;
                case "4":
                    province = (Province)4;
                    break;
                case "5":
                    province = (Province)5;
                    break;
                case "6":
                    province = (Province)6;
                    break;
                case "7":
                    province = (Province)7;
                    break;
                case "8":
                    province = (Province)8;
                    break;
                default:
                    province = (Province)1;
                    break;
            }
            return province;
        }
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
