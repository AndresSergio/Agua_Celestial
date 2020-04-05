using Pedidos.Models;
using Pedidos.Models.Usuario;
using Pedidos.Services;
using Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {   public BaseViewModel ViewModel { get; set; }
        public GeoLocation _GeoLocation = new GeoLocation();
        public RegisterPage()
        {
            InitializeComponent();
            geolocalizacion();
            this.IsBusy = false;


            nombre.TextChanged += Nombre_TextChanged;


        }
        void geolocalizacion()
        {
            Device.BeginInvokeOnMainThread(async () => {
                await _GeoLocation.getLocationGPS();
                lat.Text = GeoLocation.lat.ToString();
                lng.Text = GeoLocation.lng.ToString();

            });
        }
        private async void Nombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            //evento que controla si una tecla es presionada
            //char key = e.NewTextValue?.Last() ?? ' ';

            //if (key=='a')
            //{
            //    await this.DisplayAlert("Advertencia", "El campo del nombre es "+key+" .", "OK");
            //}

            
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new BaseViewModel();
            this.BindingContext = this;
            
        }

        async void Btn_account_Clicked(object sender, EventArgs e)
        {
            //agregar aqui las validaciones para cada entry del formulario
            
            if (await ValidarFormulario())
            {
                Cliente cliente = new Cliente()
                {

                    Nombre_cli =  nombre.Text,
                    Telefono_cli = Convert.ToInt32(telefono.Text),
                    Ci_cli = Convert.ToInt32(ci.Text),
                    Direccion_cli = direccion.Text,
                    Correo_cli = correo.Text,
                    Latitud = lat.Text,
                    Longitud = lng.Text,
                };

                registrar(cliente);
            }
            
          
        }

        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(nombre.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Nombre es obligatorio.", "OK");
                nombre.Focus();
                return false;
            }
            else if (nombre.Text.Length<4)
            {
                await this.DisplayAlert("Advertencia", "El campo Nombre debe tener por lo menos 4 letras, intente de nuevo.", "OK");
                nombre.Focus();
                return false;
            }
            
            else
            {
                //Valida si se ingresan caracteres especiales
                string caractEspecial = @"^[^ ][a-zA-Z ]+[^_\?\-\=\+\.\,\>\<\:\;\!\@\#\$\%\&\*\(\)\[\]\{\} ]$";
                string isnumber = @"^[0-9]$";
                string coleccion = nombre.Text;
                string var1;
                bool resultado2;
                bool resultado = Regex.IsMatch(nombre.Text, caractEspecial, RegexOptions.IgnoreCase);
                
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales en el campo nombre, intente de nuevo.", "OK");
                    nombre.Focus();
                    return false;
                }
                
                foreach (char c in coleccion)
                {
                    var1 = Convert.ToString(c);
                    resultado2 = Regex.IsMatch(var1, isnumber, RegexOptions.IgnoreCase);
                    if (resultado2)
                    {
                        await this.DisplayAlert("Advertencia", "El campo Nombre contiene números, porfavor ingrese solo letras.", "OK");
                        nombre.Focus();
                        return false;
                    }
                }
            }
            if (String.IsNullOrWhiteSpace(ci.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Cédula de Identidad es obligatorio.", "OK");
                ci.Focus();
                return false;
            }
            
            else
            {
                //Valida si se ingresan caracteres especiales
                string caractEspecial = @"^[^ ][0-9 ]+[^_\?\-\=\+\.\,\>\<\:\;\!\@\#\$\%\&\*\(\)\[\]\{\} ]$";
                bool resultado = Regex.IsMatch(ci.Text, caractEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales en el campo Cédula de Identidad, intente de nuevo.", "OK");
                    ci.Focus();
                    return false;
                }
            }
            if (String.IsNullOrWhiteSpace(telefono.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Teléfono es obligatorio.", "OK");
                telefono.Focus();
                return false;
            }
            //Valida que solo se ingresen letras
            else if (telefono.Text.ToCharArray().All(Char.IsLetter))
            {
                await this.DisplayAlert("Advertencia", "El campo Teléfono contiene letras, porfavor ingrese solo números.", "OK");
                telefono.Focus();
                return false;
            }
            else if (telefono.Text.Length != 8)
            {
                await this.DisplayAlert("Advertencia", "El campo Teléfono debe contener 8 dígitos, porfavor ingrese un teléfono válido.", "OK");
                telefono.Focus();
                return false;
            }

            else
            {
                //Valida si se ingresan caracteres especiales
                string caractEspecial = @"^[^ ][0-9 ]+[^_\?\-\=\+\.\,\>\<\:\;\!\@\#\$\%\&\*\(\)\[\]\{\} ]$";
                bool resultado = Regex.IsMatch(telefono.Text, caractEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales en el campo Teléfono, intente de nuevo.", "OK");
                    telefono.Focus();
                    return false;
                }
            }
            if (String.IsNullOrWhiteSpace(correo.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Correo Electrónico es obligatorio.", "OK");
                correo.Focus();
                return false;
            }
                       
            else
            {
                //Valida si se ingresan caracteres especiales
                string caractEspecial = @"^([a-zA-Z0-9_\.-]+)@([\da-zA-Z\.-]+)\.([a-z\.]{2,6})$";
                bool resultado = Regex.IsMatch(correo.Text, caractEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales en el campo Correo Electrónico o el formato no es el correcto \nEJEMPLO:\nmicorreo@empresa.com, intente de nuevo.", "OK");
                    correo.Focus();
                    return false;
                }
            }
           
            return true;
        

        }

        private async void  registrar(Cliente _customers)
        {
            //AppPedidosServices service = new AppPedidosServices();
            try
            {
                this.IsBusy = true;


                await AppPedidosServices.Post(_customers);
                //await DandoUmTempo(5000);
                this.IsBusy = false;
                await DisplayAlert("MESAJE", "REGISTRADO CORRECTAMENTE", "OK");

            }
            catch (Exception ex)
            {

                await DisplayAlert("upss", ex.ToString(), "OK", "cancelar");
            }
        }
        //async Task DandoUmTempo(int valor)
        //{
        //    await Task.Delay(valor);
        //}
    }
}