using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FileMaker
{
    public static class XMLMaker
    {

        /// <summary>
        /// Creates the turtle word account/user file and adds the first account the user creates.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void CreateUserXML(string filepath, string username, string password)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                OmitXmlDeclaration = true
            };

            try
            {
                using (XmlWriter writer = XmlWriter.Create(filepath, settings))
                {
                    writer.WriteStartDocument();

                    writer.WriteStartElement("Users");

                    writer.WriteStartElement("ID");
                    writer.WriteAttributeString("Username", username);
                    writer.WriteAttributeString("Password", password);
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds a new username and password pair to the turtle word accounts file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void AddUser(string filepath, string username, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            XmlNode Users = doc.SelectSingleNode("Users");

            XmlElement ID = doc.CreateElement("ID");
            ID.SetAttribute("Username", username);
            ID.SetAttribute("Password", password);

            XmlNode newID = ID;

            Users.AppendChild(newID);

            doc.Save(filepath);
        }

        /// <summary>
        /// Creates an account information file associated with a particular account. All of the applications/passwords/usernames associated with a newly created 
        /// account are added here.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="owner"></param>
        /// <param name="application"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void CreateAccountInformationXML(string filepath, string owner, string application, string username, string password)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                OmitXmlDeclaration = true
            };

            try
            {
                using (XmlWriter writer = XmlWriter.Create(filepath, settings))
                {
                    writer.WriteStartDocument();

                    writer.WriteStartElement("Owner");
                    writer.WriteAttributeString("Name", owner);

                    writer.WriteStartElement("Application");
                    writer.WriteAttributeString("AppName", application);
                    writer.WriteElementString("Username", username);
                    writer.WriteElementString("Password", password);
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds non duplicate entries to a particular user's account information XML file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="application"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void AddInfoToAccountInformationXML(string file, string application, string username, string password)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                string xpath = String.Format("Owner/Application[@AppName='{0}'][Username='{1}'][Password='{2}']", application, username, password);

                XmlNode node = doc.SelectSingleNode(xpath);

                if (node == null)
                {
                    XmlNode root = doc.FirstChild;

                    XmlElement App = doc.CreateElement("Application");
                    App.SetAttribute("AppName", application);

                    XmlNode user = doc.CreateNode("element", "Username", "");
                    user.InnerText = username;

                    XmlNode pass = doc.CreateNode("element", "Password", "");
                    pass.InnerText = password;

                    App.AppendChild(user);
                    App.AppendChild(pass);

                    XmlNode newNode = App;

                    root.AppendChild(newNode);

                    doc.Save(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Searches the user's account information XML file for an entry with a matching username, password and application, and removes it from the file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="application"></param>
        public static void RemoveInfoFromAccountInformationXML(string file, string username, string password, string application)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                string xpath = String.Format("Owner/Application[@AppName='{0}'][Username='{1}'][Password='{2}']", application, username, password);

                XmlNode node = doc.SelectSingleNode(xpath);

                if (node != null)
                {
                    XmlNode root = node.ParentNode;

                    root.RemoveChild(node);

                    doc.Save(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }




        #region Old functions that have been replaced by better/simpler functions.

        /// <summary>
        /// Updates the applications/usernames/passwords found in an already created account's information file. This function prevents duplicates from being
        /// saved.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="applications"></param>
        /// <param name="usernames"></param>
        /// <param name="passwords"></param>
        public static void UpdateAccountInformationXMLDuplicateTest(string filepath, List<string> applications, List<string> usernames, List<string> passwords)
        {
            XDocument doc = XDocument.Load(filepath);

            List<int> indexesToRemove = new List<int>();

            var duplicateApps = applications
                            .Select((t, i) => new TextGrouping(i, t))
                            .GroupBy(g => g.Text);

            try
            {
                foreach (XElement docElement in doc.Descendants("Owner"))
                {

                    foreach (XElement appElement in docElement.Descendants("Application"))
                    {
                        foreach (var duplicateApp in duplicateApps)
                        {
                            if (duplicateApp.Key.Equals(appElement.FirstAttribute.Value.Trim(' ')))
                            {
                                IEnumerator<TextGrouping> indexRator = duplicateApp.GetEnumerator();

                                while (indexRator.MoveNext())
                                {
                                    if (indexRator.Current != null)
                                    {
                                        int AppIndex = indexRator.Current.Index;

                                        if (usernames[AppIndex].Equals(appElement.Element("Username").Value.Trim(' ')) && passwords[AppIndex].Equals(appElement.Element("Password").Value.Trim(' ')))
                                        {
                                            indexesToRemove.Add(AppIndex);
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
                //figure out how to remove the items at the proper indexes
                string[] appArray = applications.ToArray();
                string[] userArray = usernames.ToArray();
                string[] passArray = passwords.ToArray();

                foreach (int index in indexesToRemove)
                {
                    appArray[index] = String.Empty;
                    userArray[index] = String.Empty;
                    passArray[index] = String.Empty;
                }



                for (int index = 0; index < appArray.Length; index++)
                {
                    if (!String.IsNullOrEmpty(appArray[index]))
                    {
                        XElement newApp = new XElement("Application");
                        newApp.SetAttributeValue("AppName", applications[index]);
                        newApp.Add(new XElement("Username", usernames[index]));
                        newApp.Add(new XElement("Password", passwords[index]));
                        doc.Element("Owner").Add(newApp);
                    }
                }



                doc.Save(filepath);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        /// <summary>
        /// Creates an account information file associated with a particular account. All of the applications/passwords/usernames associated with a newly created 
        /// account are added here.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="owner"></param>
        /// <param name="applications"></param>
        /// <param name="usernames"></param>
        /// <param name="passwords"></param>
        public static void CreateAccountInformationXML(string filepath, string owner, List<string> applications, List<string> usernames, List<string> passwords)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                OmitXmlDeclaration = true
            };

            try
            {
                using (XmlWriter writer = XmlWriter.Create(filepath, settings))
                {
                    writer.WriteStartDocument();

                    writer.WriteStartElement("Owner");
                    writer.WriteAttributeString("Name", owner);

                    for (int index = 0; index < applications.Count; index++)
                    {
                        writer.WriteStartElement("Application");
                        writer.WriteAttributeString("AppName", applications[index]);
                        writer.WriteElementString("Username", usernames[index]);
                        writer.WriteElementString("Password", passwords[index]);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Helper class that creates a data structure useful for dealing with duplicates. Has no use since updating the way that entries are added to user 
        /// account information files.
        /// </summary>
        private class TextGrouping
        {
            public int Index;
            public string Text;

            public TextGrouping(int index, string text)
            {
                Index = index;
                Text = text;
            }
        }
        #endregion

    }
}
