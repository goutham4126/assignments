
namespace practise
{
    public class DeptNameWiseComparer: IComparer<Emp>
    {
            public int Compare(Emp? x, Emp? y)
            {
                return x.EmpName.CompareTo(y.EmpName);
            }
    }
}
