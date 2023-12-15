using Microsoft.CodeAnalysis.Sarif.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace LazniCardGame
{
    public partial class Game : Form
    {

        public Game()
        {
            InitializeComponent();
            SetGame();
        }

        public static readonly Image BackOfTheCard = Properties.Resources.CardBack;

        public Random random = new Random();

        public int playerCardIndex = 0;

        bool IsAttacking = false;

        // empty player cards' data
        PlayerCard p1PlayerCardData;
        PlayerCard p2PlayerCardData;
        PlayerCard[] playerCards;


        // import from the winform picturebox
        PictureBox[] p1SecCards;
        PictureBox[] p2SecCards;

        // arrays of the empty secondary cards' data
        SoldierCard[] p1SecCardsData;
        SoldierCard[] p2SecCardsData;
        SoldierCard[] soldierCards;

        // card currently viewed
        PlayerCard viewedCardPlayer;

        SoldierCard viewedCardSoldier;

        // card attacking
        PlayerCard attackingCardPlayer;

        SoldierCard attackingCardSoldier;

        private void SetCards()
        {

            //PLAYER CARDS
            // arrays of all the current player cards in the game
            playerCards = new PlayerCard[] { Slovannoya, Allemapon, Anglestan, Garulmonie };

            // player card value is the first one by default
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.Image = p1PlayerCardData.imageLocation;

            // opponent player card value is random
            int cpuCardIndex = random.Next(0, playerCards.Length);
            p2PlayerCardData = playerCards[cpuCardIndex];
            p2PlayerCard.Image = playerCards[cpuCardIndex].imageLocation;


            //SECONDARY CARDS
            // import from the winform picturebox
            p1SecCards = new PictureBox[] { p1SecondaryCard1, p1SecondaryCard2, p1SecondaryCard3 };
            p2SecCards = new PictureBox[] { p2SecondaryCard1, p2SecondaryCard2, p2SecondaryCard3 };

            // arrays of the empty cards' data
            p1SecCardsData = new SoldierCard[3];
            p2SecCardsData = new SoldierCard[3];

            // arrays of all the current soldier cards in the game
            soldierCards = new SoldierCard[] { Allemanie_A, Allemanie_B, Allemapon_A, Allemapon_B, Almahad_A, Almahad_B, Anglestan_A, Anglestan_B, Canalgeria_A, Canalgeria_B, Criota_A, Criota_B };

            // shuffled array of the soldier cards
            IList<SoldierCard> soldierCardsMixUp = EnumerableExtensions.Shuffle(soldierCards, random);

            int CardsUsedFromDeck = 0;
            for (int i = 0; i < p1SecCards.Length; i++)
            {
                // Initiate each secondary cards on the player side
                p1SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p1SecCards[i].Image = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                p1SecCardsData[i].cardInGame = p1SecCards[i];
                CardsUsedFromDeck++;
                // Initiate each secondary cards on the other player side
                p2SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p2SecCards[i].Image = soldierCardsMixUp[CardsUsedFromDeck].imageLocation;
                p2SecCardsData[i].cardInGame = p2SecCards[i];
                CardsUsedFromDeck++;
            }
        }

        private void SetGame()
        {
            // Reset the selected card view
            CardView.Image = BackOfTheCard;
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
            // Log in the current card viewed 
            viewedCardPlayer = pCardData;
            viewedCardSoldier = null;
            // If the card selected is a ennemy card do not enable the ability panel menu
            if (pCardData != p2PlayerCardData || IsAttacking == true)
            {
                checkAbility1.Enabled = true;
                checkAbility2.Enabled = true;
                checkAtk.Enabled = true;
                IsCardShownSecondary = false;
                // Enable the confirm button if the Player 2 card is shown
                btnConfirm.Enabled = pCardData == p2PlayerCardData;
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
            // Log in the current card viewed 
            viewedCardSoldier = pCardData[index];
            viewedCardPlayer = null;
            // If the card selected is a ennemy card do not enable the ability panel menu
            if (pCardData != p2SecCardsData || IsAttacking)
            {
                checkAbility1.Enabled = true;
                checkAbility2.Enabled = true;
                checkAtk.Enabled = true;
                IsCardShownSecondary = true;
                // Enable the confirm button if a Player 2's card is shown
                btnConfirm.Enabled = pCardData == p2SecCardsData;
            }
            else
            {
                checkAbility1.Enabled = false;
                checkAbility2.Enabled = false;
                checkAtk.Enabled = false;
                IsCardShownSecondary = false;
                btnConfirm.Enabled = false;
            }
#if DEBUG
            Console.WriteLine("All ability panel buttons set to " + checkAbility1.Enabled + ".");
            Console.WriteLine(/*pCardData[index] + */"Soldier card data loaded.");
#endif
        }

        private void AttackCardCalculation(PlayerCard pCardAtk, PlayerCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.hp -= pCardAtk.atk/*(1 - pCardDef.def)*/;

        }

        private void AttackCardCalculation(PlayerCard pCardAtk, SoldierCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.hp -= pCardAtk.atk/*(1 - pCardDef.def)*/;

        }

        private void AttackCardCalculation(SoldierCard pCardAtk, SoldierCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.hp -= pCardAtk.atk/*(1 - pCardDef.def)*/;

        }

        private void AttackCardCalculation(SoldierCard pCardAtk, PlayerCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.hp -= pCardAtk.atk/*(1 - pCardDef.def)*/;

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
            // If the box is checked, make the player card controls invisible (small possibility to make them only disabled instead again in the future) and make the ability panel appears
            checkBoxPlayerCardConfirm.Checked = false;
            checkBoxPlayerCardConfirm.Visible = false;
            btnPlayerCardLeft.Visible = false;
            btnPlayerCardRight.Visible = false;
            menuAbilities.Visible = true;
        }

        private void StartGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // FOR NOW
            // Reset the game
            SetGame();
        }

        private void CheckAtk_CheckedChanged(object sender, EventArgs e)
        {
            // Log the viewed card as the attacking card
            if (viewedCardPlayer != null)
            {
                attackingCardPlayer = viewedCardPlayer;
                attackingCardSoldier = null;
            }
            else
            {
                attackingCardSoldier = viewedCardSoldier;
                attackingCardPlayer = null;
            }

            // Disable the player's cards if the checkAtk check box is enabled
            IsAttacking = !IsAttacking;
            p1PlayerCard.Enabled = !p1PlayerCard.Enabled;
            p1SecondaryCard1.Enabled = !p1SecondaryCard1.Enabled;
            p1SecondaryCard2.Enabled = !p1SecondaryCard2.Enabled;
            p1SecondaryCard3.Enabled = !p1SecondaryCard3.Enabled;
            btnConfirm.Enabled = false;
#if DEBUG
            Console.WriteLine("Enabled states changed.");
#endif
            // If the box is checked, higlights the card(s) which can be attacked, which depends of the attacking card used
            if (IsAttacking)
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
        Image[] originalImages = new System.Drawing.Image[8];

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

        private void btnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            // If the attacking card is a player card and the other player card is alive then it'll attack it
            if (attackingCardPlayer != null && p2PlayerCard.Visible)
            {
                p1PlayerCard.Visible = false;
                AttackCardCalculation(attackingCardPlayer, viewedCardPlayer);
            }
            // If the attacking card is a player card but the other player card is NOT alive then it'll attack a secondary card
            else if (attackingCardPlayer != null)
            {
                p1PlayerCard.Visible = false;
                AttackCardCalculation(attackingCardPlayer, viewedCardSoldier);
            }
            // Otherwise it is most likely another secondary card so it will attack another secondary card
            else if (p2SecondaryCard1.Visible && p2SecondaryCard2.Visible && p2SecondaryCard3.Visible)
            {
                attackingCardSoldier.cardInGame.Visible = false;
                AttackCardCalculation(attackingCardSoldier, viewedCardSoldier);
            }
            // In the case all other secondary cards have died, secondary cards can attack the other player card
            else
            {
                attackingCardSoldier.cardInGame.Visible = false;
                AttackCardCalculation(attackingCardSoldier, viewedCardPlayer);
            }


            CardView.Image = BackOfTheCard;

            btnConfirm.Checked = false;
            checkAtk.Checked = false;

            if (!p1PlayerCard.Visible && !p1SecondaryCard1.Visible && !p1SecondaryCard2.Visible && !p1SecondaryCard3.Visible)
            {
                p1PlayerCard.Visible = true;
                p1SecondaryCard1.Visible = true;
                p1SecondaryCard2.Visible = true;
                p1SecondaryCard3.Visible = true;
            }
        }
    }
}