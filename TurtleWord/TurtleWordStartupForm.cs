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
    /// This is the start-up form that a user will see when first opening the program.
    /// </summary>
    public partial class TurtleWordControl : Form
    {
        private String filepath;
        private String filename = "Users.xml";
        private String completePath;

        /// <summary>
        /// Initializing the start-up form and the path where the user information is stored.
        /// </summary>
        public TurtleWordControl()
        {
            InitializeComponent();
            filepath = Environment.CurrentDirectory;
            filepath = filepath.Substring(0, filepath.LastIndexOf("TurtleWord"));
            filepath = filepath + @"Resources\";
            completePath = filepath + filename;
        }

        /// <summary>
        /// Checks the login information a user enters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Login_MouseClick(object sender, MouseEventArgs e)
        {
            bool isAnAccount = false;

            if (File.Exists(completePath))
            {
                if (textbox_Username.Text.Length == 0 || textbox_Password.Text.Length == 0)
                {
                    MessageBox.Show("A username and/or password has not been entered. Please re-enter your username and password",
                                      "Login Error", MessageBoxButtons.OK);
                }
                else
                {
                    XMLChecker.ReadUserXMLForLogin(completePath, textbox_Username.Text, textbox_Password.Text, ref isAnAccount);

                    if (isAnAccount)
                    {
                        //DoLoginStuff
                        TurtleWordInfoForm passForm = new TurtleWordInfoForm(textbox_Username.Text);
                        passForm.ChildFormClosed += OnChildFormClosed;

                        this.Hide();
                        passForm.Show();

                        textbox_Username.Clear();
                        textbox_Password.Clear();
                        textbox_CreateUsername.Clear();
                        textbox_CreatePassword.Clear();
                        textbox_ConfirmPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Username and/or password not found. Make sure you typed the information in correctly" +
                            " and please try again.", "Login Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("No users have been created for use in this program. Please create a user.", "Login Error", MessageBoxButtons.OK);
            }
        }
        
        /// <summary>
        /// Creates a new account for a user, as long as the username doesn't already exist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CreateAccount_MouseClick(object sender, MouseEventArgs e)
        {
            bool CanCreateAccount;
            bool UsernameExists = false;

            XMLChecker.ReadUserXMLForCreate(completePath, textbox_CreateUsername.Text, ref UsernameExists);
            CheckInputsAreValid(out CanCreateAccount);

            if (CanCreateAccount && !File.Exists(completePath) && !UsernameExists)
            {
                XMLMaker.CreateUserXML(completePath, textbox_CreateUsername.Text, textbox_CreatePassword.Text);
                MessageBox.Show("User added successfully.", "User Created", MessageBoxButtons.OK);

                textbox_CreateUsername.Clear();
                textbox_CreatePassword.Clear();
                textbox_ConfirmPassword.Clear();
            }
            else if(CanCreateAccount && File.Exists(completePath) && !UsernameExists)
            {
                XMLMaker.AddUser(completePath, textbox_CreateUsername.Text, textbox_CreatePassword.Text);
                MessageBox.Show("User added successfully.", "User Created", MessageBoxButtons.OK);

                textbox_CreateUsername.Clear();
                textbox_CreatePassword.Clear();
                textbox_ConfirmPassword.Clear();
            }
            else if (CanCreateAccount && UsernameExists)
            {
                MessageBox.Show("An account with this username already exists. Please use a different username or login.", "Account Creation Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Performs some simple checks on username and password information entered by the user, and determines whether or not these inputs
        /// are valid for account creation.
        /// </summary>
        /// <param name="CanCreateAccount"></param>
        private void CheckInputsAreValid(out bool CanCreateAccount)
        {
            if (textbox_CreateUsername.Text.Length < 1)
            {
                MessageBox.Show("Please enter a username", "Username Warning", MessageBoxButtons.OK);
                CanCreateAccount = false;
                return;
            }

            if (textbox_CreateUsername.Text.Length > 24)
            {
                MessageBox.Show("Username is too long, please enter a username that's less than 25 characters long", "Username Warning", MessageBoxButtons.OK);
                CanCreateAccount = false;
                return;
            }

            if (textbox_CreatePassword.Text.Length < 8)
            {
                MessageBox.Show("Password is too short, it must be at least 8 characters long", "Password Warning", MessageBoxButtons.OK);
                CanCreateAccount = false;
                return;
            }

            if (textbox_CreatePassword.Text.Length > 40)
            {
                MessageBox.Show("Password is too long, it must be less than 41 characters long", "Password Warning", MessageBoxButtons.OK);
                CanCreateAccount = false;
                return;
            }

            if (!textbox_ConfirmPassword.Text.Equals(textbox_CreatePassword.Text))
            {
                MessageBox.Show("Password entries do not match. Please re-enter your password entries", "Password Error", MessageBoxButtons.OK);
                CanCreateAccount = false;
                return;
            }

            CanCreateAccount = true;
            return;
        }

        /// <summary>
        /// Shows the start-up form and runs a simple message box when the turtle word program window is closed.
        /// </summary>
        private void OnChildFormClosed()
        {
            this.Show();
            Task.Run(() => MessageBox.Show("You have successfully logged out.", "Logged Out", MessageBoxButtons.OK));
        }

        
    }
}
