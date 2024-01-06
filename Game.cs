using Microsoft.CodeAnalysis.Sarif.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public static Random random = new Random();

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
            playerCards = new PlayerCard[] { Slovanoya, Allemapon, Anglestan, Garulmonie };


            // player card value is the first one by default
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.Image = p1PlayerCardData.ImageLocation;

            // Opponent player card's value is set with another method called when the player card is chosen
            p2PlayerCard.Image = BackOfTheCard;
            p2PlayerCard.Enabled = false;

            // Link the player card data to their card in game
            p1PlayerCardData.CardInGame = p1PlayerCard;

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
            IList<SoldierCard> soldierCardsMixUp = soldierCards.Shuffle();

            int CardsUsedFromDeck = 0;
            for (int i = 0; i < p1SecCards.Length; i++)
            {
                // Initiate each secondary cards on the player side
                p1SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p1SecCards[i].Image = soldierCardsMixUp[CardsUsedFromDeck].ImageLocation;
                p1SecCardsData[i].CardInGame = p1SecCards[i];
                CardsUsedFromDeck++;

                // Initiate each secondary cards on the other player side
                p2SecCardsData[i] = soldierCardsMixUp[CardsUsedFromDeck];
                p2SecCards[i].Image = soldierCardsMixUp[CardsUsedFromDeck].ImageLocation;
                p2SecCardsData[i].CardInGame = p2SecCards[i];
                CardsUsedFromDeck++;
            }
        }

        private void SetOpponent()
        {
            // Set the opponent attack's pattern
            noOpponentPlay = random.Next(0, 4);

            // Enable the card
            p2PlayerCard.Enabled = true;

            // arrays of all the current player cards in the game
            playerCards = new PlayerCard[] { Slovanoya, Allemapon, Anglestan, Garulmonie };

            // opponent player card value is random
            int cpuCardIndex = random.Next(0, playerCards.Length);
            while (cpuCardIndex == playerCardIndex)
                cpuCardIndex = random.Next(0, playerCards.Length);

            // Load the card
            p2PlayerCardData = playerCards[cpuCardIndex];
            p2PlayerCard.Image = playerCards[cpuCardIndex].ImageLocation;

            // Link the player card data to the card in game
            p2PlayerCardData.CardInGame = p2PlayerCard;


#if DEBUG
            Console.WriteLine("Opponent's player card is now set.");
#endif
        }

        private void SetGame()
        {
            // Activate the player card selector
            checkBoxPlayerCardConfirm.Visible = true;
            btnPlayerCardLeft.Visible = true;
            btnPlayerCardRight.Visible = true;

            // Make invisible the ability menu panel and disable its buttons
            menuAbilities.Visible = false;
            checkAbility1.Enabled = false;
            checkAbility2.Enabled = false;
            checkAtk.Enabled = false;
            btnConfirm.Enabled = false;
            SetCards();
            SetForTurn();
#if DEBUG
            Console.WriteLine("Game set.");
            Console.WriteLine("-------------------------------");
#endif
        }
        private void SetForTurn()
        {
            // Reset the selected card view
            CardView.Image = BackOfTheCard;
            textHP.Text = " ";
            textATK.Text = " ";

            // Enable all the player cards and mark them unused
            p1PlayerCardData.Used = false;
            p1SecCardsData[0].Used = false;
            p1SecCardsData[1].Used = false;
            p1SecCardsData[2].Used = false;
            p1PlayerCard.Enabled = true;
            p1SecondaryCard1.Enabled = true;
            p1SecondaryCard2.Enabled = true;
            p1SecondaryCard3.Enabled = true;
            
        }

        /// <summary>
        /// Type of the card shown. TRUE if a Secondary. FALSE if a Player Card.
        /// </summary>
        bool IsCardShownSecondary;

        private void ShowCard(PlayerCard pCardData)
        {
            // Change the ViewCard picture box and its labels for the selected Player card in the parameter
            CardView.Image = pCardData.ImageLocation;
            textHP.Text = pCardData.Hp.ToString();
            textATK.Text = pCardData.Atk.ToString();

            // Log in the current card viewed 
            viewedCardPlayer = pCardData;
            viewedCardSoldier = null;
            IsCardShownSecondary = false;

            // If the selected card is the other's player disable the attack controls
            // EXCEPT if the player is attacking
            checkAbility1.Enabled = pCardData != p2PlayerCardData || IsAttacking;
            checkAbility2.Enabled = pCardData != p2PlayerCardData || IsAttacking;
            checkAtk.Enabled = pCardData != p2PlayerCardData || IsAttacking;

            // Enable the confirm button if the Player 2 card is shown
            btnConfirm.Enabled = pCardData == p2PlayerCardData && IsAttacking;
#if DEBUG
            Console.WriteLine("All ability panel buttons set to " + checkAbility1.Enabled + ".");

            if (pCardData == p1PlayerCardData)
                Console.WriteLine("Player 1 card data loaded.");
            else if (pCardData == p2PlayerCardData)
                Console.WriteLine("Player 2 card data loaded.");
            else
                Console.WriteLine("ERROR when loading Player card data: Card should be a Player card.");

            Console.WriteLine("-------------------------------");
#endif
        }

        private void ShowCard(SoldierCard[] pCardData, int index)
        {
            // Change the ViewCard picture box and its labels for the selected Soldier card in the parameters
            CardView.Image = pCardData[index].ImageLocation;
            textHP.Text = pCardData[index].Hp.ToString();
            textATK.Text = pCardData[index].Atk.ToString();

            // Log in the current card viewed 
            viewedCardSoldier = pCardData[index];
            viewedCardPlayer = null;
            IsCardShownSecondary = true;

            // If the selected card is the other's player disable the attack controls
            // EXCEPT if the player is attacking
            checkAbility1.Enabled = pCardData != p2SecCardsData || IsAttacking;
            checkAbility2.Enabled = pCardData != p2SecCardsData || IsAttacking;
            checkAtk.Enabled = pCardData != p2SecCardsData || IsAttacking;

            // Enable the confirm button if a Player 2's card is shown
            btnConfirm.Enabled = pCardData == p2SecCardsData && IsAttacking;
#if DEBUG
            Console.WriteLine("All ability panel buttons set to " + checkAbility1.Enabled + ".");

            if (pCardData == p1SecCardsData)
                Console.WriteLine("Player 1's Soldier card data loaded.");
            else if (pCardData == p2SecCardsData)
                Console.WriteLine("Player 2's Soldier card data loaded.");
            else
                Console.WriteLine("ERROR when loading Soldier card data: Card should be a Soldier card.");

            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(PlayerCard pCardAtk, PlayerCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;
#if DEBUG
            Console.WriteLine($"PLAYER HAS DONE {pCardAtk.Atk} DMG to PLAYER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(PlayerCard pCardAtk, SoldierCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;
#if DEBUG
            Console.WriteLine($"PLAYER HAS DONE {pCardAtk.Atk} DMG to SOLDIER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(SoldierCard pCardAtk, SoldierCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;
#if DEBUG
            Console.WriteLine($"SOLDIER HAS DONE {pCardAtk.Atk} DMG to SOLDIER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(SoldierCard pCardAtk, PlayerCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;
#if DEBUG
            Console.WriteLine($"SOLDIER HAS DONE {pCardAtk.Atk} DMGs to PLAYER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        /// <summary>
        /// Disable cards when their hp reached 0
        /// </summary>
        private void UpdateCards()
        {
            foreach (SoldierCard cards in p2SecCardsData)
            {
#if DEBUG
                Console.WriteLine($"Card has {cards.Hp}hp.");
#endif
                // Disable cards when their hp reached 0
                cards.CardInGame.Visible = cards.Hp > 0;
#if DEBUG
                if (cards.Hp <= 0)
                    Console.WriteLine("Card visibility set to false.");
                Console.WriteLine("-------------------------------");
#endif
            }

#if DEBUG
            Console.WriteLine($"P2 Card has {p2PlayerCardData.Hp}hp.");
#endif
            p2PlayerCardData.CardInGame.Visible = p2PlayerCardData.Hp > 0;
#if DEBUG
            if (p2PlayerCardData.Hp <= 0)
                Console.WriteLine("P2 Card visibility set to false. You won!");
            Console.WriteLine("-------------------------------");
#endif

            /*foreach (SoldierCard cards in p1SecCardsData)
            {
#if DEBUG
                Console.WriteLine($"Card has {cards.hp}hp.");
#endif
                if (cards.hp <= 0)
                    cards.cardInGame.Visible = false;
            }*/
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
            p1PlayerCard.Image = p1PlayerCardData.ImageLocation;

            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
#if DEBUG
            Console.WriteLine(/*playerCards[playerCardIndex] +*/  "Another player card is now shown.");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void BtnPlayerCardRight_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the maximum, if yes change it to the minimum
            if (playerCardIndex != playerCards.Length - 1) playerCardIndex++;
            else playerCardIndex = 0;

            // Refresh the player card data
            p1PlayerCardData = playerCards[playerCardIndex];
            p1PlayerCard.Image = p1PlayerCardData.ImageLocation;

            // Show the new current card in the ViewCard picture box
            ShowCard(p1PlayerCardData);
#if DEBUG
            Console.WriteLine(/*playerCards[playerCardIndex] +*/ "Another player card is now shown.");
            Console.WriteLine("-------------------------------");
#endif
        }

        /// <summary>
        /// This button start the game in sort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPlayerCardConfirm_CheckedChanged(object sender, EventArgs e)
        {
            // If the box is checked, make the player card controls invisible (small possibility to make them only disabled instead again in the future) and make the ability panel appears
            if (checkBoxPlayerCardConfirm.Checked)
            {
                checkBoxPlayerCardConfirm.Checked = false;
                checkBoxPlayerCardConfirm.Visible = false;
                btnPlayerCardLeft.Visible = false;
                btnPlayerCardRight.Visible = false;
                menuAbilities.Visible = true;
#if DEBUG
                Console.WriteLine("Player card chosen.");
                Console.WriteLine("Player card chosen.");
#endif
                SetOpponent();
#if DEBUG
                Console.WriteLine("-------------------------------");
#endif
            }
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
            attackingCardPlayer = viewedCardPlayer ?? null;
            attackingCardSoldier = viewedCardSoldier ?? null;
#if DEBUG
            if (viewedCardPlayer != null)
            {
                Console.WriteLine("Attacking card logged on as PLAYER CARD");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("Attacking card logged on as SOLDIER CARD");
                Console.WriteLine("-------------------------------");
            }
#endif
            // Disable the player's cards if the checkAtk check box is enabled
            IsAttacking = !IsAttacking && !p2SecCardsData.Contains(viewedCardSoldier) && p2PlayerCardData != viewedCardPlayer;

            // Disable the button in some cases (need to make it better later)
            checkAtk.Enabled = IsAttacking;

            p1PlayerCard.Enabled = !p1PlayerCard.Enabled && !p1PlayerCardData.Used;
            p1SecondaryCard1.Enabled = !p1SecondaryCard1.Enabled && !p1SecCardsData[0].Used;
            p1SecondaryCard2.Enabled = !p1SecondaryCard2.Enabled && !p1SecCardsData[1].Used;
            p1SecondaryCard3.Enabled = !p1SecondaryCard3.Enabled && !p1SecCardsData[2].Used;
            btnConfirm.Enabled = false;
#if DEBUG
            Console.WriteLine($"Player's cards are now set to {!p1PlayerCard.Enabled}.");
            Console.WriteLine("-------------------------------");
#endif
            // Enable the player card if other secondary cards are not on the battlefield
            if (p2SecCardsData[0].Hp <= 0 && p2SecCardsData[1].Hp <= 0 && p2SecCardsData[2].Hp <= 0)
            {
                p2PlayerCard.Enabled = true;
                RedBorderPlayer_panel.BackColor = IsAttacking ? Color.Red : Color.Transparent;
            }
            else
            {
                // If the box is checked, disable cards which cannot be attacked by that card
                p2PlayerCard.Enabled = !IsCardShownSecondary || !IsAttacking;
                p2SecondaryCard1.Enabled = IsCardShownSecondary || !IsAttacking;
                p2SecondaryCard2.Enabled = IsCardShownSecondary || !IsAttacking;
                p2SecondaryCard3.Enabled = IsCardShownSecondary || !IsAttacking;

                // If the card is a SECONDARY card, it can only attack other secondary cards
                // Highlight player 2's Secondary cards
                RedBorderpanel1.BackColor = IsAttacking && IsCardShownSecondary ? Color.Red : Color.Transparent;
                RedBorderpanel2.BackColor = IsAttacking && IsCardShownSecondary ? Color.Red : Color.Transparent;
                RedBorderpanel3.BackColor = IsAttacking && IsCardShownSecondary ? Color.Red : Color.Transparent;

                // If the card is not a Secondary card (PLAYER card), it can only attack the other's player card
                // Highlight player 2's Player card
                RedBorderPlayer_panel.BackColor = IsAttacking && !IsCardShownSecondary ? Color.Red : Color.Transparent;
            }

            // EXCEPT if there is only the Player Card remaining or ability says otherwise (Later)
#if DEBUG
            Console.WriteLine("Borders added.");
            Console.WriteLine("-------------------------------");
#endif
        }

        // CARDS ENABLED/DISABLE STATES

        // arrays containing all the images for the enabled states
        Image[] originalImages = new Image[8];

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
            if (btnConfirm.Checked)
            {
                // If the attacking card is a player card and the other player card is alive then it'll attack it
                if (attackingCardPlayer != null && p2PlayerCard.Visible)
                {
                    p1PlayerCardData.Used = true;
                    AttackCardCalculation(attackingCardPlayer, viewedCardPlayer);
#if DEBUG
                    Console.WriteLine($"(PLAYER VS PLAYER) {attackingCardPlayer} has attacked {viewedCardPlayer}.");
                    Console.WriteLine("-------------------------------");
#endif

                }
                // If the attacking card is a player card but the other player card is NOT alive then it'll attack a secondary card
                else if (attackingCardPlayer != null)
                {
                    p1PlayerCardData.Used = true;
                    AttackCardCalculation(attackingCardPlayer, viewedCardSoldier);
#if DEBUG
                    Console.WriteLine($"(PLAYER VS SOLDIER) {attackingCardPlayer} has attacked {viewedCardSoldier}.");
                    Console.WriteLine("-------------------------------");
#endif
                }
                // Otherwise it is most likely another secondary card so it will attack another secondary card
                else if (p2SecondaryCard1.Visible || p2SecondaryCard2.Visible || p2SecondaryCard3.Visible)
                {
                    attackingCardSoldier.Used = true;
                    AttackCardCalculation(attackingCardSoldier, viewedCardSoldier);
#if DEBUG
                    Console.WriteLine($"(SOLDIER VS SOLDIER) {attackingCardSoldier} has attacked {viewedCardSoldier}.");
                    Console.WriteLine("-------------------------------");
#endif
                }
                // In the case all other secondary cards have died, secondary cards can attack the other player card
                else
                {
                    attackingCardSoldier.Used = true;
                    AttackCardCalculation(attackingCardSoldier, viewedCardPlayer);
#if DEBUG
                    Console.WriteLine($"(SOLDIER VS PLAYER) {attackingCardSoldier} has attacked {viewedCardPlayer}.");
                    Console.WriteLine("-------------------------------");
#endif
                }


                CardView.Image = BackOfTheCard;

                btnConfirm.Checked = false;
                checkAtk.Checked = false;
                UpdateCards();
                // If each cards have played, finish the player's turn
                if (!p1PlayerCard.Enabled && !p1SecondaryCard1.Enabled && !p1SecondaryCard2.Enabled && !p1SecondaryCard3.Enabled)
                {
#if DEBUG
                    Console.WriteLine("Player turn is over.");
#endif
                    SetForTurn();
                    // Start the opponent's turn
                    OpponentTurn();
                }
            }
        }
    }
}