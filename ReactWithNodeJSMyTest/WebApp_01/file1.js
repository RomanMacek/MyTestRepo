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
var a = "nazdar";
var b = "nazdar";
var c = {
    firstname: "Roman",
    lastname: "Macek"
};
function Test01(value) {
    return value * value;
}
var Person = /** @class */ (function () {
    //public firstname: string;
    //public lastname: string;
    function Person(firstname, lastname) {
        this.firstname = firstname;
        this.lastname = lastname;
    }
    Person.prototype.FullName = function () {
        return this.firstname + "" + this.lastname;
    };
    return Person;
}());
var p = new Person("Romanecek", "Macicek");
var PersonEx = /** @class */ (function (_super) {
    __extends(PersonEx, _super);
    function PersonEx() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    PersonEx.prototype.FullName = function () {
        //super.FullName();
        return this.firstname + "" + this.lastname + " (" + this.age + ")";
    };
    return PersonEx;
}(Person));
//# sourceMappingURL=file1.js.map