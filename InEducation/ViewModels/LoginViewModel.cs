using InEducation.Infrastructure;
using InEducation.Server;
using InEducation.ViewModels.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InEducation.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private InEducationEntities context = new InEducationEntities();

        private string _Login;

        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        private string _password = "";

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand AuthorizationCommand =>
            new LambdaCommand(async (param) =>
            {
                try
                {
                    await UserConnect(Login, Password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, (param) => Login != "" && Password != "");

        private async Task UserConnect(string login, string password)
        {
            await Task.Run(() =>
            {
                var user = context.Пользователь.Where(u => u.Email == login &&
                u.Пароль == password).FirstOrDefault();
                if (user != null)
                {
                    if ((bool)user.Активность)
                    {
                        switch (user.Роль.Роль1)
                        {
                            case "Администратор":
                                //TODO переход страницы
                                break;
                            case "Преподаватель":
                                //TODO переход страницы
                                break;
                            case "Ученик":
                                //TODO переход страницы
                                break;
                        }
                    }
                    else
                        MessageBox.Show("Данный пользователь не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
