using MVVM_Tutorial.Stores;

namespace MVVM_Tutorial.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            /* 
             * 1. NavigationStore에 새로운 CurrentViewModel이 할당된다. 
             * 2. NavigationStore의 Set에서 OnCurrentViewModelChanged()가 호출된다.
             * 3. OnCurrentViewModelChanged()는 CurrentViewModelChanged 이벤트를 호출한다.
             * 4. MainViewModel에서 CurrentViewModelChanged에 추가한 OnCurrentViewModelChanged(MainViewModel)이 호출된다.
             * 5. CurrentViewModel의 변경을 View에 알린다.
             * 6. CurrentViewModel이 업데이트되고 ViewModel에 따라 뷰가 바뀐다.
             */
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
