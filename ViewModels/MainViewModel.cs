namespace MVVM_Tutorial.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new ReservationListingViewModel();
        }
    }
}
