using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper 
    { 
        ICourseRepository Course { get; } 
        IStudentRepository Student { get; }

        //IPaymentGateway PaymentGateway { get; }

        void Save(); 
    }
}
