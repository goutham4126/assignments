using InsuranceLibrary.Models;
using System.Collections.Generic;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private List<InsurancePolicy> policies = new List<InsurancePolicy>();

        public void AddPolicy(InsurancePolicy policy)
        {
            policies.Add(policy);
        }

        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

        public InsurancePolicy GetPolicyById(int policyId)
        {
            foreach (var policy in policies)
            {
                if (policy.PolicyId == policyId)
                    return policy;
            }
            return null;
        }

        public bool UpdatePolicy(InsurancePolicy updatedPolicy)
        {
            for (int i = 0; i < policies.Count; i++)
            {
                if (policies[i].PolicyId == updatedPolicy.PolicyId)
                {
                    policies[i] = updatedPolicy;
                    return true;
                }
            }
            return false;
        }

        public bool DeletePolicy(int policyId)
        {
            var policy = GetPolicyById(policyId);
            if (policy != null)
            {
                policies.Remove(policy);
                return true;
            }
            return false;
        }
    }
}
