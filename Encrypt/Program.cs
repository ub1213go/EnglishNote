using JWT.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Encrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            //RSAService rsa = new RSAService(@"./PrivateKey.pem");

            //Console.WriteLine(rsa.Decrypt(@"WK98UR1rtq/6QywTaeJ9jEFIUTBa4CQQbi3K3EecNVR0T2jePSg1lz1+invUVGLwXROAZ8ijtZ6Hs5iWI2Tz1/BeOfr43hvbdBgcTav84xZPHdGwC3RcZKlaAeilQCBlIuATRhpOqeXtzbcQ4UpwNPmfQcFrn7t4FEWkk56c/0w="));

            var pemKeyUtils = new PemKeyUtils();
            
            JWTService jwt = new JWTService(pemKeyUtils.getKeyContent("./PrivateKey.pem"));
            var token = jwt.getJWT();

            Console.WriteLine(token);

            Console.WriteLine(varifyJWT(jwt, token));
        }

        /// <summary>
        /// 生成公私鑰
        /// </summary>
        /// <param name="path"></param>
        static void generatePairKeyToFiles(string path = "./")
        {
            RSAService rsa = new RSAService();

            using(var write = File.CreateText(path + "PublicKey.pem"))
            {
                rsa.ExportPublicKey(write);
            }
            using (var write = File.CreateText(path + "PrivateKey.pem"))
            {
                rsa.ExportPrivateKey(write);
            }
        }
    
        static string varifyJWT(JWTService jwt, string token)
        {
            try
            {
                return jwt.varifyJWT(token);
            }
            catch (TokenExpiredException err)
            {
                return err.Message;
            }
            catch (SignatureVerificationException err)
            {
                return err.Message;
            }
        }
    }

    
}
