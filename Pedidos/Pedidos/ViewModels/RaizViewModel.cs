using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Pedidos.ViewModels
{
    public class RaizViewModel : INotifyPropertyChanged
    {

        public string indicador { get => indicador1; set { indicador1 = value; OnPropertyChanged(nameof(indicador)); } }
        public string IsEmpty { get => isEmpty; set { isEmpty = value; OnPropertyChanged(nameof(IsEmpty)); } }
        public string ClickProd { get => clickProd; set { clickProd = value; OnPropertyChanged(nameof(ClickProd)); } }

        private bool _isBusy;
        private string indicador1;
        private string isEmpty;
        private string clickProd;

        public bool Isbusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(Isbusy));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }



    }

}
