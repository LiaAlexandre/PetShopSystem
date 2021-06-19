using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Entity
{
    public class Booking
    {
        public Booking(int Id, DateTime CheckInDate, DateTime CheckOutDate, int IdAnimal, int IdHosting)
        {
            this.Id = Id;
            this.CheckInDate = CheckInDate;
            this.CheckOutDate = CheckOutDate;
            this.IdAnimal = IdAnimal;
            this.IdHosting = IdHosting;
        }

        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int IdAnimal { get; set; }
        public int IdHosting { get; set; }
    }
}
