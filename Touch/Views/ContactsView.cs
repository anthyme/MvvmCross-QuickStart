using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using Core.ViewModels;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Touch.Views
{
    [Register("ContactsView")]
    public class ContactsView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText ., Converter=ContactFullName");
            TableView.Source = source;

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(source).To(x => x.Contacts);
            set.Bind(source).For(x=>x.SelectionChangedCommand).To(x => x.OpenContactCommand);
            set.Apply();
        }
    }
}