using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.FullFragging;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.Droid.FullFragging.Presenter;
using Cirrious.MvvmCross.ViewModels;
using Core.ViewModels;

namespace Droid.Views
{
    [Activity(Label = "View for ContactsViewModel")]
    public class ShellView : MvxCachingFragmentActivity, IMvxFragmentHost
    {
        protected override void OnCreate(Bundle bundle)
        {
            RegisterHostedViews(bundle);
            SetContentView(Resource.Layout.ShellView);
            base.OnCreate(bundle);
        }

        public bool Show(MvxViewModelRequest request, Bundle bundle)
        {
            var vm = request.ViewModelType;
            if (vm == typeof (ContactDetailsViewModel))
            {
                ShowFragment(vm.FullName, Resource.Id.detail_container, bundle);
            }
            else if (vm == typeof (ContactsViewModel))
            {
                ShowFragment(vm.FullName, Resource.Id.view_container, bundle);
            }
            return true;
        }

        private void RegisterHostedViews(Bundle bundle)
        {
            RegisterView<ContactsView, ContactsViewModel>(bundle);
            RegisterView<ContactDetailsView, ContactDetailsViewModel>(bundle);
        }

        public void RegisterView<TFragment, TViewModel>(Bundle args, IMvxViewModel viewModel = null)
            where TFragment : IMvxFragmentView
            where TViewModel : IMvxViewModel
        {
            var customPresenter = Mvx.Resolve<IMvxFragmentsPresenter>();
            customPresenter.RegisterViewModelAtHost<TViewModel>(this);
            RegisterFragment<TFragment, TViewModel>(typeof (TViewModel).FullName);
        }

        public bool? Show<TViewModel>(MvxViewModelRequest request, Bundle bundle, int contentId)
        {
            if (typeof (TViewModel) != request.ViewModelType) return null;
            ShowFragment(request.ViewModelType.FullName, contentId, bundle);
            return true;
        }
    }
}