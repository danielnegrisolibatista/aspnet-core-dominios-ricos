using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRespository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
            {
                return true;
            }

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "daniel@daniel.com")
            {
                return true;
            }

            return false;
        }
    }
}
