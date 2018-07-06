using System;

namespace MultipleInherritance
{
    public interface IClassB
    {

    }

    public class ClassB //: IClassB
    {
        private string Id { get; set; }

        public ClassB(string id)
        {
            Id = id;
        }

        public void ShowMsg()
        {
            Console.WriteLine($"Objekt ClassB. ID={Id}");
        }
    }

    public class ClassBAux : ClassB
    {
        internal ClassC classC;

        public ClassBAux(string id) : base(id)
        {
            
        }

        //public static implicit operator ClassC(ClassBAux classBAux)
        //{
        //    return classBAux.classC;
        //}
    }
}