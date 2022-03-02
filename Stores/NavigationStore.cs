using MVVM_Tutorial.ViewModels;
using System;

namespace MVVM_Tutorial.Stores
{
    /*
     * View간 이동을 할 때, 사용된다. 
     * 주로 MainViewModel에서 CurrentViewModelChanged에다가 이벤트를 추가하고 관리한다.
     */
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged = null;
    }
}
