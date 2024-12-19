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

                    if (move > 4) { move = 0; }
                    else if (move < 0) { move = 4; }

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
                case "ex":
                    active = 0;
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
                else { Console.Write($"{store[i]}\t"); }
            }
        }

        void add(ref List<string> store, string store_inf)
        {
            features.skip();

            Console.WriteLine("\nВведите название товара, его стоимость и количество\n");

            for (int i = 0; i < 3; i++)
            {
                string objects = Console.ReadLine();

                store.Add(objects);
            }

            store.Add("|");

            Console.WriteLine("\nDone\n");

            if (File.Exists(store_inf)) { File.Delete(store_inf); }

            using (BinaryWriter writer = new BinaryWriter(File.Open(store_inf, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < store.Count; i++)
                {
                    writer.Write(store[i]);
                }
            }

            //upd_store(ref store, store_inf);

        }

        void del(ref List<string> store, string store_inf)
        {
            features.skip();

            List<string> bufer = new List<string>();
            Console.WriteLine("Введите что хотите удалить\n");
            string del_item = Console.ReadLine();

            using (BinaryReader reader = new BinaryReader(File.Open(store_inf, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    if (name == del_item)
                    {
                        string sk1 = reader.ReadString();
                        string sk2 = reader.ReadString();

                    }
                    else { bufer.Add(name); }
                }
            }

            for (int i = 0; i < store.Count; i++) { store.Remove(store[i]); }
            for (int i = 0; i < bufer.Count; i++) { store.Add(bufer[i]); }

            File.Delete(store_inf);

            using (BinaryWriter writer = new BinaryWriter(File.Open(store_inf, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++) { writer.Write(bufer[i]); }
            }

            //for (int i = 0; i < store.Count; i++) { store.Remove(store[i]); }

            Console.WriteLine("\nDone\n");

            upd_store(ref store, store_inf);
        }

        public void upd_store(ref List<string> store, string store_inf)
        {
            List<string> bufer = new List<string>();

            if (File.Exists(store_inf))
            {

                using (BinaryReader reader = new BinaryReader(File.Open(store_inf, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        bufer.Add(name);
                    }
                }

                File.Delete(store_inf);

                for (int i = 0; i < store.Count; i++) { store.Remove(store[i]); }
                for (int i = 0; i < bufer.Count; i++) { store.Add(bufer[i]); }

                using (BinaryWriter writer = new BinaryWriter(File.Open(store_inf, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < bufer.Count; i++)
                    {
                        writer.Write(bufer[i]);
                    }
                }

                Console.WriteLine("\nDone store\n");
            }

            else
            {
                File.Create(store_inf);
            }
        }



        public void check_st_count(string orders, string store_inf, ref List<string> store)
        {
            List<string> bufer = new List<string>();
            List<string> change = new List<string>();

            using (BinaryReader reader = new BinaryReader(File.Open(orders, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    bufer.Add(name);
                }
            }

            for (int i = 0; i < bufer.Count; i++)
            {
                if (bufer[i] == "|")
                {
                    for (int j = 0; j < store.Count; j++)
                    {
                        if (store[j] == bufer[i - 3])
                        {
                            int st_c = int.Parse(store[j - 1]);
                            int ord_c = int.Parse(bufer[i - 1]);

                            int new_c = st_c - ord_c;

                            store[j - 1].Replace(store[j - 1], new_c.ToString());
                        }
                    }
                }
            }

        }

    }
}
