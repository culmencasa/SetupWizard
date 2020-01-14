using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Windows.Utils
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public partial class Misc
    {        
        #region MD5
        public static string MD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(str)));
            t2 = t2.Replace("-", "").ToLower();
            return t2;
        }
        #endregion

    }
}