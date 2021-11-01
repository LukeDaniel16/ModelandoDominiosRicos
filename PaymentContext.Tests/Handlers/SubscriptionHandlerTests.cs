using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(
                new FakeStudentRepository(),
                new FakeEmailService()
            );

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Clark";
            command.LastName = "Kent";
            command.Document = "99999999999";
            command.Email = "hello@balta.io";
            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "123123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Kent SA";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "superman@dc.com";
            command.Street = "Rua 5";
            command.Number = "55";
            command.Neighborhood = "Centro";
            command.City = "Metropolis";
            command.State = "Illinois";
            command.Country = "USA";
            command.ZipCode = "123456789";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}
