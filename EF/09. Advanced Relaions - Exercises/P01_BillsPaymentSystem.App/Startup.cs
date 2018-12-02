namespace P01_BillsPaymentSystem.App
{
    using P01_BillsPaymentSystem.App.Executers;

    class Startup
    {
        private static InputComander inputComandExecuter = new InputComander();
        
        static void Main(string[] args)
        {
            inputComandExecuter.StartReading();
        }
    }
}
