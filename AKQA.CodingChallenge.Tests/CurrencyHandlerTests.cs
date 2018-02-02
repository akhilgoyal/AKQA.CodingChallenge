using System;
using AKQA.CodingChallenge.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AKQA.CodingChallenge.Tests
{
    [TestClass]
    public class CurrencyHandlerTests
    {
        [TestMethod]
        public void ConvertToWord_Negative()
        {
            decimal amount = -1;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("- one dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Zero()
        {
            decimal amount = 0;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("zero dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_lessThanOne()
        {
            decimal amount = 0.89M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Eighty nine cents", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_One()
        {
            decimal amount = 1;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_Ten()
        {
            decimal amount = 10;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Ten Dollars", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_Hundred()
        {
            decimal amount = 100M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One Hundred Dollars", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_DollorAndCents()
        {
            decimal amount = 65342.563M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Sixty five thousand three hundred and forty two dollars and fifty six cents", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_Million()
        {
            decimal amount = 1234567.12M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One million  two hundred and thirty four thousand five hundred and sixty seven dollars and twelve cents", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_Billion()
        {
            decimal amount = 2454234856.54M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Two billion  four hundred and fifty four million  two hundred and thirty four thousand eight hundred and fifty six dollars and fifty four cents", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_Trillion()
        {
            decimal amount = 7671234567123.06M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Seven trillion  six hundred and seventy one billion  two hundred and thirty four million  five hundred and sixty seven thousand one hundred and twenty three dollars and six cents", words, true);
        }

        [TestMethod]
        public void ConvertToWord_Input_VeryLarge()
        {
            decimal amount = 12312345645678978956712345671.06M;
            OverflowException expectedExcetpion = null;

            try
            {
                AmountHandler.ConvertToWord(amount);
            }
            catch(OverflowException ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }
    }

}
