using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // red, green, refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("31340204000103", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        } 

        [TestMethod]
        [DataTestMethod]
        [DataRow("56674651320")]
        [DataRow("03140525850")]
        [DataRow("90725665645")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }

    }
}
