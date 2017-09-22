using MMonitorLib;
using MMonitorLib.Entities;
using MMonitorLib.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SourcesUploader
{
    class Program
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static MD5 md5 = null; 

        static void Main(string[] args)
        {
            md5 = MD5.Create();
            string file = System.Configuration.ConfigurationManager.AppSettings["file_with_sources"];
            int row = 0;

            using (var db = new MMonitorContext())
            {
                var lines =  File.ReadAllLines(file);

                TheSource s;
                string url = string.Empty;
                Uri u;
                Langs lang = Langs.UNDEFINED;
                string sourceType = string.Empty;
                

                foreach(var line in lines)
                {                    
                    string[] parts = line.Split('\t').Select(p => p.Trim()).ToArray();
                    if (parts[0].Contains("http"))
                    {
                        if (!Uri.IsWellFormedUriString(parts[0], UriKind.Absolute))
                        {
                            log.Error(string.Format("Bad format for Url {0} at line {1}", parts[0], row));
                            throw new FormatException(string.Format("Bad format for Url {0} at line {1}", parts[0], row));
                        }
                        u = new Uri(parts[0]);
                        url = u.Scheme + "://" + u.Host;
                    }
                    else
                    {
                        url = "http://" + parts[0];
                        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                        {
                            log.Error(string.Format("Bad format for Url {0} at line {1}", parts[0], row));
                            throw new FormatException(string.Format("Bad format for Url {0} at line {1}", parts[0], row));
                        }

                        u = new Uri(url);
                        url = u.Scheme + "://" + u.Host;
                    }

                    if(string.IsNullOrEmpty(parts[1]))
                    {
                        lang = IdentifyLanguage(url);
                    }

                    s = new TheSource()
                    {
                        Url = url,
                        UrlHash = GetMD5Hash(url),
                        Lang = (Langs)Enum.Parse(typeof(Langs), parts[1]), 
                        TheSourceType = (TheSourceType)Enum.Parse(typeof(TheSourceType), parts[2])
                    };

                    if (db.TheSources.Where(x => x.UrlHash == s.UrlHash).FirstOrDefault() == null)
                    {
                        db.TheSources.Add(s);
                        row++;
                        Console.WriteLine("row is " + row);
                    }                        
                }

                try
                {
                    db.SaveChanges();
                    log.Info($"Loaded {row} sources to database");
                }
                catch(Exception ex)
                {
                    log.Error("Can't upload sources", ex);
                }                
            }
            
            Console.ReadLine();
        }

        /// <summary>
        /// Identifying content language.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static Langs IdentifyLanguage(string url)
        {
            return Langs.UNDEFINED;
        }

        /// <summary>
        /// Get MD5 Hash from url.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMD5Hash(string input)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
