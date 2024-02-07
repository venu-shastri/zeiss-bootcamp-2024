# Understanding the Diamond Problem in Object-Oriented Programming
When it comes to object-oriented programming, where inheritance and polymorphism are frequently used, developers frequently face fascinating problems that call for creative fixes. One such difficulty is the Diamond Problem, a well-known puzzle that appears in languages that allow for multiple inheritance.

Imagine that we have two classes, Printer and Scanner, that each include two different functionalities. Both classes are derived from the Device class. Printer and Scanner are two distinct classes that provide printing and scanning functionalities, respectively. 

```c++
class Device{
    private:
        string id;
    protected:
        Device(string idArg):id{idArg}{}
    public:
        string getDeviceId(){ return this->id; } 
};
```
```c++
class Printer: public Device{
    public:
	    Printer(){}
	    Printer(string idArg): Device::Device{idArg}{}
	    void print(string path){
	        cout<<"Printing ....."<<path;
	    }
};
```
```c++
class Scanner: public Device{
    public:
	    Scanner(){}
	    Scanner(string idArg): Device::Device{idArg}{}
	    void scan(string path){
	        cout<<"Scanning ....."<<path;
	    }
};
```
The `TaskManager` class performs the role of an orchestrator by offering a practical interface for carrying out operations like printing and scanning. Its static methods `executePrintTask` and `executeScanTask` take a document path as input and accept instances of the `Printer` and `Scanner` classes, respectively. These techniques use the associated print or scan functionality.
```c++
public  class TaskManager{
    public:
     static void executePrintTask(Printer *printer,string documentPath){
        printer->print(documentPath);
    }
     static void executeScanTask(Scanner *scanner,string documentPath){
            scanner->scan(documentPath);
    }
};
```

