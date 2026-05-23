using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursMVVM.ViewModels
{
    public partial class SettingsPageViewModel:ViewModelBase
    {
        [ObservableProperty]
        private bool isDarkTheme;
        [ObservableProperty]
        private string userName = "Пользователь";
    }
}
