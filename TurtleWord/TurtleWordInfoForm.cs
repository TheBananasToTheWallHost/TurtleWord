using FileMaker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWord
{
    /// <summary>
    /// This is the form a user will see once they've logged into an account. This can be considered the actual turtle word program.
    /// </summary>
    public partial class TurtleWordInfoForm : Form
    {
        public delegate void ChildFormClosedHandler();
        public event ChildFormClosedHandler ChildFormClosed;

        private String filepath;
        private String filename = "UserInformation.xml";
        private String completePath;
        private String infoFormOwner;
        private bool isPopulated;

        private ToolTip fulltext = new ToolTip() { AutoPopDelay = 10000 };

        private List<Tuple<String, String, String>> tableEntries = new List<Tuple<string, string, string>>();

        /// <summary>
        /// Initializes the turtle word form and sets the path for this user's info file.
        /// </summary>
        /// <param name="accountOwner"></param>
        public TurtleWordInfoForm(string accountOwner)
        {
            InitializeComponent();
            ResetTableRowStyles();

            infoFormOwner = accountOwner;

            filepath = Environment.CurrentDirectory;
            filepath = filepath.Substring(0, filepath.LastIndexOf("TurtleWord"));
            filepath = filepath + @"Resources\";

            filename = infoFormOwner + filename;

            completePath = filepath + filename;

            isPopulated = false;
        }

        /// <summary>
        /// Triggers the OnChildClosedEvent in the turtle word start up form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChildFormClosed();
        }

        /// <summary>
        /// Logging out closes the turtle word info form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Logout_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Adds an entry into the user's application username/password information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddEntry_MouseClick(object sender, MouseEventArgs e)
        {
            if (textbox_AddProgramWebsite.Text.Length > 0 && textbox_AddUsername.Text.Length > 0 && textbox_AddPassword.Text.Length > 0)
            {
                Parallel.Invoke(() => AddTableRowLabels(1, new List<string>() { textbox_AddProgramWebsite.Text }, new List<string>() { textbox_AddUsername.Text }, new List<string>() { textbox_AddPassword.Text }),
                                 () => AdjustEntryList(new List<string>() { textbox_AddProgramWebsite.Text }, new List<string>() { textbox_AddUsername.Text }, new List<string>() { textbox_AddPassword.Text }, 1));

                if (!File.Exists(completePath))
                {
                    Task.Run(() => XMLMaker.CreateAccountInformationXML(completePath, infoFormOwner, textbox_AddProgramWebsite.Text, textbox_AddUsername.Text, textbox_AddPassword.Text));
                }
                else
                {
                    XMLMaker.AddInfoToAccountInformationXML(completePath, textbox_AddProgramWebsite.Text, textbox_AddUsername.Text, textbox_AddPassword.Text);
                }


                textbox_AddProgramWebsite.Clear();
                textbox_AddUsername.Clear();
                textbox_AddPassword.Clear();
            }
        }

        /// <summary>
        /// Displays all entries in a user's information file in the turtle word information form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DisplayAllInfo_MouseClick(object sender, MouseEventArgs e)
        {

            if (File.Exists(completePath) && !isPopulated)
            {
                PopulateForm();
                isPopulated = true;
            }

            else
            {
                MessageBox.Show("There are currently no other entries to display.", "Display Message", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Searches for a password based on the information entered in the search textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SearchForEntry_MouseClick(object sender, MouseEventArgs e)
        {
            if (textbox_GetProgramWebsite.TextLength > 0 && textbox_GetAccountUsername.TextLength > 0)
            {
                textbox_ReturnSearch.Text = XMLChecker.SearchAppInfoInUserInfoXML(completePath, textbox_GetAccountUsername.Text, textbox_GetProgramWebsite.Text);
            }
        }

        /// <summary>
        /// Removes the entry specified in the add/remove entry textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RemoveEntry_MouseClick(object sender, MouseEventArgs e)
        {
            if (textbox_AddPassword.TextLength > 0 && textbox_AddProgramWebsite.TextLength > 0 && textbox_AddUsername.TextLength > 0)
            {
                XMLMaker.RemoveInfoFromAccountInformationXML(completePath, textbox_AddUsername.Text, textbox_AddPassword.Text, textbox_AddProgramWebsite.Text);
            }


            AdjustEntryList(new List<string>() { textbox_AddProgramWebsite.Text },
                                                   new List<string>() { textbox_AddUsername.Text },
                                                   new List<string>() { textbox_AddPassword.Text },
                                                   -1);

            ResetTable();

            ReenterTableEntries();

            textbox_AddPassword.Clear();
            textbox_AddProgramWebsite.Clear();
            textbox_AddUsername.Clear();
        }

        /// <summary>
        /// Displays a username or password on a tooltip. This is useful when the password or username is too long and can't be seen in it's entirety.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayFullLabelText(object sender, EventArgs e)
        {
            Label tableLabel = sender as Label;
            fulltext.Show(tableLabel.Text, tableLabel);
        }

        /// <summary>
        /// Reads the user's information file and fills the rows in the table in the turtle word info form with the information it pulls.
        /// </summary>
        private void PopulateForm()
        {
            ResetTable();

            int numRows = 0;
            Dictionary<int, List<string>> info;

            info = XMLChecker.ReadUserInfoXML(completePath, ref numRows);

            Parallel.Invoke(() => AddTableRowLabels(numRows, info[0], info[1], info[2]),
                            () => AdjustEntryList(info[0], info[1], info[2], 1));

        }

        /// <summary>
        /// 
        /// </summary>
        private void ReenterTableEntries()
        {
            for (int i = 0; i < tableEntries.Count; i++)
            {
                AddTableRowLabels(1,
                                  new List<string>() { tableEntries[i].Item1 },
                                  new List<string>() { tableEntries[i].Item2 },
                                  new List<string>() { tableEntries[i].Item3 });
            }
        }

        /// <summary>
        /// Adds or removes entries to the table entry list
        /// </summary>
        /// <param name="appLabelText"></param>
        /// <param name="userLabelText"></param>
        /// <param name="passwordLabelText"></param>
        /// <param name="action"></param>
        private void AdjustEntryList(List<string> appLabelText, List<string> userLabelText, List<string> passwordLabelText, int action)
        {
            switch (action)
            {
                case 1:
                    for (int i = 0; i < appLabelText.Count; i++)
                    {
                        tableEntries.Add(Tuple.Create(appLabelText[i], userLabelText[i], passwordLabelText[i]));
                    }
                    break;
                case -1:
                    for (int i = 0; i < appLabelText.Count; i++)
                    {
                        tableEntries.Remove(Tuple.Create(appLabelText[i], userLabelText[i], passwordLabelText[i]));
                    }
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Dynamically adds rows to the turtle word information table, and fills the row text with the input information.
        /// </summary>
        /// <param name="numRows"></param>
        /// <param name="appLabelText"></param>
        /// <param name="userLabelText"></param>
        /// <param name="passwordLabelText"></param>
        private void AddTableRowLabels(int numRows, List<string> appLabelText, List<string> userLabelText, List<string> passwordLabelText)
        {
            for (int row = 0; row < numRows; row++)
            {
                Label appLabel = new Label() { Text = appLabelText[row], AutoSize = true };
                appLabel.MouseHover += new EventHandler(DisplayFullLabelText);

                Label userLabel = new Label() { Text = userLabelText[row], AutoSize = true };
                userLabel.MouseHover += new EventHandler(DisplayFullLabelText);

                Label passLabel = new Label() { Text = passwordLabelText[row], AutoSize = true };
                passLabel.MouseHover += new EventHandler(DisplayFullLabelText);

                tableLayoutPanel_Info.Controls.Add(appLabel, 0, tableLayoutPanel_Info.RowCount - 1);
                tableLayoutPanel_Info.Controls.Add(userLabel, 1, tableLayoutPanel_Info.RowCount - 1);
                tableLayoutPanel_Info.Controls.Add(passLabel, 2, tableLayoutPanel_Info.RowCount - 1);

                tableLayoutPanel_Info.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableLayoutPanel_Info.RowCount++;
            }
        }

        /// <summary>
        /// Empties the table layout panel of all controls and resets the row count to 0
        /// </summary>
        private void ResetTable()
        {
            tableLayoutPanel_Info.Controls.Clear();
            tableLayoutPanel_Info.RowCount = 1;
        }


        /// <summary>
        /// Ensures the turtle word info table is empty upon initialization.
        /// </summary>
        private void ResetTableRowStyles()
        {
            tableLayoutPanel_Info.RowStyles.Clear();
        }

        #region Functions that may need to be implemented in the future/functions that currently have no use after recent changes.
        /// <summary>
        /// *** As of now, this function doesn't have a use. But it might in the future ***
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //List<string> apps = new List<string>();
            //List<string> users = new List<string>();
            //List<string> passes = new List<string>();

            //GetTableLabelsInformation(apps, users, passes);

            //if (!File.Exists(completePath))
            //{
            //    Task.Run(() => XMLMaker.CreateAccountInformationXML(completePath, infoFormOwner, apps, users, passes));
            //}
            //else
            //{
            //    Task.Run(() => XMLMaker.UpdateAccountInformationXMLDuplicateTest(completePath, apps, users, passes));
            //}


        }

        /// <summary>
        /// *** As of now, this function doesn't have a use. But it might in the future ***
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Adds the application, user, and password information in the turtle word information table to three lists.
        /// </summary>
        /// <param name="apps"></param>
        /// <param name="users"></param>
        /// <param name="passwords"></param>
        private void GetTableLabelsInformation(List<string> apps, List<string> users, List<string> passwords)
        {
            foreach (Control label in tableLayoutPanel_Info.Controls)
            {
                if (tableLayoutPanel_Info.GetCellPosition(label).Column == 0)
                {
                    apps.Add((label as Label).Text.Trim(' '));
                }

                else if (tableLayoutPanel_Info.GetCellPosition(label).Column == 1)
                {
                    users.Add((label as Label).Text.Trim(' '));
                }

                else if (tableLayoutPanel_Info.GetCellPosition(label).Column == 2)
                {
                    passwords.Add((label as Label).Text.Trim(' '));
                }
            }
        }
        #endregion


    }
}
