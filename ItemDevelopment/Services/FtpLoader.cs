using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDevelopment.Services
{
    public class FtpLoader
    {
        SftpClient client;
        string ftpServer = "shop.elartcom.eu";

        public FtpLoader()
        {
            Stream stream = File.OpenRead("ec2-efsuser.pem");
            var privateKey = new PrivateKeyFile(stream);
            client = new SftpClient(ftpServer, "ec2-efsuser", new[] { privateKey });
            client.Connect();
        }

        ~FtpLoader()
        {
            client.Disconnect();
        }

        public void Delete(string path)
        {
            while (!client.IsConnected)
            {
                try
                {
                    client.Connect();
                }
                catch
                {
                    Task.Delay(50);
                }
            }
            try
            {
                client.DeleteFile(path);
            } catch(Exception exc)
            {
                throw exc;
            }

        }

        public string Upload(byte[] byteArr, string name, string brandName)
        {
            while (!client.IsConnected)
            {
                try
                {
                    client.Connect();
                }
                catch
                {
                    Task.Delay(50);
                }
            }            

            string ftpFullFileName;
            
            try
            {
                string ftpDirectory = $"/var/www/html/static/images/" + brandName;
                if (!client.Exists(ftpDirectory))
                {
                    client.CreateDirectory(ftpDirectory);
                }

                ftpFullFileName = ftpDirectory + "/" + name;
                using (MemoryStream fstream = new MemoryStream(byteArr))
                {
                    client.UploadFile(fstream, ftpFullFileName);
                }
            }
            finally
            {
                //client.Disconnect();
            }
            return "https://" + ftpServer + ftpFullFileName.Remove(0, 13);
        }

        public MemoryStream Download(string path)
        {

            while (!client.IsConnected)
            {
                try
                {
                    client.Connect();
                }
                catch
                {
                    Task.Delay(50);
                }
            }

            MemoryStream mstream = new MemoryStream();

            try
            {
                client.DownloadFile(path, mstream);
            }
            finally
            {
                //client.Disconnect();
            }

            return mstream;

        }
    }
}
