namespace practise
{
    public class Emp: IComparable<Emp>  
    {

        // Fields 

        //private string name;
        //public Emp(string name)
        //{
        //    this.name = name;
        //}

        // Properties

        //private string name;
        //public string Name
        //{
        //    get => name;
        //    set => name = value;
        //}


        public Emp()
        {

        }
        
         
        private string empName;
        public string EmpName {
            get { return empName; }
            set { empName = value; }
        }

        private int empId;
        public int EmpId { 
            get { return empId; }
            set { empId = value; }
        }

        private decimal empSalary;
        public decimal EmpSalary { 
            get { return empSalary; }
            set { empSalary = value; }
        }


        public Emp(string empName, int empId, decimal empSalary)
        {
            EmpName = empName;
            EmpId = empId;
            EmpSalary = empSalary;
        }

        public override string ToString()
        {
            return $"EmpName: {EmpName}, EmpId: {EmpId}, EmpSalary: {EmpSalary}";
        }

        override public bool Equals(object? obj)
        {
            Emp other = obj as Emp;
            // Emp other = (Emp)obj;
            return EmpId == other.EmpId && EmpName == other.EmpName && EmpSalary == other.EmpSalary;
        }


        public int CompareTo(Emp? other)
        {
            return this.EmpId.CompareTo(other.EmpId);
            // return this.EmpName.CompareTo(other.EmpName);
            // return this.EmpSalary.CompareTo(other.EmpSalary);
            // We can only do one at a time. So we create a separate Comparer class for each field.
        }



    }
}