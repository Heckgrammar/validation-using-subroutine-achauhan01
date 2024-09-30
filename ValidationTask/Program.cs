namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, password, emailAddress;
            int age;

            // get the user inputs until all are valid.
            // The username should only be output once
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            if (ValidName(firstName) == false)
            {
                Console.WriteLine("First name is invalid");
            }
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            if (ValidName(lastName) == false)
            {
                Console.WriteLine("Last name is invalid");
            }
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());
            if (validAge(age) == false)
            {
                Console.WriteLine("Age is invalid");
            }
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            if (ValidPassword(password) == false)
            {
                Console.WriteLine("Password is invalid");
            }
            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();
            if (validEmail(emailAddress))
            {
                Console.WriteLine("Email is invalid");
            }


            username = createUserName(firstName, lastName, age);
            Console.WriteLine($"Username is {username}, you have successfully registered please remember your password");

            //  Test your program with a range of tests to show all validation works
            // Show your evidence in the Readme

        }
        static bool ValidName(string name)
        {
            // name must be at least two characters and contain only letters
            int charNum = name.Length;
            if (charNum >= 2 && name.All(Char.IsLetter))
            {
                return true;
            }
            return false;
        }

        static bool validAge(int age)
        {
            //age must be between 11 and 18 inclusive
            if (age >= 11 && age <= 18)
            {
                return true;
            }
            return false;
        }


        static bool ValidPassword(string password)
        {
            // Check password is at least 8 characters in length
            int charNum = password.Length; //gets the length of password
            if (charNum >= 8)
            {
                return true;
            }
            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$!£|^*+=%~#@_-])$"; //lowercase, uppercase, numbers and special characters
            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }
            return false;
            // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
            // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
            // abC461*+ = not valid (abC are 3 consecutive letters)
            // 987poiq! = not valid (987 are consecutive)
            //DID NOT MANAGE TO FIGURE OUT HOW TO DO ^^^
        }
        static bool validEmail(string email)
        {
            // a valid email address
            // has at least 2 characters followed by an @ symbol and has at least 2 characters followed by a .
            string firstTwo = email.Substring(0, 2);
            if ((firstTwo.Substring(0, 1) != ".") || (firstTwo.Substring(1, 1) != ".")) //checks if first two characters are not .
            {
                return true;
            }
            // has at least 2 characters after the .
            string lastTwo = email.Substring((email.Length - 2), 2); //last two letters of email
            if ((lastTwo.Substring(0, 1) != ".") || (lastTwo.Substring(1, 1) != ".")) //checks if last two characters are not .
            {
                return true;
            }
            // contains only one @ and any number of .
            string symbol = "^(?=.*[@])?(?=.*[.])+$"; //checks if @ occurs either 0 or 1 times, checks if . occurs at least once
            if (Regex.IsMatch(email, symbol))
            {
                return true;
            }
            // does not contain any other non letter or number characters
            string nonLetters = "^(?=.*[0-9]){0}(?=.*[$!£|^*+=%~#_-]){0}$"; //these symbols/numbers should occur 0 times
            if (Regex.IsMatch(email, nonLetters))
            {
                return true;
            }
            return false;
        }
        static string createUserName(string firstName, string lastName, int age)
        {
            // username is made up from:
            // first two characters of first name
            // last two characters of last name
            // age
            //e.g. Bob Smith aged 34 would have the username Both34
            string lastTwo = lastName.Substring((lastName.Length - 2), 2); //last two letters of surname
            string username = (firstName.Substring(0, 2) + lastTwo + age); //combining to make username
            return username;
        }

    }
}
