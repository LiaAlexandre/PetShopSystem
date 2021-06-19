using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Animal
    {
        public Animal(int Id, string Name, string InternationMotive, string Status, int IdTutor )
        {
            this.Id = Id;
            this.Name = Name;
            this.InternationMotive = InternationMotive;
            this.Status = Status;
            this.IdTutor = IdTutor;
        }
        public Animal(int Id, string Name, string InternationMotive, string Status, int IdTutor, DateTime DeletedAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.InternationMotive = InternationMotive;
            this.Status = Status;
            this.IdTutor = IdTutor;
            this.DeletedAt = DeletedAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string InternationMotive { get; set; }
        public string Status { get; set; }
        public int IdTutor { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
