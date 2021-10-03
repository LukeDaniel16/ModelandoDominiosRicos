using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = false;
            Payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get; set; }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void MakeActive()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void MakeInactive()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}