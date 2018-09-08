var a = "zkracena definice";       // zkracena definice
var b: string = "plna definice";   // plna definice i s urcenim typu promenne

var c = {                          // Herceg tomu rika "anonymni typ"
    firstname: "Roman",
    lastname: "Macek"
};
var d = {
    firstname: "Jim",
    lastname: "Hacker"
};
c = d ;            // c i d jsou stejneho typu, proto muzu mezi ne napsat =

// ***********************************
// ************ funkce ************
// ***********************************
function Test1(a: number) : number {
    return a * a;
}
var e = Test1(4);

function Test2A(a: number)  {
    return {
        firstname: "Jim",
        lastname: "Hacker"
    };
}

function Test2B(a: number): { firstname: string; lastname: string }
{
    return {
        firstname: "Jim",
        lastname: "Hacker"
    };
};
// ***********************************
// ************ classy ************
// ***********************************
class Person1 {
    public firstname: string;
    public lastname: string;

    constructor(first: string, last: string) {
        this.firstname = first;
        this.lastname = last;
    }
    public MetodaA(info : string) : void {
        
    }
}
var p1 = new Person1("Roman", "Macek");

class Person2 {
    public age: number;
    private pomocna: string;

    constructor(public first: string, public last: string)  // kvuli parametru public TypeScript sam prida tyto property (first + last) do teto classy
    {
    }
}
var p2 = new Person2("Roman", "Macek");
var xx = p2.first;

class Actor extends Person1 {

    public moviesPlayed: string[];

    public MetodaA(info: string): void {
        super.MetodaA(info);  // timto rikam aby pouzil puvodni implementaci metody

        // override puvodni implementaci metody z predka
    }
}

// ***********************************
// ************ interface ************
// ***********************************
interface IPersonName {
    firstname: string;
    lastname: string;
   // age: number;
}

var f = {
    firstname: "Jim",
    lastname: "Hacker",
    info: "bla bla bla"
};
var g: IPersonName;
g = f;  // muzu toto napsat, i dyz f nema implementaci interface. Ma ale stejne property jako interface a to TypeScriptu staci
