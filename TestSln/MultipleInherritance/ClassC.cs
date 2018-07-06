using System;

namespace MultipleInherritance
{
    public class ClassC : ClassA
    {
        public string Id;
        public string Jmeno;
        public string Prijmeni;

        internal ClassBAux classBAux;

        public ClassC(string id, string jmeno, string prijmeni) : base(id)
        {
            Id = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;

            classBAux = new ClassBAux(id);
        }

        public override void ShowMsg()
        {
            Console.WriteLine($"Objekt ClassC. ID={Id} /Jmeno={Jmeno} /Prijmeni={Prijmeni}");
        }

        public static implicit operator ClassB(ClassC classC)
        {
            return classC.classBAux;
        }
    }
}