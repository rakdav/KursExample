using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KursMVVM.Models;
using System.Linq.Expressions;

namespace KursMVVM;

public partial class ClientWindow : Window
{
    public Client Client {  get; private set; }
    public ClientWindow(Client _client)
    {
        InitializeComponent();
        Client = _client;
        DataContext = Client;
    }
}