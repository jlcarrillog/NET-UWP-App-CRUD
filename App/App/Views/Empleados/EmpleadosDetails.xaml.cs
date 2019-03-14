using App.Data;
using App.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App.Views
{
    public sealed partial class EmpleadosDetails : Page
    {
        public EmpleadosDetails()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                this.DataContext = new EmpleadosDbContext().Find((Guid)e.Parameter);
            }
        }
        private void Todos(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Empleados));
        }
        private void Editar(object sender, RoutedEventArgs e)
        {
            var data = (Empleado)DataContext;
            this.Frame.Navigate(typeof(EmpleadosEdit), data.EmpleadoID);
        }
        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            var data = (Empleado)DataContext;
            var dialog = new MessageDialog("¿Eliminar el registro?");
            dialog.Title = "Eliminar";

            dialog.Commands.Add(new UICommand("Eliminar", (command) =>
            {
                //new EmpleadosDbContext().Remove(data.EmpleadoID);
                this.Frame.Navigate(typeof(Empleados));
            }));
            dialog.Commands.Add(new UICommand("Cancelar"));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            await dialog.ShowAsync();
        }
    }
}
