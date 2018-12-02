namespace P01_BillsPaymentSystem.App.Queries
{
    using System.Linq;
    using System.Collections.Generic;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Models;

    public class SelectedUser
    {
        public SelectedUser(int ID)
        {
            this.ID = ID;
        }

        public SelectedUser(decimal[] data)
        {
            this.ID = (int)data[0];
            this.Amount = data[1];
        }

        public decimal Amount { get; private set; }

        private int id;

        public int ID
        {
            get => this.id;
            protected set => this.id = value;
        }

        public User UserData(BillsPaymentSystemContext context)
        {
            return context.Users.ToList().FirstOrDefault(u => u.UserId == this.ID);
        }

        public ICollection<BankAccount> BankAcountData(BillsPaymentSystemContext context)
        {
            return context.PaymentMethods
                .Where(u => u.UserId == this.ID && u.Type == PaymentType.BankAccount)
                .Select(ba => ba.BankAccount).ToArray();
        }

        public ICollection<CreditCard> CreditCardData(BillsPaymentSystemContext context)
        {
            return context.PaymentMethods
                .Where(u => u.UserId == this.ID && u.Type == PaymentType.CreditCard)
                .Select(ba => ba.CreditCard).ToArray();
        }
    }
}
