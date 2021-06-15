using r0678304_Examen_2021.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r0678304_Examen_2021.Model
{
    public class ProfWielrenner : Wielrenner
    {
        private int aantalwedstrijden;
        public new int AantalWedstrijden
        {
            get { return  aantalwedstrijden; }
            set 
            { 

                if (value >= 20)
                    aantalwedstrijden = value;
                else
                {
                    var error = new CustomException("Aantal wedstrijden gespeeld moet hoger zijn dan 20 ");
                    errorMessages.Add(error);
                }
            }
        }


        private double _loon;

        public double Loon
        {
            get { return _loon; }
            set 
            {
                if (value > 0)
                    _loon = value;
                else
                {
                    var error = new CustomException("Loon kan niet 0 zijn");
                    errorMessages.Add(error);
                }
            }
        }

        private string _disciple;

        public string Disciple
        {
            get { return _disciple; }
            set { _disciple = value; }
        }


        public ProfWielrenner(string naam, 
            string ploeg,
            int aantalWedstrijden,
            double startgeld, double loon, string disciple) : base(naam, ploeg, aantalWedstrijden, startgeld)
        {
            _disciple = disciple;
            _loon = loon;
            if (errorMessages.Count > 0)
            {
                throw new Exception();
            }

        }
        public ProfWielrenner() : base()
        { }

        public override string ToString()
        {
            return
                $"Naam: {Naam}," +
                $"Ploeg: {Ploeg}," +
                $"Aantal Wedstrijden:  {base.AantalWedstrijden}" +
                $"Inkomsten: {Inkomsten()} euro"+
                $"Disciple: {Disciple}"+
                $"Stargeld: {Startgeld}";
        }

        public override double Inkomsten()
        {
            return Convert.ToDouble(aantalwedstrijden * Startgeld + Loon);
        }
    }


}
