using System.ComponentModel.DataAnnotations;

namespace LINQ_Session1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implicitly Type Local Variable

            #region VAR
            var Name = "Ahmed";
            // Compiler will detect the variable datatype
            // based on its initial value at compilation time

            ///var name02;
            // must be initialized

            //var name03 = null;
            // can't be initialized by null 
            #endregion

            #region Dynamic

            dynamic Name2 = "Ahmed";
            Name2 = 5;

            // CLR detects variable datatype
            // based on last assigned value at runtime

            dynamic name02;
            dynamic name03 = null;

            #endregion

            #endregion

            #region Extention Methods
            //to add method to int like reverse method [Add extra behaviour]




            #endregion

            #region Anonumyous Type

            // Create object form a specific data type


            //create object form employee
            //Employee employee03 = new Employee()
            //{
            //    Id = 1,
            //    Name = "Naya",
            //    Salary = 4000
            //};


            ///If we need to craete this object just one Time. we do like below.
            //object employee04 = new { Id = 1, Name = "Naya",Salary = 4000};
            // We can not do it with object beacuse we can not do 
            // employee.Id [beacuse object it is the parent and it is referer to his child {binding} and it dont has access to child property]


            //So with anaonyous type it is better to use var , the compiler will create the class
            var employee04 = new { Id = 1, Name = "Naya",Salary = 4000};

            Console.WriteLine(employee04);
            int x = 0;
            Console.WriteLine(x.GetType().Name);
            Console.WriteLine(employee04.GetType().Name); //<>f__AnonymousType0`3 => 3 it is the number of the properties in thisf__AnonymousType0 
            //this class is immutable 
            //so we can not do => employee.Id = 40 ; so we need to create a new object until C#9
            var employee05 = new { Id = 40, Name = employee04.Name, Salary = employee04.Salary };


            //C#10
            employee05 = employee05 with { Id = 400 }; //Sytax suger

            //Ex

            var employee06 = new { Id = 100, Name = "bayan" };
            Console.WriteLine(employee06.GetType().Name);

            #endregion


            #region What is LINQ
            //stands for => language integrated Query

            // To talk with  dataBase , we use LINQ
            // ORM tool => to link C# application with your database
            // +40 Extension methods with overLoad.
            //all LINQ operator in [Enumerable Class]
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //You can use "LINQ operatores" against data
            //[Stored in sequance]: Rgrardless the source of data [sql , mySql , OrCLE ]
            //Sequence 
            // 1. local (numbers.where() , the data is in the application ) => L2O (LINQ TO OBJECT) , OR  L2XML)
            // 2. Remote => L2EF (LINQ TO ENTITY FRAMEWORK).
            List<int> oddNumber = numbers.Where(N => N% 2==1 ).ToList();//Tolist is casting operator 

            var OddNum = numbers.Where(N => N % 2 == 1);

            // Why all collection implement IEnumerable ?
            // To use foreach
            // we can not use for in IEnumerable
            #endregion

            #region LINQ SYNTAX

            // 1. Fluent syntax
            List<int> numbers2 = new List<int>() { 10, 20, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 1.1 use linq operatore as => static method through "IEnumerable class".
            var oddnum = Enumerable.Where<int>(numbers2, N => N % 2 == 1);
            foreach(var number in oddnum)
            {
                Console.WriteLine( number);
            }



            //1.2 use linq operators as Extenstion method
            oddnum = numbers.Where(N => N % 2 == 1);



            // 2.Query syntax : Query Expression [Like sql]

            /*
             * Remeber : تتنفذ عللى حسب execution order
            select N 
            from Numbers N
            where N => N % 2 ==1 

             */
            //تكتب بترتيب تنفيذه
            oddnum = from N in numbers2
                     where N % 2 == 1
                     select N;
            #endregion



            #region LINQ Execution
            Console.WriteLine("\n ====== LINQ Execution ========");
            //LINQ Execution :
            // 1.what is immediate execution in LINQ ? category : (element operator , casting operator , aggregate operators)
            // 2.what is defierd Execution ? (10 category) // بتتنقذ بس بتتأخر لحد ما اعملها call or the output sequence

            List<int> numbers3 = new List<int>() { 10, 20, 3, 4, 5, 6, 7, 8, 9, 10 };
            var oddnum02 /* This is an output sequenec يتم تنفيذه في حالة استخدامه*/  = Enumerable.Where<int>(numbers3, N => N % 2 == 1);
            numbers3.AddRange(new int[] { 10, 23, 300,15 });

            foreach(int number in oddnum02)
            {
                Console.WriteLine(number);
            }


            //What is execution in LINQ ?
            // to make defierd execution type work as immediate execution : we add one of immediate category with defierd category
            //Ex
            var oddnumImmediate = Enumerable.Where<int>(numbers3, N => N % 2 == 1).ToList();
            numbers3.AddRange(new int[] { 111});

            Console.WriteLine("\n Immediate category Casting");
            foreach (int number in oddnumImmediate)
            {
                Console.WriteLine(number);
            }


            #endregion

            #region Data Setup

            // 1. Data is local
            // 1.1 Static
            Console.WriteLine(ListGenerator.ProductsList[0]);
            Console.WriteLine();
            Console.WriteLine(ListGenerator.CustomersList[0]);






            #endregion




        }
    }
}
