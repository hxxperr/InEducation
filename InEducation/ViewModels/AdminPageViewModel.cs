using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InEducation.Server;
using InEducation.ViewModels.Base;
using System.Threading.Tasks;
using InEducation.Model;

namespace InEducation.ViewModels
{
    public class AdminPageViewModel : ViewModel, IObserver, IDisposable
    {
        private InEducationEntities context = new InEducationEntities();

        private static User GetUser { get; set; }

        private string _greet = "";

        public string Greet
        {
            get => _greet;
            set => Set(ref _greet, value);
        }

        private IObservable _concreteObservable;

        public IObservable ConcreteObservable
        {
            get => _concreteObservable;
            set
            {
                _concreteObservable = value;
                _concreteObservable.AddObserver(this);
            }
        }

        public void Update(User user)
        {
            GetUser = user;
        }

        public void Dispose()
        {
            ConcreteObservable.RemoveObserver(this);
        }
    }
}
