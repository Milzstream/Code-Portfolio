using System.Linq;
using BungieDestiny;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.BungieDestiny
{
    [TestClass]
    public class DestinyServiceTest
    {
        //Variables
        private DestinyService _service = new DestinyService("1843f6d8226e46d1a0a62ae021f6b408");

        [TestMethod]
        public void SearchPlayers()
        {
            //Variables
            MembershipType membershipType = MembershipType.Xbox;
            string displayName = "Shadeslayor";
            var response = _service.SearchPlayers(membershipType, displayName).FirstOrDefault();

            Assert.AreEqual(response?.DisplayName, displayName);
        }

        [TestMethod]
        public void GetAdvisors()
        {
            var response = _service.GetAdvisors();
        }
    }
}
