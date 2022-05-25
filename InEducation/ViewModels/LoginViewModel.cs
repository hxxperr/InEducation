﻿using InEducation.Infrastructure;
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
                var loginUser = context.Пользователь.Where(u => u.Email == login &&
                u.Пароль == password).FirstOrDefault();
                if (loginUser != null)
                {
                    if ((bool)loginUser.Активность)
                    {
                        switch (loginUser.Роль.Роль1)
                        {
                            case "Администратор":
                                User user = new User(loginUser.id_пользователя, loginUser.Фамилия, loginUser.Имя, loginUser.Отчество, loginUser.Дата_рождения);
                                Application.Current.Dispatcher.Invoke(() => Navigation.Navigation.GoTo(new AdminPage()));
                                break;
                            case "Преподаватель":
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    Navigation.Navigation.GoTo(new AdminPage());

                                });
                                break;
                            case "Ученик":
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    Navigation.Navigation.GoTo(new AdminPage());

                                });
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
