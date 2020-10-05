using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("999999999" + i.ToString().Trim(), EDocumentType.CPF),
                    new Email(i.ToString() + "@daniel.com")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var expression = StudentQueries.GetStudentInfo("00000000000");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var expression = StudentQueries.GetStudentInfo("9999999991");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}
