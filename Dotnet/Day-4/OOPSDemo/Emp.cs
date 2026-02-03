// fields and properties
// Zero argument constructor
// parameterized constructors
// ToString() override 

namespace OOPSDemo
{
    public class Emp
    {

        public Emp() { }
        private int empSalary;

        public int EmpSalary 
        {
            get { return empSalary; } // Returns the value of EmpId
            set { empSalary = value; }  // Writing the value to EmpId
        }



        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { 
                if(value.Length>10)
                {
                    throw new ApplicationException("Name length exceeded");
                }
                else
                {
                    empName = value;
                }
            }
        }



        private int empId;
        public Emp(int EmpId,string EmpName,int EmpSalary)
        {
            empName= EmpName;
            empId= EmpId;
            empSalary= EmpSalary;
        }

        public override string ToString()
        {
            return "EmpName : " + empName + "\nEmpId : " + empId + "\nEmpSalary : " + empSalary;
        }


    }
}
