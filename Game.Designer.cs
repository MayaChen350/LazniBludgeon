namespace LazniCardGame
{
    partial class Game
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cheatsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theKillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healOf87ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deathEraserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textWallet = new System.Windows.Forms.TextBox();
            this.PlayerCardsListTest = new System.Windows.Forms.ImageList(this.components);
            this.btnPlayerCardLeft = new System.Windows.Forms.Button();
            this.btnPlayerCardRight = new System.Windows.Forms.Button();
            this.checkBoxPlayerCardConfirm = new System.Windows.Forms.CheckBox();
            this.checkAbility1 = new System.Windows.Forms.CheckBox();
            this.checkAtk = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.CheckBox();
            this.RedBorderpanel1 = new System.Windows.Forms.Panel();
            this.p2SecondaryCard3 = new System.Windows.Forms.PictureBox();
            this.RedBorderpanel2 = new System.Windows.Forms.Panel();
            this.p2SecondaryCard2 = new System.Windows.Forms.PictureBox();
            this.RedBorderpanel3 = new System.Windows.Forms.Panel();
            this.p2SecondaryCard1 = new System.Windows.Forms.PictureBox();
            this.RedBorderPlayer_panel = new System.Windows.Forms.Panel();
            this.p2PlayerCard = new System.Windows.Forms.PictureBox();
            this.p2SecondaryCard4 = new System.Windows.Forms.PictureBox();
            this.p1SecondaryCard3 = new System.Windows.Forms.PictureBox();
            this.p1SecondaryCard2 = new System.Windows.Forms.PictureBox();
            this.p1SecondaryCard1 = new System.Windows.Forms.PictureBox();
            this.p1PlayerCard = new System.Windows.Forms.PictureBox();
            this.cheatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameLogs = new System.Windows.Forms.TextBox();
            this.p1SecondaryCard4 = new System.Windows.Forms.PictureBox();
            this.checkAbility2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuAbilities = new System.Windows.Forms.GroupBox();
            this.CardView = new System.Windows.Forms.Panel();
            this.textATK = new System.Windows.Forms.Label();
            this.textHP = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.RedBorderpanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard3)).BeginInit();
            this.RedBorderpanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard2)).BeginInit();
            this.RedBorderpanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard1)).BeginInit();
            this.RedBorderPlayer_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2PlayerCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1PlayerCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard4)).BeginInit();
            this.menuAbilities.SuspendLayout();
            this.CardView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem,
            this.cheatsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1629, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem1});
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.startGameToolStripMenuItem.Text = "Menu";
            // 
            // startGameToolStripMenuItem1
            // 
            this.startGameToolStripMenuItem1.Name = "startGameToolStripMenuItem1";
            this.startGameToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.startGameToolStripMenuItem1.Text = "&New game";
            this.startGameToolStripMenuItem1.Click += new System.EventHandler(this.StartGameToolStripMenuItem1_Click);
            // 
            // cheatsToolStripMenuItem1
            // 
            this.cheatsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theKillerToolStripMenuItem,
            this.healOf87ToolStripMenuItem,
            this.deathEraserToolStripMenuItem});
            this.cheatsToolStripMenuItem1.Name = "cheatsToolStripMenuItem1";
            this.cheatsToolStripMenuItem1.Size = new System.Drawing.Size(202, 20);
            this.cheatsToolStripMenuItem1.Text = "Cheats (TESTING PURPOSES ONLY)";
            // 
            // theKillerToolStripMenuItem
            // 
            this.theKillerToolStripMenuItem.Name = "theKillerToolStripMenuItem";
            this.theKillerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.theKillerToolStripMenuItem.Text = "Instant kill";
            this.theKillerToolStripMenuItem.Click += new System.EventHandler(this.theKillerToolStripMenuItem_Click);
            // 
            // healOf87ToolStripMenuItem
            // 
            this.healOf87ToolStripMenuItem.Name = "healOf87ToolStripMenuItem";
            this.healOf87ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.healOf87ToolStripMenuItem.Text = "Heal 100% hp";
            // 
            // deathEraserToolStripMenuItem
            // 
            this.deathEraserToolStripMenuItem.Name = "deathEraserToolStripMenuItem";
            this.deathEraserToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deathEraserToolStripMenuItem.Text = "Revive (if ever necessary)";
            // 
            // textWallet
            // 
            this.textWallet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textWallet.Location = new System.Drawing.Point(273, 493);
            this.textWallet.Name = "textWallet";
            this.textWallet.ReadOnly = true;
            this.textWallet.Size = new System.Drawing.Size(84, 20);
            this.textWallet.TabIndex = 23;
            this.textWallet.Text = "Your money :";
            this.textWallet.Visible = false;
            // 
            // PlayerCardsListTest
            // 
            this.PlayerCardsListTest.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PlayerCardsListTest.ImageStream")));
            this.PlayerCardsListTest.TransparentColor = System.Drawing.Color.Transparent;
            this.PlayerCardsListTest.Images.SetKeyName(0, "Allemanie.png");
            this.PlayerCardsListTest.Images.SetKeyName(1, "Allemapon.png");
            this.PlayerCardsListTest.Images.SetKeyName(2, "Almahad.png");
            this.PlayerCardsListTest.Images.SetKeyName(3, "Anglestan.png");
            this.PlayerCardsListTest.Images.SetKeyName(4, "Canalgerie.png");
            this.PlayerCardsListTest.Images.SetKeyName(5, "Fitalie.png");
            this.PlayerCardsListTest.Images.SetKeyName(6, "Garulmonie.png");
            this.PlayerCardsListTest.Images.SetKeyName(7, "Khenaga.png");
            this.PlayerCardsListTest.Images.SetKeyName(8, "Mulretonie.png");
            this.PlayerCardsListTest.Images.SetKeyName(9, "Nitralvie.png");
            this.PlayerCardsListTest.Images.SetKeyName(10, "Qaland.png");
            this.PlayerCardsListTest.Images.SetKeyName(11, "Slovanoya.png");
            this.PlayerCardsListTest.Images.SetKeyName(12, "Starvas.png");
            this.PlayerCardsListTest.Images.SetKeyName(13, "TheLeaf.png");
            this.PlayerCardsListTest.Images.SetKeyName(14, "Traicere.png");
            this.PlayerCardsListTest.Images.SetKeyName(15, "Yedesna.png");
            // 
            // btnPlayerCardLeft
            // 
            this.btnPlayerCardLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlayerCardLeft.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerCardLeft.Location = new System.Drawing.Point(256, 561);
            this.btnPlayerCardLeft.Name = "btnPlayerCardLeft";
            this.btnPlayerCardLeft.Size = new System.Drawing.Size(17, 24);
            this.btnPlayerCardLeft.TabIndex = 39;
            this.btnPlayerCardLeft.Text = "◄";
            this.btnPlayerCardLeft.UseVisualStyleBackColor = true;
            this.btnPlayerCardLeft.Click += new System.EventHandler(this.BtnPlayerCardLeft_Click);
            // 
            // btnPlayerCardRight
            // 
            this.btnPlayerCardRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlayerCardRight.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerCardRight.Location = new System.Drawing.Point(363, 561);
            this.btnPlayerCardRight.Name = "btnPlayerCardRight";
            this.btnPlayerCardRight.Size = new System.Drawing.Size(17, 24);
            this.btnPlayerCardRight.TabIndex = 40;
            this.btnPlayerCardRight.Text = "►";
            this.btnPlayerCardRight.UseVisualStyleBackColor = true;
            this.btnPlayerCardRight.Click += new System.EventHandler(this.BtnPlayerCardRight_Click);
            // 
            // checkBoxPlayerCardConfirm
            // 
            this.checkBoxPlayerCardConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxPlayerCardConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayerCardConfirm.Location = new System.Drawing.Point(273, 493);
            this.checkBoxPlayerCardConfirm.Name = "checkBoxPlayerCardConfirm";
            this.checkBoxPlayerCardConfirm.Size = new System.Drawing.Size(90, 20);
            this.checkBoxPlayerCardConfirm.TabIndex = 41;
            this.checkBoxPlayerCardConfirm.Text = "Confirm Choice";
            this.checkBoxPlayerCardConfirm.UseVisualStyleBackColor = true;
            this.checkBoxPlayerCardConfirm.CheckedChanged += new System.EventHandler(this.CheckBoxPlayerCardConfirm_CheckedChanged);
            // 
            // checkAbility1
            // 
            this.checkAbility1.BackColor = System.Drawing.Color.White;
            this.checkAbility1.Enabled = false;
            this.checkAbility1.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAbility1.Location = new System.Drawing.Point(23, 15);
            this.checkAbility1.Name = "checkAbility1";
            this.checkAbility1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkAbility1.Size = new System.Drawing.Size(78, 42);
            this.checkAbility1.TabIndex = 0;
            this.checkAbility1.Text = "Use Ab. 1";
            this.checkAbility1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkAbility1.UseVisualStyleBackColor = false;
            // 
            // checkAtk
            // 
            this.checkAtk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkAtk.BackColor = System.Drawing.Color.Red;
            this.checkAtk.Enabled = false;
            this.checkAtk.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAtk.Location = new System.Drawing.Point(341, 15);
            this.checkAtk.Name = "checkAtk";
            this.checkAtk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkAtk.Size = new System.Drawing.Size(78, 42);
            this.checkAtk.TabIndex = 4;
            this.checkAtk.Text = "ATTACK";
            this.checkAtk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkAtk.UseVisualStyleBackColor = false;
            this.checkAtk.CheckedChanged += new System.EventHandler(this.CheckAtk_CheckedChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Lime;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfirm.Location = new System.Drawing.Point(447, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConfirm.Size = new System.Drawing.Size(78, 42);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.CheckedChanged += new System.EventHandler(this.btnConfirm_CheckedChanged);
            // 
            // RedBorderpanel1
            // 
            this.RedBorderpanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedBorderpanel1.BackColor = System.Drawing.Color.Transparent;
            this.RedBorderpanel1.Controls.Add(this.p2SecondaryCard3);
            this.RedBorderpanel1.Location = new System.Drawing.Point(381, 126);
            this.RedBorderpanel1.Margin = new System.Windows.Forms.Padding(0);
            this.RedBorderpanel1.Name = "RedBorderpanel1";
            this.RedBorderpanel1.Size = new System.Drawing.Size(86, 117);
            this.RedBorderpanel1.TabIndex = 42;
            // 
            // p2SecondaryCard3
            // 
            this.p2SecondaryCard3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2SecondaryCard3.BackColor = System.Drawing.Color.Transparent;
            this.p2SecondaryCard3.Location = new System.Drawing.Point(5, 4);
            this.p2SecondaryCard3.Margin = new System.Windows.Forms.Padding(0);
            this.p2SecondaryCard3.Name = "p2SecondaryCard3";
            this.p2SecondaryCard3.Size = new System.Drawing.Size(78, 109);
            this.p2SecondaryCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2SecondaryCard3.TabIndex = 5;
            this.p2SecondaryCard3.TabStop = false;
            this.p2SecondaryCard3.EnabledChanged += new System.EventHandler(this.p2SecondaryCard3_EnabledChanged);
            this.p2SecondaryCard3.Click += new System.EventHandler(this.p2SecondaryCard3_Click);
            // 
            // RedBorderpanel2
            // 
            this.RedBorderpanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedBorderpanel2.BackColor = System.Drawing.Color.Transparent;
            this.RedBorderpanel2.Controls.Add(this.p2SecondaryCard2);
            this.RedBorderpanel2.Location = new System.Drawing.Point(487, 126);
            this.RedBorderpanel2.Margin = new System.Windows.Forms.Padding(0);
            this.RedBorderpanel2.Name = "RedBorderpanel2";
            this.RedBorderpanel2.Size = new System.Drawing.Size(86, 117);
            this.RedBorderpanel2.TabIndex = 44;
            // 
            // p2SecondaryCard2
            // 
            this.p2SecondaryCard2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2SecondaryCard2.BackColor = System.Drawing.Color.Transparent;
            this.p2SecondaryCard2.Location = new System.Drawing.Point(4, 4);
            this.p2SecondaryCard2.Name = "p2SecondaryCard2";
            this.p2SecondaryCard2.Size = new System.Drawing.Size(78, 109);
            this.p2SecondaryCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2SecondaryCard2.TabIndex = 6;
            this.p2SecondaryCard2.TabStop = false;
            this.p2SecondaryCard2.EnabledChanged += new System.EventHandler(this.p2SecondaryCard2_EnabledChanged);
            this.p2SecondaryCard2.Click += new System.EventHandler(this.p2SecondaryCard2_Click);
            // 
            // RedBorderpanel3
            // 
            this.RedBorderpanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedBorderpanel3.BackColor = System.Drawing.Color.Transparent;
            this.RedBorderpanel3.Controls.Add(this.p2SecondaryCard1);
            this.RedBorderpanel3.Location = new System.Drawing.Point(593, 126);
            this.RedBorderpanel3.Margin = new System.Windows.Forms.Padding(0);
            this.RedBorderpanel3.Name = "RedBorderpanel3";
            this.RedBorderpanel3.Size = new System.Drawing.Size(86, 117);
            this.RedBorderpanel3.TabIndex = 45;
            // 
            // p2SecondaryCard1
            // 
            this.p2SecondaryCard1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2SecondaryCard1.BackColor = System.Drawing.Color.Transparent;
            this.p2SecondaryCard1.Location = new System.Drawing.Point(5, 4);
            this.p2SecondaryCard1.Name = "p2SecondaryCard1";
            this.p2SecondaryCard1.Size = new System.Drawing.Size(78, 109);
            this.p2SecondaryCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2SecondaryCard1.TabIndex = 7;
            this.p2SecondaryCard1.TabStop = false;
            this.p2SecondaryCard1.EnabledChanged += new System.EventHandler(this.p2SecondaryCard1_EnabledChanged);
            this.p2SecondaryCard1.Click += new System.EventHandler(this.p2SecondaryCard1_Click);
            // 
            // RedBorderPlayer_panel
            // 
            this.RedBorderPlayer_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedBorderPlayer_panel.BackColor = System.Drawing.Color.Transparent;
            this.RedBorderPlayer_panel.Controls.Add(this.p2PlayerCard);
            this.RedBorderPlayer_panel.Location = new System.Drawing.Point(699, 126);
            this.RedBorderPlayer_panel.Margin = new System.Windows.Forms.Padding(0);
            this.RedBorderPlayer_panel.Name = "RedBorderPlayer_panel";
            this.RedBorderPlayer_panel.Size = new System.Drawing.Size(86, 117);
            this.RedBorderPlayer_panel.TabIndex = 44;
            // 
            // p2PlayerCard
            // 
            this.p2PlayerCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2PlayerCard.BackColor = System.Drawing.Color.Transparent;
            this.p2PlayerCard.Image = global::LazniCardGame.Properties.Resources.CardBack;
            this.p2PlayerCard.Location = new System.Drawing.Point(5, 4);
            this.p2PlayerCard.Name = "p2PlayerCard";
            this.p2PlayerCard.Size = new System.Drawing.Size(78, 109);
            this.p2PlayerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2PlayerCard.TabIndex = 8;
            this.p2PlayerCard.TabStop = false;
            this.p2PlayerCard.EnabledChanged += new System.EventHandler(this.p2PlayerCard_EnabledChanged);
            this.p2PlayerCard.Click += new System.EventHandler(this.p2PlayerCard_Click);
            // 
            // p2SecondaryCard4
            // 
            this.p2SecondaryCard4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2SecondaryCard4.BackColor = System.Drawing.Color.Olive;
            this.p2SecondaryCard4.Location = new System.Drawing.Point(279, 130);
            this.p2SecondaryCard4.Name = "p2SecondaryCard4";
            this.p2SecondaryCard4.Size = new System.Drawing.Size(78, 109);
            this.p2SecondaryCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2SecondaryCard4.TabIndex = 13;
            this.p2SecondaryCard4.TabStop = false;
            this.p2SecondaryCard4.Visible = false;
            // 
            // p1SecondaryCard3
            // 
            this.p1SecondaryCard3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1SecondaryCard3.BackColor = System.Drawing.Color.Transparent;
            this.p1SecondaryCard3.Location = new System.Drawing.Point(597, 519);
            this.p1SecondaryCard3.Name = "p1SecondaryCard3";
            this.p1SecondaryCard3.Size = new System.Drawing.Size(78, 109);
            this.p1SecondaryCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1SecondaryCard3.TabIndex = 4;
            this.p1SecondaryCard3.TabStop = false;
            this.p1SecondaryCard3.EnabledChanged += new System.EventHandler(this.p1SecondaryCard3_EnabledChanged);
            this.p1SecondaryCard3.Click += new System.EventHandler(this.p1SecondaryCard3_Click);
            // 
            // p1SecondaryCard2
            // 
            this.p1SecondaryCard2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1SecondaryCard2.BackColor = System.Drawing.Color.Transparent;
            this.p1SecondaryCard2.Location = new System.Drawing.Point(492, 519);
            this.p1SecondaryCard2.Name = "p1SecondaryCard2";
            this.p1SecondaryCard2.Size = new System.Drawing.Size(78, 109);
            this.p1SecondaryCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1SecondaryCard2.TabIndex = 3;
            this.p1SecondaryCard2.TabStop = false;
            this.p1SecondaryCard2.EnabledChanged += new System.EventHandler(this.p1SecondaryCard2_EnabledChanged);
            this.p1SecondaryCard2.Click += new System.EventHandler(this.p1SecondaryCard2_Click);
            // 
            // p1SecondaryCard1
            // 
            this.p1SecondaryCard1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1SecondaryCard1.BackColor = System.Drawing.Color.Transparent;
            this.p1SecondaryCard1.Location = new System.Drawing.Point(386, 519);
            this.p1SecondaryCard1.Name = "p1SecondaryCard1";
            this.p1SecondaryCard1.Size = new System.Drawing.Size(78, 109);
            this.p1SecondaryCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1SecondaryCard1.TabIndex = 2;
            this.p1SecondaryCard1.TabStop = false;
            this.p1SecondaryCard1.EnabledChanged += new System.EventHandler(this.p1SecondaryCard1_EnabledChanged);
            this.p1SecondaryCard1.Click += new System.EventHandler(this.p1SecondaryCard1_Click);
            // 
            // p1PlayerCard
            // 
            this.p1PlayerCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1PlayerCard.BackColor = System.Drawing.Color.Transparent;
            this.p1PlayerCard.Location = new System.Drawing.Point(279, 519);
            this.p1PlayerCard.Name = "p1PlayerCard";
            this.p1PlayerCard.Size = new System.Drawing.Size(78, 109);
            this.p1PlayerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1PlayerCard.TabIndex = 1;
            this.p1PlayerCard.TabStop = false;
            this.p1PlayerCard.EnabledChanged += new System.EventHandler(this.p1PlayerCard_EnabledChanged);
            this.p1PlayerCard.Click += new System.EventHandler(this.p1PlayerCard_Click);
            // 
            // cheatsToolStripMenuItem
            // 
            this.cheatsToolStripMenuItem.Name = "cheatsToolStripMenuItem";
            this.cheatsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.cheatsToolStripMenuItem.Text = "Cheats";
            // 
            // gameLogs
            // 
            this.gameLogs.AcceptsReturn = true;
            this.gameLogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameLogs.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gameLogs.CausesValidation = false;
            this.gameLogs.Font = new System.Drawing.Font("Consolas", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLogs.Location = new System.Drawing.Point(1331, 398);
            this.gameLogs.Multiline = true;
            this.gameLogs.Name = "gameLogs";
            this.gameLogs.ReadOnly = true;
            this.gameLogs.Size = new System.Drawing.Size(271, 279);
            this.gameLogs.TabIndex = 46;
            this.gameLogs.TabStop = false;
            this.gameLogs.WordWrap = false;
            // 
            // p1SecondaryCard4
            // 
            this.p1SecondaryCard4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1SecondaryCard4.BackColor = System.Drawing.Color.Transparent;
            this.p1SecondaryCard4.Location = new System.Drawing.Point(703, 519);
            this.p1SecondaryCard4.Name = "p1SecondaryCard4";
            this.p1SecondaryCard4.Size = new System.Drawing.Size(78, 109);
            this.p1SecondaryCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1SecondaryCard4.TabIndex = 47;
            this.p1SecondaryCard4.TabStop = false;
            // 
            // checkAbility2
            // 
            this.checkAbility2.BackColor = System.Drawing.Color.White;
            this.checkAbility2.Enabled = false;
            this.checkAbility2.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAbility2.Location = new System.Drawing.Point(129, 15);
            this.checkAbility2.Name = "checkAbility2";
            this.checkAbility2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkAbility2.Size = new System.Drawing.Size(78, 42);
            this.checkAbility2.TabIndex = 48;
            this.checkAbility2.Text = "Use Ab. 2";
            this.checkAbility2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkAbility2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(235, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(78, 42);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "Use Ab. 2";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // menuAbilities
            // 
            this.menuAbilities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuAbilities.BackColor = System.Drawing.Color.Transparent;
            this.menuAbilities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuAbilities.Controls.Add(this.btnConfirm);
            this.menuAbilities.Controls.Add(this.checkBox1);
            this.menuAbilities.Controls.Add(this.checkAtk);
            this.menuAbilities.Controls.Add(this.checkAbility1);
            this.menuAbilities.Controls.Add(this.checkAbility2);
            this.menuAbilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAbilities.Location = new System.Drawing.Point(256, 634);
            this.menuAbilities.Name = "menuAbilities";
            this.menuAbilities.Size = new System.Drawing.Size(550, 73);
            this.menuAbilities.TabIndex = 38;
            this.menuAbilities.TabStop = false;
            this.menuAbilities.Visible = false;
            // 
            // CardView
            // 
            this.CardView.BackgroundImage = global::LazniCardGame.Properties.Resources.Allemanie_A;
            this.CardView.Controls.Add(this.textATK);
            this.CardView.Controls.Add(this.textHP);
            this.CardView.ForeColor = System.Drawing.Color.White;
            this.CardView.Location = new System.Drawing.Point(827, 46);
            this.CardView.Name = "CardView";
            this.CardView.Size = new System.Drawing.Size(476, 664);
            this.CardView.TabIndex = 49;
            // 
            // textATK
            // 
            this.textATK.AutoSize = true;
            this.textATK.BackColor = System.Drawing.Color.Transparent;
            this.textATK.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textATK.Location = new System.Drawing.Point(292, 625);
            this.textATK.Name = "textATK";
            this.textATK.Size = new System.Drawing.Size(46, 23);
            this.textATK.TabIndex = 53;
            this.textATK.Text = "ATK";
            // 
            // textHP
            // 
            this.textHP.AutoSize = true;
            this.textHP.BackColor = System.Drawing.Color.Transparent;
            this.textHP.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHP.Location = new System.Drawing.Point(144, 625);
            this.textHP.Name = "textHP";
            this.textHP.Size = new System.Drawing.Size(34, 23);
            this.textHP.TabIndex = 52;
            this.textHP.Text = "HP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LazniCardGame.Properties.Resources.CardBack;
            this.pictureBox1.Location = new System.Drawing.Point(145, 325);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LazniCardGame.Properties.Resources.Example;
            this.ClientSize = new System.Drawing.Size(1629, 719);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CardView);
            this.Controls.Add(this.p1SecondaryCard4);
            this.Controls.Add(this.gameLogs);
            this.Controls.Add(this.RedBorderPlayer_panel);
            this.Controls.Add(this.RedBorderpanel3);
            this.Controls.Add(this.RedBorderpanel2);
            this.Controls.Add(this.RedBorderpanel1);
            this.Controls.Add(this.checkBoxPlayerCardConfirm);
            this.Controls.Add(this.btnPlayerCardRight);
            this.Controls.Add(this.btnPlayerCardLeft);
            this.Controls.Add(this.menuAbilities);
            this.Controls.Add(this.textWallet);
            this.Controls.Add(this.p2SecondaryCard4);
            this.Controls.Add(this.p1SecondaryCard3);
            this.Controls.Add(this.p1SecondaryCard2);
            this.Controls.Add(this.p1SecondaryCard1);
            this.Controls.Add(this.p1PlayerCard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game";
            this.Text = "Lazni Bludgeon (ALPHA)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RedBorderpanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard3)).EndInit();
            this.RedBorderpanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard2)).EndInit();
            this.RedBorderpanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard1)).EndInit();
            this.RedBorderPlayer_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2PlayerCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2SecondaryCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1PlayerCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1SecondaryCard4)).EndInit();
            this.menuAbilities.ResumeLayout(false);
            this.CardView.ResumeLayout(false);
            this.CardView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox p1PlayerCard;
        private System.Windows.Forms.PictureBox p1SecondaryCard1;
        private System.Windows.Forms.PictureBox p1SecondaryCard2;
        private System.Windows.Forms.PictureBox p1SecondaryCard3;
        private System.Windows.Forms.PictureBox p2SecondaryCard3;
        private System.Windows.Forms.PictureBox p2SecondaryCard2;
        private System.Windows.Forms.PictureBox p2SecondaryCard1;
        private System.Windows.Forms.PictureBox p2PlayerCard;
        private System.Windows.Forms.PictureBox p2SecondaryCard4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem1;
        private System.Windows.Forms.TextBox textWallet;
        public System.Windows.Forms.ImageList PlayerCardsListTest;
        private System.Windows.Forms.Button btnPlayerCardLeft;
        private System.Windows.Forms.Button btnPlayerCardRight;
        private System.Windows.Forms.CheckBox checkBoxPlayerCardConfirm;
        private System.Windows.Forms.CheckBox checkAbility1;
        private System.Windows.Forms.CheckBox btnConfirm;
        private System.Windows.Forms.CheckBox checkAtk;
        private System.Windows.Forms.Panel RedBorderpanel1;
        private System.Windows.Forms.Panel RedBorderpanel2;
        private System.Windows.Forms.Panel RedBorderpanel3;
        private System.Windows.Forms.Panel RedBorderPlayer_panel;
        private System.Windows.Forms.ToolStripMenuItem cheatsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cheatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theKillerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem healOf87ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deathEraserToolStripMenuItem;
        private System.Windows.Forms.TextBox gameLogs;
        private System.Windows.Forms.PictureBox p1SecondaryCard4;
        private System.Windows.Forms.CheckBox checkAbility2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox menuAbilities;
        private System.Windows.Forms.Panel CardView;
        private System.Windows.Forms.Label textATK;
        private System.Windows.Forms.Label textHP;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

