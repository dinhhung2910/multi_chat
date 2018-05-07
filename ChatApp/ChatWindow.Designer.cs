namespace ChatApp
{
    partial class ChatRoom
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatRoom));
            this.typeArea = new System.Windows.Forms.TextBox();
            this.chatHistory = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeArea
            // 
            this.typeArea.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeArea.Location = new System.Drawing.Point(22, 284);
            this.typeArea.Multiline = true;
            this.typeArea.Name = "typeArea";
            this.typeArea.Size = new System.Drawing.Size(269, 75);
            this.typeArea.TabIndex = 0;
            // 
            // chatHistory
            // 
            this.chatHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatHistory.Location = new System.Drawing.Point(22, 22);
            this.chatHistory.Multiline = true;
            this.chatHistory.Name = "chatHistory";
            this.chatHistory.ReadOnly = true;
            this.chatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.chatHistory.Size = new System.Drawing.Size(360, 244);
            this.chatHistory.TabIndex = 3;
            // 
            // btSend
            // 
            this.btSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSend.BackgroundImage")));
            this.btSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSend.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btSend.FlatAppearance.BorderSize = 0;
            this.btSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSend.Image = ((System.Drawing.Image)(resources.GetObject("btSend.Image")));
            this.btSend.Location = new System.Drawing.Point(307, 284);
            this.btSend.Margin = new System.Windows.Forms.Padding(0);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 75);
            this.btSend.TabIndex = 4;
            this.btSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // ChatRoom
            // 
            this.AcceptButton = this.btSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 397);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.chatHistory);
            this.Controls.Add(this.typeArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatRoom";
            this.Text = "Chat room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox typeArea;
        private System.Windows.Forms.TextBox chatHistory;
        private System.Windows.Forms.Button btSend;
    }
}