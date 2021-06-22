using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Animal
    {
        public Animal() { }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string InternationMotive { get; set; }
        public StatusId? Status { get; set; }
        public string StatusName { 
            get 
            { 
                if (Status == StatusId.InTreatment) return "Em tratamento";

                if (Status == StatusId.Recovering) return "Se recuperando";

                return "Recuperado";
            }
        }
        public int? IdTutor { get; set; }
        public string NameTutor { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? IdHosting { get; set; }
        public DateTime? DeletedAt { get; set; }

        public enum StatusId
        {
            InTreatment = 0,
            Recovering = 1,
            Healed = 2
        }
    }
}
