namespace P01_BillsPaymentSystem.App.Executers
{
    using System;
    using System.Threading;

    using P01_BillsPaymentSystem.App.Constants;
    using System.Reflection;
    using P01_BillsPaymentSystem.App.Providers;

    public class InputComander
    {
        private static int elements = Integers.OptionsStartRows.Length;
        private static InputProvider inpitProvider = new InputProvider();
        private static OutputProvider outputRenderer = new OutputProvider();
        private static MethodInfo[] methods = typeof(Execute).GetMethods();

        public void StartReading()
        {
            int countKeyPressesed = 0;
            outputRenderer.SetWindow();
            outputRenderer.DrawFrame();
            outputRenderer.ShowInitialOptions(countKeyPressesed % elements);

            while (true)
            {
                ConsoleKey keyPressed = inpitProvider.Key();
                inpitProvider.ClearBuffer();

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    countKeyPressesed = countKeyPressesed == 0 ? 4 : countKeyPressesed - 1;
                    outputRenderer.ShowInitialOptions(countKeyPressesed % elements);
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    countKeyPressesed = countKeyPressesed == 4 ? 0 : countKeyPressesed + 1;
                    outputRenderer.ShowInitialOptions(countKeyPressesed % elements);
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    Execute exe = new Execute();
                    outputRenderer.ShowWaiting(countKeyPressesed);
                    methods[countKeyPressesed].Invoke(exe, null);
                    if (countKeyPressesed != 2)
                    {
                        outputRenderer.ShowDone(countKeyPressesed);
                    }
                }
                Thread.Sleep(80);
            }
        }
    }
}
