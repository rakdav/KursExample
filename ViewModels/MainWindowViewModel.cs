using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursMVVM.Services;

namespace KursMVVM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    [ObservableProperty]
    private object? currentPage;
    [ObservableProperty]
    private string title;
    public MainWindowViewModel()
    {
        _navigationService = new NavigationService(this);
        _navigationService.RegisterPage("Home", new HomePageViewModel());
        _navigationService.RegisterPage("Settings", new SettingsPageViewModel());
        _navigationService.RegisterPage("About", new AboutPageViewModel());

        // Переходим на главную страницу
        _navigationService.NavigateTo("Home");
        title = "Магазин";
    }
    [RelayCommand]
    public void Navigate(string pageKey)
    {
        _navigationService.NavigateTo(pageKey);
    }
}
