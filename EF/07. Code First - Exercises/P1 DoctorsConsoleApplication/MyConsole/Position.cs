namespace P1_DoctorsConsoleApplication.MyConsole
{
    public class Position
    {
        public Position() { }

        public Position(int col, int row)
        {
            this.Col = col;
            this.Row = row;
        }

        public int Col { get; set; }

        public int Row { get; set; }
    }
}
