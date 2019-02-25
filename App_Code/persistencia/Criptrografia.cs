using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class Criptrografia
{
    //MD5
    static string hash = "f0xle@rgn!PL";   
    public static string Criptografar(string texto)
    {
        string resultado;
        byte[] data = UTF8Encoding.UTF8.GetBytes(texto);
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                resultado = Convert.ToBase64String(results, 0, results.Length);
            }
        }
        return resultado;
    }

    public static string Descriptografar(string texto)
    {
        string resultado;
        byte[] data = Convert.FromBase64String(texto);
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                resultado = UTF8Encoding.UTF8.GetString(results);
            }
        }
        return resultado;
    }

    private static string key = "ABC123DEF456GH78";
    private static byte[] GetByte(string data)
    {
        return Encoding.UTF8.GetBytes(data);
    }
    public static byte[] EncryptString(string data)
    {
        byte[] byteData = GetByte(data);
        SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        algo.Key = GetByte(key);
        algo.GenerateIV();
        MemoryStream mStream = new MemoryStream();
        mStream.Write(algo.IV, 0, algo.IV.Length);

        CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateEncryptor(), CryptoStreamMode.Write);
        myCrypto.Write(byteData, 0, byteData.Length);
        myCrypto.FlushFinalBlock();
        return mStream.ToArray();
    }

    public static string DecryptString (byte[] data)
    {
        SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        algo.Key = GetByte(key);
        MemoryStream mStream = new MemoryStream();
        byte[] byteData = new byte[algo.IV.Length];
        Array.Copy(data, byteData, byteData.Length);
        algo.IV = byteData;

        int readFrom = 0;
        readFrom +=algo.IV.Length;

        CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateDecryptor(), CryptoStreamMode.Write);
        myCrypto.Write(data, readFrom, data.Length - readFrom);
        myCrypto.FlushFinalBlock();

        return Encoding.UTF8.GetString(mStream.ToArray());
    }
    public static string GetencyptedQueryString(string data)
    {
        return Convert.ToBase64String(EncryptString(data));
    }

    public static string GetDescryptedQueryString(string data)
    {
        byte[] byteData = Convert.FromBase64String(data.Replace(" ", "+"));
        return DecryptString(byteData);
    }
}