We have a problem when a new demand emerges, like the necessity for a device that can print and scan. How do we represent this new functionality without repeating code or breaking rules like the DRY (Don't Repeat Yourself) principle?

Using multiple inheritance appears to be one possible option. We can easily combine the features of printing and scanning into one single entity by letting the new class, `PrintScanner`, inherit from both `Printer` and `Scanner`. This method offers a direct mapping of the issue domain to the object-oriented paradigm, making it initially seem natural and simple.
## The Diamond Dilemma
![DiamondProblem](https://github.com/PradhipJ/Freshers-Bootcamp/assets/96421552/620ee0df-8049-431b-8e01-05e38a040307)
One important question that comes up when we instantiate a `PrintScanner` object is: **How many instances of the Device class are created?** The answer might not be obvious right away because inheritance is hierarchical. The possibility of having duplicate instances of a device is high because Printer and Scanner are the two direct parents who inherit from Device.

In addition, the issue of method resolution in the `PrintScanner` class is still open. **Should `PrintScanner` yield to the functionality contained in Printer or Scanner when calling device-specific methods, such `getDeviceId()`?** The robustness and clarity of our software architecture are undermined by the ambiguity caused by the lack of a clear resolution strategy.

## Virtual Inheritance: A Solution
The virtual keyword in the context of inheritance is a feature of the C++ programming language that helps to alleviate the problems caused by the Diamond Problem. No matter how many times the Device class is indirectly inherited, we can guarantee that just one instance of it is created by utilizing virtual inheritance in the Printer and Scanner classes.

By explicitly calling the `Device` constructor within the `PrintScanner` class, we assert a clear path to the base class, eliminating any uncertainty regarding object creation.
```c++
class Device{
    private:
        string id;
    protected:
        Device(){}
        Device(string idArg):id{idArg}{}
    public:
        string getDeviceId(){ return this->id; } 
        ~Device(){}
};

class Printer:virtual public Device{
    public:
    Printer(){}
    Printer(string idArg): Device::Device{idArg}{}
     void print(string path){
        cout<<"Printing ....."<<path<<endl;
    }
};

class Scanner:virtual public Device{
    public:
    Scanner(){}
    Scanner(string idArg): Device::Device{idArg}{}
     void scan(string path){
        cout<<"Scanning ....."<<path<<endl;
    }
};

class PrintScanner: public Printer, public Scanner {
    public:
    PrintScanner(string idArg): Device::Device{idArg}{}
    ~PrintScanner(){}
};

class TaskManager{
    public:
     static void executePrintTask(Printer *printer,string documentPath){
        printer->print(documentPath);
    }
     static void executeScanTask(Scanner *scanner,string documentPath){
            scanner->scan(documentPath);
    }
};

int main(){
    Printer printerObj("p1");
    Scanner scannerObj("s1");
    PrintScanner printScannerObj("ps1");

    TaskManager::executePrintTask(&printerObj,"Test.doc");
    TaskManager::executeScanTask(&scannerObj,"MyImage.png");
	TaskManager::executePrintTask(&printScannerObj,"NewDoc.doc");
    TaskManager::executeScanTask(&printScannerObj,"YourImage.png");
}
```
## Resolving the Diamond Problem with a design-centric approach
Although there is a solution in the simple use of multiple inheritance, a more sophisticated strategy is shown by the adoption of composition and the composite pattern. 

Rather of relying on the painstaking details of multiple inheritance, which frequently result in the notorious "Diamond Problem," we take a more tasteful approach by building the `PrintScanner` class from separate Printer and Scanner components.

### Reframing our Design
![PrintScannerDesign](https://github.com/PradhipJ/Freshers-Bootcamp/assets/96421552/4a00f2ca-15ca-4ccc-a0e6-085a23321bac)
A key component of our design is the Composite Pattern, which enables us to handle individual and composite devices equally. We create a uniform contract for printing and scanning operations, independent of the underlying device implementation, by implementing interfaces like `IPrinter` and `IScanner`.
```c++
class IPrinter{
    public:
        virtual void print(string path) = 0;
};

class IScanner{
    public:
        virtual void scan(string path) = 0;
};
```

The `PrintScanner` class is designed to enable a clear and unambiguous integration of printing and scanning operations through the use of interfaces, namely, `IPrinter` and `IScanner`. `PrintScanner` circumvents the complexities of multiple inheritance by implementing these interfaces, avoiding problems with incompatible method implementations and unclear object instantiation.

```c++
class Printer:public Device, public IPrinter{
    public:
    Printer(){}
    Printer(string idArg): Device::Device{idArg}{}
     void print(string path){
        cout<<"Printing ....."<<path<<endl;
    }
};

class Scanner:public Device, public IScanner{
    public:
    Scanner(){}
    Scanner(string idArg): Device::Device{idArg}{}
     void scan(string path){
        cout<<"Scanning ....."<<path<<endl;
    }
};

class PrintScanner:public Device, public IPrinter, public IScanner {
    private:
        Printer printer;
        Scanner scanner;
    public:
        PrintScanner(string idArg) :  Device::Device(idArg){}
        ~PrintScanner() {}
        void print(string path) {
            printer.print(path);
        }
        void scan(string path) {
            scanner.scan(path);
        }
};

class TaskManager{
    public:
    static void executePrintTask(IPrinter *printer,string documentPath){
            printer->print(documentPath);
    }
    
    static void executeScanTask(IScanner *scanner,string documentPath){
            scanner->scan(documentPath);
    }
};
```
The latter approach to the scenario adheres to best practices in software engineering and is thoughtfully designed, showing a dedication to durability and extensibility. The code lessens the difficulties posed by the "Diamond Problem" and the drawbacks of conventional inheritance hierarchies by prioritizing composition over inheritance. The code uses composition to build complex objects from basic components rather than depending on a strict inheritance structure where classes are tightly related and alterations to one class can have cascading effects on others.
## Conclusion
We began our investigation of the Diamond Problem by looking at the simple use of multiple inheritance, which is an alluring but risky route full of ambiguity and complexity. We discovered problems with object instantiation ambiguity and method call ambiguity by inheriting the printing and scanning functionality directly into the `PrintScanner` class, highlighting the drawbacks of a naive approach. A design environment that is cohesive, extensible, and clear was established with the use of the `IPrinter` and `IScanner` interfaces and the use of Composite Design Pattern.

Design principles must be applied in software development in order to create reliable and maintainable systems. Software develops from simple utility to elegant, long-lasting solutions through careful design decisions, opening the door for creativity and adaptability in a rapidly changing technical environment.

