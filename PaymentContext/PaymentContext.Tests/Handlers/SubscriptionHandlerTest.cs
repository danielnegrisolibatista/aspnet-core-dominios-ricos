using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _document;
        private readonly string _email;
        private readonly string _barCode;
        private readonly string _boletoNumber;
        private readonly string _paymentNumber;
        private readonly DateTime _paidDate;
        private readonly DateTime _expireDate;
        private readonly decimal _total;
        private readonly decimal _totalPaid;
        private readonly string _payer;
        private readonly string _payerDocument;
        private readonly EDocumentType _payerDocumentType;
        private readonly string _payerEmail;
        private readonly string _street;
        private readonly string _number;
        private readonly string _neighborhood;
        private readonly string _city;
        private readonly string _state;
        private readonly string _country;
        private readonly string _zipCode;

        public SubscriptionHandlerTest()
        {
            _firstName = "Daniel";
            _lastName = "Negrisoli";
            _document = "9999999999";
            _email = "daniel@daniel.com";
            _barCode = "123456789";
            _boletoNumber = "1234654987";
            _paymentNumber = "123121";
            _paidDate = DateTime.Now.Date;
            _expireDate = DateTime.Now.AddMonths(1);
            _total = 100;
            _totalPaid = 100;
            _payer = "Payer";
            _payerDocument = "12345678911";
            _payerDocumentType = EDocumentType.CPF;
            _payerEmail = "payer@payer.com";
            _street = "Rua Payer";
            _number = "1010";
            _neighborhood = "Payer";
            _city = "São Paulo";
            _state = "SP";
            _country = "Brasil";
            _zipCode = "12345678";
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999999";
            command.Email = "daniel2@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = _paidDate;
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenDocumentNotExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999990";
            command.Email = "daniel2@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = _paidDate;
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(true, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenEmailExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999990";
            command.Email = "daniel@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = _paidDate;
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenEmailNotExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999990";
            command.Email = "daniel2@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = _paidDate;
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(true, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenPaidDateIsGreaterThanTheCurrentDate()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999990";
            command.Email = "daniel2@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = DateTime.Now.AddDays(1);
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenPaidDateIsEqualsThanTheCurrentDate()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = _firstName;
            command.LastName = _lastName;
            command.Document = "99999999990";
            command.Email = "daniel2@daniel.com";
            command.BarCode = _barCode;
            command.BoletoNumber = _boletoNumber;
            command.PaymentNumber = _paymentNumber;
            command.PaidDate = _paidDate;
            command.ExpireDate = _expireDate;
            command.Total = _total;
            command.TotalPaid = _totalPaid;
            command.Payer = _payer;
            command.PayerDocument = _payerDocument;
            command.PayerDocumentType = _payerDocumentType;
            command.PayerEmail = _payerEmail;
            command.Street = _street;
            command.Number = _number;
            command.Neighborhood = _neighborhood;
            command.City = _city;
            command.State = _state;
            command.Country = _country;
            command.ZipCode = _zipCode;

            handler.Handle(command);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}
