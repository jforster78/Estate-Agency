using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davison_Estate_Agency
{
    //BASE CLASS
    class Office
    {
        //ATTRIBUTES
        protected int RefNo { get; set; }
        protected string Postcode { get; set; }
        protected int UnitNo { get; set; }
        protected string Type { get; set; }
        protected int SquareFeet { get; set; }
        protected int Value { get; set; }
        protected string Available { get; set; }


        //CONSTRUCTOR
        public Office(int Ref, string Loc, int No, string type, int Sqft, int Cost, string Avlb)
        {
            RefNo = Ref;
            Postcode = Loc;
            UnitNo = No;
            Type = type;
            SquareFeet = Sqft;
            Value = Cost;
            Available = Avlb;
        }


        //METHOD
        public override string ToString()
        {
            return "Ref No." + " " + RefNo + "\r\n\r\n" + "Available:" + " " + Available + "\r\n" + "Cost £" + Value + "\r\n\r\n" + "Location:" + " " + Postcode + "\r\n" + "Unit:" + " " + UnitNo + "\r\n" + "Type:" + " " + Type + "\r\n" + "Sq ft:" + " " + SquareFeet;
        }
    }
}
