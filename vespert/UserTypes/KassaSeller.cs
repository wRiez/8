using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTypes
{
    public class KassaSeller
    {

        features features = new features();
        Storage storage_ = new Storage();

        public void seller_gen(ref int active, ref string act, ref int activity)
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

                    if (move > 5) { move = 0; }
                    else if (move < 0) { move = 5; }

                    switch (move)
                    {
                        case 0:
                            features.skip();
                            Console.WriteLine("->Просмотреть корзину   Просмотреть склад   Оформить заказ   Отменить заказ   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev_can"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть корзину   ->Просмотреть склад   Оформить заказ   Отменить заказ   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev_store"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть корзину   Просмотреть склад   ->Оформить заказ   Отменить заказ   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "accept"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть корзину   Просмотреть склад   Оформить заказ   ->Отменить заказ   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "deny"; }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть корзину   Просмотреть склад   Оформить заказ   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 5:
                            features.skip();
                            Console.WriteLine("Просмотреть корзину   Просмотреть склад   Оформить заказ   Выход с аккаунта   ->Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }

        }

        public void all_features(ref int active, ref string act, ref int activity, ref List<string> can, ref string can_inf, ref List<string> storage, ref string storage_inf, string order )
        {
            switch (act)
            {
                case "viev_can":
                    viev_can(can);
                    act = "0";
                    break;
                case "viev_store":
                    viev_stor(storage_inf);
                    act = "0";
                    break;
                case "accept":
                    accept(ref can, ref can_inf, ref storage, ref storage_inf, order);
                    act = "0";
                    break;
                case "deny":
                    deny(ref can, ref can_inf);
                    act = "0";
                    break;
                case "ex":
                    active = 0;
                    break;
            }
        }



        void viev_can(List<string> can)
        {
            features.skip();

            for (int i = 0; i < can.Count; i++)
            {
                if ((can[i] != "+") || (i != can.Count))
                {
                    if (i + 1 == can.Count) { break; }
                    Console.Write($"{can[i]}\t");
                }
                else { Console.WriteLine(" \n"); }
            }
        }

        void viev_stor(string store_inf)
        {
            features.skip();

            using (BinaryReader reader = new BinaryReader(File.Open(store_inf, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    if (name == "|")
                    {
                        Console.WriteLine(" \n");
                    }
                    else { Console.Write($"{name}\n"); }
                }
            }
        }

        void accept(ref List<string> can, ref string can_inf, ref List<string> storage, ref string sotrage_infm, string order)
        {
            features.skip();

            Console.WriteLine("Введите логин пользователя\n");

            string login = Console.ReadLine();
            int j = 0;

            features.skip();

            for (int i = 0; i < can.Count; i++)
            {
                if (can[i] == login)
                {

                    Console.WriteLine("Чек пользователя:\n");

                    Console.WriteLine(can[i]);
                    i += 1;

                    while ((can[i] != "+") || (i != can.Count))
                    {
                        if (i + 1 == can.Count) { break; }
                        if (can[i] != "|") { Console.Write($"{can[i]}\t"); }
                        else { Console.WriteLine($" \n"); }

                        i += 1;
                    }

                    if (File.Exists(order))
                    {
                        List<string> bufer = new List<string>();

                        using (BinaryReader reader = new BinaryReader(File.Open(order, FileMode.OpenOrCreate)))
                        {
                            string name = reader.ReadString();

                            bufer.Add(name);
                        }

                        while ((can[i] != "+") || (i != can.Count))
                        {
                            if (i + 1 == can.Count) { break; }
                            bufer.Add(bufer[i]);

                            i += 1;
                        }

                        using (BinaryWriter writer = new BinaryWriter(File.Open(order, FileMode.OpenOrCreate)))
                        {
                            for (int t = 0; t < bufer.Count; t++)
                            {
                                writer.Write(bufer[t]);
                            }
                        }

                    break;

                    }

                    else
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(order, FileMode.OpenOrCreate)))
                        {
                            for (int k = 0; k < can.Count; k++)
                            {
                                if (can[k] == login)
                                {
                                    while ((can[k] != "+") || (k != can.Count))
                                    {
                                        if (k + 1 == can.Count) { break; }
                                        writer.Write(can[k]);

                                        k += 1;
                                    }
                                }
                            }

                        }

                    break;
                    }

                }

            }


            for (int i = 0; i < can.Count; i++)
            {
                if (can[i] == login)
                {
                    while ((can[i] != "+") || (i != can.Count))
                    {
                        if (i + 1 == can.Count) { break; }
                        can.Remove(can[i]);
                    }
                    if (can[i - 1] == "+") { can.Remove(can[i]); }

                    break;
                }
            }

            File.Delete(can_inf);

            using (BinaryWriter writer = new BinaryWriter(File.Open(can_inf, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < can.Count; i++) { writer.Write(can[i]); }
            }

            storage_.check_st_count(order, sotrage_infm, ref storage);

            Console.WriteLine("\n\nЗаказ оформлен\n");

        }

        void deny(ref List<string> can, ref string can_inf)
        {
            features.skip();

            Console.WriteLine("Введите логин пользователя\n");

            string login = Console.ReadLine();
            int j = 0;

            for (int i = 0; i < can.Count; i++)
            {
                if (can[i] == login)
                {
                    while ((can[i] != "+") || (i != can.Count))
                    {
                        if (i + 1 == can.Count) { break; }
                        can.Remove(can[i]);

                    }
                    if (can[i - 1] == "+") { can.Remove(can[i]); }

                    break;
                }
            }

            File.Delete(can_inf);

            using (BinaryWriter writer = new BinaryWriter(File.Open(can_inf, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < can.Count; i++) { writer.Write(can[i]); }
            }

            Console.WriteLine("\nЗаказ отменён\n");
        }

    }
}
