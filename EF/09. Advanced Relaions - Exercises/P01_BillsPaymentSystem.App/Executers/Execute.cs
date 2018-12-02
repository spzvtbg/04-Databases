namespace P01_BillsPaymentSystem.App.Executers
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using P01_BillsPaymentSystem.App.Providers;
    using P01_BillsPaymentSystem.App.Queries;
    using P01_BillsPaymentSystem.Data;
    using P01_DataGenerator;
    using P01_BillsPaymentSystem.App.Constants;
    using P01_BillsPaymentSystem.Models;
    using System.Collections.Generic;

    public class Execute
    {
        private static InputProvider inputProvider = new InputProvider();
        private static OutputProvider outputProvider = new OutputProvider();

        /// <summary>
        /// Create initial database.
        /// </summary>
        public void CreateDatabase()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }


        /// <summary>
        /// Seed some data.
        /// </summary>
        public void SeedSomeData()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                Generator.Seed(context);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Show user info.
        /// </summary>
        public void ShowUserByID()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                Console.Clear();
                outputProvider.DrawFrame(2);
                outputProvider.SelectUser();
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        outputProvider.DrawFrame(2);
                        outputProvider.SelectUser();
                        int ID = inputProvider.ReadNumber();
                        if (ID < 0 || ID > context.Users.Count())
                        {
                            throw new Exception(Strings.InvalidInput(ID));
                        }

                        var selectedUser = new SelectedUser(ID);
                        Console.CursorVisible = false;
                        var currentUser = selectedUser.UserData(context);
                        var bankAccounts = selectedUser.BankAcountData(context);
                        var creditCards = selectedUser.CreditCardData(context);
                        outputProvider.PrintUserData(currentUser, bankAccounts, creditCards);
                        break;
                    }
                    catch (Exception e)
                    {
                        outputProvider.ShowException(e.Message);
                        if (inputProvider.Key() == ConsoleKey.Enter)
                        {
                            continue;
                        }
                    }
                }

                if (inputProvider.Key() == ConsoleKey.Enter)
                {
                    var inputComander = new InputComander();
                    inputComander.StartReading();
                }
            }
        }


        /// <summary>
        /// Make transaction.
        /// </summary>
        public void PayBills()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        outputProvider.DrawFrame(2);
                        outputProvider.PayBills();
                        var data = inputProvider.ReadUserData();
                        if (data[0] < 0 || data[0] > context.Users.Count())
                        {
                            throw new Exception(Strings.InvalidInput((int)data[0]));
                        }

                        var selectedUser = new SelectedUser(data);
                        Console.CursorVisible = false;
                        var currentUser = selectedUser.UserData(context);
                        var bankAccounts = selectedUser.BankAcountData(context);
                        var creditCards = selectedUser.CreditCardData(context);

                        if (bankAccounts.Sum(x => x.Balance) + creditCards.Sum(x => x.Limit - x.MoneyOwed) 
                            < selectedUser.Amount)
                        {
                            throw new Exception(Strings.InvalidInput());
                        }

                        outputProvider.StartWaiting();
                        Withdraw(context, bankAccounts, creditCards, selectedUser.Amount);
                        outputProvider.Done();

                        break;
                    }
                    catch (Exception e)
                    {
                        outputProvider.ShowException(e.Message);
                        if (inputProvider.Key() == ConsoleKey.Enter)
                        {
                            continue;
                        }
                    }
                }

                if (inputProvider.Key() == ConsoleKey.Enter)
                {
                    var inputComander = new InputComander();
                    inputComander.StartReading();
                }
            }
        }


        /// <summary>
        /// Quit from this console application.
        /// </summary>
        public void Quit()
        {
            Environment.Exit(-1);
        }

        private static void Withdraw
            (BillsPaymentSystemContext context, 
            ICollection<BankAccount> banks, 
            ICollection<CreditCard> cards,
            decimal amount)
        {
            banks = banks.OrderBy(x => x.BankAccountId).ToArray();
            foreach (var item in banks)
            {
                while (item.Balance > 0)
                {
                    if (amount <= 0)
                    {
                        context.SaveChanges();
                        return;
                    }
                    item.Withdraw(ref amount);
                }
            }

            cards = cards.OrderBy(x => x.CreditCardId).ToArray();
            foreach (var item in cards)
            {
                while (item.Limit - item.MoneyOwed > 0)
                {
                    if (amount <= 0)
                    {
                        context.SaveChanges();
                        return;
                    }
                    item.Withdraw(ref amount);
                }
            }
        }
    }
}
