using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace assignment_one
{
    class Program
    {

        static void Main(string[] args)
        {
            int choice; 
            Console.WriteLine("you will see what will happen in the file :");//reflection of what is done in the file 
            Threads T = new Threads(); //T object of class Threads
           
            /*
             intalizing the functions as Threads
             */
            Thread t1 = new Thread(T.function1); 
            Thread t2 = new Thread(T.function2);
            Thread t3 = new Thread(T.function3);
            Thread t4 = new Thread(T.function4);
            Thread t5 = new Thread(T.function5);
            /*
           starting the threads 
           */
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            Thread.Sleep(28500);//28500 is the sum of all iteration .
            //Main thread here waits for all threads to finish and then print the following statement 
         
            Console.WriteLine("reading data from file press 1");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {

                T.readFile();//reading file 
            }
            else
            {
                Console.WriteLine("thank you for using the FcFS Scheduling method");
            }
            
        }
    }
}