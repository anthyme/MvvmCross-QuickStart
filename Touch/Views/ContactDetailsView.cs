using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Core.ViewModels;

namespace Touch.Views
{
    [MvxFromStoryboard("ContactDetailsView")]
    public partial class ContactDetailsView : MvxViewController
    {
        public ContactDetailsView()
        {
        }

        public ContactDetailsView(IntPtr intPtr)
            : base(intPtr)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactDetailsView, ContactDetailsViewModel>();
            set.Bind(IdText).To(x => x.Contact.Id);
            set.Bind(FirstnameText).To(x => x.Contact.Firstname);
            set.Bind(LastnameText).To(x => x.Contact.Lastname);
            set.Bind(PhoneNumberText).To(x => x.Contact.PhoneNumber);
            set.Apply();
        }
    }
}