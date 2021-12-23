using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts.Entities
{
    public class Contract
    {
        private IList<Installment> _installments;
        
        public int Number { get; set; }
        public DateTime DateOfContract { get; set; }
        public double ContractValue { get; set; }
        public IReadOnlyCollection<Installment> Installments { get { return _installments.ToArray(); } } 

        public Contract(int number, DateTime dateOfContract, double contractValue)
        {
            Number = number;
            DateOfContract = dateOfContract;
            ContractValue = contractValue;
            _installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            _installments.Add(installment);
        }
    }
}
