using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
  public interface IEncryption
  {
    string Countchar(string source);
    string stringToBase64(string source);
    Task<string> base64ToString(string source);
    string Encrypt(string text, string key);
    string Decrypt(string text, string key);
    string Hash(string source);
  }
}