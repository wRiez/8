using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace UserTypes
{
    public class Buyer
    {

        features features = new features();

        public void user_gen(ref int active, ref string act, ref int activity)
        {
            int move = 0;

            if (act == "0")
            {
                ConsoleKeyInfo start = Console.ReadKey();
                while (start.Key != ConsoleKey.Enter)
                {
                    start = Console.ReadKey();

                    if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                    else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                    if (move > 4) { move = 0; }
                    else if (move < 0) { move = 4; }

                    switch (move)
                    {
                        case 0:
                            features.skip();
                            Console.WriteLine("->Просмотреть   Добавить в корзину   Удалить из корзины   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть   ->Добавить в корзину   Удалить из корзины   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "add"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить в корзину   ->Удалить из корзины   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "del"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить в корзину   Удалить из корзины   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить в корзину   Удалить из корзины   Выход с аккаунта   ->Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }
        }


        public void all_features(ref int active, ref string act, ref int activity, List<string> store, ref List<string> can, string user_inf, string login, ref string usr_can)
        {
            switch (act)
            {
                case "viev":
                    viev(store, ref can, user_inf, login);
                    act = "0";
                    break;
                case "add":
                    add(store, ref can, user_inf, ref usr_can, login);
                    act = "0";
                    break;
                case "del":
                    del(store, ref can, user_inf, ref usr_can, login);
                    act = "0";
                    break;
                case "ex":
                    active = 0;
                    break;
            }
        }


        void viev(List<string> store, ref List<string> can, string user_inf, string login)
        {
            features.skip();
            int move = 0;

            Console.WriteLine("\nЧто просмотреть?\n");

                ConsoleKeyInfo start = Console.ReadKey();
                while (start.Key != ConsoleKey.Enter)
                {
                    start = Console.ReadKey();

                    if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                    else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                    if (move > 1) { move = 0; }
                    else if (move < 0) { move = 1; }

                    switch (move)
                    {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Товары   Корзину\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            for (int i = 0; i < store.Count; i++)
                            {
                                if (store[i] == "|")
                                {
                                    Console.WriteLine(" \n");
                                }
                                else 
                                {
                                    if (store[i + 1] == "|") 
                                    {
                                        i += 1;
                                    }
                                    Console.Write($"{store[i]}\t");
                                }
                            }
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Товары   ->Корзину\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            for (int i = 1; i < can.Count; i++)
                            {
                                if (can[i] == login)
                                {
                                    int j = 0;
                                    while ((can[i] != "+") || (i != can.Count))
                                    {
                                        if (i + 1 == can.Count) { break; }
                                        if (i == 1) { j += 0; }
                                        else 
                                        { 
                                            if (j % 5 == 0) { Console.WriteLine(" \n"); }
                                            Console.Write($"{can[i]}\t"); 
                                        }

                                        j += 1;
                                        i += 1;
                                    }
                                    break;
                                }
                                
                            }
                        }
                        break;
                    }
                }
        }

        void add(List<string> store, ref List<string> can, string user_inf, ref string user_can, string login)
        {
            features.skip();

            Console.WriteLine("\nЧто хотите добавить в корзину и сколько?\n");

            string name = Console.ReadLine();
            string score = Console.ReadLine();

            using (BinaryWriter writer = new BinaryWriter(File.Open(user_can, FileMode.Open)))
            {
                //writer.Write(login);
                for (int i = 0; i < store.Count; i++)
                {
                    if (store[i] == name)
                    {
                        int cost_p_one = int.Parse(store[i + 1]);
                        int cost_p_all = int.Parse(score) * cost_p_one;
                        string cost = cost_p_all.ToString();

                        //writer.Write(store[i]);
                        ////writer.Write(store[i + 1]);
                        //writer.Write(score);
                        //writer.Write(cost);

                        if (can.Count == 0)
                        {
                            can.Add("+");
                            can.Add(login);
                            can.Add(store[i]);
                            //can.Add(store[i + 1]);
                            can.Add(score);
                            can.Add(cost);
                            can.Add("|");
                        }
                        else
                        {
                            int s = 0;
                            for (int j = 0; j < can.Count; j++)
                            {
                                if (can[j] == login)
                                {
                                    can.Add(store[i]);
                                    //can.Add(store[i + 1]);
                                    can.Add(score);
                                    can.Add(cost);
                                    can.Add("|");
                                    s = 1;
                                    break;
                                }
                            }
                            if (s != 1)
                            {
                                can.Add("+");
                                can.Add(login);
                                can.Add(store[i]);
                                //can.Add(store[i + 1]);
                                can.Add(score);
                                can.Add(cost);
                                can.Add("|");
                                break;
                            }
                        }
                        
                        break;
                    }
                    
                }
                //writer.Write("|");

            }

            File.Delete(user_can);

            using (BinaryWriter writer = new BinaryWriter(File.Open(user_can, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < can.Count; i++)
                {
                    writer.Write(can[i]);
                }
            }

            Console.WriteLine("\nDone\n");

        }

        void del(List<string> store, ref List<string> can, string user_inf, ref string user_can, string login)
        {
            features.skip();

            Console.WriteLine("Что хотите убрать?\n");

            string name = Console.ReadLine();

            //using (BinaryReader reader = new BinaryReader(File.Open(, FileMode.Open)))
            //{

            //}

            for (int i = 0; i < can.Count; i++)
            {
                if (can[i] == login)
                {
                    while ((can[i] != "+") || (i != can.Count))
                    {
                        if (can[i] == name)
                        {
                            can.Remove(can[i]);
                            can.Remove(can[i]);
                            can.Remove(can[i]);
                            break;
                        }

                        i += 1;
                    }
                    break;
                }
            }

            File.Delete(user_can);

            using (BinaryWriter writer = new BinaryWriter(File.Open(user_can, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < can.Count; i++)
                {
                    writer.Write(can[i]);
                }


            }

            Console.WriteLine("\nDone\n");
        }


        public void can_upd(ref List<string> can_inf, string usr_can)
        {
            if (can_inf.Count != 0)
            {
                while (can_inf.Count != 1) { can_inf.Remove(can_inf[0]); }
                can_inf.Remove(can_inf[0]);
            }

            using (BinaryReader reader = new BinaryReader(File.Open(usr_can, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    can_inf.Add(reader.ReadString());
                }
            }
        }

        public void register(ref string usr_a, ref string usr_inf, ref int activ)
        {
            features.skip();

            Console.WriteLine("\nВведите вам email, логин и пароль:\n");

            string email = Console.ReadLine();
            string login = Console.ReadLine();
            string password = Console.ReadLine();
            features.pas_check(ref password);

            if (File.Exists(usr_a))
            {
                List<string> bufer = new List<string>();

                using (BinaryReader reader = new BinaryReader(File.Open(usr_a, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        bufer.Add(name);
                    }
                }

                bufer.Add(login);
                bufer.Add(password);
                //bufer.Add(email);

                File.Delete(usr_a);

                using (BinaryWriter writer = new BinaryWriter(File.Open(usr_a, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < bufer.Count; i++)
                    {
                        //if (i % 4 == 0) { i += 1; }
                        writer.Write(bufer[i]);
                    }
                }
            }

            else
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(usr_a, FileMode.OpenOrCreate)))
                {
                    writer.Write(login);
                    writer.Write(password);
                }
            }


            if (File.Exists(usr_inf))
            {
                List<string> bufer = new List<string>();

                using (BinaryReader reader = new BinaryReader(File.Open(usr_inf, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        bufer.Add(name);
                    }
                }

                bufer.Add(login);
                bufer.Add(password);
                bufer.Add(email);

                File.Delete(usr_inf);

                using (BinaryWriter writer = new BinaryWriter(File.Open(usr_inf, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < bufer.Count; i++)
                    {
                        //if (i % 4 == 0) { i += 1; }
                        writer.Write(bufer[i]);
                    }
                }

            }

            else
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(usr_inf, FileMode.OpenOrCreate)))
                {
                    writer.Write(login);
                    writer.Write(password);
                    writer.Write(email);
                }
            }

            features.skip();
            activ = 0;

            Console.WriteLine("\nDone\n");

            Console.ReadKey();
        }

    }
}
