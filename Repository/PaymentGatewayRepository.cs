using Contracts;
using Entities;
//using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PaymentGatewayRepository : IPaymentGateway
    { 

        public bool IsValidForAsync { get; set; }
        public string Environment { get; set; }
        public string MerchantId { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        public int Create(int id)
        {
            try
            {
                if (id < 18)
                    return 0;

                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Task<int> CreateAsync(int id)
        {
            if (!IsValidForAsync)
                throw new InvalidOperationException();

            var createstatus = Task.Run(() => Create(id));
            return createstatus;
        }


        public string Sale(decimal paymentrequest, string creditcardnumber, string studentname)
        {
            try
            {
                var transactionresult = string.Empty;

                if (!string.IsNullOrEmpty(studentname) && studentname == "Jorge")
                {
                    return transactionresult;
                }


                if (paymentrequest == 0)
                {
                    transactionresult = "Course is charge free.";
                }

                if (paymentrequest > 0)
                {
                    var financeresponse = FinancialCheckRequest(creditcardnumber);


                    transactionresult = financeresponse;
                }

                return transactionresult;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string FinancialCheckRequest(string creditcard)
        {
            try
            {
                var financeresp = string.Empty;

                //Student Contract a Course: Success scenario
                if (!string.IsNullOrEmpty(creditcard) && creditcard.Contains("0666"))
                {
                    financeresp = "Approved";
                }

                //Student Contract a Course: Fail scenario - Insufficient funds.
                if (!string.IsNullOrEmpty(creditcard) && creditcard.Contains("0000"))
                {
                    financeresp = "Declined. Insufficient funds.";
                }

                return financeresp;
            }
            catch (Exception ex)
            {
           
                return string.Empty;
            }

        }

       
        public Task<string> SaleAsync(int id)
        {
            if (!IsValidForAsync)
                throw new InvalidOperationException();

            var name = Task.Run(() => Sale(1000, "12340666", "Amelia"));
            return name;
        }

        public Task<string> FinancialCheckRequestAsync(string creditcard)
        {
            if (IsValidForAsync == true)
            {
                var name = Task.Run(() => FinancialCheckRequest(creditcard));

                return name;
            }
            else
            {
                throw new Exception("Using async method was not valid.");
            }
        }

    }
}
