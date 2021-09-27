using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetCards(int decks)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/new/shuffle/?deck_count={decks}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Deck deck = await connection.Content.ReadAsAsync<Deck>();

            return View(deck);
        }
        public async Task<IActionResult> Draw(string deckId, int drawCount)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/{deckId}/draw/?count={drawCount}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);

            List<Card> cards = new List<Card>();
            Deck deck = await connection.Content.ReadAsAsync<Deck>();
          
            return View(deck);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
