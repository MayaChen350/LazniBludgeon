using System.Windows.Forms;
using System;
using Microsoft.CodeAnalysis.Sarif.Driver;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using LazniCardGame.Properties;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Security.Cryptography;
using System.Reflection;

namespace LazniCardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetGame();
        }

        public Random random = new Random();

        public int playerCardIndex = 0;

        #region CARDS TYPES
        class PlayerCard
        {
            public int hp;
            public int atk;
            public string imageLocation;
            // ability1
            // ability2

            public PlayerCard(int Hp, int Atk, string Image)
            {
                hp = Hp;
                atk = Atk;
                imageLocation = Image;
            }
        }

        class SoldierCard
        {
            public int hp;
            public int atk;
            public string imageLocation;
            // ability1

            public SoldierCard()
            {

            }

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
        PlayerCard Slovannoya = new PlayerCard(2850, 350, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Player\\Slovanoya.png");
        PlayerCard Allemapon = new PlayerCard(3000, 0,  "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Player\\Allemapon.png");
        PlayerCard Anglestan = new PlayerCard(3450, 100, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Player\\Anglestan.png");
        PlayerCard Garulmonie = new PlayerCard(3400, 150, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Player\\Garulmonie.png");

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
        SoldierCard Anglestan_A = new SoldierCard(200, 35, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Anglestan_A.png");
        SoldierCard Anglestan_B = new SoldierCard(150, 75, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Anglestan_B.png");
        SoldierCard Canalgeria_A = new SoldierCard(350, 0, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Canalgerie_A.png");
        SoldierCard Canalgeria_B = new SoldierCard(150, 50, "C:\\Users\\GChen\\Dev\\Desktop\\Projects\\LazniCardGame\\Resources\\Images\\Cards\\Soldier\\Canalgerie_B.png");
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

        // empty player cards' data
        PlayerCard p1PlayerCardData;
        PlayerCard p2PlayerCardData;
        PlayerCard[] playerCards;


        // import from the winform picturebox
        PictureBox[] p1SecCardsImages;
        PictureBox[] p2SecCardsImages;

        // arrays of the empty secondary cards' data
        SoldierCard[] p1SecCardsData;
        SoldierCard[] p2SecCardsData;
        SoldierCard[] soldierCards;

        private void SetCards()
        {

            //PLAYER CARDS
            // arrays of all the current player cards in the game
            playerCards = new PlayerCard[] { Slovannoya, Allemapon, Anglestan, Garulmonie };

            // player card value is the first one by default
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.ImageLocation = p1PlayerCardData.imageLocation;

            // cpu player card value is random
            int cpuCardIndex = random.Next(0, playerCards.Length);
            p2PlayerCardData = playerCards[cpuCardIndex];
            p2PlayerCard.ImageLocation = playerCards[cpuCardIndex].imageLocation;


            //SECONDARY CARDS
            // import from the winform picturebox
            p1SecCardsImages = new PictureBox[] { p1SecondaryCard1, p1SecondaryCard2, p1SecondaryCard3 };
            p2SecCardsImages = new PictureBox[] { p2SecondaryCard1, p2SecondaryCard2, p2SecondaryCard3 };

            // arrays of the empty cards' data
            p1SecCardsData = new SoldierCard[3];
            p2SecCardsData = new SoldierCard[3];

            // arrays of all the current soldier cards in the game
            soldierCards = new SoldierCard[] { Allemanie_A, Allemanie_B, Allemapon_A, Allemapon_B, Almahad_A, Almahad_B, Anglestan_A, Anglestan_B, Canalgeria_A, Canalgeria_B, Criota_A, Criota_B };

            // shuffled array of the soldier cards
            IList<SoldierCard> soldierCardsMixUp = EnumerableExtensions.Shuffle(soldierCards, random);

            int CardsUsedFromDeck = 0;
            for (int i = 0; i < p1SecCardsImages.Length; i++)
            {
                // Initiate each secondary cards on the player side
                p1SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p1SecCardsImages[i].ImageLocation = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                CardsUsedFromDeck++;
                // Initiate each secondary cards on the other player side
                p2SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p2SecCardsImages[i].ImageLocation = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                CardsUsedFromDeck++;
            }
        }

        private void SetGame()
        {
            SetCards();
        }

        private void ShowCard(PlayerCard pCardData)
        {
            // Change the ViewCard picture box and its labels for the selected Player card in the parameter
            CardView.ImageLocation = pCardData.imageLocation;
            textHP.Text = pCardData.hp.ToString();
            textATK.Text = pCardData.atk.ToString();
        }

        private void ShowCard(SoldierCard[] pCardData, int index)
        {
            // Change the ViewCard picture box and its labels for the selected Soldier card in the parameters
            CardView.ImageLocation = pCardData[index].imageLocation;
            textHP.Text = pCardData[index].hp.ToString();
            textATK.Text = pCardData[index].atk.ToString();
        }

        #region GAME INTERACTION METHODS
        private void p1PlayerCard_Click(object sender, EventArgs e)
        {
            ShowCard(p1PlayerCardData);
        }
        private void p2PlayerCard_Click(object sender, EventArgs e)
        {
            ShowCard(p2PlayerCardData);
        }

        private void p1SecondaryCard1_Click(object sender, EventArgs e)
        {
            ShowCard(p1SecCardsData, 0);
        }
        private void p1SecondaryCard2_Click(object sender, EventArgs e)
        {
            ShowCard(p1SecCardsData, 1);
        }

        private void p1SecondaryCard3_Click(object sender, EventArgs e)
        {
            ShowCard(p1SecCardsData, 2);
        }

        //Unused for now
        /* private void p1SecondaryCard4_Click(object sender, EventArgs e)
         {
             ShowCard(p1SecCardsData, 0);
         }
         private void p1SecondaryCard5_Click(object sender, EventArgs e)
         {
             ShowCard(p1SecCardsData, 0);
         }
         private void p1SecondaryCard6_Click(object sender, EventArgs e)
         {
             ShowCard(p1SecCardsData, 0);
         }
         private void p1SecondaryCard7_Click(object sender, EventArgs e)
         {
             ShowCard(p1SecCardsData, 0);
         }*/

        private void p2SecondaryCard1_Click(object sender, EventArgs e)
        {
            ShowCard(p2SecCardsData, 0);
        }

        private void p2SecondaryCard2_Click(object sender, EventArgs e)
        {
            ShowCard(p2SecCardsData, 1);
        }

        private void p2SecondaryCard3_Click(object sender, EventArgs e)
        {
            ShowCard(p2SecCardsData, 2);
        }

        //Unused for now
        /*private void p2SecondaryCard4_Click(object sender, EventArgs e)
        {
        }
        private void p2SecondaryCard5_Click(object sender, EventArgs e)
        {
        }
        private void p2SecondaryCard6_Click(object sender, EventArgs e)
        {
        }
        private void p2SecondaryCard7_Click(object sender, EventArgs e)
        {
        }*/
        
        private void btnPlayerCardLeft_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the minimum, if yes change it to the maximum
            if (playerCardIndex != 0)  playerCardIndex--;
            else playerCardIndex = playerCards.Length -1;

            // Refresh the player card data
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.ImageLocation = p1PlayerCardData.imageLocation;

            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
        }

        private void btnPlayerCardRight_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the maximum, if yes change it to the minimum
            if (playerCardIndex != playerCards.Length -1) playerCardIndex++;
            else playerCardIndex = 0;

            // Refresh the player card data
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.ImageLocation = p1PlayerCardData.imageLocation;
            
            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
        }

        private void checkBoxPlayerCardConfirm_CheckedChanged(object sender, EventArgs e)
        {
            // If the box is checked, disable the controls (possibility to make them invisible in the future)
            if (checkBoxPlayerCardConfirm.Checked)
            {
                btnPlayerCardLeft.Enabled = false;
                btnPlayerCardRight.Enabled = false;
            }
            else
            {
                btnPlayerCardLeft.Enabled = true;
                btnPlayerCardRight.Enabled = true;
            }
        }
        private void startGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // FOR NOW 
            // Reshuffle the cards
            SetCards();
        }
        #endregion

    }
}