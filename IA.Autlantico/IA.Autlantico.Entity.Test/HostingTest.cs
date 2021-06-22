using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IA.Autlantico.Entity.Test
{
    [TestClass]
    public class HostingTest
    {
        [TestMethod]
        public void TestShouldReturnStatusNameCorrectly()
        {
            Hosting hosting = new Hosting();

            hosting.Status = true;
            Assert.AreEqual("Ocupado", hosting.StatusName);

            hosting.Status = false;
            Assert.AreEqual("Livre", hosting.StatusName);
        }

        [TestMethod]
        public void TestShouldReturnStatusNameDefaultCorrectly()
        {
            Hosting hosting = new Hosting();

            Assert.AreEqual("Livre", hosting.StatusName);
        }
    }
}
