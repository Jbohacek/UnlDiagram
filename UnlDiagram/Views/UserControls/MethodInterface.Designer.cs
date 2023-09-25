namespace UnlDiagram.Views.UserControls
{
    partial class MethodInterface
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextNameBox = new TextBox();
            ComboAccess = new ComboBox();
            ComboVariable = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // TextNameBox
            // 
            TextNameBox.Location = new Point(3, 3);
            TextNameBox.Name = "TextNameBox";
            TextNameBox.Size = new Size(284, 23);
            TextNameBox.TabIndex = 0;
            TextNameBox.TextChanged += TextChangedObj;
            // 
            // ComboAccess
            // 
            ComboAccess.FormattingEnabled = true;
            ComboAccess.Location = new Point(3, 32);
            ComboAccess.Name = "ComboAccess";
            ComboAccess.Size = new Size(126, 23);
            ComboAccess.TabIndex = 1;
            ComboAccess.SelectedValueChanged += TextChangedObj;
            ComboAccess.TextChanged += TextChangedObj;
            // 
            // ComboVariable
            // 
            ComboVariable.FormattingEnabled = true;
            ComboVariable.Location = new Point(155, 32);
            ComboVariable.Name = "ComboVariable";
            ComboVariable.Size = new Size(132, 23);
            ComboVariable.TabIndex = 2;
            ComboVariable.TextChanged += TextChangedObj;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(3, 99);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(288, 111);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(216, 70);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "+ Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 56);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 82);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 6;
            label1.Text = "Parameters";
            // 
            // MethodInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(ComboVariable);
            Controls.Add(ComboAccess);
            Controls.Add(TextNameBox);
            Name = "MethodInterface";
            Size = new Size(290, 211);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextNameBox;
        private ComboBox ComboAccess;
        private ComboBox ComboVariable;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        private Label label1;
    }
}
