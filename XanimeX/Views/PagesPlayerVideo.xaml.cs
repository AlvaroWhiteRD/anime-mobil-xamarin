using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XanimeX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagesPlayerVideo : ContentPage
    {
      
        public PagesPlayerVideo( string urlVideo )
        {
            InitializeComponent();

            HtmlWebViewSource htmlContent = new HtmlWebViewSource();
            //htmlContent.Html = @"<iframe src='https://www.youtube.com/embed/gIt4hv501Bc' align='center' width='100%' height='100%' />";
            htmlContent.Html = @"<iframe src='"+urlVideo+"' align='center' width='100%' height='100%' />";
            PlayVideo.Source = htmlContent;

        }

    }
}