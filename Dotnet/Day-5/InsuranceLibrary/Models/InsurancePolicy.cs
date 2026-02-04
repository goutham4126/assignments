using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        private int policyId;
        private string policyHolderName;
        private string policyType;
        private decimal premiumAmount;
        private int policyTerm;
        private bool isActive;


        public int PolicyId
        {
            get => policyId;
            set => policyId = value;
        }

        public string PolicyHolderName
        {
            get { return policyHolderName; }
            set { policyHolderName = value; }
        }

        public string PolicyType
        {
            get { return policyType; }
            set { policyType = value; }
        }

        public decimal PremiumAmount
        {
            get { return premiumAmount; }
            set { premiumAmount = value; }
        }

        public int PolicyTerm
        {
            get { return policyTerm; }
            set { policyTerm = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public InsurancePolicy()
        {

        }

        public InsurancePolicy(int policyId, string policyHolderName, string policyType, decimal premiumAmount, int policyTerm, bool isActive)
        {
            PolicyId = policyId;
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            PolicyTerm = policyTerm;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"Policy ID: {PolicyId}, Holder: {PolicyHolderName}, Type: {PolicyType}, Premium: {PremiumAmount}, Term: {PolicyTerm} years, Active: {IsActive}";
        }
    }
}
