using System;

namespace MultipleInherritance
{
    public class ClassOA
    {
        public string Id;

        public ClassOA(string id)
        {
            Id = id;
        }

        public void ShowMsgA()
        {
            Console.WriteLine($"ClassOA: {Id}");
        }
    }
}