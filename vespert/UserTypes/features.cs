using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserTypes
{
    public class features
    {
        public void skip() { Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); }

        void check_files(string admin_a, string frame_a, string storage_a, string seller_a, string bux_a, string user_a)
        {
            string path = "0";

            for (int i = 0; i < 6; i++)
            {

                switch (i)
                {
                    case 0:
                        if (File.Exists(admin_a)) { path = admin_a; } else { File.Create(admin_a); }
                        break;
                    case 1:
                        if (File.Exists(frame_a)) { path = frame_a; } else { File.Create(frame_a); }
                        break;
                    case 2:
                        if (File.Exists(storage_a)) { path = storage_a; } else { File.Create(storage_a); }
                        break;
                    case 3:
                        if (File.Exists(seller_a)) { path = seller_a; } else { File.Create(seller_a); }
                        break;
                    case 4:
                        if (File.Exists(bux_a)) { path = bux_a; } else { File.Create(bux_a); }
                        break;
                    case 5:
                        if (File.Exists(user_a)) { path = user_a; } else { File.Create(user_a); }
                        break;
                }
            }
        }

        public void auth_collection(string admin_a, string frame_a, string storage_a, string seller_a, string bux_a, string user_a, string Login, string Password, ref int active, ref List<string> workers)
        {
            check_files(admin_a, frame_a, storage_a, seller_a, bux_a, user_a);

            //List<string> auth_all = new List<string>();
            string path = "0";
            string path_l = admin_a;

            for (int i = 0; i < 6;  i++)
            {

                switch (i)
                {
                    case 0:
                        path = admin_a;
                        break;
                    case 1:
                        path = frame_a;
                        break;
                    case 2:
                        path = storage_a;
                        break;
                    case 3:
                        path = seller_a;
                        break;
                    case 4:
                        path = bux_a;
                        break;
                    case 5:
                        path = user_a;
                        break;
                }

                //using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate))) { writer.Write("admin"); writer.Write("admin123"); }

                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    //Console.WriteLine(reader.PeekChar());

                    if (reader.PeekChar() != -1)
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string name = reader.ReadString();

                            if (path != path_l) { workers.Add("|"); }

                            workers.Add(name);

                            path_l = path;

                            //if (reader.PeekChar() == -1) { auth_all.Add("|"); }
                        }

                       
                    }
                    else
                    {
                        workers.Add("|");
                        Console.WriteLine("\nДанных не существует\n");
                        //break;
                    }
                }

                //Console.WriteLine(123);
            }


            authorixation(Login, Password, workers, ref active);
            
        }
        void authorixation(string Login, string Password, List<string> auth_all, ref int active)
        {
            for (int i = 0; i < auth_all.Count; i++)
            {
                Console.WriteLine(auth_all[i]);
            }

            int j = 0;
            string[] all_a = { "auth/admin_a.dat", "auth/frame_a.dat", "auth/storage_a.dat", "auth/seller_a.dat", "auth/bux_a.dat", "auth/main_user_a.dat"};
            string auth_path = all_a[j];

            for (int i = 0; i <  auth_all.Count; i++)
            {
                if (auth_all[i] == "|") { auth_path = all_a[j+1]; }

                if (auth_all[i] == Login)
                {
                    
                    if (auth_all[i+1] == Password)
                    {
                        skip();

                        switch (auth_path)
                        {
                            case "auth/admin_a.dat":
                                active = -1;
                                break;
                            case "auth/frame_a.dat":
                                active = 1;
                                break;
                            case "auth/storage_a.dat":
                                active = 2;
                                break;
                            case "auth/seller_a.dat":
                                active = 3;
                                break;
                            case "auth/bux_a.dat":
                                active = 4;
                                break;
                            case "auth/main_user_a.dat":
                                active = 5;
                                break;
                        }

                        //Console.WriteLine(auth_path);
                        Console.WriteLine(active);

                        Console.WriteLine("\nУспешный вход\n");

                        break;
                    }
                }
            }

            if (active == 0)
            {
                skip();
                Console.WriteLine("\nНеверне данные\n");

                Console.WriteLine("\nЖелаете зарегистрироваться как обычный пользователь?\n");

                Console.WriteLine("\nДа   Нет");

                int move = 0;

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
                            skip();
                            Console.WriteLine("->Да   Нет");

                            if (start.Key == ConsoleKey.Enter) { active = -2; }
                            break;
                        case 1:
                            skip();
                            Console.WriteLine("Да   ->Нет");

                            if (start.Key == ConsoleKey.Enter) { skip(); }
                            break;
                       
                    }
                }
            }
        }


        public void pas_check(ref string password)
        {
            skip();
            var Upp = new Regex(@"[A-Z]+");
            var numbers = new Regex(@"[0-9]+");
            var spec = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]+");

            int cnt = 0;
            int I = 0;
            int num = 0;
            int special = 0;
            int inf = 0;

            while (inf == 0)
            {
                skip();
                cnt = 0; I = 0; num = 0; special = 0;

                if (password.Count() < 8) { Console.WriteLine("\nКороткий пароль\n"); }
                else { cnt = password.Count(); }

                foreach (var i in password)
                {
                    string j = Char.ToString(i);
                    if (Upp.IsMatch(j)) { I += 1; }
                    if (numbers.IsMatch(j)) { num += 1; }
                    if (spec.IsMatch(j)) { special += 1; }
                }

                //Console.WriteLine($"{cnt}, {I}, {num}, {special}");

                if ((cnt >= 8) && (I >= 3) && (num >= 3) && (special >= 2))
                {
                    inf = 1;
                    Console.WriteLine("\nПароль соответствует всем требованиям\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nВведите новый пароль: \n");
                    password = Console.ReadLine();
                }
            }
        }



        public void zp(ref List<string> bufer)
        {
            string who = bufer[bufer.Count-1];

            string work = bufer[bufer.Count-2];
            string[] work_who = work.Split(new char[] {' '});

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
        public void path_upd(ref string path_a, ref string path_inf, List<string> to_add)
        {
            List<string> bufer = new List<string>();
            List<string> bufer_a = new List<string>();

            using (BinaryReader reader = new BinaryReader(File.Open(path_inf, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    bufer.Add(name);
                }
            }

            using (BinaryReader reader = new BinaryReader(File.Open(path_a, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    bufer_a.Add(name);
                }
            }

            for (int i = 0; i < to_add.Count; i++) { bufer.Add(to_add[i]); }

            for (int i = 0; i < to_add.Count; i++) 
            { 
                if ((to_add[i] == to_add[0]) || (to_add[i] == to_add[1]))
                {
                    bufer_a.Add(to_add[i]);
                }
 
            }

            File.Delete(path_inf);
            File.Delete(path_a);

            using (BinaryWriter writer = new BinaryWriter(File.Open(path_inf, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++) { writer.Write(bufer[i]); }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(path_a, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer_a.Count; i++) { writer.Write(bufer_a[i]); }
            }

        }

    }
}
