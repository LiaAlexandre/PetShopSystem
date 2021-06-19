using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Animal
    {
        public Animal(int Id, string Name, string InternationMotive, string Status, string Photo, int IdTutor )
        {
            this.Id = Id;
            this.Name = Name;
            this.InternationMotive = InternationMotive;
            this.Status = Status;
            this.Photo = Photo;
            this.IdTutor = IdTutor;
        }
        public Animal(int Id, string Name, string InternationMotive, string Status, int IdTutor)
        {
            this.Id = Id;
            this.Name = Name;
            this.InternationMotive = InternationMotive;
            this.Status = Status;
            this.IdTutor = IdTutor;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string InternationMotive { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public int IdTutor { get; set; }
    }
}
