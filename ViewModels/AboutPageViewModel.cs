using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursMVVM.ViewModels
{
    public partial class AboutPageViewModel:ViewModelBase
    {
        [ObservableProperty]
        private string version = "1.0.0";
        [ObservableProperty]
        public string appName = "Avalonia Navigation Demo";
    }
}
