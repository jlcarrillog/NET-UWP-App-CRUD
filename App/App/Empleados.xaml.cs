﻿using App.Data;
using App.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace App
{
    public sealed partial class Empleados : Page
    {
        private List<Empleado> Model = new List<Empleado>();
        public Empleados()
        {
            this.InitializeComponent();
            Datos();
        }
        private void Datos()
        {
            Model = new EmpleadosDataService().ToList();
            this.DataContext = Model;
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
