using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encrypt
{
    public class RSAService
    {
        public RSACryptoServiceProvider rSACryptoServiceProvider { get; set; }
        public PemKeyUtils pemKeyUtils { get; set; }

        public RSAService()
        {
            pemKeyUtils = new PemKeyUtils();
            rSACryptoServiceProvider = new RSACryptoServiceProvider();
        }
        public RSAService(string path)
        {
            pemKeyUtils = new PemKeyUtils();
            rSACryptoServiceProvider = pemKeyUtils.GetRSAProviderFromPemFile(path);
        }

        public void parsePem(string path)
        {
            rSACryptoServiceProvider = pemKeyUtils.GetRSAProviderFromPemFile(path);
        }

        public string Encrypt(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var encryptString = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), false));

            return encryptString;
        }

        public string Encrypt(string content)
        {
            var encryptString = Convert.ToBase64String(rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(content), false));

            return encryptString;
        }
        /// <summary>
        /// 解密字串
        /// </summary>
        public string Decrypt(string privateKey, string encryptedContent)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var decryptString = Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(encryptedContent), true));

            return decryptString;
        }

        public string Decrypt(string encryptedContent)
        {
            var decryptString = Encoding.UTF8.GetString(rSACryptoServiceProvider.Decrypt(Convert.FromBase64String(encryptedContent), true));

            return decryptString;
        }
        /// <summary>
        /// 加密檔案
        /// </summary>
        public void EncryptFile(string publicKey, string rawFilePath, string encryptedFilePath)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            using (FileStream testDataStream = File.OpenRead(rawFilePath))
            using (FileStream encrytpStream = File.OpenWrite(encryptedFilePath))
            {
                var testDataByteArray = new byte[testDataStream.Length];
                testDataStream.Read(testDataByteArray, 0, testDataByteArray.Length);

                var encryptDataByteArray = rsa.Encrypt(testDataByteArray, false);

                encrytpStream.Write(encryptDataByteArray, 0, encryptDataByteArray.Length);
            }
        }
        /// <summary>
        /// 解密檔案
        /// </summary>
        public void DecryptFile(string privateKey, string encryptedFilePath, string decryptedFilePath)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            using (FileStream encrytpStream = File.OpenRead(encryptedFilePath))
            using (FileStream decrytpStream = File.OpenWrite(decryptedFilePath))
            {
                var encryptDataByteArray = new byte[encrytpStream.Length];
                encrytpStream.Read(encryptDataByteArray, 0, encryptDataByteArray.Length);

                var decryptDataByteArray = rsa.Decrypt(encryptDataByteArray, false);

                decrytpStream.Write(decryptDataByteArray, 0, decryptDataByteArray.Length);
            }
        }

        /// <summary>
        /// 匯出PEM格式的Private秘鑰
        /// </summary>
        /// <param name="csp"></param>
        /// <param name="outputStream"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ExportPrivateKey(RSACryptoServiceProvider csp, TextWriter outputStream)
        {
            if (csp.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
            var parameters = csp.ExportParameters(true);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    EncodeIntegerBigEndian(innerWriter, parameters.D);
                    EncodeIntegerBigEndian(innerWriter, parameters.P);
                    EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                outputStream.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
                // Output as Base64 with lines chopped at 64 characters
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
                outputStream.WriteLine("-----END RSA PRIVATE KEY-----");
            }
        }

        public void ExportPrivateKey(TextWriter outputStream)
        {
            if (rSACryptoServiceProvider.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
            var parameters = rSACryptoServiceProvider.ExportParameters(true);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    EncodeIntegerBigEndian(innerWriter, parameters.D);
                    EncodeIntegerBigEndian(innerWriter, parameters.P);
                    EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                outputStream.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
                // Output as Base64 with lines chopped at 64 characters
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
                outputStream.WriteLine("-----END RSA PRIVATE KEY-----");
            }
        }

        /// <summary>
        /// 匯出PEM格式的Private秘鑰
        /// </summary>
        /// <param name="csp"></param>
        /// <param name="outputStream"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ExportPublicKey(RSACryptoServiceProvider csp, TextWriter outputStream)
        {
            var parameters = csp.ExportParameters(false);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    //EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    //EncodeIntegerBigEndian(innerWriter, parameters.D);
                    //EncodeIntegerBigEndian(innerWriter, parameters.P);
                    //EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    //EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    //EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    //EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                outputStream.WriteLine("-----BEGIN RSA PUBLIC KEY-----");
                // Output as Base64 with lines chopped at 64 characters
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
                outputStream.WriteLine("-----END RSA PUBLIC KEY-----");
            }
        }
        
        public void ExportPublicKey(TextWriter outputStream)
        {
            var parameters = rSACryptoServiceProvider.ExportParameters(false);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    //EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    //EncodeIntegerBigEndian(innerWriter, parameters.D);
                    //EncodeIntegerBigEndian(innerWriter, parameters.P);
                    //EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    //EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    //EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    //EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                outputStream.WriteLine("-----BEGIN RSA PUBLIC KEY-----");
                // Output as Base64 with lines chopped at 64 characters
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
                outputStream.WriteLine("-----END RSA PUBLIC KEY-----");
            }
        }

        private static void EncodeLength(BinaryWriter stream, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
            if (length < 0x80)
            {
                // Short form
                stream.Write((byte)length);
            }
            else
            {
                // Long form
                var temp = length;
                var bytesRequired = 0;
                while (temp > 0)
                {
                    temp >>= 8;
                    bytesRequired++;
                }
                stream.Write((byte)(bytesRequired | 0x80));
                for (var i = bytesRequired - 1; i >= 0; i--)
                {
                    stream.Write((byte)(length >> (8 * i) & 0xff));
                }
            }
        }

        private void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
        {
            stream.Write((byte)0x02); // INTEGER
            var prefixZeros = 0;
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] != 0) break;
                prefixZeros++;
            }
            if (value.Length - prefixZeros == 0)
            {
                EncodeLength(stream, 1);
                stream.Write((byte)0);
            }
            else
            {
                if (forceUnsigned && value[prefixZeros] > 0x7f)
                {
                    // Add a prefix zero to force unsigned if the MSB is 1
                    EncodeLength(stream, value.Length - prefixZeros + 1);
                    stream.Write((byte)0);
                }
                else
                {
                    EncodeLength(stream, value.Length - prefixZeros);
                }
                for (var i = prefixZeros; i < value.Length; i++)
                {
                    stream.Write(value[i]);
                }
            }
        }
    }
}
