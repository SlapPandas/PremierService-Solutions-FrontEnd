using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    class Address
    {
        #region Fields
        private int addressID;
        private string streetName;
        private string suburb;
        private Province province;
        private string postalcode;
        #endregion

        #region Properties
        //access modifiers are public as they need to be accessibly by several other parts of the program
        public string StreetName { get => streetName; set => streetName = value; }
        public string Suburb { get => suburb; set => suburb = value; }
        public Province Province { get => province; set => province = value; }
        public string Postalcode { get => postalcode; set => postalcode = value; }
        public int AddressID { get => addressID; set => addressID = value; }
        #endregion

        #region Constructor
        //default constructor
        public Address()
        {

        }
        //constructor with all fields
        public Address(int id, string street, string suburb, Province province, string code)
        {
            this.addressID = id;
            this.streetName = street;
            this.suburb = suburb;
            this.province = province;
            this.postalcode = code;
        }
        //constructor without ID field
        public Address(string street, string suburb, Province province, string code)
        {
            this.streetName = street;
            this.suburb = suburb;
            this.province = province;
            this.postalcode = code;
        }
        #endregion

        #region Methods
        public void UpdateAddress(Address a)
        {
            AddressDH addressDataHandler = new AddressDH();

            addressDataHandler.Update(a);
        }

        public void InsertAddess(Address a)
        {
            AddressDH addressDH = new AddressDH();
            addressDH.Insert(a);
        }

        public List<Address> SelectAllAddresses()
        {
            AddressDH addressDH = new AddressDH();
            return addressDH.SelectAllAddresses();
        }

        #endregion

    }

    //enum containing all the provinces in South-Africa, since it is constant
    enum Province
    {
        North_West,
        Gauteng,
        Western_Cape,
        Eastern_Cape,
        Free_State,
        Northern_Cape,
        Mpumalanga,
        Limpopo,
        Kwazulu_Natal
    }
}
