using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    // Defect(s) Found: The logic for decrementing turns and re-enqueuing is wrong. When a person with 1 turn is dequeued, they are not re-enqueued, but their turns should only be decremented after dequeuing. The check should be on the original value. The current check `if (person.Turns > 1)` means a person with 1 turn is *not* re-enqueued (correct) but also a person with 2 turns has their turns decremented and is re-enqueued (correct). The test fails because it expects 10 items but the number of items received is 11 or 12 depending on the `Person` class logic, but primarily due to the infinite turn logic being flawed later. However, with the current logic, the test **passes** because it correctly handles the finite case (n > 1) and exits correctly. **No defect found for this specific finite case test.**
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        // ... (código do teste)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // After running 5 times, add George with 3 turns. Run until the queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found: The logic for decrementing turns and re-enqueuing is wrong. No defect found for this specific test case, as the logic handles finite turns > 1 correctly. **No defect found for this specific finite case test.**
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        // ... (código do teste)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: The logic in GetNextPerson() does not correctly identify 0 turns as an infinite number of turns. The check `if (person.Turns > 1)` prevents the person with 0 turns (Tim) from being re-enqueued, causing the test to fail because Tim is only returned once, not multiple times as expected by the result array. The final assertion on `infinitePerson.Turns` also fails because Tim is not present in the queue at the end.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        // ... (código do teste)
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
    // Run 10 times.
    // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found: The logic in GetNextPerson() does not correctly identify negative turns (-3) as an infinite number of turns. The check `if (person.Turns > 1)` prevents the person with -3 turns (Tim) from being re-enqueued, causing the test to fail because Tim is only returned once, not multiple times as expected by the result array. The final assertion on `infinitePerson.Turns` also fails because Tim is not present in the queue at the end.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        // ... (código do teste)
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: **No defect found**. The check for `_people.IsEmpty()` at the beginning of `GetNextPerson()` correctly throws the `InvalidOperationException` with the correct message.
    public void TestTakingTurnsQueue_Empty()
    {
        // ... (código do teste)
    }
}