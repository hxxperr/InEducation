using InEducation.Infrastructure;
using InEducation.Server;
using InEducation.ViewModels.Base;
using System;
using System.Linq;
using InEducation.Model;
using System.Threading.Tasks;
using InEducation.View.Pages;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.Generic;

namespace InEducation.ViewModels
{
    public class LoginViewModel : ViewModel, IObservable
    {
        private InEducationEntities context = new InEducationEntities();
        private readonly List<IObserver> _observers = new List<IObserver>();

        private User _user;

        public User NewUser
        {
            get => _user;
            set
            {
                Set(ref _user, value);
                NotifyObservers();
            } 
        }

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
        /// <summary>
        /// Команда авторизации
        /// </summary>
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
        /// <summary>
        /// Поиск пользователя по данным введные в свойства класса и выполнение входа
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task UserConnect(string login, string password)
        {
            // Выполняется асинхронно
            await Task.Run(() =>
            {
                var loginUser = context.Пользователь.Where(u => u.Email == login &&
                u.Пароль == password).FirstOrDefault();
                if (loginUser != null)
                {
                    if ((bool)loginUser.Активность)
                    {
                        switch (loginUser.Роль.Роль1)
                        {
                            case "Администратор":
                                Application.Current.Dispatcher.Invoke(() => Navigation.Navigation.GoTo(new AdminView()));
                                break;
                            case "Преподаватель":
                                Application.Current.Dispatcher.Invoke(() => Navigation.Navigation.GoTo(new TeacherView()));
                                break;
                            case "Ученик":
                                Application.Current.Dispatcher.Invoke(() => Navigation.Navigation.GoTo(new TeacherView()));
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

        public void AddObserver(IObserver observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(NewUser);
            }

        }
        //User user = new User(loginUser.id_пользователя, loginUser.Фамилия, loginUser.Имя, loginUser.Отчество, loginUser.Дата_рождения);

    }
}
