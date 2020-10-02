using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        public void AdicionarSubscriptionTest()
        {
            //var subscription = new Subscription(null);
            //var student = new Student("Daniel", "Negrisoli Batista", "123459789", "daniel@daniel.com.br");

            //student.AddSubscription(subscription);

            var name = new Name("", "");

            foreach (var not in name.Notifications)
            {
                // not.Message
            }
        }
    }
}
