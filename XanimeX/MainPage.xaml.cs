using XanimeX.Model;
using XanimeX.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XanimeX.Views;

namespace XanimeX
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Anime> CarruselAnimeArray { get; set; } = new ObservableCollection<Anime>();
 
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;
            GetAnime();
        }
        //traemos la lista de animes a la vista principal
        public async void GetAnime()
        {
            AnimeList anime = new AnimeList();
            //AnimeArray.ItemsSource = await anime.GetAnime<Anime[]>();
            var array = await anime.GetAnime<Anime[]>();
            //llenamos el carrusel en este for
            foreach (var item in array)
            {
                CarruselAnimeArray.Add(item);
                // IdAnime = item.Id;
            }
        }
        private async void ImgClick_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            //obtenemos el id seleccionado.
            string Id = button.CommandParameter.ToString();
            //enviamos el id seleccionado a la PagesAnimeDetail
            await Navigation.PushAsync(new PagesAnimeDetail(Convert.ToInt32(Id)));

        }
    }

}
