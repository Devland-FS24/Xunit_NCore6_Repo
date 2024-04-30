using Entities.Models;

namespace Contracts
{
    public interface IPaymentGateway
    {
        bool IsValidForAsync { get; set; }
        string Environment { get; set; }
        string MerchantId { get; set; }
        string PublicKey { get; set; }
        string PrivateKey { get; set; }

        int Create(int id);
        Task<int> CreateAsync(int id);

        string Sale(decimal paymentrequest, string creditcardnumber, string studentname);

        //Task<string> SaleAsync(decimal paymentrequest, string creditcardnumber, string studentname);
        Task<string> SaleAsync(int id);

        string FinancialCheckRequest(string creditcard);

        Task<string> FinancialCheckRequestAsync(string creditcard);



    }
}
