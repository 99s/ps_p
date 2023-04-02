using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PS_Portal_Api.Repositories
{
  
        public class EncryptionClass : Dictionary<string, string>
        {

            // Change the following keys to ensure uniqueness
            // Must be 8 bytes
            protected byte[] _keyBytes = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18 };

            // Must be at least 8 characters
            protected string _keyString = "ABC12345";

            // Name for checksum value (unlikely to be used as arguments by user)
            protected string _checksumKey = "__$$";

            /// <summary>
            /// Creates an empty dictionary
            /// </summary>
            public EncryptionClass()
            {
            }

            /// <summary>
            /// Creates a dictionary from the given, encrypted string
            /// </summary>
            /// <param name="encryptedData"></param>
            public EncryptionClass(string encryptedData)
            {
                // Descrypt string
                string data = Decrypt(encryptedData);

                // Parse out key/value pairs and add to dictionary
                string checksum = null;
                string[] args = data.Split('&');

                foreach (string arg in args)
                {
                    int i = arg.IndexOf('=');
                    if (i != -1)
                    {
                        string key = arg.Substring(0, i);
                        string value = arg.Substring(i + 1);
                        if (key == _checksumKey)
                            checksum = value;
                        else
                            base.Add(HttpUtility.UrlDecode(key), HttpUtility.UrlDecode(value));
                    }
                }

                // Clear contents if valid checksum not found
                if (checksum == null || checksum != ComputeChecksum())
                    base.Clear();
            }

            /// <summary>
            /// Returns an encrypted string that contains the current dictionary
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // Build query string from current contents
                StringBuilder content = new StringBuilder();

                foreach (string key in base.Keys)
                {
                    if (content.Length > 0)
                        content.Append('&');
                    content.AppendFormat("{0}={1}", HttpUtility.UrlEncode(key),
                        HttpUtility.UrlEncode(base[key]));
                }

                // Add checksum
                if (content.Length > 0)
                    content.Append('&');
                content.AppendFormat("{0}={1}", _checksumKey, ComputeChecksum());

                return Encrypt(content.ToString());
            }

            /// <summary>
            /// Returns a simple checksum for all keys and values in the collection
            /// </summary>
            /// <returns></returns>
            protected string ComputeChecksum()
            {
                int checksum = 0;

                foreach (KeyValuePair<string, string> pair in this)
                {
                    checksum += pair.Key.Sum(c => c - '0');
                    checksum += pair.Value.Sum(c => c - '0');
                }

                return checksum.ToString("X");
            }

            /// <summary>
            /// Encrypts the given text
            /// </summary>
            /// <param name="text">Text to be encrypted</param>
            /// <returns></returns>
            public string Encrypt(string text)
            {
                try
                {
                    byte[] keyData = Encoding.UTF8.GetBytes(_keyString.Substring(0, 8));
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] textData = Encoding.UTF8.GetBytes(text);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                        des.CreateEncryptor(keyData, _keyBytes), CryptoStreamMode.Write);
                    cs.Write(textData, 0, textData.Length);
                    cs.FlushFinalBlock();
                    return GetString(ms.ToArray());
                }
                catch (Exception)
                {
                    return String.Empty;
                }
            }

            /// <summary>
            /// Decrypts the given encrypted text
            /// </summary>
            /// <param name="text">Text to be decrypted</param>
            /// <returns></returns>
            public string Decrypt(string text)
            {
                try
                {
                    byte[] keyData = Encoding.UTF8.GetBytes(_keyString.Substring(0, 8));
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] textData = GetBytes(text);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                        des.CreateDecryptor(keyData, _keyBytes), CryptoStreamMode.Write);
                    cs.Write(textData, 0, textData.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch (Exception)
                {
                    return String.Empty;
                }
            }

            /// <summary>
            /// Converts a byte array to a string of hex characters
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            protected string GetString(byte[] data)
            {
                StringBuilder results = new StringBuilder();

                foreach (byte b in data)
                    results.Append(b.ToString("X2"));

                return results.ToString();
            }

            /// <summary>
            /// Converts a string of hex characters to a byte array
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            protected byte[] GetBytes(string data)
            {
                // GetString() encodes the hex-numbers with two digits
                byte[] results = new byte[data.Length / 2];

                for (int i = 0; i < data.Length; i += 2)
                    results[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);

                return results;
            }

            public static string HashString(string stringToHash)
            {
                SHA256Managed sha256 = new SHA256Managed();
                var bytes = UTF8Encoding.UTF8.GetBytes(stringToHash);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash).Replace("+", string.Empty).Replace("=", string.Empty);//+ char is not well handled in urls, therefore skipping it

            }


            public string HashPassword(string password)
            {
                var prf = KeyDerivationPrf.HMACSHA256;
                var rng = RandomNumberGenerator.Create();
                const int iterCount = 10000;
                const int saltSize = 128 / 8;
                const int numBytesRequested = 256 / 8;

                // Produce a version 3 (see comment above) text hash.
                var salt = new byte[saltSize];
                rng.GetBytes(salt);
                var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

                var outputBytes = new byte[13 + salt.Length + subkey.Length];
                outputBytes[0] = 0x01; // format marker
                WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
                WriteNetworkByteOrder(outputBytes, 5, iterCount);
                WriteNetworkByteOrder(outputBytes, 9, saltSize);
                Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
                Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
                return Convert.ToBase64String(outputBytes);
            }

            public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
            {
                var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

                // Wrong version
                if (decodedHashedPassword[0] != 0x01)
                    return false;

                // Read header information
                var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
                var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
                var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

                // Read the salt: must be >= 128 bits
                if (saltLength < 128 / 8)
                {
                    return false;
                }
                var salt = new byte[saltLength];
                Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

                // Read the subkey (the rest of the payload): must be >= 128 bits
                var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }
                var expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the incoming password and verify it
                var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
                return actualSubkey.SequenceEqual(expectedSubkey);
            }

            private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
            {
                buffer[offset + 0] = (byte)(value >> 24);
                buffer[offset + 1] = (byte)(value >> 16);
                buffer[offset + 2] = (byte)(value >> 8);
                buffer[offset + 3] = (byte)(value >> 0);
            }

            private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
            {
                return ((uint)(buffer[offset + 0]) << 24)
                    | ((uint)(buffer[offset + 1]) << 16)
                    | ((uint)(buffer[offset + 2]) << 8)
                    | ((uint)(buffer[offset + 3]));
            }
            public static string Base64Encode(string plainText)
            {
                try
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                    return System.Convert.ToBase64String(plainTextBytes);
                }
                catch
                {
                    return string.Empty;
                }

            }

            public static string Base64Decode(string base64EncodedData)
            {
                try
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                }
                catch
                {
                    return string.Empty;
                }


            }
        }
    }

