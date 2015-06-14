using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using Core.Models;
using Core.Models.Events;
using Core.Services;

namespace Core.ViewModels
{
    public class ContactDetailsViewModel : MvxViewModel
    {
        private readonly IContactService _contactService;
        private int _contactId;
        private Contact _contact;

        public ContactDetailsViewModel(IContactService contactService, IMvxMessenger messenger)
        {
            _contactService = contactService;
            messenger.SubscribeOnMainThread<ContactSelected>(Handle);
        }

        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }

        public void Init(int contactId)
        {
            _contactId = contactId;
        }

        public override void Start()
        {
            LoadContact();
        }

        private void LoadContact()
        {
            Contact = _contactService.Get(_contactId);
        }

        private void Handle(ContactSelected @event)
        {
            _contactId = @event.ContactId;
            LoadContact();
        }
    }
}
