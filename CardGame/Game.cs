﻿using Microsoft.CodeAnalysis.Sarif.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinformCardGame.Card;
using WinformCardGame.Other;

namespace WinformCardGame.CardGame
{
    public partial class Game : Form
    {

        public Game()
        {
            InitializeComponent();
            SetGame();
            Logger.SetLogTextBox(gameLogs);
        }

        public static readonly Image BackOfTheCard = null;

        public static Random random = new Random();

        private int playerCardIndex = 0;

        private bool IsAttacking = false;

        // empty player cards' data
        MainCard p1PlayerCardData = new MainCard();
        MainCard p2PlayerCardData = new MainCard();
        PlayerCard[] playerCards;


        // import from the winform picturebox
        PictureBox[] p1SecCards;
        PictureBox[] p2SecCards;

        // empty secondary cards' data
        SecondaryCard[] p1SecCardsData = new SecondaryCard[3];
        SecondaryCard[] p2SecCardsData = new SecondaryCard[3];
        // shuffled array of the soldier cards
        IList<SoldierCard> soldierCardsMixUp;

        SecondaryCard p1SecondaryCardData1 = new SecondaryCard();
        SecondaryCard p1SecondaryCardData2 = new SecondaryCard();
        SecondaryCard p1SecondaryCardData3 = new SecondaryCard();
        SecondaryCard p2SecondaryCardData1 = new SecondaryCard();
        SecondaryCard p2SecondaryCardData2 = new SecondaryCard();
        SecondaryCard p2SecondaryCardData3 = new SecondaryCard();
        SoldierCard[] soldierCards;


        // card currently viewed
        MainCard viewedCardPlayer;

        SecondaryCard viewedCardSoldier;

        // card attacking
        MainCard attackingCardPlayer;

        SecondaryCard attackingCardSoldier;

        // Initialize a new deck
        Deck deck = new Deck();


        private void SetCards()
        {
            //PLAYER CARDS
            // arrays of all the current player cards in the game
            playerCards = deck.PlayerCardsList;


            // player card value is the first one by default
            RefreshOrSetCard(p1PlayerCardData, p1PlayerCard);

            // Opponent player card's value is set with another method called when the player card is chosen
            p2PlayerCard.Image = BackOfTheCard;
            p2PlayerCard.Enabled = false;

            //SECONDARY CARDS
            // import from the winform picturebox
            p1SecCards = new PictureBox[] { p1SecondaryCard1, p1SecondaryCard2, p1SecondaryCard3 };
            p2SecCards = new PictureBox[] { p2SecondaryCard1, p2SecondaryCard2, p2SecondaryCard3 };

            // arrays of the empty cards' data
            p1SecCardsData = new SecondaryCard[] { p1SecondaryCardData1, p1SecondaryCardData2, p1SecondaryCardData3 };
            p2SecCardsData = new SecondaryCard[] { p2SecondaryCardData1, p2SecondaryCardData2, p2SecondaryCardData3 };

            // arrays of all the current soldier cards in the game
            // TODO: Make this into the Deck class instead
            soldierCards = deck.SoldierCardsList;

            // shuffled array of the soldier cards
            soldierCardsMixUp = soldierCards.Shuffle();

            // Initiate each secondary cards on the player side
            RetrieveCards(p1SecCardsData, p1SecCards);

            // Initiate each secondary cards on the other player side
            RetrieveCards(p2SecCardsData, p2SecCards);

            // Activate all the cards in case
            p1PlayerCard.Visible = true;
            p1PlayerCard.Enabled = true;

            p2PlayerCard.Visible = true;
            p2PlayerCard.Enabled = true;

            for (int i = 0; i < p1SecCards.Length; i++)
            {
                p1SecCards[i].Visible = true;
                p1SecCards[i].Enabled = true;

                p2SecCards[i].Visible = true;
                p2SecCards[i].Enabled = true;
            }
        }

