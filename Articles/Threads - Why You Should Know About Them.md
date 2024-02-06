## The Problem

Over the course of my programming journey, I have identified a fundamental problem with modern developers: **Result Oriented Programming**, they tend to write code to get an output, but the fundamental rule of software development is not to write code for a machine, but to write code for other developers. This problem is mostly observed with junior developers, people would argue that this can be a simple *lack of experience*.
But I disagree, I could blame the peer pressure of solving 100s of leetcode problems to clear that technical interview, all the leetcode problems' solution contains one class and one function and the adrenaline rush to get an AC on all test cases carries over to development. But I would not do so, I could also blame the "self taught" approach where people join 10 different online courses and 20 different bootcamps all "claiming" to make you learn *xyz* framework or *abc* language in 7 days. 
I think the inherent issue lies within the lack of knowledge about development in general, it is often times not viewed as what it is and if unchecked the junior can carry the habit to a senior position as well.
	There is a well known verse in the programming community: *"Our codebase is held together by duct tape and hope"*

While this may sound funny, it is quite common for corporations to end up in an ultra convoluted and non maintainable codebase that either rewriting the entire solution is more feasible than maintaining the code.

Why am I talking about this in an article about threads? well, I want to get the reader into the context that why theoretical concepts like these are important to a developer. 

Here are 3 fundamental problems that you must work upon if you happen to have them.

1. Writing result oriented code, my code meets the **functional requirements**, it is good enough!
2. Not adhering to design principles.
3. Not understanding how code works behind the scenes.

These problems can be detrimental to writing "clean code", as a developer you should always strive to not make these mistakes. I will try to provide reflection on the third problem in this article. I will use in this article. I will use `C#` for code examples but the article content will remain language independent.

Many of the bootcamps that I mentioned can be a great way to learn about a language but finding a good one that actually teaches you how to code properly is like trying to find a needle in a haystack. People nowadays want to be over achievers , they want to get everything as fast as possible often times without being ready to provide the due diligence required to achieve it. These bootcamps use the thought process of people to lure them into the courses, every day on platforms like LinkedIn and YouTube, I see hundreds of ads on topics such as "learn JavaScript in 7 days, become a game dev with this one course, master data science with this course" etc. etc. That is probably the reason that companies are valuing classroom certifications more over such courses, because you can never be sure if *xyz course* from the pacific of online courses was a good one. I did **react** during my college years and I was too into the bootcamp loop. The plague known as "react-way" has infected countless young minds trying to learn a library. It has become a long running meme in the community, that react devs use a library for everything and it is quite true, the npm package `isEven` has over 250k downloads each week. The average react developer has become so unaware that they are willing to introduce one third party dependency in their project for menial tasks such as this.

## The Solution

	You Must Understand how Your Code does What it Does

This is what a standard computer science degree is structured around, trying to teach you about operating systems, the data structures and other layers of abstractions, that a bad bootcamp will fail to teach you. 

*"If a craftsman wants to do good work, he must first sharpen his tools"*
																			-Confucius

You should learn about the design of the machine, how a piece of code is compiled and executed, what are the operating system concepts that govern your runtime. If you learn these you can write clean and performant code that will take advantage of the machine. Further sections discuss about one such concept "Threading" which is often misunderstood or not understood at all by developers. But first we must talk about parallelism.
## Parallelism

*"Parallelism is a way of doing multiple things at once."*
This concept is not new, it has been around since 1950s, earlier mainframe computers were capable of doing one thing at a time, the sweet era of punchcard am I right? Even though concepts such as SPOOLING were introduces to increase throughput, the need was obvious as the total progress in research was becoming governed by computing time of the mainframe. 

The earliest **Shared Memory Multiprocessors** emerged in the 60s.They allowed multiple processors to access a common memory pool, enabling parallel execution of tasks.

The introduction of **SIMD & MIMD** architectures boosted the computer design more towards parallelism however the pinnacle of parallelism is said to be achieved by Thinking Machine Corps with their Connection Machine CM-1, it had 16 1-bit processors per processor chip, for a total of 4,096 processor chips -- each with an LED.

Parallelism can be many things, multiprocessing, multiprogramming, multithreading etc.

The one we are interested in is multithreading!

## Threads

*"Thread is a smallest unit of execution"*
This is a very bad textbook definition and it never tells the reader what a thread actually is.

Ultimately thread is a block of code like everything in a computer aside from hardware. This is what typically happens when your computer runs a piece of code (simplified for ease of understanding): 
1. **Fetch:** The processor fetches the instructions from the memory whose address is stored in a special register `IP` or instruction pointer register.
2. **Decode:**  This typically involves interpreting the binary representation of the instruction and determining the operation code (opcode) and any associated operands.
3. **Execute:** After decoding the instruction, the processor executes the operation specified by the opcode.

Where does thread come into picture is when we talk about preemption and deal with large amount of blocking code, imagine you are printing a document and your whole computer becomes unusable while doing it, or you are downloading a file and your whole browser stops working before the download has finished, these are the scenarios where Quality Factors such as Turn Around Time, Waiting Time and Response Time come into picture.

