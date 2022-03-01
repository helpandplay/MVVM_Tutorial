using MVVM_Tutorial.Stores;
using MVVM_Tutorial.ViewModels;
using System;

namespace MVVM_Tutorial.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            /*
             * CurrentViewModel에 새로운 뷰모델을 할당한다.
             * 할당되는 것은 App.xaml.cs에서 service 객체를 생성할 때 지정한 뷰모델이다.
             */
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
