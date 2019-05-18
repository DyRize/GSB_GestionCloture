using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GSB_GestionCloture.Tests
{
    [TestClass()]
    public class GestionDatesTests
    {
        [TestMethod()]
        public void GetMoisPrecedentTest()
        {
            Assert.AreEqual("04", GestionDates.GetMoisPrecedent(), "Le mois doit être égal à 04");
        }

        [TestMethod()]
        public void GetMoisPrecedentTest1()
        {
            Assert.AreEqual("08", GestionDates.GetMoisPrecedent(Convert.ToDateTime("12/09/2019")), "Le mois doit être égal à 08");
            Assert.AreNotEqual("00", GestionDates.GetMoisPrecedent(Convert.ToDateTime("12/01/2019")), "Le mois ne doit pas être égal à 00");
        }

        [TestMethod()]
        public void GetMoisSuivantTest()
        {
            Assert.AreEqual("06", GestionDates.GetMoisSuivant(), "Le mois doit être égal à 06");
        }

        [TestMethod()]
        public void GetMoisSuivantTest1()
        {
            Assert.AreEqual("10", GestionDates.GetMoisSuivant(Convert.ToDateTime("12/09/2019")), "Le mois doit être égal à 10");
            Assert.AreNotEqual("13", GestionDates.GetMoisSuivant(Convert.ToDateTime("12/12/2019")), "Le mois ne doit pas être égal à 13");
        }

        [TestMethod()]
        public void EntreTest()
        {
            Assert.AreEqual(true, GestionDates.Entre(03, 05), "La fonction doit retourner vrai");
            Assert.AreEqual(false, GestionDates.Entre(05, 30), "La fonction doit retourner false");
        }

        [TestMethod()]
        public void EntreTest1()
        {
            DateTime uneDate = new DateTime();
            uneDate = Convert.ToDateTime("25/10/1999");
            Assert.AreEqual(true, GestionDates.Entre(24, 26, uneDate), "La fonction doit retourner vrai");
            Assert.AreEqual(false, GestionDates.Entre(01, 24, uneDate), "La fonction doit retourner false");
        }
    }
}