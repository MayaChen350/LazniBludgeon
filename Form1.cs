using System.Windows.Forms;
using System;

namespace LazniCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region CARDS TYPES
        class PlayerCard
        {
            public int hp;
            public int atk;
            // ability1
            // ability2

            public PlayerCard(int Hp, int Atk)
            {
                hp = Hp;
                atk = Atk;
            }
        }

        class SoldierCard
        {
            public int hp;
            public int atk;
            // ability1

            public SoldierCard(int Hp, int Atk)
            {
                hp = Hp;
                atk = Atk;
            }
        }

        class SpecialdCard
        {
            public int hp;
            public int atk;
            //ability1
            //ability2

            public SpecialdCard(int Hp, int Atk)
            {
                hp = Hp;
                atk = Atk;
            }
        }

        class ObjectCard
        {
            public int atk;
            //effect
        }

        #endregion

        #region CARDS
        // Player cards
        PlayerCard Allemanie = new PlayerCard(3500, 250);
        PlayerCard Allemapon = new PlayerCard(3000, 0);
        PlayerCard Almahad = new PlayerCard(3500, 250);
        PlayerCard Anglestan = new PlayerCard(3450, 100);
        PlayerCard Canalgeria = new PlayerCard(3500, 200);
        PlayerCard Fitalie = new PlayerCard(4000, 250);
        PlayerCard Garulmonie = new PlayerCard(3400, 150);
        PlayerCard Khenaga = new PlayerCard(3350, 200);
        PlayerCard Mulretonie = new PlayerCard(3000, 300);
        PlayerCard Nitralvie = new PlayerCard(3250, 250);
        /*PlayerCard Qaland = new PlayerCard();
        PlayerCard Slovannoya = new PlayerCard();
        PlayerCard Starvas = new PlayerCard();
        PlayerCard TheLeaf = new PlayerCard();
        PlayerCard Traicere = new PlayerCard();
        PlayerCard Yedesna = new PlayerCard();*/
        #endregion

        String[] PlayerCards = { "Allemanie", "Allemapon", "Almahad", "Anglestan", "Canalgeria", "Fitalie", "Garulmonie", "Khenaga", "Mulretonie", "Nitralvie", "Qaland", "Slovannoya", "Starvas", "TheLeaf", "Traicere", "Yedesna" };

        Image[] Cards = new Image[110];

        #region PASSIVE ABILITIES
        private void MethodicalPlanning(PlayerCard playerCard)
        {
            //foreach (SoldierCard card in #ALLSoldiersInTheField) 
            // {
            //    playerCard.atk += 50;
            // }
        }
        private void TeaTimeTactician(PlayerCard playerCard)
        {

        }
        #endregion

        private void SetGame()
        {
            // PlayerCard.HP = CardHP (Generally 3500);
        }

    }
}