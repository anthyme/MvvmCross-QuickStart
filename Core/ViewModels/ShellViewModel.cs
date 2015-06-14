using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class ShellViewModel : MvxViewModel
    {
        public override void Start()
        {
            ShowViewModel<ContactsViewModel>();
            ShowViewModel<ContactDetailsViewModel>();
        }
    }
}
