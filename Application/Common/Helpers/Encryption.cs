using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Helpers
{
  public class Encryption
  {
    private const string aesIV256 = @"!VedZF_F4YE@1906"; // 16 digit

    /// <summary>
    /// Encrypts 256 bit AES.
    /// </summary>
    /// <param name="text">Text to encrypt.</param>
    /// <param name="key">Encryption key.</param>
    /// <returns>Encrypted text.</returns>

    public static string Encrypt(string text, string key)
    {
      if (string.IsNullOrWhiteSpace(key))
        throw new Exception("Key cannot be null or white space.");

      if (key.Length != 32)
        throw new Exception("Key must be 32 length.");

      AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
      aes.BlockSize = 128;
      aes.KeySize = 256;
      aes.IV = Encoding.UTF8.GetBytes(aesIV256);
      aes.Key = Encoding.UTF8.GetBytes(key);
      aes.Mode = CipherMode.CBC;
      aes.Padding = PaddingMode.PKCS7;

      // Convert string to byte array
      byte[] src = Encoding.Unicode.GetBytes(text);

      // encryption
      using (ICryptoTransform encrypt = aes.CreateEncryptor())
      {
          byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

          aes.Dispose();
          // Convert byte array to Base64 strings
          return Convert.ToBase64String(dest);
      }
    }

    /// <summary>
    /// Decrypts 256 bit AES.
    /// </summary>
    /// <param name="text">Text to decrypt.</param>
    /// <param name="key">Encryption key. This key must be the same as the encryption key.</param>
    /// <returns>Decrypted string.</returns>
    public static string Decrypt(string text, string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new Exception("Key cannot be null or white space.");

        if (key.Length != 32)
            throw new Exception("Key must be 32 length.");

        // AesCryptoServiceProvider
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        aes.BlockSize = 128;
        aes.KeySize = 256;
        aes.IV = Encoding.UTF8.GetBytes(aesIV256);
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        // Convert Base64 strings to byte array
        byte[] src = System.Convert.FromBase64String(text);

        // decryption
        using (ICryptoTransform decrypt = aes.CreateDecryptor())
        {
            byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

            aes.Dispose();

            return Encoding.Unicode.GetString(dest);
        }
    }
  }
}