using Cirrious.MvvmCross.Plugins.Messenger;

namespace Core.Models.Events
{
    public class ContactSelected : MvxMessage
    {
        public int ContactId { get; private set; }

        public ContactSelected(object sender, int contactId)
            : base(sender)
        {
            ContactId = contactId;
        }
    }
}
