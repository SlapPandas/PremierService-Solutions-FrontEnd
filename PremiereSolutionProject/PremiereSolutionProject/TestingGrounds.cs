using PremiereSolutionProject.BLL;
using PremiereSolutionProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject
{
    class TestingGrounds
    {
        public void Run(bool input)
        {
            if (input)
            {
                RunTest();
            }
        }

        private void RunTest()
        {
            Console.WriteLine("======================================================");

            //CallDH callDH = new CallDH();
            ////DateTime dateTime = new DateTime(2001, 01, 01);
            //callDH.InsertBusinessClientToCall(1, "B00000001");
            //SpecializationDH specializationDH = new SpecializationDH();
            //List<Specialisation> specialisations = specializationDH.SelectAllSpecialisations();
            //ServiceRequestDH serviceRequestDH = new ServiceRequestDH();
            //List<ServiceRequest> serviceRequests = serviceRequestDH.SelectAllServiceRequestsByIndividualClient("A00000001");
            //ServiceDH serviceDH = new ServiceDH();
            //List<Service> services = serviceDH.se(1);
            //ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            //List<ServicePackage> servicePackages = servicePackadgeDH.SelectAllServicePackedges();
            //IndividualClientDH individualClientDH = new IndividualClientDH();
            //List<IndividualClient> individualClients = individualClientDH.SelectAllIndividualClients();
            AddressDH addressDH = new AddressDH();
            List<Address> addresses = addressDH.SelectAllAddresses();

            DateTime dateTime = new DateTime(2001, 01, 01);
            //JobDH jobDH = new JobDH();
            //Address address = new Address(1, "update", "update", GetProvince("3"), "1233");
            //DateTime dateTime = new DateTime(2001, 01, 01);
            //List<Specialisation> specialisations = new List<Specialisation>();
            //specialisations.Add(new Specialisation(1, "name", "desc"));
            //specialisations.Add(new Specialisation(2, "name", "desc"));
            //specialisations.Add(new Specialisation(3, "name", "desc"));
            //specialisations.Add(new Specialisation(4, "name", "desc"));
            //Specialisation specialisation = new Specialisation(1, "name", "desc");
            //List<MaintenanceEmployee> maintenanceEmployees = new List<MaintenanceEmployee>();
            //maintenanceEmployees.Add(new MaintenanceEmployee("E00000001", "updates", "updates", address, "updates", "updates", "updates", dateTime, specialisations, true, "updated"));
            //maintenanceEmployees.Add(new MaintenanceEmployee("E00000004", "updates", "updates", address, "updates", "updates", "updates", dateTime, specialisations, true, "updated"));
            //maintenanceEmployees.Add(new MaintenanceEmployee("E00000006", "updates", "updates", address, "updates", "updates", "updates", dateTime, specialisations, true, "updated"));
            //maintenanceEmployees.Add(new MaintenanceEmployee("E00000008", "updates", "updates", address, "updates", "updates", "updates", dateTime, specialisations, true, "updated"));
            //Job job = new Job(1, address, Getstate("0"), "updates", maintenanceEmployees, specialisation,1,4);
            //string my = ((int)job.JobState).ToString();
            //jobDH.UpdateJobEmployeeList(job);
            //jobDH.AddSingleEmployeeToJob(1, "E00000005");

            //ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            //DateTime dateTimestart = new DateTime(2001, 01, 01);
            //DateTime dateTimeend = new DateTime(2001, 01, 20);
            //List<Service> services = new List<Service>();
            //services.Add(new Service(1, "ser1", "des1"));
            //services.Add(new Service(2, "ser1", "des1"));
            //services.Add(new Service(3, "ser1", "des1"));
            //services.Add(new Service(4, "ser1", "des1"));
            //ServicePackage serviceRequest = new ServicePackage(1, "updated", services, false, dateTimestart, dateTimeend, 123.321, 456.654);
            //servicePackadgeDH.InsertSingleServiceToServicePackedge(1,1); //Commented out due to error


            Console.WriteLine("======================================================");
        }

        //public void ShowcontractDetails()
        //{
        //    List<Service> serviceList = new List<Service>();
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));

        //    List<ServicePackage> servList = new List<ServicePackage>();
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));
        //    Contract cont = new Contract("C0000001", DateTime.Now, DateTime.Today.AddDays(5.00),servList, "Platinum",2000.00);

        //    Console.WriteLine(cont.ToString());
        //}

        //public void OrderContractList()
        //{
        //    List<Contract> contracts = new List<Contract>();

        //    List<Service> serviceList = new List<Service>();
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));
        //    serviceList.Add(new Service("Gardening", "mowing and pruning"));

        //    List<ServicePackage> servList = new List<ServicePackage>();
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));
        //    servList.Add(new ServicePackage("PackOne", serviceList, false, DateTime.Now, DateTime.Now, 0.00, 3000.00));

        //    DateTime breakStart1 = new DateTime(2012, 02, 15, 12, 30, 00);
        //    DateTime breakStart2 = new DateTime(2016, 02, 15, 12, 30, 00);

        //    contracts.Add(new Contract("C0000001",false, DateTime.Now, DateTime.Today.AddDays(5.00), servList, "Platinum", 2000.00));
        //    contracts.Add(new Contract("C0000002",true, breakStart1, DateTime.Today.AddDays(10.00), servList, "Bronze", 2000.00));
        //    contracts.Add(new Contract("C0000003",false, breakStart2, DateTime.Today.AddDays(2.00), servList, "Silver", 2000.00));

        //    Contract c = new Contract();
        //    c.OrderContractList(contracts);

        //    foreach (Contract contract in contracts)
        //    {
        //        Console.WriteLine(contract.ToString());
        //    }
        //}
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
        private JobState Getstate(string input)
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
    }
}
