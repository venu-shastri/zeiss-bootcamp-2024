




# Crafting Elegant Objects: A Journey from Telescoping Constructors to Builder Pattern

## Introduction

Constructing complex objects in object-oriented programming often involves navigating a maze of challenges. This article explores and traces the evolution from traditional constructors to the pitfalls of telescoping constructors and introduces the elegant solution offered by the builder pattern which eases the efforts of developers while solving certain problems .

## Traditional Constructors

In object-oriented programming, constructors are special methods responsible for initializing an object. They play a crucial role in creating instances of classes.

    class Student {
    
    private: string name;int age;
    
    double gpa;
    
    public:
    
    //Traditional Constructor
    
    Student(string nameArg, int ageArg, double gpaArg) {
    
    name = nameArg;
    
    age = ageArg;
    
    gpa = gpaArg;
    
    }
    
    //Initializer List
    
    Student(string nameArg, int ageArg, double gpaArg): name(nameArg),
    
    age(ageArg),
    
    gpa(gpaArg) {}
    
    };

## Telescopic Constructors

Applications may occasionally need more than one constructor. It’s possible that this is due to a user requirement. However, the issue with multiple constructors is that if you have too many parameters, your code may become unclear / too complex.

### What are telescoping constructors ?

> **Telescoping Constructor Pattern** is a specific type of constructor overloading where each constructor takes one more argument than the  previous one. This pattern is often used when a class has many optional parameters, and it can lead to a large number of constructors  if not managed properly. It's generally considered an anti-pattern because it can become difficult to maintain and understand as the number of parameters grows.

Consider a scenario where a Customer wants to take a bank loan. The customer has to provide some mandatory set of details like name,address, unique identifaction like pan number,aadhar Card. On the other hand , some fields may be optional like phone number or email address . So there is a possibility of multiple types of Customers based on set of features they have .

![Customer Bank Loan Scenario](https://github.com/Prodeep0312/Fresher-Bootcamp-2024/blob/main/Article/scenario.jpg)






To implement this problem , one solution could be to use telescopic constructor .  
 

    class Customer {
    private:
        string name;
        string address;
        string panNumber;
        string aadharNumber;
        long long phone;
        string email;
    
    public:
        Customer(string nameArg, string addressArg, string panNumberArg, string aadharNumberArg)
            : name(nameArg), address(addressArg), panNumber(panNumberArg), aadharNumber(aadharNumberArg), phone(0), email("") {}
    
        Customer(string nameArg, string addressArg, string panNumberArg, string aadharNumberArg, long long phoneArg)
            : name(nameArg), address(addressArg), panNumber(panNumberArg), aadharNumber(aadharNumberArg), phone(phoneArg), email("") {}
        Customer(string nameArg, string addressArg, string panNumberArg, string aadharNumberArg, string emailArg)
            : name(nameArg), address(addressArg), panNumber(panNumberArg), aadharNumber(aadharNumberArg), phone(0), email(emailArg) {}
    
        Customer(string nameArg, string addressArg, string panNumberArg, string aadharNumberArg, long long phoneArg, string emailArg)
            : name(nameArg), address(addressArg), panNumber(panNumberArg), aadharNumber(aadharNumberArg), phone(phoneArg), email(emailArg) {}
    };



In this version, each constructor adds one more parameter compared to the previous constructor.
However the above code suffers from following **limitations** :-

**1) Code Duplication**

In telescoping constructor , if there are common initialization steps among multiple constructors, we may need to duplicate the code in each overloaded constructor. This can lead to code redundancy and increases the chance of errors if the common initialization logic changes.

**2)Maintenance Overhead**

As the number of constructors increases, maintaining and updating the class becomes more challenging. If we need to make changes to the common initialization logic, we have to update it in multiple places, which can be error-prone and time-consuming.

## Delegating Constructors

In the delegating  constructor pattern, each constructor with additional parameters calls the constructor with fewer parameters 

This pattern is useful when you want to allow the creation of objects with varying numbers of parameters, 

Here's an example of delegating constructor for the Customer class:

    class Customer {
    
    private:
    
    string name;
    
    string address;
    
    string panNumber;
    
    string aadharNumber;
    
    long long phone;
    
    string email;
    
    public:
    
    
    
    Customer(string nameArg,  string addressArg,
    
    string panNumberArg, string aadharNumberArg)
    
    : name(nameArg), address(addressArg), panNumber(panNumberArg), aadharNumber(aadharNumberArg), phone(0), email("") {}
    
    
    Customer(string nameArg, string addressArg,
    
    string panNumberArg,  string aadharNumberArg,
    
    long long phoneArg)
    
    : Customer(nameArg, addressArg, panNumberArg, aadharNumberArg) {
    
    phone = phoneArg;
    
    }
    
 
    Customer(string nameArg,  string addressArg,
    
    string panNumberArg,  string aadharNumberArg,
    
    string emailArg)
    
    : Customer(nameArg, addressArg, panNumberArg, aadharNumberArg) {
    
    email = emailArg;
    
    }
    
    
    
    Customer(string nameArg,  string addressArg,
    
    string panNumberArg,  string aadharNumberArg,
    
    long long phoneArg,  string emailArg)
    
    : Customer(nameArg, addressArg, panNumberArg, aadharNumberArg, phoneArg) {
    
    email = emailArg;
    
    }
    
    };

