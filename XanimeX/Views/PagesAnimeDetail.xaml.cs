using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XanimeX.Model;
using XanimeX.ViewModels;

namespace XanimeX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagesAnimeDetail : ContentPage
    {
        AnimeList anime;

        public PagesAnimeDetail(int idAnime)
        {
            InitializeComponent();
            //IdAnime.Text = IdAnime.ToString();
            GetAnimeDetail(idAnime);
        }

        //traemos el anime seleccionado.
        public async void GetAnimeDetail(int id)
        {
            anime = new AnimeList();
            var animeDetail = await anime.GetAnimeDetail(id);
            foreach (var item in animeDetail)
            {
                Synopsis.Text = "Synopsis: " + item.Synopsis;
                Img.Source = item.Img;
                TitlesAnime.Text = item.Title;
            }
            //consultamos nuevamente la api para traer la lista de episodios del anime seleccionado
            GetEpisodeAnimeList(id);
        }
        //traemos la lista de Episodios a la vista principal
        public async void GetEpisodeAnimeList(int id)
        {
            anime = new AnimeList();
            EpisodeAnimeList.ItemsSource = await anime.GetEpisodeAnimeList<Episode[]>(id);

        }
        //este evento-metodo se encarga de tomar el el objeto clickeado del listViews
        // en este caso todo el id del anime y el numero del episodio 
        //para luego pasar esos datos ala consula.
        private async void EpisodeAnimeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Episode ItemSelected = (Episode) e.SelectedItem;
  
            await Navigation.PushAsync(new PagesAnimePlayer(ItemSelected));
        }

    }
}