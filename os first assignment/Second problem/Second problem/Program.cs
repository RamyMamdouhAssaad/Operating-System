using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace assignment_one
{

    class Program
    {
        //helping function : array containing from 1->25 for the functions to access it 
        public static string arr(int number)
        {
            string[] arr = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "tweleve", "therteen", "fourteen", "fifteen", "sixteen", "seventeen", "eigteen", "ninteen", "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five" };

            return arr[number];




        }
        //writing into file
        public static void writeIntoFile(string name)
        {
            FileStream file = new FileStream("file.txt", FileMode.Append, FileAccess.Write);
            StreamWriter filewriter = new StreamWriter(file);
            filewriter.WriteLine(name);//writing the name passed to the function in "file.txt"
            filewriter.Close();
            file.Close();

        }

        //reading all contents of the file 
        public static void readFile()
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
        //count is the number of array that must be printed
        //int words = how many words gonna be printed in each slice(word slice)
        //each thread has to print 2 words only and then go to another thread
        static public void function1(int count,int words)
        {

            lock ("file.txt")
            {
                string threadname = "thread-one";
                //for loop to print numbers according to the word slice (ex : 2 words then print 1 2/ex : 3 words then print 1 2 3)
                for (int i = 0; i < words; i++)
                {
                    if (count < 5)// as this function print from 1 to 5 if more than 5 is the input of count then the function won't respond
                    {
                        string number = arr(count);
                        writeIntoFile(number + "--------------------------------------------------------------" + threadname);
                        Console.WriteLine(number + "--------------------------------------------------------------" + threadname);
                        count++;//to print the next one 
                        Thread.Sleep(200); 
                        //Thread.sleep main use here is for the user to see clearly the iteration by decreasing the speed of the iterations 
                    }
                }
            }
        }


        //function 2 to write from 1 to 10
        static public void function2(int count, int words)
        {

            lock ("file.txt")
            {


                string threadname = "thread-two";
                for (int i = 0; i < words; i++)
                {
                    if (count < 10)
                    {
                        string number = arr(count);
                        writeIntoFile(number + "--------------------------------------------------------------" + threadname);
                        Console.WriteLine(number + "--------------------------------------------------------------" + threadname);
                        count++;
                        Thread.Sleep(200);
                    }
                }
            }
        }

        static public void function3(int count,int words)
        {
            lock ("file.txt")
            {

                string threadname = "thread-three";
                for (int i = 0; i < words; i++)
                {

                    if (count < 15)
                    {
                        string number = arr(count);
                        writeIntoFile(number + "---------------------------------------------------------" + threadname);
                        Console.WriteLine(number + "---------------------------------------------------------" + threadname);
                        count++;

                        Thread.Sleep(200);
                    }
                }
            }


        }

        static public void function4(int count, int words)
        {
            lock ("file.txt")
            {
                string threadname = "thread-four";
                for (int i = 0; i < words; i++)
                {

                    if (count < 20)
                    {
                        string number = arr(count);
                        writeIntoFile(number + "---------------------------------------------------------" + threadname);
                        Console.WriteLine(number + "---------------------------------------------------------" + threadname);
                        count++;

                        Thread.Sleep(200);
                    }
                }
            }
        }


        static public void function5(int count, int words)
        {
            lock ("file.txt")
            {
                string threadname = "thread-five";
                for (int i = 0; i < words; i++)
                {
                    if (count < 25)
                    {
                        string number = arr(count);
                        writeIntoFile(number + "--------------------------------------------------------" + threadname);
                        Console.WriteLine(number + "--------------------------------------------------------" + threadname);
                        count++;

                        Thread.Sleep(200);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int choice;// choice for readfile 
            int words=2 ;//default value of word slice is 2 
            int i = 0; // i is declared seperataly as i increases according to how many words are added //dont need for loop
            Console.WriteLine("you will see what will happen in the file :");
          while(i<25) //i is the number of the array passed to the threads inorder to print it / words is the slice 
              {
                Thread t1 = new Thread(() => function1(i,words));//method : for passing arguments to Threads 
                t1.Start();
                Thread.Sleep(500);//main function waits for 0.5 seconds as threads may interfere with each others 
                Thread t2 = new Thread(() => function2(i,words));
                t2.Start();
                Thread.Sleep(500);//0.5 seconds between the start of each function 
                Thread t3 = new Thread(() => function3(i,words));
                t3.Start();
                Thread.Sleep(500);
                Thread t4 = new Thread(() => function4(i,words));
                t4.Start();
                Thread.Sleep(500);
                Thread t5 = new Thread(() => function5(i,words));
                t5.Start();
                Thread.Sleep(500);
                for (int j = 0; j < words; j++)// to increase i by the slice quantity
                {
                    i++;
                }
            }
            //every time in the loop threads arguments are changed so creating and starting them is obligatory 

                
              
            //reading from the file 
                Console.WriteLine("reading data from file press 1");
                choice =int.Parse(Console.ReadLine()) ; 
                if (choice == 1)
                {

                    readFile();
                }
                else
                {
                    Console.WriteLine("thank you for using the Round Robin Scheduling method");
                }

            }
        }
    }
