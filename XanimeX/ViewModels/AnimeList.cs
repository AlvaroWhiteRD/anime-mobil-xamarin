using XanimeX.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace XanimeX.ViewModels
{
    public class AnimeList
    {
        HttpClient client;

        //traemos la lista de animes a la vista
        public async Task<T> GetAnime<T>()
        {
            client = new HttpClient();

            var response = await client.GetAsync("http://10.0.2.2:5000/api/home/anime");
            //var response = await client.GetAsync("http://localhost:5000/api/home/anime");

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);

        }

        public async Task<List<Anime>> GetAnimeDetail(int idAnime)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://10.0.2.2:5000/api/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new StringContent(JsonConvert.SerializeObject( new { Id = idAnime }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"home/animedetail", request);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            var respuesta = JsonConvert.DeserializeObject<List<Anime>>(response.Content.ReadAsStringAsync().Result);
            return respuesta;
            //}
        }
        //traemos la lista de capitulos del anime
        //aqui traemos todos los capitulos que tiene el anime seleccionado
        public async Task<T> GetEpisodeAnimeList<T>(int idAnime)
        {
            client = new HttpClient();
            string UrlApi = "http://10.0.2.2:5000/api/home/anime/" + idAnime;
            var response = await client.GetAsync(UrlApi);
            //var response = await client.GetAsync("http://localhost:5000/api/home/anime");

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);

        }
        //este metodo se encarga de traer el episodio seleccionado del listView
        public async Task<T> GetOneEpisodeByAnime<T>(int idAnime, int numberEpisode)
        {
            client = new HttpClient();
            string UrlApi = "http://10.0.2.2:5000/api/home/anime/" + idAnime + "/"+ numberEpisode;
           
            var response = await client.GetAsync(UrlApi);
            
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);

        }


    }

}
