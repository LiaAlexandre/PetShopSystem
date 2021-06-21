using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Tutor
    {
        public Tutor(int id, string Name, string Adress, string PhoneNumber, DateTime DeletedAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Adress;
            this.PhoneNumber = PhoneNumber;
            this.DeletedAt = DeletedAt;
        }

        public Tutor(string Name, string Adress, string PhoneNumber)
        {
            this.Name = Name;
            this.Address = Adress;
            this.PhoneNumber = PhoneNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
