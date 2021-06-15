using r0678304_Examen_2021.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r0678304_Examen_2021.Model
{
    public class Wielrenner : PloegMedewerker
    {

        private double _startgeld;

        public double Startgeld
        {
            get { return _startgeld; }
            set {
                if (value > 0)
                    _startgeld = value;
                else
                {
                    var error = new CustomException("Startgeld moet hoger zijn dan 0");
                    errorMessages.Add(error);
                }
            }
        }

        public Wielrenner(string naam, string ploeg, int aantalWedstrijden, double startgeld) : base(naam, ploeg, aantalWedstrijden)
        {
            _startgeld = startgeld;
            if (errorMessages.Count > 0)
            {
                throw new Exception();
            }


        }

        public Wielrenner() : base()
        { }


        public virtual double Inkomsten()
        {
            return Convert.ToDouble(AantalWedstrijden * Startgeld);
        }

        public override string ToString()
        {
            return $"" +
                $"Naam: {Naam}," +
                $"Ploeg: {Ploeg}," +
                $"Aantal Wedstrijden:  {AantalWedstrijden}"+
                $"Inkomsten: {Inkomsten()} euro";
        }
    }
}
