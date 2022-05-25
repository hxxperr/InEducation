namespace InEducation.ViewModels.Base
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            TitleBarVM = new TitleBarViewModel();

            LoginVM = new LoginViewModel();

        }

        public ViewModel MainVM { get; set; }

        public ViewModel TitleBarVM { get; set; }

        public ViewModel LoginVM { get; set; }
    }
}
