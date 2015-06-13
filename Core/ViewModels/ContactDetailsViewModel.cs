using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Core.Models;
using Core.Services;

namespace Core.ViewModels
{
    public class ContactDetailsViewModel : MvxViewModel
    {
        private readonly IContactService _contactService;
        private int contactId;
        private Contact _contact;

        public ContactDetailsViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }

        public void Init(int contactId)
        {
            this.contactId = contactId;
        }

        public override void Start()
        {
            Contact = _contactService.Get(contactId);
        }
    }
}
