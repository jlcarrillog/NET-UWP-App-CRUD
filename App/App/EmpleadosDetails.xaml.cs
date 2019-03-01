using App.Data;
using App.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App
{
    public sealed partial class EmpleadosDetails : Page
    {
        public Empleado Model;
        public EmpleadosDetails()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                //StorageFile file = (StorageFile)e.Parameter;
                Model = new EmpleadosDataService().Find((Guid)e.Parameter);
            }
        }
        private void Todos(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Empleados));
        }
        private void Editar(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EmpleadosEdit), (sender as Button).Tag);
        }
        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Eliminar el registro: " + Model.EmpleadoID);
            dialog.Title = "Eliminar";

            dialog.Commands.Add(new UICommand("Eliminar", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            dialog.Commands.Add(new UICommand("Cancelar"));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            await dialog.ShowAsync();
        }
        private void CommandInvokedHandler(IUICommand command)
        {
            new EmpleadosDataService().Remove(Model.EmpleadoID);
            this.Frame.Navigate(typeof(Empleados));
        }
    }
}
