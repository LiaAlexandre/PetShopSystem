using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IA.Autlantico.Entity.Test
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void TestShouldReturnStatusNameCorrectly()
        {
            Animal animal = new Animal();

            animal.Status = Animal.StatusId.Recovering;
            Assert.AreEqual("Se recuperando", animal.StatusName);

            animal.Status = Animal.StatusId.Healed;
            Assert.AreEqual("Recuperado", animal.StatusName);

            animal.Status = Animal.StatusId.InTreatment;
            Assert.AreEqual("Em tratamento", animal.StatusName);
        }

        [TestMethod]
        public void TestShouldReturnStatusNameDefaultCorrectly()
        {
            Animal animal = new Animal();

            Assert.AreEqual("Recuperado", animal.StatusName);
        }
    }
}
