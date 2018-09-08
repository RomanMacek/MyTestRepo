var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var a = "zkracena definice"; // zkracena definice
var b = "plna definice"; // plna definice i s urcenim typu promenne
var c = {
    firstname: "Roman",
    lastname: "Macek"
};
var d = {
    firstname: "Jim",
    lastname: "Hacker"
};
c = d; // c i d jsou stejneho typu, proto muzu mezi ne napsat =
// ***********************************
// ************ funkce ************
// ***********************************
function Test1(a) {
    return a * a;
}
var e = Test1(4);
function Test2A(a) {
    return {
        firstname: "Jim",
        lastname: "Hacker"
    };
}
function Test2B(a) {
    return {
        firstname: "Jim",
        lastname: "Hacker"
    };
}
;
// ***********************************
// ************ classy ************
// ***********************************
var Person1 = /** @class */ (function () {
    function Person1(first, last) {
        this.firstname = first;
        this.lastname = last;
    }
    Person1.prototype.MetodaA = function (info) {
    };
    return Person1;
}());
var p1 = new Person1("Roman", "Macek");
var Person2 = /** @class */ (function () {
    function Person2(first, last) {
        this.first = first;
        this.last = last;
    }
    return Person2;
}());
var p2 = new Person2("Roman", "Macek");
var xx = p2.first;
var Actor = /** @class */ (function (_super) {
    __extends(Actor, _super);
    function Actor() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Actor.prototype.MetodaA = function (info) {
        _super.prototype.MetodaA.call(this, info); // timto rikam aby pouzil puvodni implementaci metody
        // override puvodni implementaci metody z predka
    };
    return Actor;
}(Person1));
var f = {
    firstname: "Jim",
    lastname: "Hacker",
    info: "bla bla bla"
};
var g;
g = f; // muzu toto napsat, i dyz f nema implementaci interface. Ma ale stejne property jako interface a to TypeScriptu staci
//# sourceMappingURL=file1.js.map