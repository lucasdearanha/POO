namespace Contracts.Services
{
    public interface IPaymentService
    {
        double TaxPayment(double amount, int monthCurrent);
    }
}
