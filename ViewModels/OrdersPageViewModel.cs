using CommunityToolkit.Mvvm.ComponentModel;
using KursMVVM.Models;
using KursMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.ViewModels
{
    public partial class OrdersPageViewModel:ViewModelBase
    {
        private OrderPageService orderPageService;
        [ObservableProperty]
        private ObservableCollection<Order> orders = new();
        [ObservableProperty]
        private Order selectedOrder;
        public OrdersPageViewModel()
        {
            orderPageService=new OrderPageService();
        }
        private void Load()
        {
            Orders.Clear();
            Orders = new ObservableCollection<Order>(getOrders());
        }
        private List<Order> getOrders()
        {
            Task<List<Order>> task = Task.Run(() => orderPageService.getOrders());
            return task.Result;
        }
    }
}
