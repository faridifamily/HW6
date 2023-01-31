using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public static class Menu
    {
        public static void MainMenu() 
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Please select a number");
            Console.WriteLine("1. Create a user");
            Console.WriteLine("2. List of all users");
            Console.WriteLine("3. Update a user information");
            Console.WriteLine("4. Delete a user");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Input name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Input mobile");
                    var mobile = long.Parse(Console.ReadLine());
                    Console.WriteLine("Input birthdate");
                    var birthDate = DateTime.Parse(Console.ReadLine());
                    UserRepository u1 = new();
                    u1.Create(name, mobile, birthDate);
                    break;
                case "2":
                    UserRepository u2 = new();
                    var list = u2.List();
                    foreach (var item in list)
                    { 
                        Console.WriteLine($"{item.Id},{item.Name},{item.Mobile},{item.BirthDate},{item.CreatedTime}"); 
                    }
                    break;
                case "3":
                    Console.WriteLine("Input your user id to edit");
                    int id = int.Parse(Console.ReadLine());
                    UserRepository u3 = new();
                    var user = u3.Detail(id);
                    Console.WriteLine("Do you want to edit name? press enter to skip edit it:");
                    string editName = Console.ReadLine();
                    if (editName != "")
                    {
                        user.Name = editName;
                    }
                    Console.WriteLine("Do you want to edit mobile? press enter to skip edit it:");
                    string editMobile = Console.ReadLine();
                    if (editMobile != "")
                    {
                        user.Mobile = long.Parse(editMobile);
                    }
                    Console.WriteLine("Do you want to edit birthDate? press enter to skip edit it:");
                    string editBirthDate = Console.ReadLine();
                    if (editBirthDate != "")
                    {
                        user.BirthDate = DateTime.Parse(editBirthDate);
                    }
                    u3.Update(id, user);
                    break;
                case "4":
                    Console.WriteLine("Input your user id to delete");
                    int deleteId = int.Parse(Console.ReadLine());
                    UserRepository u4 = new();
                    u4.Delete(deleteId);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
    }
}
