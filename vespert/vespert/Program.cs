﻿using System.Globalization;
using System.Runtime.InteropServices;
using UserTypes;

// - - - Поделючение классов - - -

features features = new UserTypes.features();
Admin admin = new UserTypes.Admin();
Frames frames = new UserTypes.Frames();
Storage storage = new UserTypes.Storage();
KassaSeller seller = new UserTypes.KassaSeller();
Buxgalter bux = new UserTypes.Buxgalter();
Buyer user = new UserTypes.Buyer();

// - - - Переменные - - -

string auth_admin = "auth/admin_a.dat";
string auth_frame = "auth/frame_a.dat";
string auth_storage = "auth/storage_a.dat";
string auth_seller = "auth/seller_a.dat";
string auth_bux = "auth/bux_a.dat";
string auth_user = "auth/main_user_a.dat";

string info_admin = "info/admin_inf.dat";
string info_frame = "info/frame_inf.dat";
string info_storage = "info/storage_inf.dat";
string info_seller = "info/seller_inf.dat";
string info_bux = "info/bux_inf.dat";
string info_user = "info/main_user_inf.dat";
string can_user = "info/main_user_can.dat";

string store_inf = "store.dat";
string order = "info/users_order.dat";

List<string> workers = new List<string>();
List<string> store = new List<string>();
List<string> can = new List<string>();

string Login = "0";
string Password = "0";
string act = "0";
int active = 0;
int activity = 1;

// - - - Основной код - - -

features.skip();

while (activity != 0)
{
    Console.WriteLine("\nВведите логин и пароль пользователя\n");

    Login = Console.ReadLine();
    Password = Console.ReadLine();

    features.auth_collection(auth_admin, auth_frame, auth_storage, auth_seller, auth_bux, auth_user, Login, Password, ref active, ref workers);
    storage.upd_store(ref store, store_inf);
    user.can_upd(ref can, can_user);


    act = "0";

    while (active != 0)
    {
        //features.skip();
        switch (active)
        {
            case -2:
                user.register(ref auth_user, ref info_user, ref active);
                break;
            case -1:
                admin.admin_gen(ref active, ref act, ref activity);
                if (active != 0) { admin.all_features(ref active, ref act, ref activity, ref auth_frame, ref info_frame, ref auth_storage, ref info_storage, ref auth_seller, ref info_seller, ref auth_bux, ref info_bux, info_user); }
                break;
            case 1:
                frames.frame_gen(ref active, ref act, ref activity);
                if (active != 0) { frames.all_features(ref active, ref act, ref activity, ref auth_storage, ref info_storage, ref auth_seller, ref info_seller, ref auth_bux, ref info_bux); }
                break;
            case 2:
                storage.storage_gen(ref active, ref act, ref activity);
                if (active != 0) { storage.all_features(ref active, ref act, ref activity, ref store, store_inf); }
                break;
            case 3:
                seller.seller_gen(ref active, ref act, ref activity);
                if (active != 0) { seller.all_features(ref active, ref act, ref activity, ref can, ref can_user, ref store, ref store_inf, order); }
                break;
            case 4:
                bux.bux_gen(ref active, ref act, ref activity);
                if (active != 0) { bux.all_features(ref active, ref act, ref activity, workers, ref store, ref store_inf, info_frame, info_storage, info_seller, info_bux); }
                break;
            case 5:
                user.user_gen(ref active, ref act, ref activity);
                if (active != 0) { user.all_features(ref active, ref act, ref activity, store, ref can, info_user, Login, ref can_user); }
                break;
        }
        
        //active = 0;
    }

    //Console.WriteLine(activity);

    if (activity == 0) { break; }
}

// - - - Доп фичи - - -

