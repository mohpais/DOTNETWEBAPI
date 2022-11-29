using System.Security.Cryptography;
using System.Text;
using Application.Common.Interfaces;
using Infrastructure.Common.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Infrastructure.Common.Services
{
  public class Encryption : IEncryption
  {
    private readonly ConfigSettings _config;
    private string aesIV256 = ""; // 16 digit

    public Encryption(IOptions<ConfigSettings> configOptions)
    {
      _config = configOptions.Value;
      aesIV256 = _config.Secret;
    }
    
    public string Countchar(string source)
    {
      string charss = "";
      int count = source.Length;
      int chars = count % 4;
      for (int i = 0; i < chars; i++)
      {
        charss = charss + "=";
      }

      return charss;
    }

    /// <summary>
    /// Encrypts 256 bit AES.
    /// </summary>
    /// <param name="text">Text to encrypt.</param>
    /// <param name="key">Encryption key.</param>
    /// <returns>Encrypted text.</returns>
    public string Encrypt(string text, string key)
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
    public string Decrypt(string text, string key)
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
    
    public string stringToBase64(string source)
    {
      byte[] expectedBytes = Encoding.Unicode.GetBytes(source);
      string base64String = Convert.ToBase64String(expectedBytes);

      return base64String;
    }

    // Decode a Base64 string to a string
    public async Task<string> base64ToString(string source)
    {
      if(string.IsNullOrEmpty(source))
        return string.Empty;

      var input = new MemoryStream(Encoding.UTF8.GetBytes(source));
      using FromBase64Transform myTransform = new FromBase64Transform();
      using CryptoStream cryptoStream = new CryptoStream(input, myTransform, CryptoStreamMode.Read);

      using var sr = new StreamReader(cryptoStream);
      string str = await sr.ReadToEndAsync(); // OK

      return str;
    }
    
    // Generate a 128-bit salt using a sequence of
    // cryptographically strong random bytes.
    public string Hash(string source)
    {
      // byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
      byte[] salt = Encoding.UTF8.GetBytes(aesIV256);
      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: source!,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 100000,
        numBytesRequested: 256 / 8)
      );

      return hashed;
    }

  }
}