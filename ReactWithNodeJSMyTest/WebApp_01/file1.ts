var a = "nazdar";
var b: string = "nazdar";

var c = {
    firstname: "Roman",
    lastname: "Macek"
};

function Test01( value: number) : number {
    return value * value;
}

class Person {
    //public firstname: string;
    //public lastname: string;

    constructor(public firstname: string, public lastname: string) {
        
    }
    public FullName(): string {
        return this.firstname + "" + this.lastname;
    }
}

var p = new Person("Romanecek", "Macicek");

class PersonEx extends Person{
    age: number;

    public FullName(): string {
        //super.FullName();
        return this.firstname + "" + this.lastname + " (" + this.age + ")";
    }
}