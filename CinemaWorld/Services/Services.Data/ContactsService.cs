using CinemaWorld.Global.Common;
using CinemaWorld.Global.Common.Repositories;
using CinemaWorld.InputModels.Contacts;
using CinemaWorld.Models.Data.Models;
using CinemaWorld.Services.Services.Data.Contracts;
using CinemaWorld.Services.Services.Data.Mapping;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace CinemaWorld.Services.Services.Data
{
    public class ContactsService : IContactsService
    {
        private readonly IRepository<ContactFormEntry> userContactsRepository;
        private readonly IRepository<AdminContactFromEntry> adminContactsRepository;
        private readonly IEmailSender emailSender;

        public ContactsService(
            IRepository<ContactFormEntry> contactsRepository,
            IRepository<AdminContactFromEntry> adminContactsRepository,
            IEmailSender emailSender)
        {
            this.userContactsRepository = contactsRepository;
            this.adminContactsRepository = adminContactsRepository;
            this.emailSender = emailSender;
        }

        public async Task<IEnumerable<TModel>> GetAllUserEmailsAsync<TModel>()
        {
            var userEmails = await this.userContactsRepository
                            .All()
                            .To<TModel>()
                            .ToListAsync();
            return userEmails;
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SendContactToAdmin(ContactFormEntryViewModel contactFormViewModel)
        {
            var contactFormEntry = new ContactFormEntry
            {
                FirstName = contactFormViewModel.FirstName,
                LastName = contactFormViewModel.LastName,
                Email = contactFormViewModel.Email,
                Subject = contactFormViewModel.Subject,
                Content = contactFormViewModel.Content,
            };

            await this.userContactsRepository.AddAsync(contactFormEntry);
            await this.userContactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                contactFormViewModel.Email,
                contactFormViewModel.Subject,
                contactFormViewModel.Content);
        }
        public async Task SendContactToUser(SendContactInputModel sendContactInputModel)
        {
            var adminContactFormEntry = new AdminContactFromEntry
            {
                FullName = sendContactInputModel.FullName,
                Email = sendContactInputModel.Email,
                Subject = sendContactInputModel.Subject,
                Content = sendContactInputModel.Content,
            };

            await this.adminContactsRepository.AddAsync(adminContactFormEntry);
            await this.adminContactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                sendContactInputModel.Email,
                sendContactInputModel.Subject,
                sendContactInputModel.Content);
        }
    }
}
