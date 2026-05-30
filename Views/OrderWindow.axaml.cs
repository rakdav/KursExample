using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KursMVVM.Models;
using KursMVVM.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KursMVVM;

public partial class OrderWindow : Window
{
    public Order Order { get; private set; }
    public OrderWindow(Order order)
    {
        InitializeComponent();
        Order = order;
        DataContext = this;
        using (KursContext db = new KursContext()) {
            ClientList.ItemsSource = getClients();
            ProductList.ItemsSource = getProducts();
        }
    }
    private List<Client> getClients()
    {
        Task<List<Client>> task = Task.Run(() => new ClientsPageService().getClients());
        return task.Result;
    }
    private List<Product> getProducts()
    {
        Task<List<Product>> task = Task.Run(() => new ProductPageService().getProducts());
        return task.Result;
    }
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        Close(Order);
    }
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close(null);
    }
}