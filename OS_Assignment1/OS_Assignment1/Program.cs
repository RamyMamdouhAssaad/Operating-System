using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OS_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            FCFS();
          
        }
        static void FCFS()
        {
            ThreadFile fo = new ThreadFile();
            Thread t1 = new Thread(fo.Thread1);
            Thread t2 = new Thread(fo.Thread2);
            Thread t3 = new Thread(fo.Thread3);
            Thread t4 = new Thread(fo.Thread4);
            Thread t5 = new Thread(fo.Thread5);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
          
            fo.read();
            
        }
        static  void RR()
        { }
    }
}

/*
 Name            ID
 Mina Essam      119791
 this program has a class and main program in the main program it contain the Round Robin() method
 and a FCFS() each method and this method define an object form ThreadFile Class which conatin
 the Write() function for writing in file and read() function for reading in file 
 and contain five functions which is Thread1() Thread2() Thread3() Thread4() Thread5()
 and each of this functions write a number of elements
 */
