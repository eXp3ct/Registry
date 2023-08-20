namespace Expect.Registry
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
			menuStrip1 = new MenuStrip();
			файлToolStripMenuItem = new ToolStripMenuItem();
			filterByNameTextBox = new ToolStripTextBox();
			tableLayoutPanel = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			incomingDocumentRegestryButton = new Button();
			basicDocumentRegestryButton = new Button();
			dataGridView1 = new DataGridView();
			bindingSource = new BindingSource(components);
			CreateDocumentButton = new Button();
			menuStrip1.SuspendLayout();
			tableLayoutPanel.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, filterByNameTextBox });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1264, 27);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			файлToolStripMenuItem.Size = new Size(48, 23);
			файлToolStripMenuItem.Text = "Файл";
			// 
			// filterByNameTextBox
			// 
			filterByNameTextBox.Name = "filterByNameTextBox";
			filterByNameTextBox.Size = new Size(100, 23);
			filterByNameTextBox.KeyPress += FilterDocumentsByName;
			// 
			// tableLayoutPanel
			// 
			tableLayoutPanel.ColumnCount = 2;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.875F));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.125F));
			tableLayoutPanel.Controls.Add(groupBox1, 0, 0);
			tableLayoutPanel.Controls.Add(dataGridView1, 1, 0);
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new Point(0, 27);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 1;
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 52.58216F));
			tableLayoutPanel.Size = new Size(1264, 534);
			tableLayoutPanel.TabIndex = 1;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(CreateDocumentButton);
			groupBox1.Controls.Add(incomingDocumentRegestryButton);
			groupBox1.Controls.Add(basicDocumentRegestryButton);
			groupBox1.Dock = DockStyle.Fill;
			groupBox1.Location = new Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(232, 528);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Выбор реестра";
			// 
			// incomingDocumentRegestryButton
			// 
			incomingDocumentRegestryButton.Dock = DockStyle.Top;
			incomingDocumentRegestryButton.Location = new Point(3, 89);
			incomingDocumentRegestryButton.Name = "incomingDocumentRegestryButton";
			incomingDocumentRegestryButton.Size = new Size(226, 70);
			incomingDocumentRegestryButton.TabIndex = 1;
			incomingDocumentRegestryButton.Text = "Входящий документ";
			incomingDocumentRegestryButton.UseVisualStyleBackColor = true;
			incomingDocumentRegestryButton.Click += LoadIncomingRegistry;
			// 
			// basicDocumentRegestryButton
			// 
			basicDocumentRegestryButton.Dock = DockStyle.Top;
			basicDocumentRegestryButton.Location = new Point(3, 19);
			basicDocumentRegestryButton.Name = "basicDocumentRegestryButton";
			basicDocumentRegestryButton.Size = new Size(226, 70);
			basicDocumentRegestryButton.TabIndex = 0;
			basicDocumentRegestryButton.Text = "Базовый документ";
			basicDocumentRegestryButton.UseVisualStyleBackColor = true;
			basicDocumentRegestryButton.Click += LoadBasicRegistry;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(241, 3);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.Size = new Size(1020, 528);
			dataGridView1.TabIndex = 1;
			// 
			// CreateDocumentButton
			// 
			CreateDocumentButton.AutoSize = true;
			CreateDocumentButton.Dock = DockStyle.Top;
			CreateDocumentButton.Location = new Point(3, 159);
			CreateDocumentButton.Name = "CreateDocumentButton";
			CreateDocumentButton.Size = new Size(226, 70);
			CreateDocumentButton.TabIndex = 2;
			CreateDocumentButton.Text = "Создать документ";
			CreateDocumentButton.UseVisualStyleBackColor = true;
			CreateDocumentButton.Click += StartCreatingDocument;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1264, 561);
			Controls.Add(tableLayoutPanel);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			Text = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			tableLayoutPanel.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem файлToolStripMenuItem;
		private TableLayoutPanel tableLayoutPanel;
		private GroupBox groupBox1;
		private Button incomingDocumentRegestryButton;
		private Button basicDocumentRegestryButton;
		private DataGridView dataGridView1;
		private BindingSource bindingSource;
		private ToolStripTextBox filterByNameTextBox;
		private Button CreateDocumentButton;
	}
}