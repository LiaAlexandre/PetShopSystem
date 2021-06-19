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
            this.Adress = Adress;
            this.PhoneNumber = PhoneNumber;
            this.DeletedAt = DeletedAt;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
