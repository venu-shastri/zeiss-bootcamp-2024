# My Experience with the Event Aggregator Design Pattern

During the third week of our intern training program at ZEISS, we were given a simple user story and tasked to come up with a system design, and its corresponding implementation in code, that satisfies all of the requirements. This article is about my original system design, the issues with the design, how the issues were addressed with the use of event aggregator design pattern, and my learning outcomes from the assignment.

## User Story

There are two types of doors: a *simple door* and a *smart door*. A simple door has only two functionalities: *open* and *close*, which open and close the door respectively. A smart door, which can also act as a simple door, has a *door state* (either *opened* or *closed*) and a *timer* that triggers a set of smart features when the door stays open for too long.

The smart features are:
1. *Buzzer Alert*: generates audible noise when triggered.
2. *Pager Alert*: sends a notification alert via pager.
3. *Auto-Close*: automatically closes the door when triggered.

The smart features must be **configurable** based on the needs of the customer.

## Original Design

My initial design revolved heavily around the use of the **Observer** pattern, where each component (*subscriber*) observed for state changes in other components (*publishers*), and communication between them took place in the form of *events*.

![raw.githubusercontent.com/rnachiappan123/Zeiss-Freshers-Bootcamp-2024/main/Article/Original Design.svg](https://raw.githubusercontent.com/rnachiappan123/Zeiss-Freshers-Bootcamp-2024/main/Article/Original%20Design.svg)

For example, a timer observes the smart door for changes in its door state and starts the timer when the door is opened, or stops the timer when the door is closed. In return, the smart door observes the timer for when the timer elapses and notifies the smart features accordingly. This, however, is a **non-blocking** process - the smart door can continue to perform its other operations while observing the timer.
## Issues with the Design

One of the main issues with the initial design is the presence of chaotic or "*chatty*" dependencies among the components. The smart features are directly linked with the smart door, which has to keep track of and notify all of its subscribers. Every time a new feature is added, the number of events being generated simultaneously increases, leading to higher system complexity and difficulty in the **testability** of the code.

This design is also not optimal for *plug-in* and *plug-out* of components. When a smart feature is to be added or removed, the list of subscribers of the smart door has to be modified, violating the **open-closed principle**.

## Addressing the Issues

The issues mentioned above can be addressed with the use of **event aggregator** design pattern. This pattern facilitates a decoupled and modular architecture, making it easier to test and extend software components. The event aggregator acts as a central hub or *broker* that facilitates the exchange of messages (events) between different components without requiring them to be directly aware of each other.

## Improved Design

The improved design uses an event aggregator which contains a dictionary of all the event types and their subscriber list. Subscribers can register themselves with the event aggregator using the *Subscribe* method which takes the event type and event *handler* as parameters. When an event is published, the event aggregator iterates through the list of subscribers for that particular event and invokes their event handlers.

![raw.githubusercontent.com/rnachiappan123/Zeiss-Freshers-Bootcamp-2024/main/Article/Improved Design.svg](https://raw.githubusercontent.com/rnachiappan123/Zeiss-Freshers-Bootcamp-2024/main/Article/Improved%20Design.svg)

Here, *SmartDoor* publishes *DoorOpened* and *DoorClosed* events. *TimerController* subscribes to those events, starts/stops the timer, and publishes the *TimerElapsed* event when the timer runs out. *BuzzerAlert*, *PagerAlert*, and *AutoClose* subscribe to this *TimerElapsed* event to execute their respective actions.

There is no "chatty" behavior among the components since all communication between them is routed through the event aggregator. The design is simplified by reducing the number of direct relationships between the components.

Plug-in and plug-out of components is also possible without violating open-closed principle as they are completely **decoupled** from each other. The publishers are not aware of the subscribers, and the subscribers are not aware of the publishers, they are both only aware of the event aggregator.

## Learning Outcomes

### Desirable features of Event Aggregator Design Pattern

1. *Simplified Communication*. Communication between various components can be extracted into a single place, making it easier to understand, maintain, and test the code.

2. *Scalability*. New components can be plugged in or out without having to modify existing components.

3. *Loose Coupling*. Reduce coupling between components by enabling them to communicate indirectly through events.

### Limitations of Event Aggregator Design Pattern

1. *Single Point of Failure*. Since most communication happens via the event aggregator, a failure or bug in the event aggregator itself can affect the entire system. It can also become a source of *bottleneck* in the case of large-scale systems.

2. *Performance Overhead*. Depending on the implementation, using an event aggregator can introduce some performance overhead. Broadcasting events and managing event subscriptions can incur additional computational costs, impacting the overall performance of the system.

3. *Asynchronous Behavior*. The asynchronous nature of event-driven systems can lead to unintended consequences or *race conditions* if not handled properly.

### Common Use Cases for Event Aggregators

1. *User Interface (UI) Updates*: In user interface development, various UI components often need to communicate with each other to reflect changes in the application state. An event aggregator can facilitate communication between different UI elements, such as updating a list view when a data model changes or triggering a refresh of a dashboard when new data is available.

2. *Event Handling in Web Applications*: Web applications often involve asynchronous operations and user interactions that trigger events. An event aggregator can be used to manage and distribute these events across different parts of the application, allowing for better organization and separation of concerns.

### Singleton Event Aggregator

In most use cases, the publishers and subscribers interact with only one event aggregator. Therefore, to avoid confusion, the event aggregator class can be made *singleton*. In C#, this can be achieved using the *readonly* keyword and *static constructors*.

```c#
public class EventAggregator
{
    public static readonly EventAggregator Instance;
    static EventAggregator()
    {
        Instance = new EventAggregator();
    }
    private EventAggregator() { }
}
```
