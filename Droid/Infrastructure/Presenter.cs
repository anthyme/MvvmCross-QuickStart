using System;
using System.Collections.Generic;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.FullFragging.Presenter;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;

namespace Droid.Infrastructure
{
    public class Presenter : MvxAndroidViewPresenter, IMvxFragmentsPresenter
    {
        public const string ViewModelRequestBundleKey = "__mvxViewModelRequest";

        private readonly Dictionary<Type, IMvxFragmentHost> _dictionary = new Dictionary<Type, IMvxFragmentHost>();
        private IMvxNavigationSerializer _serializer;

        protected IMvxNavigationSerializer Serializer
        {
            get
            {
                if (_serializer != null)
                    return _serializer;

                _serializer = Mvx.Resolve<IMvxNavigationSerializer>();
                return _serializer;
            }
        }

        public void RegisterViewModelAtHost<TViewModel>(IMvxFragmentHost host)
            where TViewModel : IMvxViewModel
        {
            if (host == null)
            {
                Mvx.Warning("You passed a null IMvxFragmentHost, removing the registration instead");
                UnRegisterViewModelAtHost<TViewModel>();
            }

            _dictionary[typeof(TViewModel)] = host;
        }

        public void UnRegisterViewModelAtHost<TViewModel>()
            where TViewModel : IMvxViewModel
        {
            _dictionary.Remove(typeof(TViewModel));
        }

        public override void Show(MvxViewModelRequest request)
        {
            var bundle = new Bundle();
            string serializedRequest = Serializer.Serializer.SerializeObject(request);
            bundle.PutString(ViewModelRequestBundleKey, serializedRequest);

            IMvxFragmentHost host;
            if (_dictionary.TryGetValue(request.ViewModelType, out host))
            {
                if (host.Show(request, bundle))
                    return;
            }

            base.Show(request);
        }
    }
}