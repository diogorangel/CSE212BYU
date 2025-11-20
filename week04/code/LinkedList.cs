using System.Collections;
using System.Linq; // Added for Cast<int>() in the extension method

// Assuming there's a Node class defined elsewhere (like in a separate file or nested).
// For the provided file to compile, let's assume the Node class is defined as:
/*
public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
*/
// Since the Node class is not provided, I am only focusing on the LinkedList class implementation.

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        Node newNode = new(value);

        // Case 1: The list is empty. Both head and tail point to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Case 2: The list is not empty.
        else
        {
            // Connect the new node's Prev pointer to the current tail.
            newNode.Prev = _tail;
            // Connect the current tail's Next pointer to the new node.
            _tail.Next = newNode;
            // Update the tail to point to the new node.
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // Case 1: The list is empty or has only one node. Reuse RemoveHead logic.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // Case 2: The list has more than one node.
        else if (_tail is not null)
        {
            // The new tail is the node before the current tail.
            Node? newTail = _tail.Prev;
            
            // Disconnect the new tail from the removed tail.
            newTail!.Next = null;
            
            // Update the tail to point to the new tail.
            _tail = newTail;
        }
        // Note: No action needed if _tail is null (empty list) because of the 
        // first 'if' block.
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Case 1: Node to remove is the Head.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // Case 2: Node to remove is the Tail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Case 3: Node to remove is in the middle.
                else
                {
                    // Disconnect the previous node from the current node.
                    curr.Prev!.Next = curr.Next;
                    // Disconnect the next node from the current node.
                    curr.Next!.Prev = curr.Prev;
                    
                    // The current node 'curr' is now disconnected and will be garbage collected.
                }

                return; // Stop after removing the first occurrence.
            }

            curr = curr.Next; // Move to the next node.
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                // Replace the value
                curr.Data = newValue;
            }

            // Continue searching through the list, even after a replacement.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var curr = _tail; // Start at the end since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go backward in the linked list (using the Prev pointer)
        }
        // The original 'yield return 0;' is replaced by the correct implementation.
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}