### Advantages Over Telescoping  Constructor

Delegating  constructors provide flexibility by allowing the creation of objects with different parameter sets and reduces code duplication as the mandatory parameters initialization is done only once .

### Disadvantages

Here the construction of the Customer object is tightly coupled with its representation because we are using the Customer class constructor.

**1)**Complexity****

While delegating constructors can simplify the code by reusing initialization logic, they can also introduce complexity, particularly in cases where there are many constructors with complex initialization logic. Understanding the flow of initialization through multiple levels of delegation can be challenging

**2)**Dependency****

Delegating constructors create a dependency between constructors (tightly coupled ) . If you change the base constructor, all delegating constructors that call it will also need to be updated. This can make maintenance more difficult, especially in large projects



So, with the building pattern, we’ll be able to solve this problem.

## Solution of Delegating Constructors- Builder Pattern

The builder pattern emerges as a superior solution to the issues associated with delegating  constructors:

### What is Builder Pattern?

> The Builder pattern is an object creation design pattern whose  intent is to separate the construction of a complex object from  its representation using a Builder class. By doing so, the same construction process can lead to different representations.This means that the actual object being constructed doesn't need to know how it's being built.

### Implementation of Builder Pattern

Let's explore the implementation of the builder pattern using a Computer class:

    #include <iostream>
    
    #include <string>
    
    using namespace std;
    
    class Customer {
    
    private:
    
    string name;
    
    string address;
    
    string panNumber;
    
    string aadharNumber;
    
    long long phone;
    
    string email;
    
    public:
    
    Customer(string nameArg, string addressArg, string panNumberArg, string aadharNumberArg )
    
    : name(nameArg), address(addressArg), panNumber(panNumberArg),
    
    aadharNumber(aadharNumberArg) {}
    
    void setPhone(long long phoneArg){
    
    phone=phoneArg;
    
    }
    
    void setEmail(string emailArg){
    
    email=emailArg;
    
    }
    
    void displayInfo()  {
    
    //display logic
    
    }
    
    };
    
    class CustomerBuilder {
    
    private:
    
    Customer* customer;
    
    public:
    
    CustomerBuilder(string name, string address, string pan, string adhaar) {
    
    customer = new Customer(name, address, pan, adhaar);
    
    }
    
    CustomerBuilder* setPhone(long long phoneArg) {
    
    customer->setPhone(phoneArg);
    
    return this;
    
    }
    
    CustomerBuilder* setEmail(string emailArg) {
    
    customer->setEmail(emailArg);
    
    return this;
    
    }
    
    Customer* getInstance() {
    
    return customer;
    
    }
    
    };
    
    int main() {
    
    Customer* customer1 = (new CustomerBuilder{" Prodeep ", "Blr", "ADDRV007", "ADH546899"})->getInstance();
    
    customer1->displayInfo();
    
    Customer* customer2 = (new CustomerBuilder{"Prodeep", "Blr", "ADDRV007", "ADH546899"})->setPhone(12345)->getInstance();
    
    customer2->displayInfo();
    
    Customer* customer3 = (new CustomerBuilder{" Prodeep ", "Blr", "ADDRV007", "ADH546899"})->setEmail("vgk@v.com")->getInstance();
    
    customer3->displayInfo();
    
    Customer* customer4 = (new CustomerBuilder{" Prodeep ", "Blr", "ADDRV007", "ADH546899"})->setPhone(12345)->setEmail("vgk@v.com")->getInstance();
    
    customer4->displayInfo();
    
    return 0;
    
    }

### Advantages of the Builder Pattern

**1)Modular Construction**

Each feature has a dedicated method in the builder, keeping the main class clean.

**2)Fluent Interface**

Chaining builder methods in the main creates a readable and user-friendly construction process.

**3)Flexibility**

Adding or removing features becomes simple by modifying the builder without touching the main class.

## Conclusion: Embracing Stability and Elegance

The transition from telescoping constructors to the builder pattern signifies a paradigm shift in object construction. While telescoping constructors have their uses, the builder pattern offers a superior, elegant, and maintainable solution, particularly for complex objects with multiple optional parameters. Adopting the builder pattern in class design contributes to cleaner code, improved readability, and a more satisfying object-oriented experience. Say goodbye to the shaky toothpick tower and welcome the stability and elegance of the builder pattern.


