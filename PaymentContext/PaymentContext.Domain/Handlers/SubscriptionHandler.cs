﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>,
        IHandler<CreateCredicardSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar");
            }

            //verificar se doc esta cadastrado
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            //verificar se email já esta cadastrado
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Este email já está em uso");
            }

            //gerar os vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);

            //gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer, 
                new Document(command.PayerDocument, command.PayerDocumentType), 
                address, 
                email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //salvar as informações
            _studentRepository.CreateSubscription(student);

            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");

            //retorna informaçoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar");
            }

            //verificar se doc esta cadastrado
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            //verificar se email já esta cadastrado
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Este email já está em uso");
            }

            //gerar os vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);

            //gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //salvar as informações
            _studentRepository.CreateSubscription(student);

            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");

            //retorna informaçoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCredicardSubscriptionCommand command)
        {
            //fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar");
            }

            //verificar se doc esta cadastrado
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            //verificar se email já esta cadastrado
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Este email já está em uso");
            }

            //gerar os vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);

            //gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //salvar as informações
            _studentRepository.CreateSubscription(student);

            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");

            //retorna informaçoes
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
