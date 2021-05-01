using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;

namespace PremiereSolutionProject.BLL
{
    class Specialisation
    {
        #region Fields
        private int specialisationID;
        private string specialisationName;
        private string description;
        #endregion

        #region Properties
        public int SpecialisationID { get => specialisationID; set => specialisationID = value; }
        public string SpecialisationName { get => specialisationName; set => specialisationName = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Contructors
        // default constructor
        public Specialisation()
        {

        }
        // constructor with fields
        public Specialisation(int specID, string specName, string desc)
        {
            this.specialisationID = specID;
            this.specialisationName = specName;
            this.description = desc;
        }
        // constructor without ID field
        public Specialisation(string specName, string desc)
        {
            this.specialisationName = specName;
            this.description = desc;
        }

        public Specialisation(string name)
        {
            this.specialisationName = name;
        }
        #endregion

        #region Methods
        public List<Specialisation> SelectSpecialisationList() // get a list of all specialisations from DAL
        {
            SpecializationDH specializationDH = new SpecializationDH();
            return specializationDH.SelectAllSpecialisations();
        }

        public List<Specialisation> GetSpecialisationNames() // returns a list of all specialisation names to be displayed
        {
            SpecializationDH specializationDH = new SpecializationDH();
            return specializationDH.SelectAllSpecialisationNames();
        }
        public void UpdateSpecialisation(Specialisation specialisation) // updates specialisation
        {
            SpecializationDH specializationDH = new SpecializationDH();
            specializationDH.Update(specialisation);
        }
        public void InsertSpecialisation(Specialisation specialisation) // inserts a new specialisation
        {
            SpecializationDH specializationDH = new SpecializationDH();
            specializationDH.Insert(specialisation);
        }

        public void DeleteSpecialisation(Specialisation specialisation) // inserts a new specialisation
        {
            SpecializationDH specializationDH = new SpecializationDH();
            specializationDH.Delete(specialisation);
        }

        #endregion
    }
}
