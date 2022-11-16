/* 
Purpose:		Demonstrate how to create and process a List<T> using a simple data type using the following methods:
                1. AddName()
                2. DisplayNames()
                3. SearchName()
                4. SortNames()
                5. RemoveName()
				6. LoadFromFile()
				7. WriteToFile()
Input:			names entered and validated with GetSafeString()
Output:			data stored in the List<T> 
Written By: 	
Last Modified:	 
*/

namespace List_T_Demo
{
    internal class Program
    {
        const string PathAndFile = @"C:\Users\iguleed1\Desktop\work\Students.txt"; // change the path to match your computer

        static void Main()
        {
            Setup();

            //variables
            List<string> students = new List<string>();
            string searchName;
            char addAnother;
            int location;

            Console.WriteLine("Welcome to the List<T> Demo");

            //1. Loop to add names to the List<T>
            Console.WriteLine("\nAdding names to the List<T> manually");
            do
            {
                //2. Call the AddName method
                AddName(students);
                //3. Prompt to add another name
                Console.Write("Add another student: (Y): ");
                addAnother = char.Parse(Console.ReadLine().ToUpper().Substring(0, 1));
            } while (addAnother == 'Y');

            //4. Display the List<T>
            Console.WriteLine("\nDisplaying the contents of the List<T>");
            DisplayNames(students);

            //5. Prompt for a name to find and display location
            Console.WriteLine("\nSearching the List<T>");
            searchName = GetSafeString("Enter a name to search for: ");
            location = SearchNames(students, searchName);
            if (location != -1)
            {
                Console.WriteLine($"The name {searchName} was found at {location}");
            }
            else
            {
                Console.WriteLine($"{searchName} not found");
            }
            //6. Remove the name at the found location if not -1
            Console.WriteLine("\nRemoving a name if found");
            if (location != -1)
            {
                RemoveName(students, location);
            }
            DisplayNames(students);
            //7. Sort the List<T>
            Console.WriteLine("\nSorting the names alphabetically");
            SortNames(students);
            //8. Display the List<T>
            Console.WriteLine("\nDisplaying the contents of the List<T>");
            DisplayNames(students);
            //9. Load the List<T> from a file
            Console.WriteLine("\nLoad the List<T> from a file");
            if (File.Exists(PathAndFile))
            {
                LoadFromFile(students);
                //10. Display the List<T>
                Console.WriteLine("\nDisplaying the contents of the List<T>");
                DisplayNames(students);

            }
            else
            {
                Console.WriteLine($"The file, {PathAndFile}, does not exist");
            }


            //11. Write the List<T> to a file
            Console.WriteLine("\nWrite the List<T> to a file");

            Console.ReadLine();
        }//eom

        //Add a name to the List<T>
        static void AddName(List<string> students)
        {
            string name = GetSafeString("Enter the student's name: ");
            students.Add(name);
        }//end of AddName

        //Display the names that are stored in the List<T>
        static void DisplayNames(List<string> students)
        {
            foreach (string student in students)
            {
                Console.WriteLine(student);
            }
        }//end of DisplayNames

        //Search for a name in the List<T>
        static int SearchNames(List<string> students, string searchName)
        {
            //If found will return a valid index, else will return -1
            //Here we are using a Lambda expression
            
            return students.FindIndex(item => item.Equals(searchName));
        }//end of SearchNames


        //Sort the names in the List<T> alphabetically
        static void SortNames(List<string> students)
        {
            int minIndex;
            string minValue,
                temp;
            for (int startScan = 0; startScan < students.Count -1; startScan++)
            {
                minIndex = startScan;
                minValue = students[startScan];
                for (int index = startScan; index < students.Count; index++)
                {
                    if (students[index].CompareTo(minValue) < 0)
                    {
                        minValue = students[index];
                        minIndex = index;
                        // swap
                        temp = students[minIndex];
                        students[minIndex] = students[startScan];
                        students[startScan] = temp;
                    }
                }
            }
        }//end of SortNames

        //Remove an "element" from the List<T>
        static void RemoveName(List<string> students, int location)
        {
            students.RemoveAt(location);
        }//end of RemoveName

        //Load the List<T> from a file
        static void LoadFromFile(List<string> students)
        {
            //1. Clear the List<T>
            students.Clear();
            //2. Standard File I/O
            string input;
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(PathAndFile);
                while ((input = reader.ReadLine()) != null)
                {
                    students.Add(input);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }//end of LoadFromFile

        //Write the List<T> to a file
        static void WriteToFile()
        {
            //Challenge:
            // 1. Add your name to the List<T>
            // 2. Sort the List<T>
            // 3. Write the modified List<T> to a file (can be a diffefrent filename)

        }//end of WriteToFile

        #region Provided Methods - DO NOT MODIFY
        static void Setup()
        {
            Console.Title = "List<T> Demo";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }//end of Setup

        static string GetSafeString(string prompt)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
                if (name.Length > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Nothing inputted ... try again");
                }
            } while (!isValid);
            return name;
        }//end of GetSafeString
        #endregion
    }//eoc
}//eon
