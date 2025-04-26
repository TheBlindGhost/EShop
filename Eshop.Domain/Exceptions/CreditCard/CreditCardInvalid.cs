using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Exceptions.CreditCard
{
    public class CardNumberInvalideException : Exception
    {

        public CardNumberInvalideException() : base("Card Number is invalide") { }

        public CardNumberInvalideException(Exception innerException) : base("Card Number is invalide", innerException) { }




    }
}
