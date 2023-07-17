using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp3
{
    internal class Program
    {
        class User
        {
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string PhoneNumber { get; set; }
            public string Password { get; set; }


        }
        private const string FilePath = "C:\\Users\\hp\\Documents\\PdpC#\\Trenirovka\\Новая папка\\Homework6\\ConsoleApp3\\Login.txt";

        private  static List<User> users  = new List<User>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.SignUp :");
                Console.WriteLine("2.Login :");
                Console.WriteLine("3.Exit :");
                Console.WriteLine("Enter a number for which you want doing :");

                int num = int.Parse(Console.ReadLine());

                switch (num) {
                    case 1: SignUp(); break;
                    case 2: Login();break;
                    case 3: DeleteUser();break; 
                    default: Console.WriteLine("Please choose numbers which have in console :"); break;
                }

                Console.WriteLine();


            }

        }
        static void SignUp()
        {
            Console.WriteLine("------SignUp------");
            Console.WriteLine("Enter a FullName : ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter a UserName : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a phonenumber :");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Enter a passwprd :");
            string password = Console.ReadLine();

            User user = new User()
            {
                FullName = fullname,
                UserName = username,
                PhoneNumber = phonenumber,
                Password = password
            };

        }

        static void Login()
        {
            Console.WriteLine("------Login------");
            Console.WriteLine("Enter a Username :");   
            string userName = Console.ReadLine();
            Console.WriteLine("Enter a Password :");
            string passWord = (Console.ReadLine());

            User founderUser = users.Find(user => user.UserName == userName && user.Password == passWord);   

            if(founderUser != null)
            {
              
                    Console.WriteLine("User found");
                    Console.WriteLine("Full Name : " + founderUser.FullName);
                    Console.WriteLine("Username: " + founderUser.UserName);
                    Console.WriteLine("Phone: " + founderUser.PhoneNumber);
            }
            else
            {
                    Console.WriteLine("Invalid username or password!");
            }
            
        }
        static void DeleteUser()
        {
            Console.WriteLine("Delete User");
            Console.Write("Enter the username of the user to delete : ");
            string username = Console.ReadLine();

            User userToDelete = users.Find(user => user.UserName == username);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                WriteUsersToFile();

                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found");
            }

            static List<User> ReadUsersFromFile()
            {
                List<User> usersList = new List<User>();

                if (File.Exists(FilePath))
                {
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] userProperties = line.Split(',');
                            User user = new User()
                            {
                                FullName = userProperties[0],
                                UserName = userProperties[1],
                                PhoneNumber = userProperties[2],
                            };
                            usersList.Add(user);
                        }
                    }
                }

                return usersList;
            }

            static void WriteUsersToFile()
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    foreach (User user in users)
                    {
                        string line = $"{user.FullName}, {user.UserName}, {user.Password}, {user.PhoneNumber}";
                        sw.WriteLine(line);
                    }
                }
            }

        }
    }
}