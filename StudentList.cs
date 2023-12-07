using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_SORTING_OPERATORS
{
    public class StudentList
    {
        List<Student> students = new List<Student>() {

            new Student() {S_ID = 209, S_Name = "Tharmesh", S_Gender = "Male",
                                    DOB = new DateTime(2002,11,22)},

            new Student() {S_ID = 210, S_Name = "Soniya", S_Gender = "Female",
                                    DOB = new DateTime(2000,1,12)},

            new Student() {S_ID = 208, S_Name = "Sairam", S_Gender = "Male",
                                DOB = new DateTime(2000,7,15)},

            new Student() {S_ID = 212, S_Name = "Mithula", S_Gender = "Female",
                                    DOB = new DateTime(2005, 12, 7) },

            new Student() {S_ID = 218, S_Name = "Deva", S_Gender = "Male",
                            DOB = new DateTime(2003, 2, 14) },

            new Student() {S_ID = 215, S_Name = "Anju", S_Gender = "Female",
                                DOB = new DateTime(1995, 6, 2) },
        };

        // Here I'm Using Iterator Concept. The ' yield return ' statement
        // retirn the element from the collection at a time.
        // So, we can use more than one yield return.

        public IEnumerable<Student> SortAscending()
        {
            var res = from std in students
                      orderby std.S_Name 
                      select std;

            Console.WriteLine("\nAscending Using Query :\n");
            
            foreach(var s in res)
                yield return s;

            Console.WriteLine("\n=================================================================\n");
            Console.WriteLine("\nAscending Using Method with Lambda Operator :\n");
            
            var res1 = students.OrderBy(s => s.S_ID);
            
            foreach (var s in res1)
                yield return s;

            Console.WriteLine("\n=================================================================\n");

        }

        public IEnumerable<Student> SortDescending()
        {
            Console.WriteLine("\nDescending Using Query :\n");

            var res = from std in students
                      orderby std.S_Name descending
                      select std;

            foreach (var s in res)
                yield return s;

            Console.WriteLine("\n=================================================================\n");

            Console.WriteLine("\nDescending Using Method with Lambda Operator :\n");

            var res1 = students.OrderByDescending(s => s.S_ID);
            foreach (var s in res1)
                yield return s;

            Console.WriteLine("\n=================================================================\n");

        }

        public IEnumerable<Student> ThenBy()
        {
            // Sorting first by S_Name in ascending order and then by DOB in ascending order

            Console.WriteLine("\nSorting first by S_Name in ascending order and then by DOB in ascending order : \n");

            Console.WriteLine("\nUsing Query : \n");
            // var sort = from std in students
            //            orderby std.S_Name ascending
            //            select std;

            //var sort1 = from std in sort
            //            orderby std.DOB ascending
            //            select std;

            //              OR

            var sort2 = from std in students
                        orderby std.S_Name ascending , std.DOB ascending
                        select std;

            //foreach (var item in sort1)
            //{
            //    yield return item;
            //}
            Console.WriteLine("\n=================================================================\n");
            foreach (var item in sort2)
            {
                yield return item;
            }
            Console.WriteLine("\n=================================================================\n");

            Console.WriteLine("Using ThenBy Method :\n");
            var sortedList = students.OrderBy(s => s.S_Name).ThenBy(s => s.DOB);

            foreach (var item in sortedList)
            {
                yield return item;
            }
            Console.WriteLine("\n=================================================================\n");


        }

        public IEnumerable<Student> ThenByDescending()
        {
            // Used for secondary sorting in descending order.

            Console.WriteLine("Using ThenByDescending Query : ");
            Console.WriteLine("\nUsed for secondary sorting in descending order.\n");
            //var sort = from std in students
            //           orderby std.S_Name
            //           select std;

            //var sort1 = from std in sort
            //            orderby std.DOB descending
            //            select std;
            //              OR
            var res = from std in students
                      orderby std.S_Name, std.DOB descending
                      select std;
           
            //foreach (var item in sort1)
            //{ yield return item; }
            Console.WriteLine("\n=================================================================\n");

            foreach (var item in res)
            { yield return item; }
            
            Console.WriteLine("\n=================================================================\n");
            Console.WriteLine("\nUsing ThenByDescending Method : \n");
            
            var res1 = students.OrderBy(s=> s.S_Name).ThenByDescending(s => s.DOB);
            foreach (var item in res1)
            { yield return item; }
            Console.WriteLine("\n=================================================================\n");

        }

        public IEnumerable<Student> Reverse()
        {
            Console.WriteLine("\nReversing the List :\n");
            students.Reverse();
            foreach (var item in students)
            {
                yield return item;
            }
            Console.WriteLine("\n=================================================================\n");

        }
        public void Print(IEnumerable<dynamic> res)
        {
            foreach (Student val in res)
            {
                Console.WriteLine("Student ID : {0}   Student Name: {1}   Student DOB : {2} ",
                    val.S_ID,val.S_Name,val.DOB.ToString("dd / MM / yyyy"));
            }
        }


    }
}





////old REC
//1           T
//6           G
//2           A
//5           X

////NAME REC
//A       2
//G       6
//T       1
//X       5

////ID REC

//1       T
//2       A
//5       X
//6       G
