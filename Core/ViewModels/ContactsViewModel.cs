using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using Core.Models;
using Core.Services;

namespace Core.ViewModels
{
    public class ContactsViewModel 
		: MvxViewModel
    {
        private readonly IContactService _contactService;
        private ObservableCollection<Contact> _contacts;

        public ContactsViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public override void Start()
        {
            Contacts = new ObservableCollection<Contact>(_contactService.GetAll());
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }
    }
}
