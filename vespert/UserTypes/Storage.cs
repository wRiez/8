using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTypes
{
    public class Storage
    {

        features features = new features();

        public void storage_gen(ref int active, ref string act, ref int activity)
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
                            Console.WriteLine("->Просмотреть   Добавить товар   Удалить товар   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть   ->Добавить товар   Удалить товар   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "add"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить товар   ->Удалить товар   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "del"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить товар   Удалить товар   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть   Добавить товар   Удалить товар   Выход с аккаунта   ->Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }

        }


        public void all_features(ref int active, ref string act, ref int activity, ref List<string> store, string store_inf)
        {
            switch (act)
            {
                case "viev":
                    viev(ref store, store_inf);
                    act = "0";
                    break;
                case "add":
                    add(ref store, store_inf);
                    act = "0";
                    break;
                case "del":
                    del(ref store, store_inf);
                    act = "0";
                    break;
            }
        }


        void viev(ref List<string> store, string store_ing)
        {
            for (int i = 0; i < store.Count; i++)
            {
                if (store[i] == "|")
                {
                    Console.WriteLine(" \n");
                }
                else { Console.WriteLine(store[i]); }
            }
        }

        void add(ref List<string> store, string store_inf)
        {
            features.skip();

            Console.WriteLine("\nВведите название товара, его стоимость и количество\n");

            for (int i = 0; i < 4; i++)
            {
                string objects = Console.ReadLine();

                store.Add(objects);
            }

            store.Add("|");

            Console.WriteLine("\nDone\n");

            upd_store(ref store, store_inf);
            
        }

        void del(ref List<string> store, string store_inf)
        {

        }

        public void upd_store(ref List<string> store, string store_inf)
        {
            if (File.Exists(store_inf))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(store_inf, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        store.Add(name);
                    }
                }

                File.Delete(store_inf);

                using (BinaryWriter writer = new BinaryWriter(File.Open(store_inf, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < store.Count; i++)
                    {
                        writer.Write(store[i]);
                    }
                }

                Console.WriteLine("\nDone store\n");
            }

            else
            {
                File.Create(store_inf);
            }
        }

    }
}
