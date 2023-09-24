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
            AddButton = new Button();
            MoveTimer = new System.Windows.Forms.Timer(components);
            MenuStrip = new ContextMenuStrip(components);
            přidatToolStripMenuItem = new ToolStripMenuItem();
            editovatToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)MainView).BeginInit();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainView
            // 
            MainView.BackColor = SystemColors.ActiveBorder;
            MainView.ContextMenuStrip = MenuStrip;
            MainView.Location = new Point(195, 12);
            MainView.Name = "MainView";
            MainView.Size = new Size(1280, 711);
            MainView.TabIndex = 0;
            MainView.TabStop = false;
            MainView.Paint += MainView_Paint;
            MainView.MouseDown += MainView_MouseDown;
            MainView.MouseMove += MainView_MouseMove;
            MainView.MouseUp += MainView_MouseUp;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 12);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(177, 66);
            AddButton.TabIndex = 1;
            AddButton.Text = "AddNew";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // MoveTimer
            // 
            MoveTimer.Enabled = true;
            MoveTimer.Interval = 1;
            MoveTimer.Tick += MoveTimer_Tick;
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { přidatToolStripMenuItem, editovatToolStripMenuItem });
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(118, 48);
            // 
            // přidatToolStripMenuItem
            // 
            přidatToolStripMenuItem.Name = "přidatToolStripMenuItem";
            přidatToolStripMenuItem.Size = new Size(117, 22);
            přidatToolStripMenuItem.Text = "Přidat";
            // 
            // editovatToolStripMenuItem
            // 
            editovatToolStripMenuItem.Name = "editovatToolStripMenuItem";
            editovatToolStripMenuItem.Size = new Size(117, 22);
            editovatToolStripMenuItem.Text = "Editovat";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 735);
            Controls.Add(AddButton);
            Controls.Add(MainView);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)MainView).EndInit();
            MenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox MainView;
        private Button AddButton;
        private System.Windows.Forms.Timer MoveTimer;
        private ContextMenuStrip MenuStrip;
        private ToolStripMenuItem přidatToolStripMenuItem;
        private ToolStripMenuItem editovatToolStripMenuItem;
    }
}