A thread is simply a way to segregate blocks of code to make it easier for the processor to break down the work and delegate it to other physical or logical processors (cores). The below image showcases a simple thread structure. Every thread has a very important data structure called its stack which is allocated when the thread spawns, here it stores the thread's execution context, including local variables, function parameters, and return addresses. 

![500](https://i.imgur.com/SgiAVF8.png)

### The difference between a process and a thread

Threads are created with performance in mind, a thread does not have its own dedicated memory but it uses a shared pool of resources, a process can spawn threads, the context switch time is very less compared to a process. You can find about the number of processes and threads running on your machine, for example in Linux

```bash
ps -e | wc -l
```

This tells you about the number of processes running on your machine, and to view the number of threads you can do

```bash
ps -o nlwp <pid>
```

where `pid` is the number of processes for a thread. NLWP stands for number of lightweight processes (threads)

You can see a process owning a large number of threads.

## Multithreading

From above discussion it must be clear what multithreading could be, it is the process of using multiple threads to speed up execution.

Let's take a simple example of a web application, your have a web application which makes a request to a server to ask for a resource, we know that the request has to travel over the network and the time of arrival of response is non deterministic in nature, so lets assume you do the call anyways.
```c#
using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting a server call...");
        
        // Simulate a long-running operation (e.g., a server call)
        Thread.Sleep(5000) // Simulate a long delay
        
        Console.WriteLine("Server call completed.");
    }
}
```
What happens is until and unless the data is returned the program comes to a pause, now imagine the same for a heavy Realtime web app like Instagram, for loading every post or every advert your whole app will hang, this will result in a very bad user experience. This is what we call a *synchronous* call. 

The key takeaway here is there is one thread that is doing all the work, so it stops and waits for finishing the data fetching. 

But the question is why should the User Interface become unresponsive for a server call? Accessibility rule #1 is to keep the UI responsive all the time.

Multithreading helps use avoid this by spawning other threads to handle these tasks for us so that the main thread remains responsive.

```c#
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting a server call...");

        // Start a new thread to perform the server call
        Thread serverThread = new Thread(ServerCall);
        serverThread.Start();

        // use can do other work and the main (UI) thread remains responsive
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main thread doing some other work...");
            Thread.Sleep(1000); // Simulate some other work being done
        }

        // Wait for the server thread to complete
        serverThread.Join();

        Console.WriteLine("Server call completed.");
    }

    static void ServerCall()
    {
        // Simulate a long-running operation (e.g., a server call)
        Thread.Sleep(5000); // Simulate a long delay
    }
}

```

<div style="border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); padding: 10px;">.NET developers should use abstractions as much as possible, the example provided above was only for the sake of simplicity, multithreading apps should always use the thread pools and the TPL provided by .NET</div>
#### The Beehive 🍯 Analogy

These threads can be thought of as worker bees 🐝 which work together to do the housekeeping for the hive. All worker come under a queen bee which produces the worker bees, they all share some resources the honey produce and the hive they occupy. 

If you want to learn more about multithreading you can refer to this excellent resource which covers everything there is in .NET for threading: https://www.albahari.com/threading/


## Applications of Multithreading

Most modern applications are heavily multithreaded, below picture showcases some of the examples here.

![[Pasted image 20240206234025.png]]

Most desktop software are heavily multithreaded, a browser uses threads to perform other tasks while keeping the UI responsive, A word processor uses threads to paint objects on the document simultaneously. Raytracing in video games heavily relies on multithreading and parallelism, The whole AI is based on parallelism, training times can be reduced even more by loading and training data simultaneously. The applications are endless, the concept of multithreading is one which will never get outdated, so a good software developer must know about it

## Multithreading may not always be the answer

Multithreading is a powerful tool in software development, but it comes with its own set of considerations. It's beneficial to use multithreading when you have tasks that can run concurrently, such as I/O operations or parallelizable computations, as it can significantly improve performance and responsiveness, especially in applications where responsiveness is critical, like user interfaces or server applications. However, multithreading should be avoided in situations where the tasks are inherently sequential or where shared resources need to be accessed safely to prevent race conditions and other concurrency issues. When implementing multithreading, developers must exercise diligence in managing synchronization, ensuring proper data sharing and avoiding deadlocks. This requires a thorough understanding of concurrency concepts and careful design to mitigate potential pitfalls. 
Moreover, rigorous testing and profiling are essential to identify and resolve any concurrency bugs or performance bottlenecks that may arise. Overall, while multithreading can offer substantial benefits, it demands careful consideration and meticulous implementation to harness its full potential effectively.

## References and Further Reading
- https://www.youtube.com/watch?app=desktop&v=T9UTfymRZXU
- https://www.codeproject.com/Articles/26148/Beginners-Guide-to-Threading-in-NET-Part-1-of-n
- https://www.albahari.com/threading/