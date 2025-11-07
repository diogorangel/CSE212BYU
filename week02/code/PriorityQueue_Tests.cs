using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test basic functionality: Enqueue a mix of priorities and Dequeue the highest priority item.
    // Expected Result: The dequeued value should be "Second" (Priority 40). The queue should then contain "First", "Third", "Fourth".
    // Defect(s) Found: The Dequeue method does not remove the item from the internal list. The list size remains the same, causing infinite looping/incorrect results if subsequent Dequeue calls were made. (Fixed by adding `_queue.RemoveAt(highPriorityIndex)`).
    public void TestPriorityQueue_1_HighestPriorityRemoval()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 40);
        priorityQueue.Enqueue("Third", 30);
        priorityQueue.Enqueue("Fourth", 20);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Second", result);
        Assert.AreEqual("[First (Pri:10), Third (Pri:30), Fourth (Pri:20)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Test FIFO tie-breaker: Enqueue items with the same highest priority. The one added first should be removed.
    // Expected Result: The dequeued value should be "First" (Priority 50) because it was added before "Third" (Priority 50). The queue should then contain "Second", "Third", "Fourth".
    // Defect(s) Found: The priority finding loop uses `>=` (`if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)`), which breaks the FIFO tie-breaker rule by choosing the item closer to the end of the list. It should use `>` to maintain the index of the first highest-priority item. (Fixed by changing `>=` to `>`).
    public void TestPriorityQueue_2_FIFOTieBreaker()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 50); // Added first
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 50); // Added second (same priority)
        priorityQueue.Enqueue("Fourth", 30);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
        Assert.AreEqual("[Second (Pri:10), Third (Pri:50), Fourth (Pri:30)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Test Dequeue on an empty queue to ensure an InvalidOperationException is thrown with the correct message.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: **No defect found** in this specific behavior, as the initial implementation included the correct exception handling.
    public void TestPriorityQueue_3_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Test the iteration of the priority finding loop, ensuring the last item in the list is considered.
    // Expected Result: The dequeued value should be "Last" (Priority 99). The queue should then contain "First", "Second", "Third".
    // Defect(s) Found: The priority finding loop condition was `index < _queue.Count - 1`, which excluded the last item in the list (index `_queue.Count - 1`) from being checked. (Fixed by changing the loop condition to `index < _queue.Count`).
    public void TestPriorityQueue_4_CheckLastElement()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 20);
        priorityQueue.Enqueue("Third", 30);
        priorityQueue.Enqueue("Last", 99); // Highest priority, last element

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Last", result);
        Assert.AreEqual("[First (Pri:10), Second (Pri:20), Third (Pri:30)]", priorityQueue.ToString());
    }

    // Add more test cases as needed below.
}