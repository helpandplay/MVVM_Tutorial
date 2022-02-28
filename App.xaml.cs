using MVVM_Tutorial.ViewModels;
using System.Windows;

namespace MVVM_Tutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //이 곳에 Application에 있는 MainWindow에 객체를 할당해줘서
            //app.xaml.cs에 starturl를 쓰지 않아도 작업할 수 있다.
            //이렇게 하게 되면 mvvm을 지키면서 datacontext를 할당할 수 있다.
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
