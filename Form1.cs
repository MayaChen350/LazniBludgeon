using Microsoft.CodeAnalysis.Sarif.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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

        bool IsAttacking = false;

        #region CARDS TYPES
        class PlayerCard
        {
            public int hp;
            public int atk;
            public Bitmap imageLocation;
            // ability1
            // ability2

            public PlayerCard(int Hp, int Atk, Bitmap Image)
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
            public Bitmap imageLocation;
            // ability1

            public SoldierCard()
            {

            }

            public SoldierCard(int Hp, int Atk, Bitmap Image)
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

        string[] PlayerCards = { "Allemanie", "Allemapon", "Almahad", "Anglestan", "Canalgeria", "Fitalie", "Garulmonie", "Khenaga", "Mulretonie", "Nitralvie", "Qaland", "Slovannoya", "Starvas", "TheLeaf", "Traicere", "Yedesna" };

        #region CARDS (110 CARDS)
        // Player cards (16 cards)

        //RESERVED FOR THE PROOF OF CONCEPT
        PlayerCard Slovannoya = new PlayerCard(2850, 350, Properties.Resources.Slovanoya);
        PlayerCard Allemapon = new PlayerCard(3000, 0, Properties.Resources.Allemapon);
        PlayerCard Anglestan = new PlayerCard(3450, 100, Properties.Resources.Anglestan);
        PlayerCard Garulmonie = new PlayerCard(3400, 150, Properties.Resources.Garulmonie);

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
        SoldierCard Allemanie_A = new SoldierCard(150, 50, Properties.Resources.Allemanie_A);
        SoldierCard Allemanie_B = new SoldierCard(100, 100, Properties.Resources.Allemanie_B);
        SoldierCard Allemapon_A = new SoldierCard(150, 75, Properties.Resources.Allemapon_A);
        SoldierCard Allemapon_B = new SoldierCard(100, 25, Properties.Resources.Allemapon_B);
        SoldierCard Almahad_A = new SoldierCard(100, 70, Properties.Resources.Almahad_A);
        SoldierCard Almahad_B = new SoldierCard(100, 20, Properties.Resources.Almahad_B);
        SoldierCard Anglestan_A = new SoldierCard(200, 35, Properties.Resources.Anglestan_A);
        SoldierCard Anglestan_B = new SoldierCard(150, 75, Properties.Resources.Anglestan_B);
        SoldierCard Canalgeria_A = new SoldierCard(350, 0, Properties.Resources.Canalgerie_A);
        SoldierCard Canalgeria_B = new SoldierCard(150, 50, Properties.Resources.Canalgerie_B);
        SoldierCard Criota_A = new SoldierCard(150, 90, Properties.Resources.Criota_A);
        SoldierCard Criota_B = new SoldierCard(200, 30, Properties.Resources.Criota_B);

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
            p1PlayerCard.Image = p1PlayerCardData.imageLocation;

            // cpu player card value is random
            int cpuCardIndex = random.Next(0, playerCards.Length);
            p2PlayerCardData = playerCards[cpuCardIndex];
            p2PlayerCard.Image = playerCards[cpuCardIndex].imageLocation;


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
                p1SecCardsImages[i].Image = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                CardsUsedFromDeck++;
                // Initiate each secondary cards on the other player side
                p2SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p2SecCardsImages[i].Image = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                CardsUsedFromDeck++;
            }
        }

        private void SetGame()
        {
            // Reset the selected card view
            CardView.Image = Properties.Resources.CardBack;
            textHP.Text = " ";
            textATK.Text = " ";


            // Activate the player card selector
            checkBoxPlayerCardConfirm.Enabled = true;
            btnPlayerCardLeft.Enabled = true;
            btnPlayerCardRight.Enabled = true;

            // Make invisible the ability menu panel and disable its buttons
            menuAbilities.Visible = false;
            checkAbility1.Enabled = false;
            checkAbility2.Enabled = false;
            checkAtk.Enabled = false;
            btnConfirm.Enabled = false;
            #if DEBUG
            SetCards();
            Console.WriteLine("Game set.");
            #endif
        }

        /// <summary>
        /// Type of the card shown. TRUE if a Secondary. FALSE if a Player Card.
        /// </summary>
        bool IsCardShownSecondary;

        private void ShowCard(PlayerCard pCardData)
        {
            // Change the ViewCard picture box and its labels for the selected Player card in the parameter
            CardView.Image = pCardData.imageLocation;
            textHP.Text = pCardData.hp.ToString();
            textATK.Text = pCardData.atk.ToString();
            // If the card selected is a ennemy card do not enable the ability panel menu
            if (pCardData != p2PlayerCardData || IsAttacking == true)
            {
                checkAbility1.Enabled = true;
                checkAbility2.Enabled = true;
                checkAtk.Enabled = true;
                IsCardShownSecondary = false;
            }
            else
            {
                checkAbility1.Enabled = false;
                checkAbility2.Enabled = false;
                checkAtk.Enabled = false;
                btnConfirm.Enabled = false;
            }
            #if DEBUG
            Console.WriteLine(/*pCardData + */"Player card data loaded.");
            #endif
        }

        private void ShowCard(SoldierCard[] pCardData, int index)
        {
            // Change the ViewCard picture box and its labels for the selected Soldier card in the parameters
            CardView.Image = pCardData[index].imageLocation;
            textHP.Text = pCardData[index].hp.ToString();
            textATK.Text = pCardData[index].atk.ToString();
            // If the card selected is a ennemy card do not enable the ability panel menu
            if (pCardData != p2SecCardsData || IsAttacking == true)
            {
                checkAbility1.Enabled = true;
                checkAbility2.Enabled = true;
                checkAtk.Enabled = true;
                IsCardShownSecondary = true;
            }
            else
            {
                checkAbility1.Enabled = false;
                checkAbility2.Enabled = false;
                checkAtk.Enabled = false;
                IsCardShownSecondary = false;
            }
            #if DEBUG
            Console.WriteLine("All ability panel buttons set to " + checkAbility1.Enabled + ".");
            Console.WriteLine(/*pCardData[index] + */"Soldier card data loaded.");
            #endif
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

        private void BtnPlayerCardLeft_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the minimum, if yes change it to the maximum
            if (playerCardIndex != 0) playerCardIndex--;
            else playerCardIndex = playerCards.Length - 1;

            // Refresh the player card data
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.Image = p1PlayerCardData.imageLocation;

            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
            Console.WriteLine(/*playerCards[playerCardIndex] +*/  "Another player card is now shown.");
        }

        private void BtnPlayerCardRight_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the maximum, if yes change it to the minimum
            if (playerCardIndex != playerCards.Length - 1) playerCardIndex++;
            else playerCardIndex = 0;

            // Refresh the player card data
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.Image = p1PlayerCardData.imageLocation;

            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
            Console.WriteLine(/*playerCards[playerCardIndex] +*/ "Another player card is now shown.");
        }

        private void CheckBoxPlayerCardConfirm_CheckedChanged(object sender, EventArgs e)
        {
            // If the box is checked, disable the controls (possibility to make them invisible in the future) and make the ability panel appears
            checkBoxPlayerCardConfirm.Checked = false;
            btnPlayerCardLeft.Enabled = false;
            btnPlayerCardRight.Enabled = false;
            menuAbilities.Visible = true;
            checkBoxPlayerCardConfirm.Enabled = false;
        }
        private void StartGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // FOR NOW
            // Reset the game
            SetGame();
        }

        // Disable the player cards if the checkAtk check box is enabled
        private void CheckAtk_CheckedChanged(object sender, EventArgs e)
        {
            IsAttacking = !IsAttacking;
            btnConfirm.Enabled = !btnConfirm.Enabled;
            p1PlayerCard.Enabled = !p1PlayerCard.Enabled;
            p1SecondaryCard1.Enabled = !p1SecondaryCard1.Enabled;
            p1SecondaryCard2.Enabled = !p1SecondaryCard2.Enabled;
            p1SecondaryCard3.Enabled = !p1SecondaryCard3.Enabled;
            #if DEBUG
            Console.WriteLine("Enabled states changed.");
            #endif
            // If the box is checked, higlights the card(s) which can be attacked, which depends of the attacking card used
            // Those actions are made depending of if the player cards are disabled, which should be disabled while the other player's cards are highlighted.
            if (!p1PlayerCard.Enabled)
            {
                // If the card is a SECONDARY card, it can only attack other secondary cards
                // EXCEPT if there is only the Player Card remaining or ability says otherwise (Later)
                if (IsCardShownSecondary)
                {
                    // Highlight player 2's Secondary cards
                    RedBorderpanel1.BackColor = Color.Red;
                    RedBorderpanel2.BackColor = Color.Red;
                    RedBorderpanel3.BackColor = Color.Red;
                    // Disable player's 2 Player card
                    p2PlayerCard.Enabled = false;

                }
                // If the card is not a Secondary card (PLAYER card), it can only attack the other's player card
                else
                {
                    // Highlight player 2's Player card
                    RedBorderPlayer_panel.BackColor = Color.Red;
                    // Disable player 2's Secondary cards
                    p2SecondaryCard1.Enabled = false;
                    p2SecondaryCard2.Enabled = false;
                    p2SecondaryCard3.Enabled = false;
                }
            }
            // If the box is unchecked, remove the borders and enable the cards
            else
            {
                p2PlayerCard.Enabled = true;
                p2SecondaryCard1.Enabled = true;
                p2SecondaryCard2.Enabled = true;
                p2SecondaryCard3.Enabled = true;
                RedBorderpanel1.BackColor = Color.Transparent;
                RedBorderpanel2.BackColor = Color.Transparent;
                RedBorderpanel3.BackColor = Color.Transparent;
                RedBorderPlayer_panel.BackColor = Color.Transparent;
            }
            #if DEBUG
            Console.WriteLine("Borders added.");
            #endif
        }

        // CARDS ENABLED/DISABLE STATES

        // arrays containing all the images for the enabled states
        System.Drawing.Image[] originalImages = new System.Drawing.Image[8];

        /// <summary>
        /// Lower the opacity of the card if it is disabled or change it back to its original oppacity from the originalImages array
        /// </summary>
        /// <param name="pCard">The card that is going to get enabled/disabled</param>
        /// <param name="pOriginalImageIndex">The index of the original image of the card in originalImages[]</param>
        private void CardEnabledStateChange(PictureBox pCard, int pOriginalImageIndex)
        {
            if (pCard.Enabled == false)
            {
                originalImages[pOriginalImageIndex] = pCard.Image;
                pCard.Image = Utils.SetImageOpacity(pCard.Image, .5F);
            }
            else pCard.Image = originalImages[pOriginalImageIndex];
        }


        private void p1SecondaryCard1_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p1SecondaryCard1, 0);
        }
        private void p1SecondaryCard2_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p1SecondaryCard2, 1);
        }

        private void p1SecondaryCard3_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p1SecondaryCard3, 2);
        }

        private void p1PlayerCard_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p1PlayerCard, 3);
        }

        private void p2PlayerCard_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p2PlayerCard, 4);
        }

        private void p2SecondaryCard1_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p2SecondaryCard1, 5);
        }

        private void p2SecondaryCard2_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p2SecondaryCard2, 6);
        }

        private void p2SecondaryCard3_EnabledChanged(object sender, EventArgs e)
        {
            CardEnabledStateChange(p2SecondaryCard3, 7);
        }
        #endregion
    }
}