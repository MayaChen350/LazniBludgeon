using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LazniBludgeon.Card
{
    public class Deck
    {
        public PlayerCard[] PlayerCardsList { get; private set; }

        public SoldierCard[] SoldierCardsList {  get; private set; }

        public Deck()
        {
            // Splitted in two methods to not make the cpu suffocate too much with jsons

            InitPlayerCards();

            InitSoldierCards();

        }

        private void InitPlayerCards()
        {
            string playerCardsJson = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("LazniBludgeon.Card.CardData.PlayerCard.json")).ReadToEnd();
            var playerCards = JsonConvert.DeserializeObject<dynamic>(playerCardsJson);
            List<PlayerCard> list = new List<PlayerCard>();
            foreach (var playerCard in playerCards)
            {
                list.Add(new PlayerCard((string)playerCard.Name,(int)playerCard.HP, (int)playerCard.ATK));
                PlayerCardsList = list.ToArray();
            }
        }

        private void InitSoldierCards()
        {
            string SoldierCardsJson = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("LazniBludgeon.Card.CardData.SoldierCard.json")).ReadToEnd();
            var cards = JsonConvert.DeserializeObject<dynamic>(SoldierCardsJson);
            List<SoldierCard> list = new List<SoldierCard>();

            foreach (var card in cards)
            {
                list.Add(new SoldierCard((string)card.Name, (int)card.HP, (int)card.ATK));
                SoldierCardsList = list.ToArray();
            }
        }
    }
}
