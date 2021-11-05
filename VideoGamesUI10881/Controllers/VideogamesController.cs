using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VideoGamesUI10881.Models;

namespace VideoGamesUI10881.Controllers
{
    public class VideogamesController : Controller
    {
        private HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:41564/";

        private HttpClient GetHttpClient(string url)
        {
            string Baseurl = url;
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        // GET: Videogames
        public async Task<ActionResult> Index()
        {
            List<Videogame> list = new List<Videogame>();

            _httpClient = GetHttpClient(_baseUrl);
            HttpResponseMessage Res = await _httpClient.GetAsync("api/Videogames");
            if (Res.IsSuccessStatusCode)
            {
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Videogame>>(PrResponse);

            }
            return View(list);
        }

        // GET: Videogames/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Videogame game = null;

            _httpClient = GetHttpClient(_baseUrl);
            HttpResponseMessage Res = await _httpClient.GetAsync("api/Videogames/" + id);
            if (Res.IsSuccessStatusCode)
            {
      
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                game = JsonConvert.DeserializeObject<Videogame>(PrResponse);

            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Videogames/Create
        public ActionResult Create()
        {
            var viewModel = new Videogame();
            return View(viewModel);
        }

        // POST: Videogames/Create
        [HttpPost]
        public async Task<ActionResult> Create(Videogame game)
        {
            try
            {
                _httpClient = GetHttpClient(_baseUrl);
                var result = await _httpClient.PostAsJsonAsync("api/Videogames/", game);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(game);
            }
            catch
            {
                return View();
            }
        }

        // GET: Videogames/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Videogame game = null;
            _httpClient = GetHttpClient(_baseUrl);
            HttpResponseMessage Res = await _httpClient.GetAsync("api/Videogames/" + id);
 
            if (Res.IsSuccessStatusCode)
            {
        
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                game = JsonConvert.DeserializeObject<Videogame>(PrResponse);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // POST: Videogames/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Videogame game)
        {
            try
            {
                _httpClient = GetHttpClient(_baseUrl);
                var result = await _httpClient.PutAsJsonAsync("api/Videogames/" + game.Id, game);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(game);
            }
            catch
            {
                return View();
            }
        }

        // GET: Videogames/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Videogame game = null;
            _httpClient = GetHttpClient(_baseUrl);
            HttpResponseMessage Res = await _httpClient.GetAsync("api/Videogames/" + id);

            if (Res.IsSuccessStatusCode)
            {

                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                game = JsonConvert.DeserializeObject<Videogame>(PrResponse);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // POST: Videogames/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Videogame game)
        {
            try
            {
                _httpClient = GetHttpClient(_baseUrl);
                HttpResponseMessage Res = await _httpClient.GetAsync("api/Videogames/" + id);
                Videogame vgame = null;
                if (Res.IsSuccessStatusCode)
                {
                    var PrResponse = await Res.Content.ReadAsStringAsync();
                    //Deserializing the response recieved from web api and storing into the Product list
                    vgame = JsonConvert.DeserializeObject<Videogame>(PrResponse);
                }

                var result = await _httpClient.DeleteAsync("api/Videogames/" + game.Id);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(vgame);
            }
            catch
            {
                return View();
            }
        }
    }
}
