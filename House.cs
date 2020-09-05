using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davison_Estate_Agency
{
    //THE DERIVED CLASS (INHERITED)
    class House : Office
    {
        //ATTRIBUTES
        private int Bedrooms { get; set; }
        private int Bathrooms { get; set; }
        private int Receptions { get; set; }
        private string Garage { get; set; }
        private string Garden { get; set; }


        //CONSTRUCTOR + (BASE CONSTRUCTOR INHERITED FORM THE BASE CLASS)
        public House(int Ref, string Loc, int No, string type, int Sqft, int Cost, string Avlb, int Beds, int Baths, int Recp, string Gar, string Gard) : base(Ref, Loc, No, type, Sqft, Cost, Avlb)
        {
            Bedrooms = Beds;
            Bathrooms = Baths;
            Receptions = Recp;
            Garage = Gar;
            Garden = Gard;
        }


        //METHOD + (BASE RETURN INHERITED FORM THE BASE CLASS)
        public override string ToString()
        {
            string property = base.ToString();
            property += "\r\n" + "Bedrooms: " + " " + Bedrooms + "\r\n" + "Bathrooms:" + " " + Bathrooms + "\r\n" + "Receptions:" + " " + Receptions + "\r\n" + "Garage:" + " " + Garage + "\r\n" + "Garden:" + " " + Garden;
            return property;
        }
    }
}
