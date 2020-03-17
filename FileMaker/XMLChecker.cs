using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileMaker
{
    public static class XMLChecker
    {
        /// <summary>
        /// Reads the user/account file and checks whether the username/password match an existing account's info.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="AccountExists"></param>
        public static void ReadUserXMLForLogin(string file, string username, string password, ref bool AccountExists)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name.Equals("ID"))
                            {
                                if (reader.HasAttributes)
                                {
                                    string user = reader.GetAttribute("Username");
                                    string pass = reader.GetAttribute("Password");

                                    if (user.Equals(username) && pass.Equals(password))
                                    {
                                        AccountExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                AccountExists = false;
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the user/account file and checks whether the username is available for use for a new account.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="username"></param>
        /// <param name="UsernameExists"></param>
        public static void ReadUserXMLForCreate(string file, string username, ref bool UsernameExists)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name.Equals("ID"))
                            {
                                if (reader.HasAttributes)
                                {
                                    string user = reader.GetAttribute("Username");

                                    if (user.Equals(username))
                                    {
                                        UsernameExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                UsernameExists = false;
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the information in a particular account's information file and adds the applications, usernames, and passwords to lists. It then returns
        /// a dictionary that matches a particular value to each list.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="numEntries"></param>
        /// <returns></returns>
        public static Dictionary<int, List<string>> ReadUserInfoXML(string file, ref int numEntries)
        {
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();
            List<string> relatedApps = new List<string>();

            try
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name.Equals("Application"))
                            {
                                if (reader.HasAttributes)
                                {
                                    relatedApps.Add(reader.GetAttribute("AppName"));
                                }

                                numEntries++;
                            }

                            else if (reader.Name.Equals("Username"))
                            {
                                usernames.Add(reader.ReadInnerXml());
                            }

                            else if (reader.Name.Equals("Password"))
                            {
                                passwords.Add(reader.ReadInnerXml());
                            }
                        }
                    }
                }

                return new Dictionary<int, List<string>>()
                {
                    {1, usernames },
                    {2, passwords },
                    {0, relatedApps }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Dictionary<int, List<string>>();
            }
        }

        /// <summary>
        /// Searches for the password that's attached to the given username and application.
        /// </summary>
        public static string SearchAppInfoInUserInfoXML(string file, string username, string application)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    while (reader.ReadToFollowing("Application"))
                    {
                        if (reader.HasAttributes && reader.GetAttribute("AppName").Trim().Equals(application))
                        {
                            if (reader.ReadToDescendant("Username"))
                            {
                                if (reader.ReadElementContentAsString().Equals(username))
                                {
                                    reader.ReadToNextSibling("Password");

                                    string pass = reader.ReadInnerXml();

                                    return pass;
                                }
                            }
                        }

                    }
                }

                return "Password not found.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "An Error Occurred.";
            }
        }
    }
}
