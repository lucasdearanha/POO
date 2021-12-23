namespace Contracts.Services
{
    class PayPaymentService : IPaymentService
    {
        public double TaxPayment(double amount, int monthCurrent)
        {
            double tax = amount;
            tax += tax * (0.01 * monthCurrent);
            return tax + (tax * 0.02);
        }
    }
}
