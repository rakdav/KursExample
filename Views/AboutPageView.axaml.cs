using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KursMVVM;

public partial class AboutPageView : UserControl
{
    public AboutPageView()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Binding(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
    }

    private void EditCommand_1(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
    }

    private void Binding(object? sender, Avalonia.Input.TappedEventArgs e)
    {
    }

    private void EditCommand_1(object? sender, Avalonia.Input.TappedEventArgs e)
    {
    }
}