namespace UnlDiagram
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainView = new PictureBox();
            MenuStrip = new ContextMenuStrip(components);
            přidatToolStripMenuItem = new ToolStripMenuItem();
            editovatToolStripMenuItem = new ToolStripMenuItem();
            MoveTimer = new System.Windows.Forms.Timer(components);
            SaveMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)MainView).BeginInit();
            MenuStrip.SuspendLayout();
            SaveMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainView
            // 
            MainView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainView.BackColor = SystemColors.ActiveBorder;
            MainView.ContextMenuStrip = MenuStrip;
            MainView.Location = new Point(12, 27);
            MainView.Name = "MainView";
            MainView.Size = new Size(1463, 696);
            MainView.TabIndex = 0;
            MainView.TabStop = false;
            MainView.Paint += MainView_Paint;
            MainView.MouseDoubleClick += MainView_MouseDoubleClick;
            MainView.MouseDown += MainView_MouseDown;
            MainView.MouseMove += MainView_MouseMove;
            MainView.MouseUp += MainView_MouseUp;
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { přidatToolStripMenuItem, editovatToolStripMenuItem });
            MenuStrip.Name = "MenuStrip";
            MenuStrip.ShowImageMargin = false;
            MenuStrip.Size = new Size(93, 48);
            // 
            // přidatToolStripMenuItem
            // 
            přidatToolStripMenuItem.Name = "přidatToolStripMenuItem";
            přidatToolStripMenuItem.Size = new Size(92, 22);
            přidatToolStripMenuItem.Text = "Přidat";
            // 
            // editovatToolStripMenuItem
            // 
            editovatToolStripMenuItem.Name = "editovatToolStripMenuItem";
            editovatToolStripMenuItem.Size = new Size(92, 22);
            editovatToolStripMenuItem.Text = "Editovat";
            // 
            // MoveTimer
            // 
            MoveTimer.Enabled = true;
            MoveTimer.Interval = 1;
            MoveTimer.Tick += MoveTimer_Tick;
            // 
            // SaveMenu
            // 
            SaveMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            SaveMenu.Location = new Point(0, 0);
            SaveMenu.Name = "SaveMenu";
            SaveMenu.Size = new Size(1487, 24);
            SaveMenu.TabIndex = 1;
            SaveMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 735);
            Controls.Add(SaveMenu);
            Controls.Add(MainView);
            MainMenuStrip = SaveMenu;
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)MainView).EndInit();
            MenuStrip.ResumeLayout(false);
            SaveMenu.ResumeLayout(false);
            SaveMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox MainView;
        private System.Windows.Forms.Timer MoveTimer;
        private ContextMenuStrip MenuStrip;
        private ToolStripMenuItem přidatToolStripMenuItem;
        private ToolStripMenuItem editovatToolStripMenuItem;
        private MenuStrip SaveMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
    }
}