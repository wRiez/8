using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserTypes
{
    public class Frames
    {

        features features = new features();

        public void frame_gen(ref int active, ref string act, ref int activity)
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
                            Console.WriteLine("->Просмотреть   Изменить данные   Удалить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть   ->Изменить данные   Удалить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "change"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   ->Удалить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "del"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   Выход с аккаунта   ->Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }

        }


        public void all_features(ref int active, ref string act, ref int activity, ref string storage_a, ref string storage_inf, ref string seller_a, ref string seller_inf, ref string bux_a, ref string bux_inf)
        {
            switch (act)
            {
                case "viev":
                    viev(storage_inf, seller_inf, bux_inf);
                    act = "0";
                    break;
                case "change":
                    change(storage_inf, seller_inf, bux_inf);
                    act = "0";
                    break;
                case "del":
                    del(ref storage_a, ref storage_inf, ref seller_a, ref seller_inf, ref bux_a, ref bux_inf);
                    act = "0";
                    break;
            }
        }


        void viev(string storage, string seller, string bux)
        {
            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(storage, FileMode.Open)))
                            {
                                string sk1 = reader.ReadString();
                                string sk2 = reader.ReadString();

                                while (reader.PeekChar() > -1)
                                {
                                    string name = reader.ReadString();

                                    if (name == "|")
                                    {
                                        sk1 = reader.ReadString();
                                        sk2 = reader.ReadString();
                                    }

                                    bufer.Add(name);
                                }
                            }

                            for (int i = 0; i < bufer.Count; i++)
                            {
                                if (bufer[i] == "|")
                                {
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }


                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(bux, FileMode.Open)))
                            {
                                string sk1 = reader.ReadString();
                                string sk2 = reader.ReadString();

                                while (reader.PeekChar() > -1)
                                {
                                    string name = reader.ReadString();

                                    if (name == "|")
                                    {
                                        sk1 = reader.ReadString();
                                        sk2 = reader.ReadString();
                                    }

                                    bufer.Add(name);
                                }
                            }

                            for (int i = 0; i < bufer.Count; i++)
                            {
                                if (bufer[i] == "|")
                                {
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(seller, FileMode.Open)))
                            {
                                string sk1 = reader.ReadString();
                                string sk2 = reader.ReadString();

                                while (reader.PeekChar() > -1)
                                {
                                    string name = reader.ReadString();

                                    if (name == "|")
                                    {
                                        sk1 = reader.ReadString();
                                        sk2 = reader.ReadString();
                                    }

                                    bufer.Add(name);
                                }
                            }

                            for (int i = 0; i < bufer.Count; i++)
                            {
                                if (bufer[i] == "|")
                                {
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }
                        }
                        break;
                }
            }
        }

        void change(string storage, string seller, string bux)
        {
            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                }
            }
        }

        void del(ref string storage_a, ref string storage, ref string seller_a, ref string seller, ref string bux_a, ref string bux)
        {
            int move = 0;

            List<string> bufer = new List<string>();
            List<string> bufer_a = new List<string>();

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nКого уволить? (ФИО)\n");

                            string FIO_name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(storage, FileMode.Open)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string login = reader.ReadString();
                                    string pass = reader.ReadString();
                                    string FIO = reader.ReadString();
                                    //string age = reader.ReadString();
                                    //string educatiom = reader.ReadString();
                                    //string work_year = reader.ReadString();
                                    //string doljnost = reader.ReadString();
                                    //string where_work = reader.ReadString();
                                    //string zp = reader.ReadString();


                                    if (FIO == FIO_name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(storage_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();
                                                }
                                                else
                                                {
                                                    bufer_a.Add(name_a);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        bufer.Add(login);
                                        bufer.Add(pass);
                                        bufer.Add(FIO);
                                    }
                                }

                            }

                            File.Delete(storage);
                            File.Delete(storage_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(storage, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(storage_a, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer_a.Count; i++)
                                {
                                    writer.Write(bufer_a[i]);
                                }
                            }

                            Console.WriteLine("\nDone\n");

                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nКого уволить? (ФИО)\n");

                            string FIO_name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(bux, FileMode.Open)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string login = reader.ReadString();
                                    string pass = reader.ReadString();
                                    string FIO = reader.ReadString();
                                    //string age = reader.ReadString();
                                    //string educatiom = reader.ReadString();
                                    //string work_year = reader.ReadString();
                                    //string doljnost = reader.ReadString();
                                    //string where_work = reader.ReadString();
                                    //string zp = reader.ReadString();


                                    if (FIO == FIO_name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        //string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(bux_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();
                                                }
                                                else
                                                {
                                                    bufer_a.Add(name_a);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        bufer.Add(login);
                                        bufer.Add(pass);
                                        bufer.Add(FIO);
                                    }
                                }

                            }

                            File.Delete(bux);
                            File.Delete(bux_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(bux, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(bux_a, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer_a.Count; i++)
                                {
                                    writer.Write(bufer_a[i]);
                                }
                            }

                            Console.WriteLine("\nDone\n");
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nКого уволить? (ФИО)\n");

                            string FIO_name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(seller, FileMode.Open)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string login = reader.ReadString();
                                    string pass = reader.ReadString();
                                    string FIO = reader.ReadString();
                                    //string age = reader.ReadString();
                                    //string educatiom = reader.ReadString();
                                    //string work_year = reader.ReadString();
                                    //string doljnost = reader.ReadString();
                                    //string where_work = reader.ReadString();
                                    //string zp = reader.ReadString();


                                    if (FIO == FIO_name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(seller_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();
                                                }
                                                else
                                                {
                                                    bufer_a.Add(name_a);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        bufer.Add(login);
                                        bufer.Add(pass);
                                        bufer.Add(FIO);
                                    }
                                }

                            }

                            File.Delete(seller);
                            File.Delete(seller_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(seller, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(seller_a, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer_a.Count; i++)
                                {
                                    writer.Write(bufer_a[i]);
                                }
                            }

                            Console.WriteLine("\nDone\n");
                        }
                        break;
                }
            }
        }


    }
}
