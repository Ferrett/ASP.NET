using System;

namespace WebApplication2
{
    public class SpendingControl
    {
        public int ID { get; set; }
        public bool IsSpending { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }

        public SpendingControl(int iD, bool isSpending, DateTime date, int amount,Category category)
        {
            ID = iD;
            IsSpending = isSpending;
            Amount = amount;
            Date = date;
            Category = category;
        }
    }
}
