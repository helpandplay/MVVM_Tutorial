using MVVM_Tutorial.Models;
using MVVM_Tutorial.Services;
using MVVM_Tutorial.Stores;
using MVVM_Tutorial.ViewModels;
using System.Windows;

namespace MVVM_Tutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _hotel = new Hotel("Penguin Hotel");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // 첫화면은 예약 리스트 화면이다.
            _navigationStore.CurrentViewModel = CreateReservationListingViewModel();

            //이 곳에 Application에 있는 MainWindow에 객체를 할당해줘서
            //app.xaml.cs에 starturl를 쓰지 않아도 작업할 수 있다.
            //이렇게 하게 되면 mvvm을 지키면서 datacontext를 할당할 수 있다.
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        /*
         * 
         */
        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationListingViewModel));
        }

        private ReservationListingViewModel CreateReservationListingViewModel()
        {
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
