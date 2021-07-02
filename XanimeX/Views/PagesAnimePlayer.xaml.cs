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
    public partial class PagesAnimePlayer : ContentPage
    {
        private AnimeList animeList;

        private Episode[] listEpisode;
        private Button button;

        private int btnCount = 1;

        public PagesAnimePlayer(Episode episode)
        {
            InitializeComponent();

            GetOneEpisodeByAnime(episode.IdAnime, episode.EpisodeNumber);

        }
        //metodo que trae el episodio del anime seleccionado.
        async void GetOneEpisodeByAnime(int idAnime, int numberEpisode)
        {
            animeList = new AnimeList();
            listEpisode = await animeList.GetOneEpisodeByAnime<Episode[]>(idAnime, numberEpisode);

            if (listEpisode.Count() > 0)
            {//btnContentList
                foreach (var item in listEpisode)
                {

                    button = new Button();
                    button.Text = "Opcion "+btnCount;
                    button.Clicked += BtnPlayVideo_Clicked;
                    button.BackgroundColor = Color.Black;
                    button.TextColor = Color.White;
                    button.CommandParameter = item.EpisodeVideo;
                    button.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    button.VerticalOptions = LayoutOptions.CenterAndExpand;
                    button.CornerRadius = 15;
                    button.BorderColor = Color.Red;
                    button.FontAttributes = FontAttributes.Bold;
                    button.FontSize = 14;
                    //Aquí quiero mostrar mi botón en la pantalla
                    btnContentList.Children.Add(button);

                    btnCount++;
                }
            }
        }

        async void BtnPlayVideo_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //obtenemos el id seleccionado.
            string url = button.CommandParameter.ToString();
            await Navigation.PushAsync(new PagesPlayerVideo(url));

        }
    }
}