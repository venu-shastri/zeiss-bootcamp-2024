# Exploring Functional Programming Paradigm: Achieve Parallelism, Testability and Reusability with Lesser Code
Paradigms in programming refer to the fundamental styles or approaches used to design and structure code.
There are several programming paradigms, each with its unique characteristics and principles.
In this article, we will delve into the Functional Programming (FP) paradigm, exploring its features, 
real-life applications, and considerations when choosing it or opting for other paradigms.

Before we dive into the Functional Programming paradigm, 
let's briefly touch on two most important programming paradigms - 
  * **Imperative Programming:**
      * It focuses on describing how a program should execute step by step.
      * It uses statements that change a program's state.
      * Includes Object Oriented Programming as a subparadigm.
        
  * **Declarative Programming:**
      * Describes what a program should accomplish without specifying how to achieve it.
      * Includes Functional Programming as a subparadigm.

## What is Functional Programming?

Functional programming is a programming paradigm that treats computation as the evaluation of mathematical functions and avoids changing-state and mutable data. Key principles of FP include immutability, first-class functions, and the absence of side effects. 
It is inspired by lambda calculus, a formal system in mathematical logic for expressing computation.
Let's understand the characteristics of Functional Programming Paradigm in depth.

## Features of Functional Programming - 

### 1. Immutability :

Once data is defined, it cannot be changed. This means that variables, once assigned a value, remain constant throughout their lifetime. This leads to several benefits:

  * **Predictability**: Since data does not change, the behavior of a program becomes more predictable. Functions operate on fixed inputs, ensuring consistent outputs.
    
  * **Concurrency**: Immutability facilitates easier management of concurrent operations. With no shared mutable state, there are fewer concerns about race conditions in a multi-threaded environment.
    
  * **Debugging**: Debugging becomes more straightforward because the state of variables is constant, reducing the chances of unexpected changes.

### 2. First-Class Functions:

In functional programming, functions are treated as first-class citizens. This means functions can be passed as arguments to other functions, returned as values from other functions and  can be assigned to variables.

```c#
std::function<bool(std::string)> startswithA = checkStringStartWithAny("A");
std::vector<std::string> filterStartWithA = filter(arr, startswithA);
```

### 3. Pure Functions:

Pure functions are functions with two main properties:

  * **Deterministic:** Given the same inputs, a pure function will always produce the same outputs.

  * **No Side Effects:** A pure function does not modify external state or have observable side effects.

Pure functions enable numerous compiler optimizations, leading to significantly reducing a program’s execution time and are ideally suited for unit testing.

``` c#
bool starts_with_lowercase(string element){
    if(islower(element[0])){
        return true;
    }
    return false;
}
```


### 4. Referential Transparency:

Referential transparency is a property of expressions in a program. An expression is referentially transparent if it can be replaced with its value without changing the program's behavior.

### 5. Higher-order Functions:

A higher-order function takes a function as its input, performs an operation on the input function, and subsequently returns a function.

### 6. Closures

A closure is a function bundled together with references to its surrounding state, enabling the function to access variables from the outer scope even after the outer function has finished execution. Closures provide a way to create private variables, implement data hiding, and design functions that carry their context with them. This feature enhances encapsulation and enables the creation of more modular and flexible code.

```c#
// Implementing closure
std::function<bool(std::string)> checkStringStartWithAny(std::string startString){
    std::function<bool(std::string)> predicateFuncObj = [&](std::string stringItem) { return stringItem.starts_with(startString); }
    return predicateFuncObj;
}
```

### 7. Function Chaining

Function chaining is a technique in Functional Programming that involves invoking multiple functions in a sequence, where each function returns an object or value that can be used as the input for the next function in the chain.

## When to Use Functional Programming?

### 1. Concurrency and Parallelism:
Functional Programming's emphasis on immutability and pure functions makes it inherently suitable for concurrent and parallel programming. By avoiding mutable state, Functional Programming minimizes the need for locks and allows for seamless parallel execution. This makes Functional Programming a preferred choice for applications dealing with large-scale data processing or distributed systems.

For example: In a data-processing application that needs to handle multiple streams of data concurrently. Functional programming can be employed to design pure functions that process each stream independently, facilitating efficient parallel execution. Another example can be in a real-time financial system, functional programming can be advantageous to ensure accurate and consistent processing of multiple transactions concurrently.

### 2. Predictable and Testable Code:
The immutability and purity of functions make code in FP more predictable and easier to test. Without side effects, unit testing becomes straightforward, as functions can be isolated and tested independently, reducing the likelihood of unexpected behaviors.

For example: In a financial application where precision and accuracy are critical, employing functional programming can lead to the creation of pure functions for calculations. This ensures that each financial calculation produces consistent results, simplifying testing and validation.

### 3. Declarative Style:
Functional Programming encourages a declarative programming style, where the emphasis is on what needs to be done rather than how it should be done. This makes the code more concise, readable, and expressive, promoting better maintainability and understandability.

For example: In a web development scenario, using functional programming for UI components can lead to more declarative and modular code. This allows developers to describe the structure and behavior of components without explicitly detailing the step-by-step procedures.

### 4. Code Reusability:
Functional Programming promotes modular and reusable code, as functions are isolated and do not rely on external state. This can lead to more maintainable and scalable software.

For example: When developing libraries or frameworks where modularity is crucial for future extensions or integrations, FP can provide a robust foundation.

## When Not to Use Functional Programming:

### 1. Performance-Critical Applications:
In scenarios where performance is a top priority, such as low-level systems programming or resource-intensive applications, Functional Programming may introduce overhead due to its emphasis on immutability.

For example: Real-time systems, such as operating systems or embedded applications, where direct manipulation of hardware and memory is necessary, might not benefit from the functional programming paradigm.

### 2. Learning Curve and Team Familiarity:
Functional paradigm can have a steeper learning curve, especially for developers accustomed to imperative or OOP paradigms. In projects with tight deadlines and a need for rapid development, this learning curve might be a hindrance.

Example: In startup environments with rapidly changing requirements, OOP might be a more pragmatic choice for quicker development cycles.

## Trade Off Between Functional Programming Paradigm and Object Oriented Programming Paradigm

| Feature                       | Functional Programming (FP)                | Object-Oriented Programming (OOP)          |
|-------------------------------|--------------------------------------------|--------------------------------------------|
| **State Management**          | Emphasizes immutability and avoids state changes | Manages state through objects and encapsulation |
| **Data Mutation**             | Avoids mutable data and favors immutability | Allows mutable state within objects        |
| **Side Effects**              | Minimizes or eliminates side effects         | Allows side effects, especially within methods |
| **Concurrency**               | Well-suited for concurrent and parallel programming | May require synchronization mechanisms due to mutable state |
| **Testing**                   | Easier to test due to pure functions and immutability | Testing can be more complex due to potential side effects |
| **Coding Style**              | Declarative, focuses on "what" needs to be done | Imperative, focuses on "how" things should be done |
| **Code lines**              | Requires much lesser no. of lines of codes | Increases amount of code |

