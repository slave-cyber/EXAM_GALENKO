using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace galnko;

public partial class MainWindow : Window
{

    private List<pol> _stud;
    private string connStr = "server=10.10.1.24;database=fitcen;port=3306;User=student;password=student";
    private MySqlConnection conn;

    public MainWindow()
    {
        {
            InitializeComponent();
            string table = "SELECT * FROM student";
            ShowData(table);
       
        }
    }

    public void ShowData(string sql)
    {
        _stud = new List<pol>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentGuest = new pol()
            {

                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                phone = reader.GetString("phone"),
                rosden = reader.GetString("rosden"),
                пол = reader.GetString("пол"),
                скидка = reader.GetString("скидка")
            };
            _stud.Add(currentGuest);
        }

        conn.Close();
        fit.ItemsSource = _stud;
    }



    private void Dell_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM student WHERE id = {t1.Text}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            _stud.Remove(null);
            ShowData("SELECT id, fio, phone, adress FROM student;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    

    private void Filter_OnClick(object? sender, RoutedEventArgs e)
    {
        var pol = _stud;
        pol = pol.Where(x => x.name.Contains(t1.Text)).ToList();
        fit.ItemsSource = pol;
    }

    private void Filtervip_OnClick(object? sender, RoutedEventArgs e)
    {
        var gorod = (ComboBox)sender;
        var currentGor = gorod.SelectedItem as pol;
        var filtrGor = _stud
            .Where(x => x.пол == currentGor.пол)
            .ToList();
        fit.ItemsSource = filtrGor;
    }
}