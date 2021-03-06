using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    public class ServicePackage
    {
        #region Fields
        private int packageID;
        private string packageName;
        private List<Service> serviceList;
        private bool onPromotion;
        private DateTime promotionStartDate;
        private DateTime promotionEndDate;
        private double promotionPercentage;
        private double servicePrice;
        #endregion

        #region Properties
        public int PackageID { get => packageID; set => packageID = value; }
        public string PackageName { get => packageName; set => packageName = value; }
        public bool OnPromotion { get => onPromotion; set => onPromotion = false; }
        public DateTime PromotionStartDate { get => promotionStartDate; set => promotionStartDate = value; }
        public DateTime PromotionEndDate { get => promotionEndDate; set => promotionEndDate = value; }
        public double PromotionPercentage { get => promotionPercentage; set => promotionPercentage = 0.00; }
        public double ServicePrice { get => servicePrice; set => servicePrice = value; }
        internal List<Service> ServiceList { get => serviceList; set => serviceList = value; }
        #endregion

        #region Constructors
        // defualt constructor
        public ServicePackage()
        {

        }
        // constructor with all fields
        public ServicePackage(int packID, string packName, List<Service> serList, bool onPromo, DateTime promoStartDate, DateTime promoEndDate, double promoPerc, double servPrice)
        {
            this.packageID = packID;
            this.packageName = packName;
            this.serviceList = serList;
            this.onPromotion = onPromo;
            this.promotionStartDate = promoStartDate;
            this.promotionEndDate = promoEndDate;
            this.promotionPercentage = promoPerc;
            this.servicePrice = servPrice;
        }
        // constructor without ID
        public ServicePackage(string packName, List<Service> serList, bool onPromo, DateTime promoStartDate, DateTime promoEndDate, double promoPerc, double servPrice)
        {
            this.packageName = packName;
            this.serviceList = serList;
            this.onPromotion = onPromo;
            this.promotionStartDate = promoStartDate;
            this.promotionEndDate = promoEndDate;
            this.promotionPercentage = promoPerc;
            this.servicePrice = servPrice;
        }
        public ServicePackage(int packID, string packName,bool onPromo, DateTime promoStartDate, DateTime promoEndDate, double promoPerc, double servPrice)
        {
            this.packageID = packID;
            this.packageName = packName;
            this.onPromotion = onPromo;
            this.promotionStartDate = promoStartDate;
            this.promotionEndDate = promoEndDate;
            this.promotionPercentage = promoPerc;
            this.servicePrice = servPrice;
        }
        #endregion

        #region Methods
        private void CheckPromotionEndDates()
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            List<ServicePackage> allPackages = servicePackadgeDH.SelectAllServicePackedges();
            foreach (ServicePackage item in allPackages)
            {
                DateTime dateTimeTest = DateTime.Now;
                if (item.promotionEndDate <= dateTimeTest && item.onPromotion)
                {
                    UpdatePromotionStateOfPackage(item.packageID, false);
                }
            }
        }
        public double CalculatePromotion(ServicePackage package) // calculate the amount a client will pay for a service package if it is on promotion   
        {
            return package.onPromotion ? (package.servicePrice * ((100 - package.promotionPercentage)/100)) : package.servicePrice;
        }
        public void UpdateWholePromotionState(ServicePackage servicePackage) 
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.UpdateServicePackedgePromotion(servicePackage);
        }

        public List<ServicePackage> SelectAllServicePackage() // get a list of service packages contract can be built from
        {
            CheckPromotionEndDates();
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            return servicePackadgeDH.SelectAllServicePackedges();
        }

        public void UpdateServicePackage(ServicePackage servicePackage) // updates a service package 
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.Update(servicePackage);
        }
        
        public void InsertServicePackage(ServicePackage servicePackage) // inserts a new service package
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.Insert(servicePackage);
        }
        
        public void InsertSingleServiceIntoPackage(int servicePackageID, int serviceID) // inserts a new service package
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.InsertSingleServiceToServicePackadge(servicePackageID, serviceID);
        }

        public void DeleteServicePackage(ServicePackage servicePackage) // inserts a new service package
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.Delete(servicePackage);
        }

        public void UpdatePromotionStateOfPackage(int id, bool state)
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.UpdatePromotionState(id, state);
        }

        public void UpdateListOfServices(ServicePackage servicePackage)
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            servicePackadgeDH.UpdateServicePackedgeServiceList(servicePackage);
        }

        public List<ServicePackage> SelectAllServicePackageState() // get a list of service packages contract can be built from
        {
            ServicePackadgeDH servicePackadgeDH = new ServicePackadgeDH();
            return servicePackadgeDH.SelectAllServicePackedgesWithState();
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
