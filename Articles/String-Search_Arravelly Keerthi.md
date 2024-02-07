# Navigating the World of String Search in C++: 
The programming  puzzle we discuss is : how to pick out strings with certain lengths? or how do we apply a certain type of filter on strings .We decided to tackle this puzzle and went on a journey, learning about cool design tricks and smart ways to write code. Come along as we explore this adventure from the beginning to the grand finale.

## Chapter 1: Getting Started

Our exploration in the realm of C++ programming began with a straightforward task: identifying strings with specific lengths. Armed with a collection of words and a numerical criterion, our initial approach involved a basic loop to traverse the words and check if their lengths were divisible by the chosen number.

```cpp
#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main() {
    vector<string> inputStrings = {"apple", "banana", "cherry", "date", "elderberry"};
    int divisor = 2;
    vector<string> mainResult;

    for (const string& str : inputStrings) {
        if (str.length() % divisor == 0) {
            mainResult.push_back(str);
        }
    }

    cout << "Strings with length divisible by " << divisor << " :";
    for (const string& str : mainResult) {
        cout << str << " ";
    }
    cout << endl;

    return 0;
}
```

## Chapter 2: Unveiling Design Magic
![image](https://github.com/Arravelly-Keerthi/Freshers-Bootcamp_zeiss/assets/95274988/66e536cc-576c-4b0b-9056-c9324f6b2fc4)


Recognizing the limitations of our initial plan, we delved into intelligent design patterns. Introducing a Criteria interface enabled the creation of a set of rules for filtering words based on various criteria. The Strategy Pattern became our weapon of choice, providing a modular and extensible way to filter strings.

```cpp
#include <iostream>
#include <vector>
#include <functional>
using namespace std;

class ICriteria {
public:
    virtual bool meetsCriteria(const string& str) const = 0;
};

class DivisibleByCriteria : public ICriteria {
private:
    int divisor;
public:
    DivisibleByCriteria() {}

    bool meetsCriteria(const string& str) const override {
        return str.length() % divisor == 0;
    }

    void setDivisor(int divArg) {
        divisor = divArg;
    }
};

class StringFilter {
private:
    const ICriteria* criteria;
public:
    StringFilter(const ICriteria* criteria) : criteria(criteria) {}

    vector<string> filterStrings(const vector<string>& strings) const {
        vector<string> result;
        for (const string& str : strings) {
            if (criteria->meetsCriteria(str)) {
                result.push_back(str);
            }
        }
        return result;
    }
};

void printStrings(const vector<string>& strings, const string& message) {
    cout << message;
    for (const string& str : strings) {
        cout << str << " ";
    }
    cout << endl;
}

int main() {
    vector<string> inputStrings = {"apple", "banana", "orange", "grape", "kiwi"};
    DivisibleByCriteria divisibleBy3;
    divisibleBy3.setDivisor(3);
    StringFilter filter(&divisibleBy3);
    vector<string> divisibleStrings = filter.filterStrings(inputStrings);
    printStrings(divisibleStrings, "Strings with length divisible by divisor: ");

    return 0;
}
```

## Chapter 3: Fun with Functions

Venturing into the playful side of programming, we stumbled upon lambda functions. These concise, inline functions, introduced in C++11, added brevity to our code. The cornerstone of this approach was the use of lambda functions for divisibility checks.

```cpp
#include <iostream>
#include <vector>
#include <algorithm>
#include <functional>

std::function<bool(const std::string&)> isDivisibleBy(int divisor) {
    return [divisor](const std::string& str) {
        return str.length() % divisor == 0;
    };
}

std::vector<std::string> search(const std::vector<std::string>& strings, const std::function<bool(const std::string&)>& criteria) {
    std::vector<std::string> result;
    for (const std::string& str : strings) {
        if (criteria(str)) {
            result.push_back(str);
        }
    }
    return result;
}

void printDivisibleStrings(const std::vector<std::string>& divisibleStrings) {
    std::cout << "Strings with length divisible by divisor: ";
    for (const std::string& str : divisibleStrings) {
        std::cout << str << " ";
    }
    std::cout << std::endl;
}

int main() {
    std::vector<std::string> strings = {"apple", "banana", "orange", "grape", "kiwi"};
    auto isDivisibleBy3 = isDivisibleBy(3);

    std::vector<std::string> divisibleStrings = search(strings, isDivisibleBy3);
    printDivisibleStrings(divisibleStrings);

    return 0;
}
```

## Chapter 4: Playing with Objects

Delving deeper into the coding sea, functors surfaced – objects that acted like functions. Our IsDivisible functor emerged as the superhero in our string-filtering adventure.

```cpp
#include <iostream>
#include <vector>
#include <functional>

class IsDivisibleBy {
    int divisor;
public:
    IsDivisibleBy() {}

    bool operator()(const std::string& str) const {
        return str.length() % divisor == 0;
    }

    void setDivisor(int divArg) {
        divisor = divArg;
    }
};

std::vector<std::string> search(const std::vector<std::string>& strings, std::function<bool(const std::string&)> criteria) {
    std::vector<std::string> result;
    for (const std::string& str : strings) {
        if (criteria(str)) {
            result.push_back(str);
        }
    }
    return result;
}

int main() {
    IsDivisibleBy isDivisibleFunctor;
    isDivisibleFunctor.setDivisor(3);
    std::function<bool(const std::string&)> isDivisibleByDivisor(isDivisibleFunctor);

    std::vector<std::string> strings = {"apple", "banana", "orange", "grape", "kiwi", "pear", "melon"};
    std::vector<std::string> divisibleStrings = search(strings, isDivisibleByDivisor);
    
    printDivisibleStrings(divisibleStrings);

    return 0;
}
```

## Chapter 5: The Grand Finale

As our narrative approached its conclusion, placeholders and bind functions entered the scene. These tools provided enhanced flexibility to our code, allowing for dynamic customization.

```cpp
#include <iostream>
#include <vector>
#include <functional>

auto isDivisibleBy(const std::string& str, int divisor) {
    return str.length() % divisor == 0;
}

std::vector<std::string> search(const std::vector<std::string>& strings, std::function<bool(const std::string&)>& criteria) {
    std::vector<std::string> result;
    for (const std::string& str : strings) {
        if (criteria(str)) {
            result.push_back(str);
        }
    }
    return result;
}

int main() {
    int divisor = 3;
    auto isDivisibleByDivisor = std::bind(isDivisibleBy, std::placeholders::_1, divisor);

    std::vector<std::string> strings = {"apple", "banana", "orange", "grape", "kiwi", "pear", "melon"};
    std::vector<std::string> divisibleStrings = search(strings, isDivisibleByDivisor);

    printDivisibleStrings

(divisibleStrings);

    return 0;
}
```

## Conclusion: Wrapping Up Our Coding Adventure

As our journey concluded, we marveled at the diverse tools in our coding arsenal. From basic loops to design patterns, lambda functions, functors, placeholders, and bind functions – each chapter added a layer of excitement and creativity. Our exploration showcased the joy of coding, where each tool became a brushstroke in the canvas of creating something functional and beautiful.

