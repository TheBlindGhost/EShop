using EShop.Application.Services;

namespace EShop.Application.Tests.Services
{
    public class CreditCardServiceTest
    {

        [Fact]
        public void ValidateCard_CardHas12Digits_ExpectedFalse()
        {
            var validatecard = new CreditCardService();


            var card = validatecard.ValidateCardNumber("342516738109");

            Assert.False(card);


        }

        [Fact]
        public void ValidateCard_CardHas19Digits_ExpectedFalse()
        {
            var validatecard = new CreditCardService();

            var card = validatecard.ValidateCardNumber("3425169754678738109");

            Assert.False(card);


        }

        [Fact]
        public void ValidateCard_CardHasLessThan12Digits_ExpectedFalse()
        {
            var validatecard = new CreditCardService();

            var card = validatecard.ValidateCardNumber("3109");

            Assert.False(card);

        }

        [Fact]
        public void ValidateCard_CardHasMoreThan19Digits_ExpectedFalse()
        {
            var validatecard = new CreditCardService();

            var card = validatecard.ValidateCardNumber("34251697546787381099265432");

            Assert.False(card);

        }
        

       

        [Theory]
        [InlineData("3497 7965 8312 797")]
        [InlineData("345-470-784-783-010")]
        [InlineData("378523393817437")]
        [InlineData("4024-0071-6540-1778")]
        [InlineData("4532 2080 2150 4434")]
        [InlineData("4532289052809181")]
        [InlineData("5530016454538418")]
        [InlineData("5551561443896215")]
        [InlineData("5131208517986691")]
        public void ValidateCard_CheckCardValidator_ReturnTrue(string cardNumber)
        {
  
            var validatecard = new CreditCardService();

            var result = validatecard.ValidateCardNumber(cardNumber);

            Assert.True(result);
        }

        [Theory]
        [InlineData("3497 7965 8312 797", "American Express")]
        [InlineData("345-470-784-783-010", "American Express")]
        [InlineData("378523393817437", "American Express")]
        [InlineData("4024-0071-6540-1778", "Visa")]
        [InlineData("4532 2080 2150 4434", "Visa")]
        [InlineData("4532289052809181", "Visa")]
        [InlineData("5530016454538418", "MasterCard")]
        [InlineData("5551561443896215", "MasterCard")]
        [InlineData("5131208517986691", "MasterCard")]
        [InlineData("", "Unknown")]
        public void ValidateCard_CheckGetCardType_ReturnTrue(string cardNumber, string cardType)
        {

            var validatecard = new CreditCardService();

            var result = validatecard.GetCardType(cardNumber);

            Assert.Equal(result, cardType);
        }
    }
}
