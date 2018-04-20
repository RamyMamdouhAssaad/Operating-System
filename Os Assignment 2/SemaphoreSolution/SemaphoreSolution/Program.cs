using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace SemaphoreSolution
{
    class Program
    {

        public static int semaphore1 = 1;//: Semaphore1 is an integer variable S, of value 0 (in use) or 1 (free to access). 
        //The value semaphore S is initialy free. The critical section has a semaphore and the queue of waiting processes. 
        
       // If a thread tries access the critical section, it checks semaphore1, 
       //if its values is 0, it waits until its value is  changed to a value greater than zero, one.

        static public void writeIntoFile_semaphore(string filename)
        {
            wait_semaphore();// to check semaphore 1 if it is 0  or less than it is used ,if it is one than the resources can be used
            //plus if the semaphore1 equals one it decreases it by one to ensure that no other thread enter,it's now locked
            Console.WriteLine("entered critical section ");
            FileStream file1 = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter filewriter = new StreamWriter(file1);
            for (int i = 1; i <= 100; i++)
            {
                filewriter.WriteLine("Semaphore " + "number= " + i + "  thread number : " + Thread.CurrentThread.ManagedThreadId);//writing inside the file from 1 to 100 + the id of the thread
                Console.WriteLine("Semaphore " + "number= " + i + "  thread number : " + Thread.CurrentThread.ManagedThreadId);//writing on the console from 1 to 100 + the id of the thread
            }
            filewriter.Close();
            file1.Close();
            signal_semaphore();// intalize semaphore by one 
            //When S is 1, the lock is released, this indicates that the critical section is free be accessed by the next waiting process

        }
        static public void wait_semaphore()
        {
            //if semaphore is 0 or less it means that critcal section is used by one thread and can't be used by another thread 
            //and enter an infinite loop until the critical lock is relased and other thread can enter
            while (semaphore1 <= 0)
            {

            }
            semaphore1--;//decreasing the semaphore by one as one thread is going to enter to ensure that no other thread enters the critical section
            
        }
        static public void signal_semaphore()
        {

            semaphore1 = 1;// intalize semaphore by one 
            //When S is 1, the lock is released, this indicates that the critical section is free be accessed by the next waiting process


        }
        static void racingThreads(string filename)
        {
            //creating 3 thread and passing the filename to all of them as paramater
            Thread t1 = new Thread(() => function1(filename));
            Thread t2 = new Thread(() => function2(filename));
            Thread t3 = new Thread(() => function3(filename));
           //statring the 3 functions
            t1.Start();
            t2.Start();
            t3.Start();
        }
        static public void function1(string filename)
        {
            writeIntoFile_semaphore(filename);//passing filename to semaphore
        }
        static public void function2(string filename)
        {
            writeIntoFile_semaphore(filename);//passing filename to semaphore
        }

        static public void function3(string filename)
        {
            writeIntoFile_semaphore(filename);//passing filename to semaphore
        }

        static void Main(string[] args)
        {
            string filename;
            Console.WriteLine("please enter the name of the file ");
            filename = Console.ReadLine();
            filename = filename + ".txt";//taking the name from user and adding .txt to act as a text file
            racingThreads(filename);//sending to racing threads the name of filename.txt
            Console.ReadLine();
        }
    }
}
//
//This solution suffers from the possibility of deadlock


//IN console output it starts from 4 but in file it runs correctly