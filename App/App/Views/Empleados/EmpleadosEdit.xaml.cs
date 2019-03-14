using App.Data;
using App.Models;
using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App.Views
{
    public sealed partial class EmpleadosEdit : Page
    {
        public EmpleadosEdit()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                this.DataContext = new EmpleadosDataService().Find((Guid)e.Parameter);
            }
        }
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            var data = (Empleado)DataContext;
            this.Frame.Navigate(typeof(EmpleadosDetails), data.EmpleadoID);
        }
        private void Guardar(object sender, RoutedEventArgs e)
        {
            var data = (Empleado)DataContext;
            new EmpleadosDataService().Update(data.EmpleadoID, data);
            this.Frame.Navigate(typeof(EmpleadosDetails));
        }
        private void ValidarNombre(object sender, TextChangedEventArgs e)
        {
            var t = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(t.Text))
            {
                ButtonGuardar.IsEnabled = true;
                NombreLabel.Text = "";
            }
            else
            {
                ButtonGuardar.IsEnabled = false;
                NombreLabel.Text = t.Header + " es requerido.";
            }
        }
        private void ValidarEdad(object sender, TextChangedEventArgs e)
        {
            Regex p = new Regex(@"[0-9]{1,2}");
            var t = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(t.Text))
            {
                if (p.IsMatch(t.Text))
                {
                    ButtonGuardar.IsEnabled = true;
                    EdadLabel.Text = "";
                }
                else
                {
                    ButtonGuardar.IsEnabled = false;
                    EdadLabel.Text = t.Header + " debe ser numero.";
                }
            }
            else
            {
                ButtonGuardar.IsEnabled = false;
                EdadLabel.Text = t.Header + " es requerido.";
            }
        }
    }
}
