using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Droid.Views
{
    [Activity(Label = "View for ContactDetailsViewModel")]
    public class ContactDetailsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContactDetailsView);
        }
    }
}