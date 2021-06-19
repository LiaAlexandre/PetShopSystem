using IA.Autlantico.Entity;
using IA.Autlantico.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IA.Autlantico.Service
{
    public class AutlanticoService
    {
        AnimalRepository AnimalRepository = new AnimalRepository();
        TutorRepository TutorRepository = new TutorRepository();
        BookingRepository BookingRepository = new BookingRepository();
        HostingRepository HostingRepository = new HostingRepository();
        public int SaveAnimal(Animal animal, Tutor tutor)
        {
            //salva novo tutor
            int idTutor = TutorRepository.Save(tutor);

            animal.IdTutor = idTutor;

            //salva novo animal
            int idAnimal = AnimalRepository.Save(animal);

            //busca um alojamento vazio
            var emptyHosting = HostingRepository.GetEmpty();

            //monta o obj reserva
            var booking = new Booking(DateTime.Now, idAnimal, emptyHosting.Id);

            //salva nova reserva
            BookingRepository.Save(booking);

            //atualiza o alojamento para ocupado
            HostingRepository.Update(emptyHosting.Id, true);

            return emptyHosting.Id;
        }

        public List<Animal> GetAnimals()
        {
            return AnimalRepository.GetAll();            
        }

        public Animal GetAnimalBySearch(string search)
        {
            return AnimalRepository.GetByName(search);        
        }

        public Animal GetAnimalById(int id)
        {
            return AnimalRepository.GetById(id);
        }

        public void UpdateAnimal(Animal animal, Tutor tutor)
        {
            //atualiza informações do tutor
            TutorRepository.Update(tutor);

            //atualiza informações do animal
            AnimalRepository.Update(animal);
        }

        public void DeleteAnimal(int id)
        {
            AnimalRepository.Delete(id);

            TutorRepository.Delete(id);

            var bookingDetails = BookingRepository.GetByAnimalId(id);

            if(bookingDetails != null)
            {
                BookingRepository.Delete(bookingDetails.Id);
                HostingRepository.Update(bookingDetails.IdHosting, false);
            }
        }

        public void CheckOutAnimal(int idAnimal)
        {
            var booking = BookingRepository.GetByAnimalId(idAnimal);

            if(booking != null)
            {
                BookingRepository.CheckOut(booking.Id, DateTime.Now);

                HostingRepository.Update(booking.IdHosting, false);
            }
            else
            {
                throw new Exception("Animal não encontra-se internado. Não é possível fazer check-out.")
            }
        }

        public List<Hosting> GetHostingList()
        {
            return HostingRepository.GetAll();
        }

        public Hosting GetHosting(int id)
        {
            return HostingRepository.GetById(id);
        }

        public int NewBooking(int idAnimal)
        {
            var animal = AnimalRepository.GetById(idAnimal);

            Hosting hosting = null;

            if(animal != null)
            {
                var booking = BookingRepository.GetByAnimalId(idAnimal);

                if(booking == null)
                {
                    hosting = HostingRepository.GetEmpty();

                    if(hosting != null)
                    {
                        var newBooking = new Booking(DateTime.Now, idAnimal, hosting.Id);
                        BookingRepository.Save(newBooking);

                        HostingRepository.Update(hosting.Id, true);
                    }
                    else
                    {
                        throw new Exception("Não há alojamentos vagos no momento.");
                    }
                }
                else
                {
                    throw new Exception("Animal já encontra-se internado.");
                }
            }
            else
            {
                throw new Exception("Animal não encontrado.");
            }
            return hosting.Id;
        }
    }
}
