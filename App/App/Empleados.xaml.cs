using App.Data;
using App.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace App
{
    public sealed partial class Empleados : Page
    {
        public List<Empleado> Model;
        public Empleados()
        {
            this.InitializeComponent();
            Model = new EmpleadosDataService().ToList();
        }
        private void Detalles(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EmpleadosDetails), (sender as Button).Tag);
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
