using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        // TODO pagamento da assinatura foi feito
        // TODO pagamento foi do valor total
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;

        public StudentTests()
        {
            _name = new Name("Daniel", "Negrisoli");
            _document = new Document("15061817591", EDocumentType.CPF);
            _email = new Email("daniel@daniel.com");
            _address = new Address("Rua X", "123", "Bairro", "Cidade", "UF", "Brazil", "00000-000");
            _student = new Student(_name, _document, _email);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("000000000000", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "", _document, _address, _email);
            subscription.AddPayment(payment);

            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHasSubscriptionHasNotPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("000000000000", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "", _document, _address, _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
