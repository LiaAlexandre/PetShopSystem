using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Hosting
    {
        public Hosting(int Id, bool Status)
        {
            this.Id = Id;
            this.Status = Status;
        }
        public int Id { get; set; }
        public bool Status { get; set; }

        public string StatusName
        {
            get
            {
                if (Status == true) return "Ocupado";                

                return "Livre";
            }
        }
    }
}