        /// <summary>
        /// Refresh a card with its data and its in-game image.
        /// </summary>
        /// <param name="cardData">The player card data to be refreshed.</param>
        /// <param name="visibleCard">The card box in game to be refreshed.</param>
        private void RefreshOrSetCard(MainCard cardData, PictureBox visibleCard)
        {
            // Link the card data to their card in game
            cardData.CardInGame = p1PlayerCard;

            cardData.Name = playerCards[playerCardIndex].Name;
            cardData.Hp = playerCards[playerCardIndex].Hp;
            cardData.Atk = playerCards[playerCardIndex].Atk;
            cardData.ImageLocation = playerCards[playerCardIndex].ImageLocation;
            visibleCard.Image = cardData.ImageLocation;

        }

        private void SetOpponent()
        {
            // Set the opponent attack's pattern
            noOpponentPlay = random.Next(0, 4);

            // Enable the card
            p2PlayerCard.Enabled = true;

            // opponent player card value is random
            int cpuCardIndex = random.Next(0, playerCards.Length);
            while (cpuCardIndex == playerCardIndex)
                cpuCardIndex = random.Next(0, playerCards.Length);


            // Link the player card data to the card in game
            p2PlayerCardData.CardInGame = p2PlayerCard;

            // Load the card
            p2PlayerCardData.Name = playerCards[cpuCardIndex].Name;
            p2PlayerCardData.Hp = playerCards[cpuCardIndex].Hp;
            p2PlayerCardData.Atk = playerCards[cpuCardIndex].Atk;
            p2PlayerCardData.ImageLocation = playerCards[cpuCardIndex].ImageLocation;
            p2PlayerCard.Image = playerCards[cpuCardIndex].ImageLocation;

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
            gameLogs.Clear();
            SetCards();
            SetForTurn();
#if DEBUG
            Console.WriteLine("Game set.");
            Console.WriteLine("-------------------------------");
#endif
        }
        private void SetForTurn()
        {
            // Fish for new cards if all player cards have died
            if (!p1SecondaryCard1.Visible && !p1SecondaryCard2.Visible && !p1SecondaryCard3.Visible)
                RetrieveCards(p1SecCardsData, p1SecCards, false);

            // Reset the selected card view
            CardView.BackgroundImage = BackOfTheCard;
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
        /// Retrieve secondary cards and get their data. Player cards should not be retrieved.
        /// </summary>
        /// <param name="cardsData">The array of cards data</param>
        /// <param name="visibleCards">The array of cards in-game</param>
        /// <param name="firstTurn">This method acts differently whether it is the first turn or not</param>
        private void RetrieveCards(SecondaryCard[] cardsData, PictureBox[] visibleCards, bool firstTurn = true)
        {
            for (int i = 0; i < visibleCards.Length; i++)
            {
                // Initiate each cards on a player side
                cardsData[i].CardInGame = visibleCards[i];
                cardsData[i].Name = soldierCardsMixUp[0].Name;
                cardsData[i].ImageLocation = soldierCardsMixUp[0].ImageLocation;
                cardsData[i].Hp = soldierCardsMixUp[0].Hp;
                cardsData[i].Atk = soldierCardsMixUp[0].Atk;

                // Soldier cards when fished AFTER THE 1ST TURN
                // have ATK/HP bonus from -20%/+20%
                if (!firstTurn)
                {
                    cardsData[i].Hp += cardsData[i].RandomStats(cardsData[i].Hp);
                    cardsData[i].Atk += cardsData[i].RandomStats(cardsData[i].Atk);
                }


                // Initiliaze game states that change during the game
                cardsData[i].Used = false;

                // Links the image from the date to the image in game
                visibleCards[i].Image = soldierCardsMixUp[0].ImageLocation;

                // Remove the cards from the deck and add them to the bottom
                soldierCardsMixUp.Append(soldierCardsMixUp[0]);
                soldierCardsMixUp.RemoveAt(0);
            }
        }

        /// <summary>
        /// Type of the card shown. TRUE if a Secondary. FALSE if a Player Card.
        /// </summary>
        bool IsCardShownSecondary;

        private void ShowCard(MainCard pCardData)
        {
            // Change the ViewCard picture box and its labels for the selected Player card in the parameter
            CardView.BackgroundImage = pCardData.ImageLocation;
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

        private void ShowCard(SecondaryCard[] pCardData, int index)
        {
            // Change the ViewCard picture box and its labels for the selected Soldier card in the parameters
            CardView.BackgroundImage = pCardData[index].ImageLocation;
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

        private void AttackCardCalculation(MainCard pCardAtk, MainCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;

            Logger.Log($"> {pCardAtk.Name} attacked {pCardDef.Name} for {pCardAtk.Atk} dmg\r\n");
#if DEBUG
            Console.WriteLine($"PLAYER HAS DONE {pCardAtk.Atk} DMG to PLAYER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(MainCard pCardAtk, SecondaryCard pCardDef)
        {
            // cardDef.hp - cardAtk.atk × (100% -cardDef.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;

            Logger.Log($"> {pCardAtk.Name} attacked {pCardDef.Name} for {pCardAtk.Atk} dmg\r\n");
#if DEBUG
            Console.WriteLine($"PLAYER HAS DONE {pCardAtk.Atk} DMG to SOLDIER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(SecondaryCard pCardAtk, SecondaryCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;

            Logger.Log($"> {pCardAtk.Name} attacked {pCardDef.Name} for {pCardAtk.Atk} dmg\r\n");
#if DEBUG
            Console.WriteLine($"SOLDIER HAS DONE {pCardAtk.Atk} DMG to SOLDIER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        private void AttackCardCalculation(SecondaryCard pCardAtk, MainCard pCardDef)
        {
            // card.hp - card.atk × (100% -card.def%)
            pCardDef.Hp -= pCardAtk.Atk/*(1 - pCardDef.def)*/;

            Logger.Log($"> {pCardAtk.Name} attacked {pCardDef.Name} for {pCardAtk.Atk} dmg\r\n");
#if DEBUG
            Console.WriteLine($"SOLDIER HAS DONE {pCardAtk.Atk} DMGs to PLAYER (Before: {pCardDef.Hp + pCardAtk.Atk}hp Now: {pCardDef.Hp}hp)");
            Console.WriteLine("-------------------------------");
#endif
        }

        /// <summary>
        /// Determine if there's a winner
        /// </summary>
        private void DetermineIfWinner()
        {
            if (p2PlayerCardData.Dead)
            {
                GameEnd(true);
            }

            if (p1PlayerCardData.Dead)
            {
                GameEnd(false);
            }
        }

        private void GameEnd(bool won)
        {
            PictureBox[] cards = won ? p2SecCards : p1SecCards;
            string state = won ? "won" : "lost";

            // Disable cards of the player who lost
            foreach (PictureBox card in cards)
            {
                card.Enabled = false;
            }

            gameLogs.Text += $"> {p2PlayerCardData.Name} has fainted\r\n You {state}!";
#if DEBUG
            string whichPlayer = won ? "P2" : "P1";

            Console.WriteLine($"{whichPlayer} Card visibility set to false. Game ended.");
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

        private void BtnPlayerCardLeft_Click(object sender, EventArgs e)
        {
            // Verify if the index is at the minimum, if yes change it to the maximum
            if (playerCardIndex != 0) playerCardIndex--;
            else playerCardIndex = playerCards.Length - 1;

            // Refresh the player card data
            RefreshOrSetCard(p1PlayerCardData, p1PlayerCard);

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
            RefreshOrSetCard(p1PlayerCardData, p1PlayerCard);

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
        /// <summary>
        /// Starts an attack
        /// </summary>
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


                CardView.BackgroundImage = BackOfTheCard;

                btnConfirm.Checked = false;
                checkAtk.Checked = false;
                DetermineIfWinner();
                // If each cards have played, finish the player's turn
                if (!p1PlayerCard.Enabled && (!p1SecondaryCard1.Enabled || !p1SecondaryCard1.Visible) && (!p1SecondaryCard2.Enabled || !p1SecondaryCard2.Visible) && (!p1SecondaryCard3.Enabled || !p1SecondaryCard3.Visible))
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

        #region CHEATS
        private void theKillerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheKiller();
        }
        #endregion

        #endregion
    }
}