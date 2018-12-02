namespace P01_BillsPaymentSystem.App.Providers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using P01_BillsPaymentSystem.App.Constants;
    using P01_BillsPaymentSystem.Models;

    public class OutputProvider
    {
        private static int row;

        /// <summary>
        /// Initialize neded tools helping drawing.
        /// </summary>
        private static OutputHelper outputHelper = new OutputHelper();


        /// <summary>
        /// Set window and buffer size.
        /// </summary>
        public void SetWindow()
        {
            //Console.SetBufferSize(100, 9000);
            Console.SetWindowSize(100, 33);
            Console.SetBufferSize(100, 9000);
        }


        /// <summary>
        /// Draw only initial frame into console window.
        /// </summary>
        public void DrawFrame()
        {
            Console.Clear();
            outputHelper.PrintHorisontalFramePart();
            for (int row = 1; row < Console.WindowHeight - 2; row++)
            {
                outputHelper.PrintVerticalFrameSides(row);
            }
            outputHelper.PrintHorisontalFramePart();
        }

        /// <summary>
        /// Draw only initial frame for selecting user into console window.
        /// </summary>
        public void DrawFrame(int number)
        {
            outputHelper.PrintHorisontalFramePart();
            for (int row = 1; row < 100; row++)
            {
                outputHelper.PrintVerticalFrameSides(row);
            }
        }


        /// <summary>
        /// Draw initial options into application frame.
        /// </summary>
        /// <param name="element"></param>
        public void ShowInitialOptions(int element)
        {
            for (int index = 0; index < Strings.Options.Length; index++)
            {
                if (index == element)
                {
                    outputHelper.PrintRowAsSelected(Strings.Options[index], Integers.OptionsStartRows[index]);
                }
                else
                {
                    outputHelper.PrintRow(Strings.Options[index], Integers.OptionsStartRows[index]);
                }
            }
        }


        /// <summary>
        /// Show waiting status untill done.
        /// </summary>
        /// /// <param name="index">int index</param>
        public void ShowWaiting(int index)
        {
            outputHelper.PrintStatus(Strings.Waiting, index);
        }

        
        /// <summary>
        /// Show done for current operation.
        /// </summary>
        /// <param name="index">int index</param>
        public void ShowDone(int index)
        {
            outputHelper.PrintStatus(Strings.Done, index);
        }


        /// <summary>
        /// Change view to select user and show user info
        /// </summary>
        public void SelectUser()
        {
            outputHelper.PrintUserSelectingView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="bankAccounts"></param>
        /// <param name="creditCards"></param>
        public void PrintUserData
            (User user, ICollection<BankAccount> bankAccounts, ICollection<CreditCard> creditCards)
        {
            row = 6;
            var forgroundColor = Console.ForegroundColor;
            Console.SetCursorPosition(2, row++);

            //Print user name:
            Console.Write(Strings.User);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(UserName(user));
            Console.ForegroundColor = forgroundColor;
            Console.SetCursorPosition(2, row++);
            Console.Write(Strings.BoldLine);

            //Print bank account/s info:
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.SmallLine);
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.BankAccounts);
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.SmallLine);

            row++;
            BankAccountData(bankAccounts, ConsoleColor.Gray, ref row);
            Console.ForegroundColor = forgroundColor;

            //Print credit card/s info;
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.SmallLine);
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.CreditCards);
            Console.SetCursorPosition(2, row++);
            Console.WriteLine(Strings.SmallLine);

            row++;
            CreditCardData(creditCards, forgroundColor, ref row);

            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.SetCursorPosition(2, row++);
            //Console.Write(Strings.BoldLine);
            Console.ForegroundColor = forgroundColor;
            Console.SetCursorPosition(Strings.EnterNumber.Length, Integers.InitialRow);
            Console.CursorVisible = false;
        }

        private static string UserName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }

        private static void BankAccountData
            (ICollection<BankAccount> bankAccountData, ConsoleColor forgroundColor, ref int row)
        {
            foreach (var account in bankAccountData.OrderBy(x => x.BankAccountId))
            {
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.ID, account.BankAccountId.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.Balance, account.Balance.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.Bank, account.BankName.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.Swift, account.SwiftCode.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(" ", " ", forgroundColor);
                row++;
            }
        }

        private static void CreditCardData
            (ICollection<CreditCard> creditCardsData, ConsoleColor forgroundColor, ref int row)
        {
            foreach (var account in creditCardsData.OrderBy(x => x.CreditCardId))
            {
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.ID, account.CreditCardId.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.Limit, account.Limit.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.MoneyOwed, account.MoneyOwed.ToString(), forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(Strings.LimitLeft, $"{(account.Limit - account.MoneyOwed):F2}", forgroundColor);
                Console.SetCursorPosition(2, row++);
                var date = account.ExpirationDate.ToString(Strings.DateFormat);
                PrintAccountRow(Strings.ExpirationDate, date, forgroundColor);
                Console.SetCursorPosition(2, row++);
                PrintAccountRow(" ", " ", forgroundColor);
                row++;
            }
        }

        private static void PrintAccountRow(string format, string data, ConsoleColor forgroudColor)
        {
            Console.Write(format);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(data);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }


        /// <summary>
        /// Return expected error message.
        /// </summary>
        /// <param name="message"></param>
        public void ShowException(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 10);
            Console.Write(message);
            Console.SetCursorPosition(10, 11);
            Console.Write("Press Enter to continue:");
            Console.ForegroundColor = color;
        }


        /// <summary>
        /// 
        /// </summary>
        public void PayBills()
        {
            outputHelper.PrintUserSelectingView(string.Empty);
        }

        public void StartWaiting()
        {
            Console.SetCursorPosition(10, 10);
            Console.Write(Strings.Waiting);
        }

        public void Done()
        {
            Console.SetCursorPosition(10, 10);
            Console.Write(Strings.EmptyLine);
            Console.SetCursorPosition(10, 10);
            Console.Write(Strings.Done);
        }
    }
}
