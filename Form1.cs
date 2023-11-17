using System.Windows.Forms;
using System;
using Microsoft.CodeAnalysis.Sarif.Driver;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace LazniCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCards();
        }

        public Random random = new Random();

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
            public string imageLocation;
            // ability1

            public SoldierCard(int Hp, int Atk, string Image)
            {
                hp = Hp;
                atk = Atk;
                imageLocation = Image;
            }
        }

        class SpecialCard
        {
            public int hp;
            public int atk;
            //ability1
            //ability2

            public SpecialCard(int Hp, int Atk)
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

        String[] PlayerCards = { "Allemanie", "Allemapon", "Almahad", "Anglestan", "Canalgeria", "Fitalie", "Garulmonie", "Khenaga", "Mulretonie", "Nitralvie", "Qaland", "Slovannoya", "Starvas", "TheLeaf", "Traicere", "Yedesna" };

        #region CARDS (110 CARDS)
        // Player cards (16 cards)
        
        //RESERVED FOR THE PROOF OF CONCEPT
        PlayerCard Slovannoya = new PlayerCard(2850, 350);
        PlayerCard Allemapon = new PlayerCard(3000, 0);
        PlayerCard Anglestan = new PlayerCard(3450, 100);
        PlayerCard Garulmonie = new PlayerCard(3400, 150);

        /*PlayerCard Allemanie = new PlayerCard(3500, 250);
        //Allemapon
        PlayerCard Almahad = new PlayerCard(3500, 250);
        //Anglestan
        PlayerCard Canalgeria = new PlayerCard(3500, 200);
        PlayerCard Fitalie = new PlayerCard(4000, 250);
        //Garulmonie
        PlayerCard Khenaga = new PlayerCard(3350, 200);
        PlayerCard Mulretonie = new PlayerCard(3000, 300);
        PlayerCard Nitralvie = new PlayerCard(3250, 250);
        PlayerCard Qaland = new PlayerCard(3500, 225);
        //Slovannoya 
        PlayerCard Starvas = new PlayerCard(3550, 250);
        PlayerCard TheLeaf = new PlayerCard(3750, 150);
        PlayerCard Traicere = new PlayerCard(3600, 100);
        PlayerCard Yedesna = new PlayerCard(3350, 250);*/
        // Soldier cards (64 cards)
        
        //RESERVED FOR THE PROOF OF CONCEPT
        SoldierCard Allemanie_A = new SoldierCard(150, 50, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Allemanie_A.png");
        SoldierCard Allemanie_B = new SoldierCard(100, 100, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Allemanie_B.png");
        SoldierCard Allemapon_A = new SoldierCard(150, 75, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Allemapon_A.png");
        SoldierCard Allemapon_B = new SoldierCard(100, 25, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Allemapon_B.png");
        SoldierCard Almahad_A = new SoldierCard(100, 70, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Almahad_A.png");
        SoldierCard Almahad_B = new SoldierCard(100, 20, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Almahad_B.png");
        SoldierCard Anglestan_A = new SoldierCard(200,35, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Anglestan_A.png");
        SoldierCard Anglestan_B = new SoldierCard(150,75, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Anglestan_B.png");
        SoldierCard Canalgeria_A = new SoldierCard(350,0, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Canalgerie_A.png");
        SoldierCard Canalgeria_B = new SoldierCard(150,50, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Canalgerie_B.png");
        SoldierCard Criota_A = new SoldierCard(150, 90, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Criota_A.png");
        SoldierCard Criota_B = new SoldierCard(200, 30, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Criota_B.png");

        /*SoldierCard Ekota_A = new SoldierCard(100,20);
        SoldierCard Ekota_B = new SoldierCard(150, 50);
        SoldierCard Finlonie_A = new SoldierCard(200,30);
        SoldierCard Finlonie_B = new SoldierCard(200, 100);
        SoldierCard Fitalie_A = new SoldierCard(150, 50);
        SoldierCard Fitalie_B = new SoldierCard(150, 70);
        SoldierCard Garulmonie_A = new SoldierCard(300, 10);
        SoldierCard Garulmonie_B = new SoldierCard(150, 75);
        SoldierCard Hongoru_A = new SoldierCard(150, 60);
        SoldierCard Hongoru_B = new SoldierCard(200, 0);
        SoldierCard Kaenia_A = new SoldierCard(100, 40);
        SoldierCard Kaenia_B = new SoldierCard(180, 60);
        SoldierCard Khenaga_A = new SoldierCard(150, 40);
        SoldierCard Khenaga_B = new SoldierCard(150, 75);
        SoldierCard Lirigant_A = new SoldierCard(175, 50);
        SoldierCard Lirigant_B = new SoldierCard(150, 80);
        SoldierCard Mageria_A = new SoldierCard(100, 50);
        SoldierCard Mageria_B = new SoldierCard(150,50);
        SoldierCard Maréquie_A = new SoldierCard(150, 50);
        SoldierCard Maréquie_B = new SoldierCard(140, 40);*/
       /* SoldierCard Mulretonie_A = new SoldierCard();
        SoldierCard Mulretonie_B = new SoldierCard();
        SoldierCard Neolantis_A = new SoldierCard();
        SoldierCard Neolantis_B = new SoldierCard();
        SoldierCard Nitralvie_A = new SoldierCard();
        SoldierCard Nitralvie_B = new SoldierCard();
        SoldierCard Onriance_A = new SoldierCard();
        SoldierCard Onriance_B = new SoldierCard();
        SoldierCard Qaland_A = new SoldierCard();
        SoldierCard Qaland_B = new SoldierCard();
        SoldierCard Slovanoya_A = new SoldierCard();
        SoldierCard Slovanoya_B = new SoldierCard();
        SoldierCard Starvas_A = new SoldierCard();
        SoldierCard Starvas_B = new SoldierCard();
        SoldierCard Suedemark_A = new SoldierCard();
        SoldierCard Suedemark_B = new SoldierCard();
        SoldierCard Suelly_A = new SoldierCard();
        SoldierCard Suelly_B = new SoldierCard();
        SoldierCard Tekay_A = new SoldierCard();
        SoldierCard Tekay_B = new SoldierCard();
        SoldierCard TheLeaf_A = new SoldierCard();
        SoldierCard TheLeaf_B = new SoldierCard();
        SoldierCard Traicere_A = new SoldierCard();
        SoldierCard Traicere_B = new SoldierCard();
        SoldierCard Tristan_A = new SoldierCard();
        SoldierCard Tristan_B = new SoldierCard();
        SoldierCard Tujar_A = new SoldierCard();
        SoldierCard Tujar_B = new SoldierCard();
        SoldierCard Ukraimea_A = new SoldierCard();
        SoldierCard Ukraimea_B = new SoldierCard();
        SoldierCard Yedesna_A = new SoldierCard();
        SoldierCard Yedesna_B = new SoldierCard();*/
        // Special cards (16 cards)
        /* SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard*/
        // Object cards (14 cards)
        /*ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard*/
        #endregion


        #region PASSIVE ABILITIES
        private void MethodicalPlanning(PlayerCard playerCard)
        {
            //foreach (SoldierCard card in #ALLSoldiersInTheField) 
            // {
            //    playerCard.atk += 50;
            // }

        }
        private void TeaTimeTactician(PlayerCard playerCard) { }
        private void StrategicMentorship() { }
        private void StrategicRetreat() { }
        private void StandUpRoutine() { }


        #endregion

        #region ACTIVE ABILITIES
        private void StoicResolve() { }
        private void DebatingDynamo() { }
        private void AdaptivePunchline() { }
        #endregion

        /// <summary>
        /// Takes a random character between 'A' and 'B'
        /// </summary>
        /// <returns>'A' or 'B'</returns>
        private char RandomLetter() 
        {
            if (random.Next(1) == 0) return 'A'; else return 'b';
        }

        PlayerCard p1PlayerCardData;
        SoldierCard p1SecCard1Data;
        SoldierCard p1SecCard2Data;
        SoldierCard p1SecCard3Data;
            
        PlayerCard p2PlayerCardData;
        SoldierCard p2SecCard1Data;
        SoldierCard p2SecCard2Data;
        SoldierCard p2SecCard3Data;

        private void SetCards()
        {
            PictureBox[] p1SecCards = { p1SecondaryCard1, p1SecondaryCard2, p1SecondaryCard3 };
            PictureBox[] p2SecCards = { p2SecondaryCard1, p2SecondaryCard2, p2SecondaryCard3 };

            SoldierCard[] p1SecCardsData = { p1SecCard1Data, p1SecCard2Data, p1SecCard3Data  };
            SoldierCard[] p2SecCardsData = { p2SecCard1Data, p2SecCard2Data, p2SecCard3Data };

            SoldierCard[] soldierCards = { Allemanie_A, Allemanie_B, Allemapon_A, Allemapon_B, Almahad_A, Almahad_B, Anglestan_A, Anglestan_B, Canalgeria_A, Canalgeria_B, Criota_A, Criota_B };
            Random random = new Random();
            SoldierCard[] soldierCardsMixUp = (SoldierCard[])soldierCards.Shuffle(random);

            int CardsUsedFromDeck = 0;
            for (int i = 0; i < p1SecCards.Length; i++)
            {
                p1SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                CardsUsedFromDeck++;
                p1SecCards[i].ImageLocation = p2SecCardsData[i].imageLocation;
                
                p2SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                CardsUsedFromDeck++;
                p2SecCards[i].ImageLocation = p2SecCardsData[i].imageLocation;
            }
           
        }

        private void SetGame()
        {
            // P1PlayerCard.hp = PlayerCard.hp;
            SetCards();
        }

        private void ShowCard(PictureBox pCard)
        {
            CardView.Image = pCard.Image;
            CardView.BackColor = pCard.BackColor;
           // textHP.Text = pCard.;
        }

        private void p1SecondaryCard2_Click(object sender, EventArgs e)
        {
            ShowCard(p1SecondaryCard2);
        }
    }
}