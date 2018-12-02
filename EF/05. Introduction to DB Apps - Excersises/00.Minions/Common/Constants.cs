namespace _00.Minions.Common
{
    public class Constants
    {
        public class Strings
        {
            // My connection values:
            public const string ServerName = @"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt";
            public const string ConnectingString = "Server={server};Integrated Security=true";
            public const string Server = "{server}";

            // Common console values:
            public const string WelcomeText = "WELLCOME TO SPZVTBG DB APPS INTRODUCTION WITH ADO.NET ...";
            public const string MenuLeft = " Press: ESC to exit.";
            public const string MenuMiddle = "To navigate: UP, DOWN, LEFT, RIGHT Arrows.   ";
            public const string MenuRight = "To select Press: ENTER ";
            public const string AppTitle = "DB INTRODUCTION WITH ADO.NET";
            public const string ConnectToDB = " CONNECT TO SQL-SERVER ";
            public const string ShowDataBases = " SHOW DATABASES ";
            public const string CRUD = " CREATE-READ-UPDATE-DELETE ";
        }

        public class Chars
        {
            public const char Equal = '=';
            public const char Dash = '-';
            public const char Star = '#';
        }

        public class Ints
        {
            // Window setings values:
            public const int Width = 100;
            public const int BufferHeight = 1000;
            public const int WindowHeight = 33;
            public const int TitleLeft = 150;

            // Print values:
            public const int DefaultZero = 0;
            public const int DefaultOne = 1;
            public const int StarsStartRow = 3;
            public const int StarsEndRow = 29;
            public const int EndFrameRow = 31;
            public const int HeaderRow = 2;
            public const int FutterRow = 30;
            public const int LastColumn = 99;
        }
    }
}
