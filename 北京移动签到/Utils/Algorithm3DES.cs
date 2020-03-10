using System;
using System.IO;
using System.Security.Cryptography;

public class Algorithm3DES
{

    #region ECB模式 
    /// <summary> 
    /// DES3 ECB模式加密 
    /// </summary> 
    /// <param name="key">密钥</param> 
    /// <param name="iv">IV(当模式为ECB时，IV无用)</param> 
    /// <param name="str">明文的byte数组</param> 
    /// <returns>密文的byte数组</returns> 
    public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
    {
        try
        {
            MemoryStream mStream = new MemoryStream();

            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.PKCS7;

            CryptoStream cStream = new CryptoStream(mStream, tdsp.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();

            byte[] ret = mStream.ToArray();

            cStream.Close();
            mStream.Close();

            return ret;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
    }



    /// <summary> 
    /// DES3 ECB模式解密 
    /// </summary> 
    /// <param name="key">密钥</param> 
    /// <param name="iv">IV(当模式为ECB时，IV无用)</param> 
    /// <param name="str">密文的byte数组</param> 
    /// <returns>明文的byte数组</returns> 
    public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
    {
        try
        {
            MemoryStream msDecrypt = new MemoryStream(data);

            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.PKCS7;

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(key, iv), CryptoStreamMode.Read);

            byte[] fromEncrypt = new byte[data.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            return fromEncrypt;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
    }
    #endregion



}