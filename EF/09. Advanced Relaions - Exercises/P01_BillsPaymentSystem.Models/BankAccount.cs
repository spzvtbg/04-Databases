namespace P01_BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        private decimal balance;
        public decimal Balance
        {
            get => this.balance;
            private set => this.balance = value;
        }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(ref decimal sum)
        {
            if (this.Balance >= sum)
            {
                this.Balance -= sum;
            }
            else
            {
                sum -= this.Balance;
                this.Balance = 0m;
            }
        }

        public void Deposit(decimal sum)
        {
            if (sum < 0)
            {
                return;
            }

            this.Balance += sum;
        }
    }
}
