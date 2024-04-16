using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace galnko;

public partial class avtaris : Window
{

    public avtaris()
    {
        InitializeComponent();
    }



    private void vhod(object? sender, RoutedEventArgs e)
    {
        if (t1.Text="admin" && t2.Text="admin")
        {
            MainWindow2 = new MainWindow();
            this.haide();

        }
        else
        {
            
        }   
    }
}