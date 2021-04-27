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
            CreateConnection();
            commandString = $"EXEC DeleteJob @id = '{job.JobID}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        #endregion

        #region Update
        public void UpdateState(int jobId, JobState jobState)
        {
            CreateConnection();
            commandString = $"EXEC UpdateJobState @id = '{jobId}', @currentstate = '{((int)jobState).ToString()}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        public void UpdateAmountOfEmployeesRequired(int jobId, int amountOfEmployees)
        {
            CreateConnection();
            commandString = $"EXEC UpdateJobEmployeesRequired @id = '{jobId}', @amount = '{amountOfEmployees}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        public void Update(Job job)
        {
            CreateConnection();
            commandString = $"EXEC UpdateJob @id = {job.JobID}, @notes = '{job.JobNotes}', @specialisationId = {job.Specialisation.SpecialisationID}, @adressid = {job.JobAddress.AddressID}, @streetName = '{job.JobAddress.StreetName}', @suburb = '{job.JobAddress.Suburb}', @province = '{((int)job.JobAddress.Province).ToString()}', @postalcode = '{job.JobAddress.Postalcode}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        public void UpdateJobEmployeeList(Job job)
        {
            InsertAllEmployeesOfJob(job);
            CreateConnection();
            commandString = $"EXEC UpdateJobEmployeeList @id = '{job.JobID}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        #endregion

        #region Insert
        public void Insert(Job job)
        {
            CreateConnection();
            commandString = $"EXEC InsertJob @id = '{job.JobID}', @addressId = '{job.JobAddress.AddressID}', @ServiceRequestID = '{job.ServiceRequestID}', @notes = '{job.JobNotes}', @currentState = '{job.JobState}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }
        public void InsertSingleEmployeeToJob(int jobId, string employeeId)
        {
            CreateConnection();
            commandString = $"EXEC InsertJobEmployeeLink @employeeID = '{employeeId}', @jobID = '{jobId}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
        }

        #endregion

        #region Select
        public List<Job> SelectAllJobs()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllJobs";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public Job SelectJobById(int id)
        {
            CreateConnection();
            commandString = $"EXEC SelectJobByJobId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            Job job = new Job();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    job = new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]);
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return job;
        }
        public List<Job> SelectAllJobsWithPriority()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllPendingJobsWithPriority";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public List<Job> SelectAllPendingJobs()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllPendingJobs";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public List<Job> SelectAllInProgressJobs()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllInProgressJobs";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public List<Job> SelectAllFinishedJobs()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllFinishedJobs";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public List<Job> SelectAllFinishedJobsByIndividualClientID(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllFinishedJobsByIndividualClientID @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        public List<Job> SelectAllFinishedJobsByBusinessClientID(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllFinishedJobsByBusinessClientID @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Job> jobList = new List<Job>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    jobList.Add(new Job((int)Reader["jobID"], GetAddressById((int)Reader["addressId"]), GetJobState((string)Reader["currentState"]), (string)Reader["notes"], GetMaintenanceEmployeeByJobId((int)Reader["jobID"]), GetSpecialisationById((int)Reader["specialisationId"]), (int)Reader["ServiceRequestID"], (int)Reader["amountOfEmployeesNeeded"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return jobList;
        }
        #endregion

        #region SeperateMethods
        private void InsertAllEmployeesOfJob(Job job)
        {
            SqlConnection jobConnection = new SqlConnection(connectionSring);

            try
            {
                jobConnection.Open();
                for (int i = 0; i < job.Employee.Count; i++)
                {
                    commandString = $"EXEC InsertIntoTVPJobEmployee @jobId = '{job.JobID}', @employeeId = '{job.Employee[i].Id}'";
                    SqlCommand jobCommand = new SqlCommand(commandString, jobConnection);
                    jobCommand.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                jobConnection.Close();
            }
        }
        private Specialisation GetSpecialisationById(int specialisationID)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            Specialisation specialisation = new Specialisation();
            commandString = $"EXEC SelectSpecialisationById @id = '{specialisationID}'";
            SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);

            try
            {
                specialisationConnection.Open();
                specialisationReader = specialisationCommand.ExecuteReader();
                while (specialisationReader.Read())
                {
                    specialisation = new Specialisation((int)specialisationReader["specialisationID"], (string)specialisationReader["name"], (string)specialisationReader["description"]);
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                specialisationConnection.Close();
            }
            return specialisation;
        }
        private Address GetAddressById(int addressId)
        {
            SqlConnection addressConnection = new SqlConnection(connectionSring);
            SqlDataReader addressReader;
            Address address = new Address();
            commandString = $"EXEC SelectAddressById @id = '{addressId}'";
            SqlCommand addressCommand = new SqlCommand(commandString, addressConnection);

            try
            {
                addressConnection.Open();
                addressReader = addressCommand.ExecuteReader();
                while (addressReader.Read())
                {
                    address = new Address((int)addressReader["addressID"], (string)addressReader["streetName"], (string)addressReader["suburb"], GetProvince((string)addressReader["province"]), (string)addressReader["postalcode"]);
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                addressConnection.Close();
            }
            return address;
        }
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
        private List<MaintenanceEmployee> GetMaintenanceEmployeeByJobId(int jobId)
        {
            SqlConnection maintenanceEmployeeConnection = new SqlConnection(connectionSring);
            SqlDataReader maintenanceEmployeeReader;
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            commandString = $"EXEC GetMaintenanceEmployeeByJobId @id = '{jobId}'";
            SqlCommand maintenanceEmployeeCommand = new SqlCommand(commandString, maintenanceEmployeeConnection);

            try
            {
                maintenanceEmployeeConnection.Open();
                maintenanceEmployeeReader = maintenanceEmployeeCommand.ExecuteReader();
                while (maintenanceEmployeeReader.Read())
                {
                    maintenanceEmployeeList.Add(new MaintenanceEmployee((string)maintenanceEmployeeReader["employeeNumber"], (string)maintenanceEmployeeReader["firstName"], (string)maintenanceEmployeeReader["surname"], GetAddressById((int)maintenanceEmployeeReader["addressId"]), (string)maintenanceEmployeeReader["contactNumber"], (string)maintenanceEmployeeReader["email"], (string)maintenanceEmployeeReader["nationalIdNumber"], (DateTime)maintenanceEmployeeReader["employmentDate"], GetSpecialisationOfEmployeeById((int)maintenanceEmployeeReader["employeeID"]), GetTrueFalseFromBit((int)maintenanceEmployeeReader["employed"]), (string)maintenanceEmployeeReader["department"]));

                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                maintenanceEmployeeConnection.Close();
            }
            return maintenanceEmployeeList;
        }
        private List<Specialisation> GetSpecialisationOfEmployeeById(int employeeID)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            List<Specialisation> specialisationList = new List<Specialisation>();
            commandString = $"EXEC GetSpecialisationOfEmployeeByEmployeeId @id = '{employeeID}'";
            SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);

            try
            {
                specialisationConnection.Open();
                specialisationReader = specialisationCommand.ExecuteReader();
                while (specialisationReader.Read())
                {
                    specialisationList.Add(new Specialisation((int)specialisationReader["specialisationID"], (string)specialisationReader["name"], (string)specialisationReader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                specialisationConnection.Close();
            }
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
