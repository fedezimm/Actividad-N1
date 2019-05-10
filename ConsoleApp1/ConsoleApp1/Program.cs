using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {

            using (var ctx = new Model())
            {
                var stud = new Student() { StudentName = "Sebastián" };
                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }


         //   using (var ctx1 = new Model())
         //    {
         //      var Lista = ctx1.Students
         //           .Where(x=>x.StudentID > 2);
         //       foreach(var stud2 in Lista)
         //           { Console.WriteLine(stud2.StudentName);
         //           stud2.Height = 1.45M;
         //       }
                
         //       ctx1.SaveChanges();
         //   }
            
        }




    }
}
