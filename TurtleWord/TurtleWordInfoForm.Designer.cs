namespace TurtleWord
{
    partial class TurtleWordInfoForm
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
            this.button_Logout = new System.Windows.Forms.Button();
            this.splitContainer_AccountInfo = new System.Windows.Forms.SplitContainer();
            this.button_RemoveEntry = new System.Windows.Forms.Button();
            this.textbox_ReturnSearch = new System.Windows.Forms.TextBox();
            this.button_SearchForEntry = new System.Windows.Forms.Button();
            this.textbox_GetAccountUsername = new System.Windows.Forms.TextBox();
            this.label_GetUsername = new System.Windows.Forms.Label();
            this.textbox_GetProgramWebsite = new System.Windows.Forms.TextBox();
            this.label_GetProgramWebsite = new System.Windows.Forms.Label();
            this.label_GetInformation = new System.Windows.Forms.Label();
            this.label_AddPassword = new System.Windows.Forms.Label();
            this.label_AddUsername = new System.Windows.Forms.Label();
            this.label_AddProgramWebsite = new System.Windows.Forms.Label();
            this.label_AddInfo = new System.Windows.Forms.Label();
            this.textbox_AddProgramWebsite = new System.Windows.Forms.TextBox();
            this.textbox_AddUsername = new System.Windows.Forms.TextBox();
            this.textbox_AddPassword = new System.Windows.Forms.TextBox();
            this.button_AddEntry = new System.Windows.Forms.Button();
            this.label_TablePasswords = new System.Windows.Forms.Label();
            this.label_TableUsername = new System.Windows.Forms.Label();
            this.label_TableProgramWebsite = new System.Windows.Forms.Label();
            this.button_DisplayAllEntries = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Info = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_AccountInfo)).BeginInit();
            this.splitContainer_AccountInfo.Panel1.SuspendLayout();
            this.splitContainer_AccountInfo.Panel2.SuspendLayout();
            this.splitContainer_AccountInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Logout
            // 
            this.button_Logout.Location = new System.Drawing.Point(3, 3);
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(85, 36);
            this.button_Logout.TabIndex = 0;
            this.button_Logout.Text = "Logout";
            this.button_Logout.UseVisualStyleBackColor = true;
            this.button_Logout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_Logout_MouseClick);
            // 
            // splitContainer_AccountInfo
            // 
            this.splitContainer_AccountInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer_AccountInfo.IsSplitterFixed = true;
            this.splitContainer_AccountInfo.Location = new System.Drawing.Point(12, 0);
            this.splitContainer_AccountInfo.Name = "splitContainer_AccountInfo";
            // 
            // splitContainer_AccountInfo.Panel1
            // 
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.button_RemoveEntry);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_ReturnSearch);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.button_SearchForEntry);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_GetAccountUsername);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_GetUsername);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_GetProgramWebsite);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_GetProgramWebsite);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_GetInformation);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_AddPassword);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_AddUsername);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_AddProgramWebsite);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.label_AddInfo);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_AddProgramWebsite);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_AddUsername);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.textbox_AddPassword);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.button_AddEntry);
            this.splitContainer_AccountInfo.Panel1.Controls.Add(this.button_Logout);
            // 
            // splitContainer_AccountInfo.Panel2
            // 
            this.splitContainer_AccountInfo.Panel2.AutoScroll = true;
            this.splitContainer_AccountInfo.Panel2.Controls.Add(this.label_TablePasswords);
            this.splitContainer_AccountInfo.Panel2.Controls.Add(this.label_TableUsername);
            this.splitContainer_AccountInfo.Panel2.Controls.Add(this.label_TableProgramWebsite);
            this.splitContainer_AccountInfo.Panel2.Controls.Add(this.button_DisplayAllEntries);
            this.splitContainer_AccountInfo.Panel2.Controls.Add(this.tableLayoutPanel_Info);
            this.splitContainer_AccountInfo.Size = new System.Drawing.Size(937, 604);
            this.splitContainer_AccountInfo.SplitterDistance = 312;
            this.splitContainer_AccountInfo.TabIndex = 1;
            this.splitContainer_AccountInfo.TabStop = false;
            // 
            // button_RemoveEntry
            // 
            this.button_RemoveEntry.Location = new System.Drawing.Point(126, 282);
            this.button_RemoveEntry.Name = "button_RemoveEntry";
            this.button_RemoveEntry.Size = new System.Drawing.Size(117, 35);
            this.button_RemoveEntry.TabIndex = 16;
            this.button_RemoveEntry.Text = "Remove Entry";
            this.button_RemoveEntry.UseVisualStyleBackColor = true;
            this.button_RemoveEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_RemoveEntry_MouseClick);
            // 
            // textbox_ReturnSearch
            // 
            this.textbox_ReturnSearch.Location = new System.Drawing.Point(76, 571);
            this.textbox_ReturnSearch.Name = "textbox_ReturnSearch";
            this.textbox_ReturnSearch.Size = new System.Drawing.Size(167, 22);
            this.textbox_ReturnSearch.TabIndex = 15;
            // 
            // button_SearchForEntry
            // 
            this.button_SearchForEntry.Location = new System.Drawing.Point(76, 530);
            this.button_SearchForEntry.Name = "button_SearchForEntry";
            this.button_SearchForEntry.Size = new System.Drawing.Size(116, 35);
            this.button_SearchForEntry.TabIndex = 14;
            this.button_SearchForEntry.Text = "Search";
            this.button_SearchForEntry.UseVisualStyleBackColor = true;
            this.button_SearchForEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_SearchForEntry_MouseClick);
            // 
            // textbox_GetAccountUsername
            // 
            this.textbox_GetAccountUsername.Location = new System.Drawing.Point(3, 491);
            this.textbox_GetAccountUsername.Name = "textbox_GetAccountUsername";
            this.textbox_GetAccountUsername.Size = new System.Drawing.Size(189, 22);
            this.textbox_GetAccountUsername.TabIndex = 13;
            // 
            // label_GetUsername
            // 
            this.label_GetUsername.AutoSize = true;
            this.label_GetUsername.Location = new System.Drawing.Point(4, 471);
            this.label_GetUsername.Name = "label_GetUsername";
            this.label_GetUsername.Size = new System.Drawing.Size(128, 17);
            this.label_GetUsername.TabIndex = 12;
            this.label_GetUsername.Text = "Account Username";
            // 
            // textbox_GetProgramWebsite
            // 
            this.textbox_GetProgramWebsite.Location = new System.Drawing.Point(3, 434);
            this.textbox_GetProgramWebsite.Name = "textbox_GetProgramWebsite";
            this.textbox_GetProgramWebsite.Size = new System.Drawing.Size(189, 22);
            this.textbox_GetProgramWebsite.TabIndex = 11;
            // 
            // label_GetProgramWebsite
            // 
            this.label_GetProgramWebsite.AutoSize = true;
            this.label_GetProgramWebsite.Location = new System.Drawing.Point(4, 414);
            this.label_GetProgramWebsite.Name = "label_GetProgramWebsite";
            this.label_GetProgramWebsite.Size = new System.Drawing.Size(158, 17);
            this.label_GetProgramWebsite.TabIndex = 10;
            this.label_GetProgramWebsite.Text = "Program/Website Name";
            // 
            // label_GetInformation
            // 
            this.label_GetInformation.AutoSize = true;
            this.label_GetInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GetInformation.Location = new System.Drawing.Point(3, 383);
            this.label_GetInformation.Name = "label_GetInformation";
            this.label_GetInformation.Size = new System.Drawing.Size(124, 20);
            this.label_GetInformation.TabIndex = 9;
            this.label_GetInformation.Text = "Get Information";
            // 
            // label_AddPassword
            // 
            this.label_AddPassword.AutoSize = true;
            this.label_AddPassword.Location = new System.Drawing.Point(2, 223);
            this.label_AddPassword.Name = "label_AddPassword";
            this.label_AddPassword.Size = new System.Drawing.Size(124, 17);
            this.label_AddPassword.TabIndex = 7;
            this.label_AddPassword.Text = "Account Password";
            // 
            // label_AddUsername
            // 
            this.label_AddUsername.AutoSize = true;
            this.label_AddUsername.Location = new System.Drawing.Point(3, 162);
            this.label_AddUsername.Name = "label_AddUsername";
            this.label_AddUsername.Size = new System.Drawing.Size(128, 17);
            this.label_AddUsername.TabIndex = 6;
            this.label_AddUsername.Text = "Account Username";
            // 
            // label_AddProgramWebsite
            // 
            this.label_AddProgramWebsite.AutoSize = true;
            this.label_AddProgramWebsite.Location = new System.Drawing.Point(3, 103);
            this.label_AddProgramWebsite.Name = "label_AddProgramWebsite";
            this.label_AddProgramWebsite.Size = new System.Drawing.Size(158, 17);
            this.label_AddProgramWebsite.TabIndex = 5;
            this.label_AddProgramWebsite.Text = "Program/Website Name";
            // 
            // label_AddInfo
            // 
            this.label_AddInfo.AutoSize = true;
            this.label_AddInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AddInfo.Location = new System.Drawing.Point(1, 71);
            this.label_AddInfo.Name = "label_AddInfo";
            this.label_AddInfo.Size = new System.Drawing.Size(192, 20);
            this.label_AddInfo.TabIndex = 4;
            this.label_AddInfo.Text = "Add/Remove Information";
            // 
            // textbox_AddProgramWebsite
            // 
            this.textbox_AddProgramWebsite.Location = new System.Drawing.Point(3, 123);
            this.textbox_AddProgramWebsite.Name = "textbox_AddProgramWebsite";
            this.textbox_AddProgramWebsite.Size = new System.Drawing.Size(189, 22);
            this.textbox_AddProgramWebsite.TabIndex = 1;
            // 
            // textbox_AddUsername
            // 
            this.textbox_AddUsername.Location = new System.Drawing.Point(3, 182);
            this.textbox_AddUsername.Name = "textbox_AddUsername";
            this.textbox_AddUsername.Size = new System.Drawing.Size(189, 22);
            this.textbox_AddUsername.TabIndex = 2;
            // 
            // textbox_AddPassword
            // 
            this.textbox_AddPassword.Location = new System.Drawing.Point(3, 243);
            this.textbox_AddPassword.Name = "textbox_AddPassword";
            this.textbox_AddPassword.Size = new System.Drawing.Size(189, 22);
            this.textbox_AddPassword.TabIndex = 3;
            // 
            // button_AddEntry
            // 
            this.button_AddEntry.Location = new System.Drawing.Point(3, 282);
            this.button_AddEntry.Name = "button_AddEntry";
            this.button_AddEntry.Size = new System.Drawing.Size(116, 35);
            this.button_AddEntry.TabIndex = 8;
            this.button_AddEntry.Text = "Add Entry";
            this.button_AddEntry.UseVisualStyleBackColor = true;
            this.button_AddEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_AddEntry_MouseClick);
            // 
            // label_TablePasswords
            // 
            this.label_TablePasswords.AutoSize = true;
            this.label_TablePasswords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TablePasswords.Location = new System.Drawing.Point(409, 19);
            this.label_TablePasswords.Name = "label_TablePasswords";
            this.label_TablePasswords.Size = new System.Drawing.Size(92, 20);
            this.label_TablePasswords.TabIndex = 4;
            this.label_TablePasswords.Text = "Passwords";
            // 
            // label_TableUsername
            // 
            this.label_TableUsername.AutoSize = true;
            this.label_TableUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TableUsername.Location = new System.Drawing.Point(227, 19);
            this.label_TableUsername.Name = "label_TableUsername";
            this.label_TableUsername.Size = new System.Drawing.Size(95, 20);
            this.label_TableUsername.TabIndex = 3;
            this.label_TableUsername.Text = "Usernames";
            // 
            // label_TableProgramWebsite
            // 
            this.label_TableProgramWebsite.AutoSize = true;
            this.label_TableProgramWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TableProgramWebsite.Location = new System.Drawing.Point(3, 19);
            this.label_TableProgramWebsite.Name = "label_TableProgramWebsite";
            this.label_TableProgramWebsite.Size = new System.Drawing.Size(157, 20);
            this.label_TableProgramWebsite.TabIndex = 2;
            this.label_TableProgramWebsite.Text = "Programs/Websites";
            // 
            // button_DisplayAllEntries
            // 
            this.button_DisplayAllEntries.Location = new System.Drawing.Point(205, 546);
            this.button_DisplayAllEntries.Name = "button_DisplayAllEntries";
            this.button_DisplayAllEntries.Size = new System.Drawing.Size(141, 29);
            this.button_DisplayAllEntries.TabIndex = 1;
            this.button_DisplayAllEntries.Text = "Display All Entries";
            this.button_DisplayAllEntries.UseVisualStyleBackColor = true;
            this.button_DisplayAllEntries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_DisplayAllInfo_MouseClick);
            // 
            // tableLayoutPanel_Info
            // 
            this.tableLayoutPanel_Info.AutoScroll = true;
            this.tableLayoutPanel_Info.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_Info.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_Info.ColumnCount = 3;
            this.tableLayoutPanel_Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel_Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel_Info.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel_Info.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel_Info.Name = "tableLayoutPanel_Info";
            this.tableLayoutPanel_Info.RowCount = 1;
            this.tableLayoutPanel_Info.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 545F));
            this.tableLayoutPanel_Info.Size = new System.Drawing.Size(565, 498);
            this.tableLayoutPanel_Info.TabIndex = 0;
            // 
            // TurtleWordInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(961, 616);
            this.Controls.Add(this.splitContainer_AccountInfo);
            this.DoubleBuffered = true;
            this.Name = "TurtleWordInfoForm";
            this.Text = "Account Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer_AccountInfo.Panel1.ResumeLayout(false);
            this.splitContainer_AccountInfo.Panel1.PerformLayout();
            this.splitContainer_AccountInfo.Panel2.ResumeLayout(false);
            this.splitContainer_AccountInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_AccountInfo)).EndInit();
            this.splitContainer_AccountInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Logout;
        private System.Windows.Forms.SplitContainer splitContainer_AccountInfo;
        private System.Windows.Forms.Label label_AddPassword;
        private System.Windows.Forms.Label label_AddUsername;
        private System.Windows.Forms.Label label_AddProgramWebsite;
        private System.Windows.Forms.Label label_AddInfo;
        private System.Windows.Forms.TextBox textbox_AddProgramWebsite;
        private System.Windows.Forms.TextBox textbox_AddUsername;
        private System.Windows.Forms.TextBox textbox_AddPassword;
        private System.Windows.Forms.Button button_AddEntry;
        private System.Windows.Forms.Button button_DisplayAllEntries;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Info;
        private System.Windows.Forms.Label label_TablePasswords;
        private System.Windows.Forms.Label label_TableUsername;
        private System.Windows.Forms.Label label_TableProgramWebsite;
        private System.Windows.Forms.TextBox textbox_GetAccountUsername;
        private System.Windows.Forms.Label label_GetUsername;
        private System.Windows.Forms.TextBox textbox_GetProgramWebsite;
        private System.Windows.Forms.Label label_GetProgramWebsite;
        private System.Windows.Forms.Label label_GetInformation;
        private System.Windows.Forms.TextBox textbox_ReturnSearch;
        private System.Windows.Forms.Button button_SearchForEntry;
        private System.Windows.Forms.Button button_RemoveEntry;
    }
}