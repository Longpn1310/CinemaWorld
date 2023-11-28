﻿using CinemaWorld.InputModels.Contacts;
using CinemaWorld.Services.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWorld.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactFormEntryViewModel contactFormViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(contactFormViewModel);
            }

            await this.contactsService.SendContactToAdmin(contactFormViewModel);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
