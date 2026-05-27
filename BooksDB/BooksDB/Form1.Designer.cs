namespace BooksDB
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            додатиАвтораToolStripMenuItem = new ToolStripMenuItem();
            видалитиАвтораToolStripMenuItem = new ToolStripMenuItem();
            редагуватиАвтораToolStripMenuItem = new ToolStripMenuItem();
            додатиКнигуToolStripMenuItem = new ToolStripMenuItem();
            видалитиКнигуToolStripMenuItem = new ToolStripMenuItem();
            редагуватиКнигуToolStripMenuItem = new ToolStripMenuItem();
            checkBox1 = new CheckBox();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(178, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(417, 118);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(733, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиАвтораToolStripMenuItem, видалитиАвтораToolStripMenuItem, редагуватиАвтораToolStripMenuItem, додатиКнигуToolStripMenuItem, видалитиКнигуToolStripMenuItem, редагуватиКнигуToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Опції";
            menuToolStripMenuItem.Click += menuToolStripMenuItem_Click;
            // 
            // додатиАвтораToolStripMenuItem
            // 
            додатиАвтораToolStripMenuItem.Name = "додатиАвтораToolStripMenuItem";
            додатиАвтораToolStripMenuItem.Size = new Size(220, 26);
            додатиАвтораToolStripMenuItem.Text = "Додати автора";
            додатиАвтораToolStripMenuItem.Click += додатиАвтораToolStripMenuItem_Click;
            // 
            // видалитиАвтораToolStripMenuItem
            // 
            видалитиАвтораToolStripMenuItem.Name = "видалитиАвтораToolStripMenuItem";
            видалитиАвтораToolStripMenuItem.Size = new Size(220, 26);
            видалитиАвтораToolStripMenuItem.Text = "Видалити автора";
            видалитиАвтораToolStripMenuItem.Click += видалитиАвтораToolStripMenuItem_Click;
            // 
            // редагуватиАвтораToolStripMenuItem
            // 
            редагуватиАвтораToolStripMenuItem.Name = "редагуватиАвтораToolStripMenuItem";
            редагуватиАвтораToolStripMenuItem.Size = new Size(220, 26);
            редагуватиАвтораToolStripMenuItem.Text = "Редагувати автора";
            редагуватиАвтораToolStripMenuItem.Click += редагуватиАвтораToolStripMenuItem_Click;
            // 
            // додатиКнигуToolStripMenuItem
            // 
            додатиКнигуToolStripMenuItem.Name = "додатиКнигуToolStripMenuItem";
            додатиКнигуToolStripMenuItem.Size = new Size(220, 26);
            додатиКнигуToolStripMenuItem.Text = "Додати книгу";
            додатиКнигуToolStripMenuItem.Click += додатиКнигуToolStripMenuItem_Click;
            // 
            // видалитиКнигуToolStripMenuItem
            // 
            видалитиКнигуToolStripMenuItem.Name = "видалитиКнигуToolStripMenuItem";
            видалитиКнигуToolStripMenuItem.Size = new Size(220, 26);
            видалитиКнигуToolStripMenuItem.Text = "Видалити книгу";
            видалитиКнигуToolStripMenuItem.Click += видалитиКнигуToolStripMenuItem_Click;
            // 
            // редагуватиКнигуToolStripMenuItem
            // 
            редагуватиКнигуToolStripMenuItem.Name = "редагуватиКнигуToolStripMenuItem";
            редагуватиКнигуToolStripMenuItem.Size = new Size(220, 26);
            редагуватиКнигуToolStripMenuItem.Text = "Редагувати книгу";
            редагуватиКнигуToolStripMenuItem.Click += редагуватиКнигуToolStripMenuItem_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(332, 375);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(178, 179);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(417, 164);
            listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(733, 430);
            Controls.Add(listBox1);
            Controls.Add(checkBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private CheckBox checkBox1;
        private ToolStripMenuItem додатиАвтораToolStripMenuItem;
        private ToolStripMenuItem видалитиАвтораToolStripMenuItem;
        private ToolStripMenuItem редагуватиАвтораToolStripMenuItem;
        private ToolStripMenuItem додатиКнигуToolStripMenuItem;
        private ToolStripMenuItem видалитиКнигуToolStripMenuItem;
        private ToolStripMenuItem редагуватиКнигуToolStripMenuItem;
        private ListBox listBox1;
    }
}
