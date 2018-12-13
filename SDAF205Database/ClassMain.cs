using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using C1.Win.C1FlexGrid;
using System.Collections;
using System.Drawing;

namespace SDAF.DataBase
{
    public static class ClassMain
    {

        public static string GetStr(string stringToSub, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;

            for (int i = 0; i < stringChar.Length; i++)
            {
                if (nLength >= length) break;
                if (regex.IsMatch((stringChar[i]).ToString()) || GetStr(stringChar[i].ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }
            }
            return sb.ToString();
        }


        public static bool GetStr(string s)
        {
            if (2 * s.Length == Encoding.Default.GetByteCount(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
