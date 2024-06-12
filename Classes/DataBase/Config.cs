using Microsoft.EntityFrameworkCore;
using System;

namespace PR44.Classes.DataBase
{
    public class Config
    {
        public static readonly string connection = "server=127.0.0.1;" +
            "uid=root;" +
            "pwd=;" +
            "database=TaskManager;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
