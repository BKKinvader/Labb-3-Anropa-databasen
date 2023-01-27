using Labb3.Migration;
using Labb3.Models;

namespace Labb3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Run = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Skolregister");
                Console.WriteLine("1: Hämta alla elever");
                Console.WriteLine("2: Hämta alla elever i en viss klass");
                Console.WriteLine("3: Lägga till ny personal");
                SampleDbContext context = new SampleDbContext();
                int Choice = int.Parse(Console.ReadLine());
                Console.Clear();


                if (Choice == 1)
                {
                    // Läsa alla studenter efter Fname
                    var FNameStuds = context.Students
                        .OrderBy(S => S.Fname).ToList();
                    //Läser in alla studenter efter Lname
                    var LNameStuds = context.Students
                        .OrderBy(S => S.Lname).ToList();

                    Console.WriteLine("Sortera efter Förnamn eller efter Efternamn ?");
                    Console.WriteLine("1: Förnamn");
                    Console.WriteLine("2: Efternamn");
                    int Result1 = int.Parse(Console.ReadLine());
                    Console.Clear();


                    switch (Result1)
                    {
                        case 1:
                            Console.WriteLine("A-Ö Eller Ö-A ?");
                            Console.WriteLine("1: A-Ö");
                            Console.WriteLine("2: Ö-A");
                            int SortedBy = int.Parse(Console.ReadLine());

                            if (SortedBy == 1)
                            {

                                //Vad vi vill se i listan
                                foreach (Student item in FNameStuds)
                                {
                                    Console.WriteLine($"StudentID : {item.StudentId}");
                                    Console.WriteLine($"FirstName : {item.Fname}");
                                    Console.WriteLine($"LastName : {item.Lname}");
                                    Console.WriteLine("-------------------------------");
                                }


                            }
                            else if (SortedBy == 2)
                            {
                                //Reverse ifall man vill ha icke alfabetisk ordning. Man kan också använda den nedan men då laddas det 2 gånger i onödan
                                // var Studs = context.Students
                                //.OrderByDescending(S => S.Fname).ToList();
                                FNameStuds.Reverse();
                                //Vad vi vill se i listan
                                foreach (Student item in FNameStuds)
                                {
                                    Console.WriteLine($"StudentID : {item.StudentId}");
                                    Console.WriteLine($"FirstName : {item.Fname}");
                                    Console.WriteLine($"LastName : {item.Lname}");
                                    Console.WriteLine("-------------------------------");
                                }

                            }
                            break;

                        case 2:
                            Console.WriteLine("A-Ö Eller Ö-A ?");
                            Console.WriteLine("1: A-Ö");
                            Console.WriteLine("2: Ö-A");
                            int SortedBy1 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (SortedBy1 == 1)
                            {
                                foreach (Student item in LNameStuds)
                                {
                                    Console.WriteLine($"StudentID : {item.StudentId}");
                                    Console.WriteLine($"FirstName : {item.Fname}");
                                    Console.WriteLine($"LastName : {item.Lname}");
                                    Console.WriteLine("-------------------------------");
                                }


                            }
                            else if (SortedBy1 == 2)
                            {
                                LNameStuds.Reverse();
                                //Vad vi vill se i listan
                                foreach (Student item in LNameStuds)
                                {
                                    Console.WriteLine($"StudentID : {item.StudentId}");
                                    Console.WriteLine($"FirstName : {item.Fname}");
                                    Console.WriteLine($"LastName : {item.Lname}");
                                    Console.WriteLine("-------------------------------");
                                }

                            }
                            break;



                    }
                }



                if (Choice == 2)
                {
                    //Förladda klasserna så inte det laddas många gånger
                    var StudentClass = context.Classes
                        .OrderBy(S => S.ClassName).ToList();
                    var Class1 = context.Students
                          .Where(S => S.ClassId == 1).ToList();
                    var Class2 = context.Students
                              .Where(S => S.ClassId == 2).ToList();


                    Console.WriteLine("Skriv in klassen du vill se");    
                    foreach (Class item in StudentClass)
                    {
                        Console.WriteLine($"Class : {item.ClassName}");
                        Console.WriteLine("-------------------------------");
                    }

                    string ChoiceOfClass = Console.ReadLine();
                    Console.Clear();
                    switch (ChoiceOfClass)
                    {
                        case "SUT21":

                            foreach (Student item in Class1)
                            {
                                Console.WriteLine($"StudentID : {item.StudentId}");
                                Console.WriteLine($"FirstName : {item.Fname}");
                                Console.WriteLine($"LastName : {item.Lname}");
                                Console.WriteLine("-------------------------------");
                            }
                            break;

                        case "SUT22":
                          
                            foreach (Student item in Class2)
                            {
                                Console.WriteLine($"StudentID : {item.StudentId}");
                                Console.WriteLine($"FirstName : {item.Fname}");
                                Console.WriteLine($"LastName : {item.Lname}");
                                Console.WriteLine("-------------------------------");
                            }
                            break;



                    }


                }

                if (Choice == 3)
                {
                    bool exist = true;
                    do
                    {
                        Console.WriteLine("Mata in ID");
                        int ID = int.Parse(Console.ReadLine());
                        //Kontrollera om EmployeeId redan finns
                        var employeeIdExist = context.Employees.Any(e => e.EmployeeId == ID);
                      
                        if (!employeeIdExist)
                        {
                            Console.WriteLine("Mata in Förnamn");
                            string FName = Console.ReadLine();
                            Console.WriteLine("Mata in Efternamn");
                            string LName = Console.ReadLine();
                            Console.WriteLine("Mata in Titel");
                            string title = Console.ReadLine();

                            var newEmployee = new Employee { EmployeeId = ID, Fname = FName, Lname = LName, Title = title };
                            context.Employees.Add(newEmployee);
                            context.SaveChanges();
                            Console.WriteLine("Success! Press enter to view all employees");
                            Console.ReadKey();
                            exist = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("This EmployeeId already exist, press enter to try again!");
                            Console.ReadKey();
                        }
                       
                        
                    } while (exist);

                    var Emp = context.Employees
                    .OrderBy(S => S.EmployeeId).ToList();

                    //Vad vi vill se i listan
                    foreach (Employee item in Emp)
                    {
                        Console.WriteLine($"EmployeeID : {item.EmployeeId}");
                        Console.WriteLine($"FirstName : {item.Fname}");
                        Console.WriteLine($"LastName : {item.Lname}");
                        Console.WriteLine($"Title : {item.Title}");

                        Console.WriteLine("-------------------------------");
                    }

                    Console.WriteLine("Done");


                }

                Console.WriteLine("Tryck enter för att starta om");
                Console.ReadKey();

            } while (Run);
        }
    }
}
