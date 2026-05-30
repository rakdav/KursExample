using Avalonia;
using Avalonia.Controls;
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
using Tmds.DBus.Protocol;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace KursMVVM.ViewModels
{
    public partial class ClientsPageViewModel : ViewModelBase
    {
        private ClientsPageService pageService;
        [ObservableProperty]
        private ObservableCollection<Client> clients = new();
        [ObservableProperty]
        private Client selectedClient;
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
            Task<List<Client>> task = Task.Run(() => pageService.getClients());
            return task.Result;
        }
        [RelayCommand]
        private async Task Add()
        {
            try
            {
                var dialog = new ClientWindow(new
                    Client());
                Client result = await dialog.ShowDialog<Client>(MainWindow.Instance!);
                if (result != null)
                {
                    await pageService.AddClient(result);
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
        [RelayCommand]
        private async Task Edit(object param)
        {
            if (param != null)
            {
                Client client=(Client)param;
                ClientWindow dialog = new ClientWindow(client);
                Client result = await dialog.ShowDialog<Client>(MainWindow.Instance!);
                if (result != null)
                {
                    await pageService.EditClient(result);
                    Load();
                }
            }
        }
        [RelayCommand]
        private async Task Delete(object param)
        {
            if (param != null)
            {
                var box = MessageBoxManager
        .GetMessageBoxStandard("Внимание", "Вы действительно хотите удалить объект?", ButtonEnum.OkCancel);
                ButtonResult result = await box.ShowAsync();
                if (result == ButtonResult.Ok)
                {
                    Client client = (Client)param;
                    await pageService.DeleteClient(client.IdClient);
                    Load();
                }
            }
        }
    }
}
