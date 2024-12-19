using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTypes
{
    public class Buxgalter
    {

        features features = new features();

        public void bux_gen(ref int active, ref string act, ref int activity)
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
                            Console.WriteLine("->Просмотреть доход сотрудников   Просмотреть доход с покупок   Просмотреть общий бюджет   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev_work"; }
                            break;
                        case 1:
                            features.skip();
                            Console.WriteLine("Просмотреть доход сотрудников   ->Просмотреть доход с покупок   Просмотреть общий бюджет   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev_store"; }
                            break;
                        case 2:
                            features.skip();
                            Console.WriteLine("Просмотреть доход сотрудников   Просмотреть доход с покупок   ->Просмотреть общий бюджет   Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "viev_all"; }
                            break;
                        case 3:
                            features.skip();
                            Console.WriteLine("Просмотреть доход сотрудников   Просмотреть доход с покупок   Просмотреть общий бюджет   ->Выход с аккаунта   Выход с приложения");

                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; features.skip(); }
                            break;
                        case 4:
                            features.skip();
                            Console.WriteLine("Просмотреть доход сотрудников   Просмотреть доход с покупок   Просмотреть общий бюджет   Выход с аккаунта   ->Выход с приложения");


                            if (start.Key == ConsoleKey.Enter) { act = "ex"; active = 0; activity = 0; features.skip(); }
                            break;
                    }
                }
            }

        }


        public void all_features(ref int active, ref string act, ref int activity, List<string> workers,  ref List<string> storage, ref string storage_inf, string frame_inf, string storage_ing, string seller_inf, string bux_inf)
        {
            switch (act)
            {
                case "viev_work":
                    viev_work(frame_inf, storage_ing, seller_inf, bux_inf);
                    act = "0";
                    break;
                case "viev_store":
                    viev_stor();
                    act = "0";
                    break;
                case "viev_all":
                    viev_all();
                    act = "0";
                    break;
                case "ex":
                    active = 0;
                    break;
            }
        }



        void viev_work(string frame_inf, string storage_inf, string seller_ing, string bux_inf)
        {
            features.skip();

            List<string> bufer = new List<string>();
            List<string> zp = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                string path = "-";

                switch (i)
                {
                    case 0:
                        path = frame_inf;
                        break;
                    case 1:
                        path = storage_inf;
                        break;
                    case 2:
                        path = seller_ing;
                        break;
                    case 3:
                        path = bux_inf;
                        break;
                }

                for (int k = 0; k < bufer.Count; k++) { bufer.Remove(bufer[k]); }

                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        bufer.Add(name);
                    }

                    for (int j = 0; j < bufer.Count; j++)
                    {
                        if ((path == frame_inf) || (path == bux_inf))
                        {
                            if (j % 10 == 2)
                            {
                                zp.Add(bufer[j]);
                            }

                            if (j % 10 == 8)
                            {
                                zp.Add(bufer[j]);
                            }
                        }
                        else
                        {
                            if (j % (bufer.Count - 8) == 0)
                            {
                                zp.Add(bufer[j]);
                            }

                            if ((j % bufer.Count - 1) == 0)
                            {
                                zp.Add(bufer[j]);
                            }
                        }
                    }

                    zp.Add("|");
                }
            }

            for (int i = 0; i < zp.Count; i++)
            {
                if (zp[i] == "|") { Console.WriteLine(" \n"); }
                else { Console.Write($"{zp[i]}\t"); }
            }
        }

        void viev_stor(string orders)
        {
            features.skip();

            int move = 0;

            Console.WriteLine("\nЗа какое время просмотреть?\n");

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
                        Console.WriteLine("->За день   За месяц   За год");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            if (File.Exists(orders))
                            {

                            }
                            else
                            {
                                Console.WriteLine("\nЗа последнее время покупок не совершалось\n");
                            }
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("За день   ->За месяц   За год");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("За день   За месяц   ->За год");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                }
            }
        }

        void viev_all()
        {
            features.skip();

            int money = 5000000;

            Console.WriteLine($"Общий бюджет копмании: {money}");
    
        }

        public void zp(ref List<string> bufer)
        {
            string who = bufer[bufer.Count - 1];

            string work = bufer[bufer.Count - 2];
            string[] work_who = work.Split(new char[] { ' ' });

            foreach (string s in work_who)
            {
                switch (who)
                {
                    case "Кадры":
                        bufer.Add("Зарплата: 25000");
                        break;
                    case "Склад":
                        switch (s)
                        {
                            case "Менеджер":
                                bufer.Add("Зарплата: 15000");
                                break;
                            case "Работник":
                                bufer.Add("Зарплата: 7500");
                                break;
                        }
                        break;
                    case "Касса":
                        switch (s)
                        {
                            case "Менеджер":
                                bufer.Add("Зарплата: 12000");
                                break;
                            case "Работник":
                                bufer.Add("Зарплата: 5500");
                                break;
                        }
                        break;
                    case "Бухгалтер":
                        bufer.Add("Зарплата: 45000");
                        break;
                }
                break;
            }
        }
    }
}
