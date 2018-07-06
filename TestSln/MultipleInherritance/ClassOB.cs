using System;

namespace MultipleInherritance
{
    public class ClassOB
    {
        public string Id;
        public ClassOB(string id)
        {
            Id = id;
        }

        public void ShowMsgB()
        {
            Console.WriteLine($"ClassOB: {Id}");
        }
    }
}