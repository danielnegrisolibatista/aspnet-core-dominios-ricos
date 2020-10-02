using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number)
        {
            Number = number;
        }
        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }
    }
}
