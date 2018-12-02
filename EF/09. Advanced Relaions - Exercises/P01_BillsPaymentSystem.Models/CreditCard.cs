namespace P01_BillsPaymentSystem.Models
{
    using System;

    public class CreditCard
    {
        public CreditCard() { }

        public CreditCard(decimal limit)
        {
            this.Limit = limit;
            this.LimitLeft = limit;
        }

        public int CreditCardId { get; set; }

        public DateTime ExpirationDate { get; set; }

        private decimal limit;

        public decimal Limit
        {
            get => this.limit;
            set => this.limit = value;
        }

        public decimal LimitLeft { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(ref decimal sum)
        {
            var temporaryLimit = this.LimitLeft;

            if (this.Limit - this.MoneyOwed >= sum)
            {
                this.MoneyOwed += sum;
            }
            else
            {
                this.MoneyOwed = this.Limit;
                sum -= temporaryLimit;
            }
        }

        public void Deposit(decimal sum)
        {
            if (sum < 0)
            {
                return;
            }

            if (this.MoneyOwed >= sum)
            {
                this.MoneyOwed -= sum;
            }                                                           
            else if (this.MoneyOwed < sum)
            {
                this.MoneyOwed = 0;
            }
        }
    }
}
