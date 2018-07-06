using System;

namespace MultipleInherritance
{
    public class ClassOC : ClassOA
    {
        public string Id;
        public string Jmeno;
        internal ClassOB classOB;

        public ClassOC(string id, string jmeno) : base(id)
        {
            Id = id;
            Jmeno = jmeno;
            classOB = new ClassOB(id);
        }

        public void ShowMsgC()
        {
            Console.WriteLine($"ClassOC: {Id}");
        }

        public static implicit operator ClassOB(ClassOC classOC)
        {
            return classOC.classOB;
        }
    }
}