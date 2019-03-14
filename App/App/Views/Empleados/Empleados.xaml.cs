using App.Data;
using App.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace App.Views
{
    public sealed partial class Empleados : Page
    {
        public Empleados()
        {
            this.InitializeComponent();
            this.DataContext = new EmpleadosDbContext().ToList();
        }
        private void Detalles(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            this.Frame.Navigate(typeof(EmpleadosDetails), b.DataContext);
        }
        private void Agregar(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EmpleadosCreate));
        }

        //private void Seleccionar(object sender, SelectionChangedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(EmpleadosDetails));
        //}
    }
}
