//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak04
{
    using System;
    
    public partial class GetAllStudents_Result
    {
        public int IDStudent { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBAG { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
