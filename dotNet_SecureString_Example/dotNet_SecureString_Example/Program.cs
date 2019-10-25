using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace dotNet_SecureString_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            SecureString sstring = new SecureString();
            
            Console.WriteLine("Enter your password");

            ConsoleKeyInfo keyInfo;
            do
            {
                /*Read each character one by one and append into the securestring object*/
                keyInfo = Console.ReadKey(true);
                Console.Write("*");
                sstring.AppendChar(keyInfo.KeyChar);
                
            } while (!keyInfo.KeyChar.Equals('\r'));

            /*Retrieve the immutable string from securestring*/
            IntPtr ptr = Marshal.SecureStringToBSTR(sstring);
            String immutableString = Marshal.PtrToStringBSTR(ptr);
            Marshal.ZeroFreeBSTR(ptr); // clean up allocated BSTR pointer
            Console.WriteLine("\n\nYou entered: \n"+immutableString);

            //Clean up the secureString in memory
            sstring.Clear();
            Console.Read();

        }
    }
}
