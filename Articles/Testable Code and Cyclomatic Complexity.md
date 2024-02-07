# Testable Code and Cyclomatic Complexity

### How to write code for testability, not for results. Tools and metrics to analyze the degree of testability. Cyclomatic Complexity.

## Why Testable Code?
Writing testable code is essential for ensuring the reliability, maintainability, and scalability of software projects. By embracing testability, developers can:
- **Enhance Quality Assurance**: Testable code facilitates the creation of comprehensive test suites, enabling thorough testing of various scenarios and reducing the likelihood of undetected bugs slipping into production.
- **Promote Code Reusability**: Testable code tends to be modular and well-structured, making it easier to reuse components across different parts of the codebase or in future projects.
- **Improve Collaboration**: Testable code encourages clear documentation, well-defined interfaces, and standardized coding practices, fostering better collaboration among team members and reducing communication overhead.

## How to Write Testable Code
### Follow Single Responsibility Principles
Adhering to the Single Responsibility Principle (SRP) is crucial for writing testable code. Avoiding "God" classes or functions that handle too many responsibilities simplifies testing and maintenance. Consider a real-life example.
**Example:** In a banking application, instead of having a single `Bank` class responsible for customer management, transaction processing, and account handling, separate classes like `CustomerManager`, `TransactionProcessor`, and `AccountHandler` should be created. Each class has a clear and distinct responsibility, making it easier to test and modify.

### Use Interfaces for Class Communication
Encourage classes to communicate through interfaces rather than directly interacting with each other. This approach facilitates easier mocking during testing. Consider the following example.
**Example:** In a messaging application, instead of classes directly calling methods of other classes to send messages, they should communicate through a common `MessageService` interface. This abstraction allows for easier mocking of the message sending process during unit tests.

### Embrace Dependency Injection (DIP)
Dependencies should be abstracted and injected into classes rather than hardcoded. Dependency Injection (DI) enables easier testing by allowing mock or stub dependencies to be injected during testing.

### Function Purity
Functions should be pure, meaning they do not perform I/O operations or rely on global variables. Pure functions produce the same output for a given input, making them easier to test and reason about.

### Avoid Singleton Classes
While singletons can be convenient, they can also introduce testing challenges due to their global state. Whenever possible, avoid singleton classes unless absolutely necessary for maintaining state.

By following these principles and practices, developers can write code that is inherently testable, leading to higher-quality software products and more efficient development processes.

## Path Testing
While unit testing, it has to be ensured that every possible execution path of the program is tested. We need *100% Code Coverage* with our testcases. This is called **Path Testing**. 

The starting point for path testing is creating a program flow graph. This is a directed graph that models all possible flows of control through a function. 
- Vertices represent decisions.
- Edges represent flow of control.

So, each branch in if-elseif-else ladders are shown as separate paths. The same goes for switch-case statements. Loops are represented by an arrow from the decision vertex to the same decision vertex.

Please refer to the following example to gain a better understanding. 
The following pseudocode is for a function that goes through an array of numbers and maintains a count of the following for each number.
- Checks if the number is prime, *otherwise*
- Checks if the number is odd or even.

Note that it only checks for odd or even if the number is not prime.

Pseudocode:
```
Function AnalyzeNumbers(Array<Integer> numbers):
    primeCounter = 0
    oddCounter = 0
    evenCounter = 0
    For each number in numbers:
        if CheckPrime(number):
            primeCounter = primeCounter + 1
        else:
            if num mod 2 == 0:
                evenCounter = evenCounter + 1
            else:
                oddCounter = oddCounter + 1
    End For
    
    return primeCounter, oddCounter, evenCounter
```

Notice that our function calls another function `CheckPrime()` within it. However, the internal working of the `CheckPrime()` function will not contribute to the Cyclomatic Complexity of our function. This is because in unit testing, we test one function or one class at a time, depending on whether we are using Functional Programming or Object Oriented Programming. For instance, when we are testing `AnalyzeNumbers()`, we take it for granted that the function `CheckPrime()` works as it should.

Now, refer to the Flow Graph for our function:
![Figure 1](https://i.imgur.com/tH8rACX.png)

## Cyclomatic Complexity
We can use this flow graph to deduce the Cyclomatic Complexity of our program. There are two ways to do it:
1. Count the number of vertices in the graph, call it `V`. Then count the number of edges, call it `E`. Then, the Cyclomatic Complexity for our function will be given by the formula `E - V + 2`. Our graph has 9 vertices and 11 edges. Therefore, its Cyclomatic Complexity = 11 - 2 + 2 = 4.
2. Count the number of regions that the graph divides the plane into. Here, the graph divides the plane into 4 regions (Don't forget to count the region outside the graph). Therefore, the Cyclomatic Complexity is 4.

Therefore, both methods give us the same solution, a Cyclomatic Complexity of 4. Now, what this means is that the function has 4 possible execution paths:
1. 1->2->3->5->8->9
2. 1->2->3->4->6->8->9
3. 1->2->3->4->7->8->9
4. 1->2->3->5->8->2->...

So, anyone performing unit tests on this function will have to test each of these 4 execution paths thoroughly. This is the effect of Cyclomatic Complexity on unit testing. The smaller our Cyclomatic Complexity is, the easier it is to test. Most DevOps tools that enforce Cyclomatic Complexity requirements do not allow more than a complexity of 3.

## Checking the Cyclomatic Complexity of your Code with Lizard
Tools like Lizard can help us effortlessly measure CC and identify areas for improvement. In this section, we will walk through how to integrate Lizard into your Github workflow to continuously monitor and analyze CC.

### Setting up Lizard in Your Github Workflow
1. **Navigate to Your Repository on Github**. To begin, open your repository on Github where your code resides.
2. **Access Github Actions**. Once in your repository, head over to the "Actions" tab located in the top menu bar.
3. **Initiate Workflow Setup**. Click on *Set up a workflow yourself* to create a custom Github workflow.
4. **Configure Workflow**. Upon initiating the workflow setup, Github will generate a `main.yml` file where you'll define your workflow steps.
5. **Define Workflow Steps**. Within the `main.yml` file, input the following code snippet to set up the Lizard runner. Note: Adjust the value after the `--CCN` flag according to your desired CC threshold.
```
name: Lizard Runner

on:
  push:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - name: Checkout repository
      uses: actions/checkout@v2

    - name: Setup Python
      uses: actions/setup-python@v2
      with:
        python-version: '3.x'

    - name: Install dependencies
      run: pip install lizard

    - name: Run Lizard
      run: lizard . --CCN 3
```
6. **Save and Commit Changes**: Save the changes to your `main.yml` file and commit them to your repository.

### Analyzing Cyclomatic Complexity Results
1. **Navigate to Actions**. After committing your changes, navigate back to the "Actions" tab in your Github repository.
2. **Access Workflow Run**. Locate the latest workflow run corresponding to your recent commit and click on it.
3. **View Lizard Results**. Within the workflow run details, find and click on "Build" followed by "Run Lizard." After a brief moment, Lizard will display a comprehensive breakdown of Complexity details, allowing you to identify specific functions with their respective complexities.


In conclusion, writing testable code is crucial for the success of software projects. By following best practices such as adhering to Single Responsibility Principles, using interfaces for class communication, embracing Dependency Injection, ensuring function purity, and avoiding singleton classes, developers can create code that is easier to test, maintain, and collaborate on.