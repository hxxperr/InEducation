using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InEducation.Server;
using InEducation.ViewModels.Base;
using System.Threading.Tasks;

namespace InEducation.ViewModels
{
    public class AdminPageViewModel : ViewModel
    {
        private InEducationEntities context = new InEducationEntities();

        private static Пользователь user = new Пользователь();

        private string _greet = $"Hi {user.Имя}, Welcome to AMONIC Airlines";

        public string Greet
        {
            get => _greet;
            set => Set(ref _greet, value);
        }
    }
}
