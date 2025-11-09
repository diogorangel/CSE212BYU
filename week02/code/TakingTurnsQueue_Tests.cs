using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

// NOTE: A minimal definition of Person is assumed for the tests to run. 
// public class Person { public string Name { get; set; } public int Turns { get; set; } public Person(string name, int turns) { Name = name; Turns = turns; } }

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
    // run until the queue is empty
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The internal PersonQueue is behaving like a Stack (LIFO) instead of a Queue (FIFO). The code returns 'Sue' (last added) when 'Bob' (first added) is expected. The turn logic in GetNextPerson() was also incorrect for infinite turns (<= 0) and needed to be fixed to pass the `ForeverZero` and `ForeverNegative` tests.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
// ... (rest of test method remains unchanged)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns. Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: The internal PersonQueue is behaving like a Stack (LIFO) instead of a Queue (FIFO). The code returns 'Sue' when 'Bob' is expected (at the end of the run).
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
// ... (rest of test method remains unchanged)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever=0), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The logic in GetNextPerson() did not correctly treat 0 turns as infinite, causing Tim to be removed. Additionally, the underlying PersonQueue is behaving like a Stack (LIFO).
    public void TestTakingTurnsQueue_ForeverZero()
    {
// ... (rest of test method remains unchanged)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever=-3), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: The logic in GetNextPerson() did not correctly treat negative turns as infinite, causing Tim to be removed. Additionally, the underlying PersonQueue is behaving like a Stack (LIFO).
    public void TestTakingTurnsQueue_ForeverNegative()
    {
// ... (rest of test method remains unchanged)
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: **No defect found**. The check for `_people.IsEmpty()` at the beginning of `GetNextPerson()` correctly throws the `InvalidOperationException` with the correct message.
    public void TestTakingTurnsQueue_Empty()
    {
// ... (rest of test method remains unchanged)
    }
}