using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSharp.Dribble.Exam70483.Encryption
{
    public class Asymetric
    {
        /// <summary>
        /// This should be generating the keys (private & public) as XML.
        /// The commented out code is .NET Framework
        /// </summary>
        public static void A()
        {
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            using (var rsa = RSA.Create())
            {
                //string publicKeyXML = rsa.ToXmlString(false);
                //string privateKeyXML = rsa.ToXmlString(true);

                Console.WriteLine(publicKeyXML);
                Console.WriteLine(privateKeyXML);
            }
        }
    }
}
