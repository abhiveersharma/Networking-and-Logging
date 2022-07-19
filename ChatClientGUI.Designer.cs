namespace ChatClient
{
    partial class ChatClientForm
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
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.MessageBoxLabel = new System.Windows.Forms.Label();
            this.MessageBoxTextBox = new System.Windows.Forms.TextBox();
            this.ConnectServerButton = new System.Windows.Forms.Button();
            this.RetrieveParticipantsButton = new System.Windows.Forms.Button();
            this.ClientsListBox = new System.Windows.Forms.ListBox();
            this.MessageBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Location = new System.Drawing.Point(29, 31);
            this.ServerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(121, 15);
            this.ServerNameLabel.TabIndex = 0;
            this.ServerNameLabel.Text = "Server Name/Address";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Location = new System.Drawing.Point(178, 31);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(184, 23);
            this.ServerNameTextBox.TabIndex = 1;
            this.ServerNameTextBox.Text = "localhost";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(89, 95);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(66, 15);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "Your Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(178, 93);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(142, 23);
            this.UserNameTextBox.TabIndex = 3;
            // 
            // MessageBoxLabel
            // 
            this.MessageBoxLabel.AutoSize = true;
            this.MessageBoxLabel.Location = new System.Drawing.Point(107, 209);
            this.MessageBoxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageBoxLabel.Name = "MessageBoxLabel";
            this.MessageBoxLabel.Size = new System.Drawing.Size(91, 15);
            this.MessageBoxLabel.TabIndex = 4;
            this.MessageBoxLabel.Text = "Type something";
            // 
            // MessageBoxTextBox
            // 
            this.MessageBoxTextBox.Location = new System.Drawing.Point(229, 209);
            this.MessageBoxTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MessageBoxTextBox.Name = "MessageBoxTextBox";
            this.MessageBoxTextBox.Size = new System.Drawing.Size(532, 23);
            this.MessageBoxTextBox.TabIndex = 5;
            // 
            // ConnectServerButton
            // 
            this.ConnectServerButton.Location = new System.Drawing.Point(178, 120);
            this.ConnectServerButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ConnectServerButton.Name = "ConnectServerButton";
            this.ConnectServerButton.Size = new System.Drawing.Size(141, 22);
            this.ConnectServerButton.TabIndex = 6;
            this.ConnectServerButton.Text = "Connect To Server";
            this.ConnectServerButton.UseVisualStyleBackColor = true;
            this.ConnectServerButton.Click += new System.EventHandler(this.ConnectServerButton_Click);
            // 
            // RetrieveParticipantsButton
            // 
            this.RetrieveParticipantsButton.Location = new System.Drawing.Point(768, 150);
            this.RetrieveParticipantsButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.RetrieveParticipantsButton.Name = "RetrieveParticipantsButton";
            this.RetrieveParticipantsButton.Size = new System.Drawing.Size(135, 22);
            this.RetrieveParticipantsButton.TabIndex = 7;
            this.RetrieveParticipantsButton.Text = "Retrieve Participants";
            this.RetrieveParticipantsButton.UseVisualStyleBackColor = true;
            this.RetrieveParticipantsButton.Click += new System.EventHandler(this.RetrieveParticipantsButton_Click);
            // 
            // ClientsListBox
            // 
            this.ClientsListBox.FormattingEnabled = true;
            this.ClientsListBox.ItemHeight = 15;
            this.ClientsListBox.Location = new System.Drawing.Point(768, 19);
            this.ClientsListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ClientsListBox.Name = "ClientsListBox";
            this.ClientsListBox.Size = new System.Drawing.Size(135, 124);
            this.ClientsListBox.TabIndex = 8;
            // 
            // MessageBox
            // 
            this.MessageBox.FormattingEnabled = true;
            this.MessageBox.ItemHeight = 15;
            this.MessageBox.Location = new System.Drawing.Point(107, 255);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ScrollAlwaysVisible = true;
            this.MessageBox.Size = new System.Drawing.Size(714, 214);
            this.MessageBox.TabIndex = 9;
            // 
            // ChatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 546);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ClientsListBox);
            this.Controls.Add(this.RetrieveParticipantsButton);
            this.Controls.Add(this.ConnectServerButton);
            this.Controls.Add(this.MessageBoxTextBox);
            this.Controls.Add(this.MessageBoxLabel);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.ServerNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "ChatClientForm";
            this.Text = "Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ServerNameLabel;
        private TextBox ServerNameTextBox;
        private Label UserNameLabel;
        private TextBox UserNameTextBox;
        private Label MessageBoxLabel;
        private TextBox MessageBoxTextBox;
        private Button ConnectServerButton;
        private Button RetrieveParticipantsButton;
        private ListBox ClientsListBox;
        private ListBox MessageBox;
    }
}