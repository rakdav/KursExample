using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursMVVM.Models;
using KursMVVM.Services;
using KursMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.ViewModels
{
    public partial class ClientsPageViewModel:ViewModelBase
    {
        private ClientsPageService pageService;
        [ObservableProperty]
        private ObservableCollection<Client> clients=new();
        public ClientsPageViewModel()
        {
            pageService = new ClientsPageService();
            Load();
        }
        private void Load()
        {
            Clients.Clear();
            Clients = new ObservableCollection<Client>(getClients());
        }
        private List<Client> getClients() 
        {
            Task<List<Client>> task = Task.Run(() =>pageService.getClients());
            return task.Result;
        }
        [RelayCommand]
        private async Task Add()
        {
            try
            {
                var dialog=new ClientWindow();
                var result = await dialog.ShowDialog<bool>(MainWindow.Instance!);
                if (result == true)
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Load();
            }
        }
    }
}
