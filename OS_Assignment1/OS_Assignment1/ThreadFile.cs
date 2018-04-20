using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
namespace OS_Assignment1
{
    class ThreadFile
    {

        // the array of string contain 25 elemnts which is required in the program and will be written 
        //in the file by the 5 threads but with different numbers of elements according to each thread
        // it is defined there to be global for functions to access the array
        string[] Numbers = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Twenty-One", "Twenty-Two", "Twenty-Three", "Twenty-Four", "Twenty-Five" };
        // for counting how many words each thread will write in file
        int count;
        // this is the function responsible for writin in file it contain the follows
        // 1.FileStream to create new file , StreamWriter to write in file 
        //2. it contain a for loop for counting how many words will be written by each thread
        // the count variable is passed in each thread function according to how many words
        //3.the if condition in the loop to concatenate the name of the thread function to words
        // written in file Ex: Thread1 : one
        // then the close of the StreamWriter and the File


        public void write()
        {

            FileStream RW = new FileStream("RW.txt", FileMode.Append, FileAccess.Write);
            StreamWriter write = new StreamWriter(RW);
      
                for (int i = 0; i < count; i++)
                {
                    if (count == 5)
                    {
                        write.Write("Thread1 :");
                        write.WriteLine(Numbers[i]);
                    }
                    else if (count == 10)
                    {
                        write.Write("Thread2 :");
                        write.WriteLine(Numbers[i]);
                    }
                    else if (count == 15)
                    {
                        write.Write("Thread3 :");
                        write.WriteLine(Numbers[i]);
                    }
                    else if (count == 20)
                    {
                        write.Write("Thread4 :");
                        write.WriteLine(Numbers[i]);
                    }
                    else if (count == 25)
                    {
                        write.Write("Thread5 :");
                        write.WriteLine(Numbers[i]);
                    }

                }

                write.WriteLine("--------");

                write.Flush();
                write.Close();
                RW.Close();
            }
        


        // this function is to reading the content of the file and contain the following
        //1.FileStream , StreamReader for accesing the File and Read the Content of it and
        //In the FileStream it is given the Same FileName Given in FileStream In Write() Function
        //2. the variable Str to hold the content of the File and for loop to check that all File
        // is read.
        //3. then Close of the StreamWriter and FileStream
        public void read()
        {
            lock (this)
            {
                FileStream RW = new FileStream("RW.txt", FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(RW);
                Console.WriteLine("Here is the Content of the File");
                string str = read.ReadLine();
                while (str != null)
                {
                    Console.WriteLine(str);
                    str = read.ReadLine();

                }
                Console.ReadLine();
                read.Close();
                RW.Close();
            }
        }
        // this the beginig of the Thread Functions which is 5 
        // Thread1() function  is the first thread and contain the following 
        // 1.assingnment of the count varible to be passed to the for loop in the write function 
        // to take the elements form the Numbers array and write it in the function
        //2.The Creation of the new Thread (Thread t1 = new Thread(write)) 
        //and we pass to it the write function to link the thread to hte write function
        // t1.Start() to make the thread running 
        //T1.Join() to give the Thread the Highest Priority to run 

        public void Thread1()
        {
            lock (this)
            {
                count = 5;
                write();
            }
            //  Thread t1 = new Thread(write);
            // t1.Start();


        }
        public void Thread2()
        {
            lock (this)
            {
                count = 10;
                write();
            }
            //  Thread t2 = new Thread(write);
            // t2.Start();

        }

        public void Thread3()
        {
            lock (this)
            {
                count = 15;
                write();
            }
            /*
            Thread t3 = new Thread(write);
            t3.Start(1);
            t3.Join();
            */
        }
        public void Thread4()
        {
            lock (this)
            {
                count = 20;
                write();
            }
            /*
            Thread t4 = new Thread(write);
            t4.Start();
            t4.Join();
            */
        }
        public void Thread5()
        {
            lock (this)
            {
                count = 25;
                write();
            }
            /*
            Thread t5 = new Thread(write);
            t5.Start();
           t5.Join();
             */
        }

    }
}
