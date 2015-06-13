using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Droid.Views
{
    [Activity(Label = "View for ContactsViewModel")]
    public class ContactsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactsView);
        }
    }
}