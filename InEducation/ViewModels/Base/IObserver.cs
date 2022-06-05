using InEducation.Model;

namespace InEducation.ViewModels.Base
{
    public interface IObserver
    {
        void Update(User user);
    }
}