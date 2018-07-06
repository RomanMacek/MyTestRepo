using System;

namespace MultipleInherritance
{

    public interface IClassA
    {
    }

    public class ClassA : IClassA
    {
        private string Id { get; set; }

        public ClassA(string id)
        {
            Id = id;
        }

        public virtual void ShowMsg()
        {
            Console.WriteLine($"Objekt ClassA. ID={Id}");
        }

        public static implicit operator ClassA(int value)
        {
            return new ClassA(value.ToString());
        }

        public static implicit operator int(ClassA classA)
        {
            return Convert.ToInt32(classA.Id);
        }
    }
}