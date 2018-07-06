using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MultipleInherritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3();
            Console.ReadLine();
        }

        private static void Test3()
        {
            ClassOA oa = new ClassOA("OA");
            ClassOB ob = new ClassOB("OB");
            ClassOC oc = new ClassOC("OC", "Jmeno OC");

            ClassOB ob2 = oc.classOB;

            oa.ShowMsgA();
            ob.ShowMsgB();
            oc.ShowMsgC();
            ob2.ShowMsgB();

        }

        private static void Test2()
        {
            ClassA a1 = 100;
            int id1 = a1;

            ClassA a2 = new ClassA("Pokus");
            int id2 = a2;
        }

        private static void Test1()
        {
            var a1 = new ClassA("A1");
            var a2 = new ClassA("A2");

            var b1 = new ClassB("B1");
            var b2 = new ClassB("B2");

            var c1 = new ClassC("C1", "Jmeno 1", "Prijmeni 1");
            var c2 = new ClassC("C2", "Jmeno 2", "Prijmeni 2");

            ClassA[] arrayA = { a1, a2, c1, c2 };
            ClassB[] arrayB = { b1, b2, c1, c2 };
            ClassC[] arrayC = { c1, c2 };

            //foreach (var arr in arrayA)
            //{
            //    arr.ShowMsg();
            //}

            foreach (var arr in arrayB)
            {
                arr.ShowMsg();
            }

            foreach (var arr in arrayC)
            {
                arr.ShowMsg();
            }
        }
    }
}
