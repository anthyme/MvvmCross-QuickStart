using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using Core.Models;
using Core.Models.Events;
using Core.Services;

namespace Core.ViewModels
{
    public class ContactsViewModel 
		: MvxViewModel
    {
        private readonly IContactService _contactService;
        private readonly IMvxMessenger _messenger;
        private ObservableCollection<Contact> _contacts;

        public ContactsViewModel(IContactService contactService, IMvxMessenger messenger)
        {
            _contactService = contactService;
            _messenger = messenger;
            OpenContactCommand = new MvxCommand<Contact>(OpenContact);
        }

        public ICommand OpenContactCommand { get; set; }

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        public override void Start()
        {
            Contacts = new ObservableCollection<Contact>(_contactService.GetAll());
        }

        private void OpenContact(Contact contact)
        {
            _messenger.Publish(new ContactSelected(this, contact.Id));
        }
    }
}
