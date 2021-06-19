using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Tutor
    {
        public Tutor (int id, string Name, string Adress, string PhoneNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.Adress = Adress;
            this.PhoneNumber = PhoneNumber;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }


    }
}
