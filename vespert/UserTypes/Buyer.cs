using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTypes
{
    public class Buyer
    {

        features features = new features();

        public void register(ref string usr_a, ref string usr_inf, ref int activ)
        {
            features.skip();

            Console.WriteLine("\nВведите вам email, логин и пароль:\n");

            string email = Console.ReadLine();
            string login = Console.ReadLine();
            string password = Console.ReadLine();
            features.pas_check(ref password);

            using (BinaryWriter writer = new BinaryWriter(File.Open(usr_a, FileMode.OpenOrCreate)))
            {
                writer.Write(login);
                writer.Write(password);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(usr_inf, FileMode.OpenOrCreate)))
            {
                writer.Write(login);
                writer.Write(password);
                writer.Write(email);
            }

            features.skip();
            activ = 0;

            Console.WriteLine("\nDone\n");

            Console.ReadKey();
        }

    }
}
