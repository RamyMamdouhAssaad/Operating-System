using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
//class "Threads" to obtain all threads(5 functions) and their helping functions  
namespace assignment_one
{
    class Threads
    {
        //helping function : array containing from 1->25 for functions to access it 
        public static string arr(int number)
        {
            string[] arr = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "tweleve", "therteen", "fourteen", "fifteen", "sixteen", "seventeen", "eigteen", "ninteen", "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five" };

            return arr[number];

        }
        //writing into file 
        public void writeIntoFile(string name)
        {
            FileStream file = new FileStream("file.txt", FileMode.Append, FileAccess.Write);//file named "file.txt"
            StreamWriter filewriter = new StreamWriter(file);
            filewriter.WriteLine(name); //writing the name passed to the function in "file.txt"
            filewriter.Close();
            file.Close();

        }
        //reading all contents of the file 
        public void readFile()
        {

            FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine("Here is the content of the file:");
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            Console.ReadLine();
            sr.Close();
            fs.Close();
        }

        //function 1 to write from 1 to 5
        public void function1()
        {
            /*
            The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. 
            * If another thread tries to enter a locked code, it will wait, block, until the object is released.
            * refernce : http://msdn.microsoft.com/en-us/library/c5kehkcz.aspx
            */
            lock ("file.txt")//object used here is the File.txt,any object can be used for this purpose 
            {
                string threadname = "thread-one";
                for (int i = 0; i < 5; i++)
                {
                    string number = arr(i);//obtainig number from function arr
                    //writing into file the number and the thread name 
                    writeIntoFile(number + "--------------------------------------------------------------" + threadname);
                    //reflection of what is being added to the file 
                    Console.WriteLine(number + "--------------------------------------------------------------" + threadname);
                    Thread.Sleep(500);//Thread.sleep main use is for the user to see clearly the iteration by decreasing the speed of the iterations 
                }


            }

        }

        //function 2 to write from 1 to 10
        public void function2()
        {

            lock ("file.txt")
            {
                string threadname = "thread-two";
                for (int i = 0; i < 10; i++)
                {
                    string number = arr(i);
                    writeIntoFile(number + "--------------------------------------------------------------" + threadname);
                    Console.WriteLine(number + "--------------------------------------------------------------" + threadname);
                    Thread.Sleep(450);
                }

            }

        }
        //function 3 to write from 1 to 15
        public void function3()
        {
            lock ("file.txt")
            {
                string threadname = "thread-three";
                for (int i = 0; i < 15; i++)
                {
                    string number = arr(i);
                    writeIntoFile(number + "----------------------------------------------------------" + threadname);
                    Console.WriteLine(number + "----------------------------------------------------------" + threadname);
                    Thread.Sleep(400);
                }

            }


        }
        //function 4 to write from 1 to 20
        public void function4()
        {
            lock ("file.txt")
            {

                string threadname = "thread-four";
                for (int i = 0; i < 20; i++)
                {
                    string number = arr(i);
                    writeIntoFile(number + "----------------------------------------------------------" + threadname);
                    Console.WriteLine(number + "----------------------------------------------------------" + threadname);
                    Thread.Sleep(350);
                }

            }
        }
        //function 5 to write from 1 to 25
        public void function5()
        {
            lock ("file.txt")
            {

                string threadname = "thread-five";
                for (int i = 0; i < 25; i++)
                {
                    string number = arr(i);
                    writeIntoFile(number + "-------------------------------------------------------" + threadname);
                    Console.WriteLine(number + "-------------------------------------------------------" + threadname);
                    Thread.Sleep(300);//decreasing the milliseconds as function 5 containing has the maximum number of all functions  
                }


            }
        }

    }
}

