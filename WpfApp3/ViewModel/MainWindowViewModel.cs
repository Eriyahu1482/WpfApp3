using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;
using WpfApp3.Core;

namespace WpfApp3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _createCommand;
        private Task2BDEntities _db = new Task2BDEntities();

        private string _testText = "А ты ли Лаура?";

        private string _fLogin = "01";
        private string _fPassword = "01";

        private string _userLogin;
        private string _userPassword;

        public string UserLogin
        {
            get => _userLogin;
            set                           
            {
                _userLogin = value;
                OnPropertyChanged();
            }
        }
        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }




        private string _buttonTitle = "Войти";

        public string ButtonTitle
        {
            get => _buttonTitle;
            set
            {
                _buttonTitle = value;
                OnPropertyChanged();
            }
        }


        public string TestText
        {
            get => _testText;
            set
            {
                _testText = value;
                OnPropertyChanged();

            }
        }


        public ICommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new RelayCommand(param => CreateNewCommand()));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void CreateNewCommand()
        {
            if (_fLogin == UserLogin && _fPassword == UserPassword)
            {
                User userModel = _db.Users.FirstOrDefault(predicate: x => x.Login == UserLogin && x.Password == UserPassword);
                UserLogin = string.Empty;
                UserPassword = string.Empty;
                ButtonTitle = "Laura 01";
                if (userModel != null)
                {
                    switch (userModel.Role.RoleID)
                    {
                        case 1:
                            TestText = "вы один";
                            break;
                        case 2:
                            TestText = "ds jlby";
                            break;
                    }
                }
                else
                {
                    TestText = "Dай хлеба";
                }
            }
        }
    }
}
