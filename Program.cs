using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_SORTING_OPERATORS
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();
            IEnumerable<Student> stud = studentList.SortAscending();
            studentList.Print(stud);
            stud = studentList.SortDescending();
            studentList.Print(stud);
            stud = studentList.ThenBy();
            studentList.Print(stud);
            stud = studentList.ThenByDescending();
            studentList.Print(stud);
            stud = studentList.Reverse();
            studentList.Print(stud);
        }
    }
}
