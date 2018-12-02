namespace P01_DataGenerator
{
    using System;

    using P01_BillsPaymentSystem.Data;
    using P01_DataGenerator.Generators;
    using P01_BillsPaymentSystem.Models;

    public class Generator
    {
        public static Random random = new Random();

        public static void Seed(BillsPaymentSystemContext context)
        {
            for (int countUsers = 1; countUsers <= 100; countUsers++)
            {
                var currentUser = UserGen.CreateNewUser();
                context.Users.Add(currentUser);

                var payments = random.Next(1, 6);
                for (int countPayments = 0; countPayments < payments; countPayments++)
                {
                    var currentPayment = new PaymentMethod();
                    var type = random.Next(1, 100) % 2;

                    if (type == 1)
                    {
                        var currentAccount = BankAccountGen.CreateNewBankAccount();
                        context.BankAccounts.Add(currentAccount);

                        currentPayment.Type = PaymentType.BankAccount;
                        currentPayment.BankAccount = currentAccount;
                    }
                    else
                    {
                        var currentAccount = CreditCardGen.CreateNewCreditCard();
                        context.CreditCards.Add(currentAccount);

                        currentPayment.Type = PaymentType.CreditCard;
                        currentPayment.CreditCard = currentAccount;
                    }

                    currentPayment.User = currentUser;
                    context.PaymentMethods.Add(currentPayment);
                }
            }
            context.SaveChanges();
        }
    }
}
