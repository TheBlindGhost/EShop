using EShop.Application.Services;
using Eshop.Domain.Exceptions.CreditCard;
namespace EShop.Application.Tests.Services
{
    public class CreditCardServiceTest
    {

        [Fact]
        public void ValidateCard_CheckCorrectLength_ExpectedTrue()
        {
            var validatecard = new CreditCardService();


            var card = validatecard.ValidateCardNumber("647389287647362");

            Assert.True(card);


        }

        [Fact]
        public void ValidateCard_NumberTooShortException_ExpectedTrue()
        {
            var validatecard = new CreditCardService();

            var card = "3425";

            Assert.Throws<CardNumberTooShortException>(() => validatecard.ValidateCardNumber(card));


        }

        [Fact]
        public void ValidateCard_NumberTooLongException_ExpectedTrue()
        {
            var validatecard = new CreditCardService();

            var card = "39097865675675675767497806769109";

            Assert.Throws<CardNumberTooLongException>(() => validatecard.ValidateCardNumber(card));

        }
        [Fact]

        public void ValidateCard_NumberIsInvalide_ExpectedTrue()
        {
            var validatecard = new CreditCardService();

            var card = "26.4-65342-65.24-654";

            Assert.Throws<CardNumberInvalideException>(() => validatecard.GetCardType(card));



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
        public void ValidateCard_CheckGetCardType_ReturnTrue(string cardNumber, string cardType)
        {

            var validatecard = new CreditCardService();

            var result = validatecard.GetCardType(cardNumber);

            Assert.Equal(result, cardType);
        }
    }
}
