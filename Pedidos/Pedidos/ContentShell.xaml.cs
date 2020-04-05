using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentShell : Shell
    {
        public ContentShell()
        {
            InitializeComponent();
        }
    }
}