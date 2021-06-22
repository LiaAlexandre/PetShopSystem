using IA.Autlantico.Entity;
using IA.Autlantico.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace IA.Autlantico.Service
{
    public class AutlanticoService
    {
        AnimalRepository AnimalRepository = new AnimalRepository();
        TutorRepository TutorRepository = new TutorRepository();
        HostingRepository HostingRepository = new HostingRepository();
        public int SaveAnimal(Animal animal)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //busca um alojamento vazio
                var emptyHosting = HostingRepository.GetEmpty();

                //atualiza o alojamento para ocupado
                HostingRepository.Update(emptyHosting.Id, true);

                //salva novo tutor
                Tutor tutor = new Tutor(animal.NameTutor, animal.Address, animal.PhoneNumber);
                int idTutor = TutorRepository.Save(tutor);

                animal.IdTutor = idTutor;
                animal.IdHosting = emptyHosting.Id;

                //salva novo animal
                int idAnimal = AnimalRepository.Save(animal);

                scope.Complete();

                return emptyHosting.Id;
            }
         
        }

        public List<Animal> GetAnimals()
        {
            return AnimalRepository.GetAll();            
        }

        public List<Animal> GetAnimalBySearch(string search)
        {
            return AnimalRepository.GetByName(search);        
        }

        public Animal GetAnimalById(int id)
        {
            var animal = AnimalRepository.GetById(id);

            var tutor = TutorRepository.GetById(animal.IdTutor.Value);

            animal.NameTutor = tutor.Name;
            animal.Address = tutor.Address;
            animal.PhoneNumber = tutor.PhoneNumber;

            return animal;
        }

        public void UpdateAnimal(Animal animal)
        {

            var animalInDb = AnimalRepository.GetById(animal.Id.Value);

            var tutor = TutorRepository.GetById(animalInDb.IdTutor.Value);

            tutor.Name = animal.NameTutor;
            tutor.PhoneNumber = animal.PhoneNumber;
            tutor.Address = animal.Address;

            TutorRepository.Update(tutor);

            AnimalRepository.Update(animal);
        }

        public void DeleteAnimal(int id)
        {
            var animal = AnimalRepository.GetById(id);

            AnimalRepository.Delete(id);

            TutorRepository.Delete(id);

            HostingRepository.Update((int)animal.IdHosting, false);

        }

        public void CheckOutAnimal(int idAnimal)
        {
            var animal = AnimalRepository.GetById(idAnimal);

            if (animal.IdHosting != null)
            {
                animal.IdHosting = null;
                AnimalRepository.Update(animal);
                HostingRepository.Update((int)animal.IdHosting, false);
            }
            else
            {
                throw new Exception("Animal não encontra-se internado. Não é possível fazer check-out.");
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
    }
}
