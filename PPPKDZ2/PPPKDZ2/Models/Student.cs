using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKDZ2.Models
{
    class Student
    {
        public int    IDStudent { get; set; }
        public string Ime       { get; set; }
        public string Prezime   { get; set; }
        public string JMBAG     { get; set; }
        public string Email     { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", IDStudent,Ime, Prezime, JMBAG,Email);
        }
    }
}
