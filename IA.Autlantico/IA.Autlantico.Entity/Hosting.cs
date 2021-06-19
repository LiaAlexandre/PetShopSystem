using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Hosting
    {
        public Hosting(int Id, bool Status, DateTime DeletedAt)
        {
            this.Id = Id;
            this.Status = Status;
            this.DeletedAt = DeletedAt;
        }
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
