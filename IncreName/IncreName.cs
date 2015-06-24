using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreName {

    class IncreName {

        static void Main(string[] args) {

            // Intializing a new instance of the StringBuilder class.
            StringBuilder sb = new StringBuilder();

            // Declaring variable for storing how much the folder name should be incremented by
            int incrementNumber;

            /* 
                * Declaring a variable for storing the root directory 
                * This is the directory that contains each of the folders with the numeric names
            */
            string rootDirectory;

            // Declaring an array for storing the path for each of the directories that have the numeric names
            string[] directories;

            /* 
                * Declaring the variables for the starting last modified time and the ending last modified times
                * The starting last modified time is the last modified time of the folder that the update should 
                * start on. 
                * The ending last modified time is the last modified time of the folder that the update should stop on
            */
            DateTime startDateTime, endDateTime;

            /* 
                * Declearing the variable for incrementing the count (used to keep track of how many folders were updated) 
                * We are also assinging a starting value of 0
            */
            int count = 0;


            // Prompting the user for the root directory of the attachment folders
            Console.WriteLine("Path to attachment folders: ");

            // Assigning the user's input to the root directory variable
            rootDirectory = Console.ReadLine();

            // Passing the user's input to the GetDirectories() method 
            directories = Directory.GetDirectories(rootDirectory);

            // Prompting the user for increment number variable value
            Console.WriteLine("Increment Amount:");

            // Assigning the user's input to the increment number variable
            incrementNumber = Convert.ToInt32(Console.ReadLine());

            // Prompting the user for last modified time fo the foldr that should be updated first  
            Console.WriteLine("Starting Last Modified DateTime:");

            // Assigning the user's input to the start datetime variable
            startDateTime = Convert.ToDateTime(Console.ReadLine());

            // Wirting the variable for storing the start datetime value to the log file 
            sb.Append("startDateTime: " + startDateTime + Environment.NewLine);

            // Prompting the user for last modified time of the folder that should be updated last
            Console.WriteLine("Ending Last Modified DateTime:");

            // Assigning the user's input to the end date time variable
            endDateTime = Convert.ToDateTime(Console.ReadLine());

            // Wirting the variable for storing the ending datetime value to the log file 
            sb.Append("endDateTime: " + endDateTime + Environment.NewLine);

            foreach (string originalDirectoryName in directories)
            {
                // Declaring variable for storing last index value
                int index;

                /* 
                    * Declaring variables for storing each part of the directory path that is split up
                    * For example, if the path is C:\Users\swaters\Desktop\mylittlepony
                    * Then the first variable will store C:\Users\swaters\Desktop\
                    * And second part will store \mylittlepony
                */
                string directoryName1, directoryName2;

                /* 
                    * Declaring a variable for storing the name of the diectory that has a numeric name. 
                    * This is so it can be converted into a Interger datatype later
                */
                int directoryNameNumber;

                // Declaring a variable for storing last modified datetime of the directory that will be renamed */
                DateTime directoryLastModifiedTime;

                // Declaring a value for storing the integer version of the new directory name */
                int newDirectoryName;

                // Declaring a variable for storing the new directory path as a string */ 
                string newDirectoryPath;

                // Writing the original name of each directory in the root directory to the log file
                sb.Append("originalDirectoryName" + originalDirectoryName + Environment.NewLine);

                // Getting the last index number of the last backslashes in the directory path  
                index = originalDirectoryName.LastIndexOf("\\") + 1;

                // Using the remove() method to get the last part of the directory path 
                directoryName1 = originalDirectoryName.Remove(0, index);

                // Using the Remove() method again to get the first part of the directory path
                directoryName2 = originalDirectoryName.Remove(index, originalDirectoryName.Length - index);

                // Writing the last part of the directory path a text file
                sb.Append("directoryName1: " + directoryName1 + Environment.NewLine);

                // Writing the fist part of the directory path to the log file 
                sb.Append("directoryName2: " + directoryName2 + Environment.NewLine);

                // Assigning string version of the directory name (the numeric name) to this variable and converiting it to an integer
                directoryNameNumber = Convert.ToInt32(directoryName1 + Environment.NewLine);

                // Writing the name of the directory to the log file
                sb.Append("directoryNameNumber: " + directoryNameNumber + Environment.NewLine);

                // Assigning the last modified time of the current directory that is being parsed to this variable
                directoryLastModifiedTime = Directory.GetLastWriteTime(originalDirectoryName);

                // Writing the last modified date time of the directory to the log file
                sb.Append("directoryLastModifiedTime: " + directoryLastModifiedTime + Environment.NewLine);

                // Creating the new name of the directory by adding the increment value to original name 
                newDirectoryName = directoryNameNumber + incrementNumber;

                // Writing the new directory name to the log file
                sb.Append("newDirectoryName: " + newDirectoryName + Environment.NewLine);

                /* 
                    * Creating the new directory path by adding the first part of the directory path we grabbed earlier
                    * and adding it to the new directory name . We are also converting the new name to a string value type 
                    * so we can add these two together 
                */
                newDirectoryPath = directoryName2 + Convert.ToString(newDirectoryName);

                // Writing the new directory path string to the log file
                sb.Append("newDirectoryPath: " + newDirectoryPath + Environment.NewLine);

                // Writing the result of the first part of the IF statement (for selecting which folders to update) to the log file 
                sb.Append("is directoryLastModifiedTime >= startDateTime: " + (directoryLastModifiedTime >= startDateTime) + Environment.NewLine);

                // Writing the result of the second part of the IF statement (for selecting which folders to update) to the log file
                sb.Append("is directoryLastModifiedTime <= endDateTime: " + (directoryLastModifiedTime <= endDateTime) + Environment.NewLine);

                // Writing a divider to the log file
                sb.Append("------------" + Environment.NewLine);

                if (directoryLastModifiedTime >= startDateTime && directoryLastModifiedTime <= endDateTime)
                {
                    // Declaring variables for storing the string value of the source and destination directories, respectively. 
                    string sourceDirectory, destinationDirectory;

                    // Incrementing the count variable by 1 during each pass
                    count++;

                    // Writing a success message to the log file
                    sb.Append("Directory Renamed");

                    // Assinging the source directory variable to the original directory name
                    sourceDirectory = @originalDirectoryName;

                    // Assinging the destination directory variable to the new directory path
                    destinationDirectory = @newDirectoryPath;

                    try
                    {
                        // Finally, we use the Move() method to rename the directory path from the original name to the new name
                        Directory.Move(sourceDirectory, destinationDirectory);
                    }
                    catch (Exception e)
                    {

                        // Writing any exceptions that might occur to the log file
                        sb.Append(e.Message);

                    }

                }

            }

            // Writing the number of directories renamed to the log file
            sb.Append("Number of directories renamed: " + count + Environment.NewLine);

            // Writing the log messages to a file and appending _log.txt to the name
            File.AppendAllText(rootDirectory + "\\log.txt", sb.ToString());

            // Using the Clear() method to remove all of the items from the sb list
            sb.Clear();

        } // End Main Function

    } // End IncreName Class

} // End IncreName Namespace
