using System;
using System.IO;

namespace UserTypes
{
    public class Admin
    {
        features features = new features();
        //DateTime datetime = new DateTime();

        public void admin_gen(ref int active, ref string act, ref int activity)
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
                            Console.WriteLine("->Просмотреть   Изменить данные   Удалить данные   Добавить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть   ->Изменить данные   Удалить данные   Добавить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "change"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   ->Удалить данные   Добавить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "del"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   ->Добавить данные   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "add"; }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   Добавить данные   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 5:
                            features.skip();
                            Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   Добавить данные   Выход с аккаунта   ->Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }
            
        }

        public void all_features(ref int active, ref string act, ref int activity, ref string frames_a, ref string frames_inf, ref string storage_a, ref string storage_inf, ref string seller_a, ref string seller_inf, ref string bux_a, ref string bux_inf, string user_inf)
        {
            switch (act)
            {
                case "viev":
                    viev_workers(frames_inf, storage_inf, seller_inf, bux_inf, user_inf);
                    act = "0";
                    break;
                case "change":
                    change_workers(frames_a, frames_inf, storage_a, storage_inf, seller_a, seller_inf, bux_a, bux_inf);
                    act = "0";
                    break;
                case "del":
                    delete_workers(frames_a, frames_inf, storage_a, storage_inf, seller_a, seller_inf, bux_a, bux_inf);
                    act = "0";
                    break;
                case "add":
                    add_workers(ref frames_a, ref frames_inf, ref storage_a, ref storage_inf, ref seller_a, ref seller_inf, ref bux_a, ref bux_inf);
                    act = "0";
                    break;
            }
        }
        void viev_workers(string frames_inf, string storage_inf, string seller_inf, string bux_inf, string user_inf)
        {
            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 3) { move = 0; }
                else if (move < 0) { move = 3; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Кадры   Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(frames_inf, FileMode.Open)))
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
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Кадры   ->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(storage_inf, FileMode.Open)))
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
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }


                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(bux_inf, FileMode.Open)))
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
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }
                        }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            List<string> bufer = new List<string>();

                            using (BinaryReader reader = new BinaryReader(File.Open(seller_inf, FileMode.Open)))
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
                                    Console.WriteLine(" \n");
                                }
                                else { Console.Write($"{bufer[i]}\t"); }
                            }
                        }
                        break;
                }
            }
        }

        void change_workers(string frames_a, string frames_inf, string storage_a, string storage_inf, string seller_a, string seller_inf, string bux_a, string bux_inf)
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

                if (move > 3) { move = 0; }
                else if (move < 0) { move = 3; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Кадры   Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {

                            features.skip();

                            Console.WriteLine("Введите фио кого хотите изменить");

                            string name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(frames_inf, FileMode.Open)))
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


                                    if (FIO == name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        //string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        Console.WriteLine("\nВведите: логин  пароль  ФИО  Дату рождения  Образование  Опыт работы  Должность\n");

                                        for (int i = 0; i < 7; i++) { bufer.Add(Console.ReadLine()); }

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(frames_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();

                                                    Console.WriteLine("\nВведите логин и пароль\n");

                                                    one_a = Console.ReadLine();
                                                    two_a = Console.ReadLine();

                                                    bufer_a.Add(one_a);
                                                    bufer_a.Add(two_a);
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

                            File.Delete(frames_inf);
                            File.Delete(frames_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(frames_inf, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(frames_a, FileMode.OpenOrCreate)))
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
                        Console.WriteLine("Кадры   ->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("Введите фио кого хотите изменить");

                            string name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(storage_inf, FileMode.Open)))
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


                                    if (FIO == name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        Console.WriteLine("\nВведите: логин  пароль  ФИО  Дату рождения  Образование  Опыт работы  Должность\n");

                                        for (int i = 0; i < 7; i++) { bufer.Add(Console.ReadLine()); }

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(storage_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();

                                                    Console.WriteLine("\nВведите логин и пароль\n");

                                                    one_a = Console.ReadLine();
                                                    two_a = Console.ReadLine();

                                                    bufer_a.Add(one_a);
                                                    bufer_a.Add(two_a);
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

                            File.Delete(storage_inf);
                            File.Delete(storage_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(storage_inf, FileMode.OpenOrCreate)))
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
                    case 2:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("Введите фио кого хотите изменить");

                            string name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(bux_inf, FileMode.Open)))
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


                                    if (FIO == name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        //string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        Console.WriteLine("\nВведите: логин  пароль  ФИО  Дату рождения  Образование  Опыт работы  Должность\n");

                                        for (int i = 0; i < 7; i++) { bufer.Add(Console.ReadLine()); }

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(bux_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();

                                                    Console.WriteLine("\nВведите логин и пароль\n");

                                                    one_a = Console.ReadLine();
                                                    two_a = Console.ReadLine();

                                                    bufer_a.Add(one_a);
                                                    bufer_a.Add(two_a);
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

                            File.Delete(bux_inf);
                            File.Delete(bux_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(bux_inf, FileMode.OpenOrCreate)))
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
                    case 3:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("Введите фио кого хотите изменить");

                            string name = Console.ReadLine();

                            using (BinaryReader reader = new BinaryReader(File.Open(seller_inf, FileMode.Open)))
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


                                    if (FIO == name)
                                    {
                                        string age = reader.ReadString();
                                        string educatiom = reader.ReadString();
                                        string work_year = reader.ReadString();
                                        string doljnost = reader.ReadString();
                                        string where_work = reader.ReadString();
                                        string zp = reader.ReadString();
                                        string up = reader.ReadString();

                                        Console.WriteLine("\nВведите: логин  пароль  ФИО  Дату рождения  Образование  Опыт работы  Должность\n");

                                        for (int i = 0; i < 7; i++) { bufer.Add(Console.ReadLine()); }

                                        using (BinaryReader reader_a = new BinaryReader(File.Open(seller_a, FileMode.Open)))
                                        {
                                            while (reader_a.PeekChar() > -1)
                                            {
                                                string name_a = reader_a.ReadString();

                                                if (name_a == login)
                                                {
                                                    string one_a = reader_a.ReadString();
                                                    string two_a = reader_a.ReadString();

                                                    Console.WriteLine("\nВведите логин и пароль\n");

                                                    one_a = Console.ReadLine();
                                                    two_a = Console.ReadLine();

                                                    bufer_a.Add(one_a);
                                                    bufer_a.Add(two_a);
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

                            File.Delete(seller_inf);
                            File.Delete(seller_a);

                            using (BinaryWriter writer = new BinaryWriter(File.Open(seller_inf, FileMode.OpenOrCreate)))
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

        void delete_workers(string frames_a, string frames_inf, string storage_a, string storage_inf, string seller_a, string seller_inf, string bux_a, string bux_inf)
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

                if (move > 3) { move = 0; }
                else if (move < 0) { move = 3; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Кадры   Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nУдалить всё?\n");

                            int move_in = 0;

                            ConsoleKeyInfo start_in = Console.ReadKey();
                            while (start_in.Key != ConsoleKey.Enter)
                            {
                                start_in = Console.ReadKey();

                                if (start_in.Key == ConsoleKey.RightArrow) { move_in += 1; }
                                else if (start_in.Key == ConsoleKey.LeftArrow) { move_in -= 1; }

                                if (move_in > 1) { move_in = 0; }
                                else if (move_in < 0) { move_in = 1; }

                                switch (move_in)
                                {
                                    case 0:
                                        features.skip();

                                        Console.WriteLine("->Да   Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            File.Delete(frames_a);
                                            File.Delete(frames_inf);

                                            Console.WriteLine("\nDone\n");
                                        }

                                        break;
                                    case 1:
                                        features.skip();

                                        Console.WriteLine("Да   ->Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            features.skip();

                                            Console.WriteLine("Введите фио кого хотите удалить");

                                            string name = Console.ReadLine();

                                            using (BinaryReader reader = new BinaryReader(File.Open(frames_inf, FileMode.Open)))
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


                                                    if (FIO == name)
                                                    {
                                                        string age = reader.ReadString();
                                                        string educatiom = reader.ReadString();
                                                        string work_year = reader.ReadString();
                                                        string doljnost = reader.ReadString();
                                                        //string where_work = reader.ReadString();
                                                        string zp = reader.ReadString();
                                                        string up = reader.ReadString();

                                                        using (BinaryReader reader_a = new BinaryReader(File.Open(frames_a, FileMode.Open)))
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

                                            File.Delete(frames_inf);
                                            File.Delete(frames_a);

                                            using (BinaryWriter writer = new BinaryWriter(File.Open(frames_inf, FileMode.OpenOrCreate)))
                                            {
                                                for (int i = 0; i < bufer.Count; i++)
                                                {
                                                    writer.Write(bufer[i]);
                                                }
                                            }

                                            using (BinaryWriter writer = new BinaryWriter(File.Open(frames_a, FileMode.OpenOrCreate)))
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
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Кадры   ->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nУдалить всё?\n");

                            int move_in = 0;

                            ConsoleKeyInfo start_in = Console.ReadKey();
                            while (start_in.Key != ConsoleKey.Enter)
                            {
                                start_in = Console.ReadKey();

                                if (start_in.Key == ConsoleKey.RightArrow) { move_in += 1; }
                                else if (start_in.Key == ConsoleKey.LeftArrow) { move_in -= 1; }

                                if (move_in > 1) { move_in = 0; }
                                else if (move_in < 0) { move_in = 1; }

                                switch (move_in)
                                {
                                    case 0:
                                        features.skip();

                                        Console.WriteLine("->Да   Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            File.Delete(storage_a);
                                            File.Delete(storage_inf);

                                            Console.WriteLine("\nDone\n");
                                        }

                                        break;
                                    case 1:
                                        features.skip();

                                        Console.WriteLine("Да   ->Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            features.skip();

                                            Console.WriteLine("Введите фио кого хотите удалить");

                                            string name = Console.ReadLine();

                                            using (BinaryReader reader = new BinaryReader(File.Open(storage_inf, FileMode.Open)))
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


                                                    if (FIO == name)
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

                                            File.Delete(storage_inf);
                                            File.Delete(storage_a);

                                            using (BinaryWriter writer = new BinaryWriter(File.Open(storage_inf, FileMode.OpenOrCreate)))
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
                                }
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nУдалить всё?\n");

                            int move_in = 0;

                            ConsoleKeyInfo start_in = Console.ReadKey();
                            while (start_in.Key != ConsoleKey.Enter)
                            {
                                start_in = Console.ReadKey();

                                if (start_in.Key == ConsoleKey.RightArrow) { move_in += 1; }
                                else if (start_in.Key == ConsoleKey.LeftArrow) { move_in -= 1; }

                                if (move_in > 1) { move_in = 0; }
                                else if (move_in < 0) { move_in = 1; }

                                switch (move_in)
                                {
                                    case 0:
                                        features.skip();

                                        Console.WriteLine("->Да   Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            File.Delete(bux_a);
                                            File.Delete(bux_inf);

                                            Console.WriteLine("\nDone\n");
                                        }

                                        break;
                                    case 1:
                                        features.skip();

                                        Console.WriteLine("Да   ->Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            features.skip();

                                            Console.WriteLine("Введите фио кого хотите удалить");

                                            string name = Console.ReadLine();

                                            using (BinaryReader reader = new BinaryReader(File.Open(bux_inf, FileMode.Open)))
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


                                                    if (FIO == name)
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

                                            File.Delete(bux_inf);
                                            File.Delete(bux_a);

                                            using (BinaryWriter writer = new BinaryWriter(File.Open(bux_inf, FileMode.OpenOrCreate)))
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
                                }
                            }
                        }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            Console.WriteLine("\nУдалить всё?\n");

                            int move_in = 0;

                            ConsoleKeyInfo start_in = Console.ReadKey();
                            while (start_in.Key != ConsoleKey.Enter)
                            {
                                start_in = Console.ReadKey();

                                if (start_in.Key == ConsoleKey.RightArrow) { move_in += 1; }
                                else if (start_in.Key == ConsoleKey.LeftArrow) { move_in -= 1; }

                                if (move_in > 1) { move_in = 0; }
                                else if (move_in < 0) { move_in = 1; }

                                switch (move_in)
                                {
                                    case 0:
                                        features.skip();

                                        Console.WriteLine("->Да   Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            File.Delete(seller_a);
                                            File.Delete(seller_inf);

                                            Console.WriteLine("\nDone\n");
                                        }

                                        break;
                                    case 1:
                                        features.skip();

                                        Console.WriteLine("Да   ->Нет");

                                        if (start_in.Key == ConsoleKey.Enter)
                                        {
                                            features.skip();

                                            Console.WriteLine("Введите фио кого хотите удалить");

                                            string name = Console.ReadLine();

                                            using (BinaryReader reader = new BinaryReader(File.Open(seller_inf, FileMode.Open)))
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


                                                    if (FIO == name)
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

                                            File.Delete(seller_inf);
                                            File.Delete(seller_a);

                                            using (BinaryWriter writer = new BinaryWriter(File.Open(seller_inf, FileMode.OpenOrCreate)))
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
                        break;
                }
            }
        }

        void add_workers(ref string frames_a, ref string frames_inf, ref string storage_a, ref string storage_inf, ref string seller_a, ref string seller_inf, ref string bux_a, ref string bux_inf)
        {
            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 3) { move = 0; }
                else if (move < 0) { move = 3; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Кадры   Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();
                            List<string> bufer = new List<string>();

                            Console.WriteLine("Введите: Логин  Пароль  ФИО  Дату_рождения  Образование  Опыт_работы и Должность для пользователя");

                            for (int i = 0; i < 7; i++)
                            {
                                string add = Console.ReadLine();

                                if (i == 1) { features.pas_check(ref add); }

                                bufer.Add(add);
                                if (i == 3)
                                {
                                    DateTime dat1 = new DateTime(int.Parse(bufer[3]));
                                    DateTime dat_n = DateTime.Today;

                                    string dat_r = dat_n.Subtract(dat1).ToString();

                                    bufer.Add($"{dat_r} лет");
                                }
                            }

                            features.zp(ref bufer);

                            bufer.Add("|");

                            features.path_upd(ref frames_a, ref frames_inf, bufer);

                            Console.WriteLine("\nDone\n");
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Кадры   ->Склад   Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();
                            List<string> bufer = new List<string>();

                            Console.WriteLine("Введите: Логин  Пароль  ФИО  Дату_рождения  Образование  Опыт_работы и Должность для пользователя");

                            for (int i = 0; i < 7; i++)
                            {
                                string add = Console.ReadLine();

                                if (i == 1) { features.pas_check(ref add); }

                                bufer.Add(add);
                                if (i == 3)
                                {
                                    DateTime dat1 = new DateTime(int.Parse(bufer[3]));
                                    DateTime dat_n = DateTime.Today;

                                    string dat_r = dat_n.Subtract(dat1).ToString();

                                    bufer.Add($"{dat_r} лет");
                                }
                                if (i == 6) { bufer.Add("Склад"); }
                            }

                            features.zp(ref bufer);

                            bufer.Add("|");

                            features.path_upd(ref storage_a, ref storage_inf, bufer);

                            Console.WriteLine("\nDone\n");

                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   ->Бухгалтеры   Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();
                            List<string> bufer = new List<string>();

                            Console.WriteLine("Введите: Логин  Пароль  ФИО  Дату_рождения  Образование  Опыт_работы и Должность для пользователя");

                            for (int i = 0; i < 7; i++)
                            {
                                string add = Console.ReadLine();

                                if (i == 1) { features.pas_check(ref add); }

                                bufer.Add(add);
                                if (i == 3)
                                {
                                    DateTime dat1 = new DateTime(int.Parse(bufer[3]));
                                    DateTime dat_n = DateTime.Today;

                                    string dat_r = dat_n.Subtract(dat1).ToString();

                                    bufer.Add($"{dat_r} лет");
                                }
                            }

                            features.zp(ref bufer);

                            bufer.Add("|");

                            features.path_upd(ref bux_a, ref bux_inf, bufer);

                            Console.WriteLine("\nDone\n");
                        }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Кадры   Склад   Бухгалтеры   ->Продавцы");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();
                            List<string> bufer = new List<string>();

                            Console.WriteLine("Введите: Логин  Пароль  ФИО  Дату_рождения  Образование  Опыт_работы и Должность для пользователя");

                            for (int i = 0; i < 7; i++)
                            {
                                string add = Console.ReadLine();

                                if (i == 1) { features.pas_check(ref add); }

                                bufer.Add(add);
                                if (i == 3)
                                {
                                    DateTime dat1 = new DateTime(int.Parse(bufer[3]));
                                    DateTime dat_n = DateTime.Today;

                                    string dat_r = dat_n.Subtract(dat1).ToString();

                                    bufer.Add($"{dat_r} лет");
                                }
                                if (i == 6) { bufer.Add("Касса"); }
                            }

                            features.zp(ref bufer);

                            bufer.Add("|");

                            features.path_upd(ref seller_a, ref seller_inf, bufer);

                            Console.WriteLine("\nDone\n");
                        }
                        break;
                }

                
            }
        }
    }
}
