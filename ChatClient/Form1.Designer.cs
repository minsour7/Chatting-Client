namespace ChatClient
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
            label1 = new Label();
            txtName = new TextBox();
            btnConnect = new Button();
            txtChatMsg = new TextBox();
            txtMsg = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "대화명";
            // 
            // txtName
            // 
            txtName.Location = new Point(70, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(106, 23);
            txtName.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(228, 31);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(126, 30);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "입장";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtChatMsg
            // 
            txtChatMsg.Location = new Point(30, 84);
            txtChatMsg.Multiline = true;
            txtChatMsg.Name = "txtChatMsg";
            txtChatMsg.ScrollBars = ScrollBars.Vertical;
            txtChatMsg.Size = new Size(341, 265);
            txtChatMsg.TabIndex = 3;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(28, 377);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(342, 23);
            txtMsg.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 435);
            Controls.Add(txtMsg);
            Controls.Add(txtChatMsg);
            Controls.Add(btnConnect);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button btnConnect;
        private TextBox txtChatMsg;
        private TextBox txtMsg;
    }
}
