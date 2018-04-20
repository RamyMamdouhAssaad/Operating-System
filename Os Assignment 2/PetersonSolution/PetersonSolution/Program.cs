using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
// here are 3 solutions for peterson 
//first one is for 2 process only 
//second one for N process
//third one using filter algorithm to solve N process
namespace PetersonSolution
{
    class Program
    {
        static int no = 3;//number of threads
        static int[] level = new int[no];//number of levels used in filter algorithm
        static int[] waiting = new int[no - 1];//number of levels used in filter algorithm
        static bool[] flags = new bool[4];//flags used in peterson for 2 threads
        static int processTurn;//turn used in peterson for 2 threads
        public static int count = 0;// used in filter algorithm
        public static int counter = 0;//used in the main peterson used used by programmer to choose the thread he wants
        public static int threadnumber;// used as the id of the thread
        static bool change = true; // used in filter algorithm as condition

        static private int other()
        {

            return threadnumber == 0 ? 1 : 0;// function to find if number ==0 change it to 1 if it's 1 change it to 0 

        }
        //here are the solution to find it for two process only 
        //if more than two process are added an exception may appear
        static public void writeIntoFile_peterson1(int threadnumber, string filename)
        {
            flags[threadnumber] = true;//set the thread who wants to enter to true inorder to be able to enter the critical section
            processTurn = other(); //setting that variable to the reverse of threadnumber inorder to see if another thread wants to enter the critical section

            //here while loop to wait if there is another thread doing their work if their is another thread it will waits till it finished it's work
            while (flags[other()] && processTurn == other())
            {


            }
            // if there is no other process doing their work the process which i intalized as true will enter the critical section and will perform the work
            Console.WriteLine("entered critical section ");
            FileStream file1 = new FileStream(filename, FileMode.Append, FileAccess.Write);//creating file using the filename given by user
            StreamWriter filewriter = new StreamWriter(file1);
            for (int i = 1; i <= 100; i++)
            {

                filewriter.WriteLine("Thread number = " + threadnumber + " number= " + i);//writing inside the file from 1 to 100
                Console.WriteLine("Thread number = " + threadnumber + " number= " + i);//writing on console from 1 to 100
            }
            filewriter.Close();
            file1.Close();

            flags[threadnumber] = false;//finishing the thread and exitting the critical section and allowing other threads to enter the critical section

        }
        //that is the version that is used writeIntoFile_peterson
        // in this function more process can enter and will be handled by peterson 
        //handling is done by letting the thread who is equal to the counter chossen by programmer to enter into the critical section
        static public void writeIntoFile_peterson(int threadnumber, string filename)
        {
            // to enforce other threads to not enter into critical section
            //only threadnumber which is equal to counter will enter the critical section

            while (threadnumber != counter)
            {

            }
            //threadnumber which is equal to counter will enter critcal section
            Console.WriteLine("entered critical section ");
            FileStream file1 = new FileStream(filename, FileMode.Append, FileAccess.Write);//creating file using the filename given by user
            StreamWriter filewriter = new StreamWriter(file1);
            for (int i = 1; i <= 100; i++)
            {

                filewriter.WriteLine("Thread number = " + (threadnumber+1) + " number= " + i);//writing inside the file from 1 to 100
                Console.WriteLine("Thread number = " + (threadnumber+1) + " number= " + i);//writing on console from 1 to 100
            }
            filewriter.Close();
            file1.Close();
            counter++;

        }

        //here are filter algorithm(peterson algorithm for N process)
        //The filter algorithm generalizes Peterson's algorithm for N processes. It uses N different levels - each represents another 'waiting room', 
        //before the critical section. Each level will allow at least one process to advance, while keeping one process in waiting
        static public void writeIntoFile_peterson2(int threadnumber, string filename)
        {

            level[threadnumber] = count;
            waiting[count] = threadnumber;

            // two condition to satisfy equation waiting[count] == threadnumber &&(there exists j ≠ count, such that level[j] ≥ count))
            // if two conditions is satisfied will enter infinite loop until one of them are false and then enter the critical section
            while (waiting[count] == threadnumber && change)
            {
                change = false;
                Console.WriteLine(count);
                for (int j = 0; j < no; j++)
                {
                    if (count != j)
                    {
                        if (level[j] >= count)
                        {
                            change = true;
                        }

                    }
                }



            }
            //one of conditions are broke and a process enter the critical section
            Console.WriteLine("entered critical section ");
            FileStream file1 = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter filewriter = new StreamWriter(file1);
            for (int i = 0; i < 100; i++)
            {

                filewriter.WriteLine("Thread number = " + threadnumber + " number= " + i);//writing inside the file from 1 to 100
                Console.WriteLine("Thread number = " + threadnumber + " number= " + i);//writing on console from 1 to 100
            }
            filewriter.Close();
            file1.Close();

            level[threadnumber] = -1;//to intalize that this thread has done it's work
            count++; //increase loop as this function act as a loop
        }
        //racing thread function to intalize threads
        static void racingThreads(string filename)
        {
            for (int i = 0; i < no; i++)
            {
                level[i] = -1;
                if (i < no - 1)
                {
                    waiting[i] = -1;
                }
            }
            //creating 3 threads and passing filename to them
            Thread t1 = new Thread(() => function1(filename));
            Thread t2 = new Thread(() => function2(filename));
            Thread t3 = new Thread(() => function3(filename));
            //starting the 3 thread randomly
            t1.Start();
            t2.Start();
            t3.Start();
        }
        //here is the first thread 
        static public void function1(string filename)
        {
            threadnumber = 0; //act as thread id but intallized by programmer
            writeIntoFile_peterson(threadnumber, filename);//this function is efficient 100 percent so it is the one which is used
            //writeIntoFile_peterson2(threadnumber, filename); filter algorithm doesn't work properly
            //writeIntoFile_peterson1(threadnumber, filename);peterson for 2 process works for function 1 and 2 only
        }
        //here is the second thread
        static public void function2(string filename)
        {

            threadnumber = 1; //act as thread id but intallized by programmer
            writeIntoFile_peterson(threadnumber, filename);//this function is efficient 100 percent so it is the one which is used
            // writeIntoFile_peterson2(threadnumber, filename); filter algorithm doesn't work properly
            //writeIntoFile_peterson1(threadnumber, filename);peterson for 2 process works for function 1 and 2 only
        }
        //here is the third thread
        static public void function3(string filename)
        {

            threadnumber = 2;
            writeIntoFile_peterson(threadnumber, filename);//this function is efficient 100 percent so it is the one which is used
            // writeIntoFile_peterson2(threadnumber, filename); filter algorithm doesn't work properly
            //doesn't use writeIntoFile_peterson1(threadnumber, filename); as it is for 2 process only s
        }


        static void Main(string[] args)
        {
            string filename;
            Console.WriteLine("please enter the name of the file ");
            filename = Console.ReadLine();//taking the name from user and adding .txt to act as a text file
            filename = filename + ".txt";
            racingThreads(filename);//sending to racing threads the name of filename.txt
            Console.ReadLine();
        }
    }
}
//peterson algorithm for n processes protects against starvation!
//Deadlock doesn't occur 
//IN console output it starts from 4 but in file it runs correctly 
