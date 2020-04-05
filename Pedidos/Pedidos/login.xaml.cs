using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Models;
using Pedidos.Services;
using Newtonsoft.Json;
using Syncfusion.XForms.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using Pedidos.ViewModels;

namespace Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            this.BindingContext = this;

            //Grid grid = new Grid();
            //SfGradientView gradientView = new SfGradientView();
            //SfLinearGradientBrush linearGradientBrush = new SfLinearGradientBrush();
            //linearGradientBrush.GradientStops = new GradientStopCollection()
            //{
            //    new SfGradientStop(){Color = Color.FromHex("#2d265b"), Offset=0.0},
            //    new SfGradientStop(){Color = Color.FromHex("#b8495c"), Offset=1.0},
            //};
            //gradientView.BackgroundBrush = linearGradientBrush;
            //grid.Children.Add(gradientView);
            //this.Content = grid;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            Application.Current.MainPage = new ContentShell();
            this.IsBusy = false;
            await DisplayAlert("MESAJE", "ACCESO CORRECTO", "OK");
            //RaizViewModel rm = new RaizViewModel();

            //if (await ValidarFormulario())
            //{

            //    Usuarios user = new Usuarios()
            //    {
            //        Login_usr = Correo.Text,
            //        Passw_usr = Password.Text
            //    };


            //    verifyLogin(user);

            //}

        }

        private async void verifyLogin(Usuarios _user)
        {
            //    try
            //    {
            //        this.IsBusy = true;



            //        var result = await AppPedidosServices.Login(_user);
            //        if (result)
            //        {
            //            Application.Current.MainPage = new ContentShell();
            //            this.IsBusy = false;
            //            await DisplayAlert("MESAJE", "ACCESO CORRECTO", "OK");


            //        }
            //        else
            //        {
            //            this.IsBusy = false;
            //            await DisplayAlert("MESAJE", "ACCESO INCORRECTO", "accept");
            //        }

            //        //await DandoUmTempo(5000);



            //    }
            //    catch (Exception ex)
            //    {

            //        await DisplayAlert("Advertencia", ex.ToString(), "accept");
            //        Correo.Focus();
            //        this.IsBusy = false;

            //    }


        }

    private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Client.RegisterPage());
            
        }
        //private async Task<bool> ValidarFormulario()
        //{
            
        //    if (String.IsNullOrWhiteSpace(Correo.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo del Correo Electrónico es obligatorio.", "OK");
        //        Correo.Focus();
        //        return false;
        //    }

        //    else
        //    {
        //        //Valida si se ingresan caracteres especiales
        //        //string caractEspecial = @"^([a-zA-Z0-9_\.-]+)@([\da-zA-Z\.-]+)\.([a-z\.]{2,6})$";
        //        string caractEspecial = @"^[a-zA-Z0-9 ]+[^_\?\-\=\+\.\,\>\<\:\;\!\@\#\$\%\&\*\(\)\[\]\{\} ]$";
        //        bool resultado = Regex.IsMatch(Correo.Text, caractEspecial, RegexOptions.IgnoreCase);
        //        if (!resultado)
        //        {
        //            await this.DisplayAlert("Advertencia", "El campo Correo Electrónico no permite caracteres especiales, intente de nuevo.", "OK");
        //            Correo.Focus();
        //            return false;
        //        }
        //    }
        //    if (String.IsNullOrWhiteSpace(Password.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo del Contraseña es obligatorio.", "OK");
        //        Password.Focus();
        //        return false;
        //    }
            

        //    return true;


        //}

    }
}