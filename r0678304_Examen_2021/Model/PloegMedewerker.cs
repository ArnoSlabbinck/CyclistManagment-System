using r0678304_Examen_2021.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace r0678304_Examen_2021.Model
{
    public class PloegMedewerker
    {
         
        public  List<CustomException> errorMessages = new List<CustomException>();
        protected CustomException customException;

        #region 
        //Properties
        private  int _aantalWedstrijden;

        public int AantalWedstrijden
        {
            get { return _aantalWedstrijden; }
            set 
            {
                if (value > 0)
                    _aantalWedstrijden = value;
                else
                {

                    var error  = new CustomException("Je kan geen 0 wedstrijden hebben");
                    errorMessages.Add(error);
                }
                  

            }
        }

        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set 
            {
                if (value != null)
                    _naam = value;
                else
                {
               
                    var error = new CustomException("De naam kan niet leeg zijn");
                    errorMessages.Add(error);
                }
            
            }
        }

 

        public string NaamMetPloeg
        {
            get { return Naam; }
            
        }

        private string _ploeg;

        public string Ploeg
        {
            get { return _ploeg; }
            set 
            {
                if (value != null)
                    _ploeg = value;
                else
                {
                    var error = new CustomException("Er moet een ploeg zijn");
                    errorMessages.Add(error);
                }


            }
        }

        #endregion


        public override bool Equals(object obj)
        {
            if (Naam == Ploeg)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"" +
                $"Naam: {Naam},"+
                $"Ploeg: {Ploeg}," +
                $"Aantal Wedstrijden:  {AantalWedstrijden}";
        }

        public PloegMedewerker(string naam, string ploeg, int aantalWedstrijden) 
        {
            Naam = naam;
            Ploeg = ploeg;
            AantalWedstrijden = aantalWedstrijden;
          
        }

        public PloegMedewerker()
        { }
    }
}
