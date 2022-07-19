namespace ChatServer
{
    partial class ChatServerForm
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
            this.ServerLabel = new System.Windows.Forms.Label();
            this.ServerIPAddressLabel = new System.Windows.Forms.Label();
            this.ParticipantsLabel = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new System.Windows.Forms.TextBox();
            this.ServerIPAddressTextBox = new System.Windows.Forms.TextBox();
            this.ParticipantsListBox = new System.Windows.Forms.ListBox();
            this.MessageListBox = new System.Windows.Forms.ListBox();
            this.ShutdownServerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(773, 57);
            this.ServerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(113, 25);
            this.ServerLabel.TabIndex = 0;
            this.ServerLabel.Text = "Server Name";
            // 
            // ServerIPAddressLabel
            // 
            this.ServerIPAddressLabel.AutoSize = true;
            this.ServerIPAddressLabel.Location = new System.Drawing.Point(773, 138);
            this.ServerIPAddressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerIPAddressLabel.Name = "ServerIPAddressLabel";
            this.ServerIPAddressLabel.Size = new System.Drawing.Size(151, 25);
            this.ServerIPAddressLabel.TabIndex = 1;
            this.ServerIPAddressLabel.Text = "Server IP Address";
            // 
            // ParticipantsLabel
            // 
            this.ParticipantsLabel.AutoSize = true;
            this.ParticipantsLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ParticipantsLabel.Location = new System.Drawing.Point(183, 200);
            this.ParticipantsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ParticipantsLabel.Name = "ParticipantsLabel";
            this.ParticipantsLabel.Size = new System.Drawing.Size(159, 38);
            this.ParticipantsLabel.TabIndex = 2;
            this.ParticipantsLabel.Text = "Participants";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Location = new System.Drawing.Point(977, 57);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(252, 31);
            this.ServerNameTextBox.TabIndex = 3;
            // 
            // ServerIPAddressTextBox
            // 
            this.ServerIPAddressTextBox.Location = new System.Drawing.Point(977, 135);
            this.ServerIPAddressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ServerIPAddressTextBox.Name = "ServerIPAddressTextBox";
            this.ServerIPAddressTextBox.Size = new System.Drawing.Size(252, 31);
            this.ServerIPAddressTextBox.TabIndex = 4;
            // 
            // ParticipantsListBox
            // 
            this.ParticipantsListBox.FormattingEnabled = true;
            this.ParticipantsListBox.ItemHeight = 25;
            this.ParticipantsListBox.Location = new System.Drawing.Point(101, 249);
            this.ParticipantsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.ParticipantsListBox.Name = "ParticipantsListBox";
            this.ParticipantsListBox.Size = new System.Drawing.Size(329, 404);
            this.ParticipantsListBox.TabIndex = 5;
            // 
            // MessageListBox
            // 
            this.MessageListBox.FormattingEnabled = true;
            this.MessageListBox.ItemHeight = 25;
            this.MessageListBox.Location = new System.Drawing.Point(712, 249);
            this.MessageListBox.Margin = new System.Windows.Forms.Padding(2);
            this.MessageListBox.Name = "MessageListBox";
            this.MessageListBox.ScrollAlwaysVisible = true;
            this.MessageListBox.Size = new System.Drawing.Size(676, 654);
            this.MessageListBox.TabIndex = 6;
            // 
            // ShutdownServerButton
            // 
            this.ShutdownServerButton.Location = new System.Drawing.Point(141, 760);
            this.ShutdownServerButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShutdownServerButton.Name = "ShutdownServerButton";
            this.ShutdownServerButton.Size = new System.Drawing.Size(231, 69);
            this.ShutdownServerButton.TabIndex = 7;
            this.ShutdownServerButton.Text = "Shutdown Server";
            this.ShutdownServerButton.UseVisualStyleBackColor = true;
            this.ShutdownServerButton.Click += new System.EventHandler(this.ShutdownServerButton_Click);
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 964);
            this.Controls.Add(this.ShutdownServerButton);
            this.Controls.Add(this.MessageListBox);
            this.Controls.Add(this.ParticipantsListBox);
            this.Controls.Add(this.ServerIPAddressTextBox);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.ParticipantsLabel);
            this.Controls.Add(this.ServerIPAddressLabel);
            this.Controls.Add(this.ServerLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChatServerForm";
            this.Text = "Chat Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ServerLabel;
        private Label ServerIPAddressLabel;
        private Label ParticipantsLabel;
        private TextBox ServerNameTextBox;
        private TextBox ServerIPAddressTextBox;
        private ListBox ParticipantsListBox;
        private ListBox MessageListBox;
        private Button ShutdownServerButton;
    }
}