using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.


[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(1), B(5), C(3), then check the queue contents
    // Expected Result: [A (Pri:1), B (Pri:5), C (Pri:3)] (items added to the back, in order)
    // Defect(s) Found: None. Enqueue already added to the back correctly.
    public void TestPriorityQueue_EnqueueAddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        Assert.AreEqual("[A (Pri:1), B (Pri:5), C (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(5), C(3). Dequeue twice.
    // Expected Result: B, then C
    // Defect(s) Found: Dequeue returned the right value first but never removed the item,
    // so B was returned twice. Fixed by adding RemoveAt(highPriorityIndex).
    public void TestPriorityQueue_DequeueHighestPriorityAndRemoves()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(5), B(5), C(1). Dequeue once.
    // Expected Result: A (same priority, so the one closest to the front wins)
    // Defect(s) Found: The comparison used >= so a later item with equal priority replaced
    // the earlier one and B was returned. Fixed by changing >= to >.
    public void TestPriorityQueue_TieGoesToFront()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(2), C(9). Dequeue once.
    // Expected Result: C (highest priority is the last item in the queue)
    // Defect(s) Found: The loop stopped at Count - 1 so the last item was never checked
    // and B was returned. Fixed by looping to index < Count.
    public void TestPriorityQueue_HighestAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(3), C(3), D(2). Dequeue four times.
    // Expected Result: B, C, D, A
    // Defect(s) Found: Failed before the fixes because of the tie bug (C returned before B)
    // and the missing removal. Passes once all three Dequeue defects are fixed.
    public void TestPriorityQueue_FullSequence()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. The empty check was already correct.
    public void TestPriorityQueue_Empty()
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
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}