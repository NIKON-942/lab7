using System.Collections;
using System.Globalization;

namespace lab7;

/// <summary>
/// Represents a singly linked list that stores float values.
/// Each node contains a float value and a reference to the next node.
/// </summary>
public class SinglyLinkedListNode : IEnumerable<SinglyLinkedListNode>, ICloneable
{
    public float? Value { get; set; }
    public SinglyLinkedListNode? NextNode { get; private set; }

    /// <summary>
    /// Creates an empty singly linked list.
    /// </summary>
    public SinglyLinkedListNode()
    {
        Value = null;
        NextNode = null;
    }

    /// <summary>
    /// Creates singly linked list from values.
    /// </summary>
    /// <param name="values">List values</param>
    public SinglyLinkedListNode(params float[] values) 
    {
        Value = values[0];
        NextNode = values.Length > 1 
            ? new SinglyLinkedListNode(values[1..]) 
            : null;
    }

    /// <summary>
    /// Adds new values to list from floats.
    /// </summary>
    /// <param name="values">Values to add to list</param>
    public void AddNodes(params float[] values) 
    {
        if (Value == null)
        {
            Value = values[0];
            NextNode = values.Length > 1 
                ? new SinglyLinkedListNode(values[1..]) 
                : null;
            return;
        }
        
        var tempNode = this;
        while (tempNode.NextNode != null) 
            tempNode = tempNode.NextNode;

        tempNode.NextNode = new SinglyLinkedListNode(values);
    }

    /// <summary>
    /// Adds new values to list from nodes.
    /// </summary>
    /// <param name="nodes">Nodes to add to list</param>
    public void AddNodes(params SinglyLinkedListNode[] nodes)
    {
        if (Value == null)
        {
            Value = nodes[0].Value;
            NextNode = nodes[0].NextNode;
            if (nodes.Length > 1)
                AddNodes(nodes[1..]);
            return;
        }
        
        var tempNode = this;
        while (tempNode.NextNode != null) 
            tempNode = tempNode.NextNode;
        
        foreach (var newNode in nodes)
        {
            tempNode.NextNode = newNode;
            while (tempNode.NextNode != null)
            {
                if (tempNode.NextNode == this)
                    tempNode.NextNode = null;
                else
                    tempNode = tempNode.NextNode;
            }
        }
    }

    /// <summary>
    /// Deletes a node from the list by value.
    /// </summary>
    /// <param name="value">Value to delete</param>
    /// <returns>New head of singly linked list</returns>
    public SinglyLinkedListNode DeleteNode(float value)
    {
        if (!Contains(value))
            return this;
        
        if (Value == value && NextNode != null)
            return NextNode;

        if (Value == value)
        {
            Value = null;
            NextNode = null;
            return this;
        }

        var tempNode = this;
        while (tempNode.NextNode != null && tempNode.NextNode.Value != value)
            tempNode = tempNode.NextNode;

        if (tempNode.NextNode == null)
            return this;

        tempNode.NextNode = tempNode.NextNode.NextNode;
        return this;
    }

    /// <summary>
    /// Deletes a specified node from the list.
    /// </summary>
    /// <param name="node">Node to delete</param>
    /// <returns>New head of singly linked list</returns>
    public SinglyLinkedListNode DeleteNode(SinglyLinkedListNode node)
    {
        if (this == node && NextNode != null)
            return NextNode;
    
        if (this == node)
        {
            Value = null;
            return this;
        }
        
        var tempNode = this;
        while (tempNode.NextNode != null && tempNode.NextNode != node)
            tempNode = tempNode.NextNode;
    
        if (tempNode.NextNode == null)
            return this;
    
        tempNode.NextNode = tempNode.NextNode.NextNode;
        return this;
    }
    
    /// <summary>
    /// Checks if a list contains a specific value.
    /// </summary>
    /// <param name="value">Value to check</param>
    /// <returns>True if list contains a passed element, otherwise false</returns>
    public bool Contains(float value) => this.Any(n => n.Value == value);

    /// <summary>
    /// Returns count of elements in singly linked list.
    /// </summary>
    /// <returns>Count of elements</returns>
    public int Count() => this.Count(n => n.Value.HasValue);
    
    /// <summary>
    /// Returns a list of singly linked list values.
    /// </summary>
    /// <returns>List of values</returns>
    public List<float> ToList() => this.Where(n => n.Value.HasValue)
            .Select(n => n.Value!.Value)
            .ToList();

    /// <summary>
    /// Returns an array of singly linked list values.
    /// </summary>
    /// <returns>Array of values</returns>
    public float[] ToArray() => this.Where(n => n.Value.HasValue)
            .Select(n => n.Value!.Value)
            .ToArray();
    
    /// <summary>
    /// Returns a string that contains all list elements.
    /// </summary>
    /// <returns>List converted to string</returns>
    public override string ToString() => "[" + 
                                         this.Select(n => Convert.ToString(n.Value, CultureInfo.InvariantCulture))
                                             .Aggregate((a, b) => a + ", " + b) + 
                                         "]";

    /// <summary>
    /// Returns clone of that singly linked list.
    /// </summary>
    /// <returns>Object of cloned linked list</returns>
    public object Clone() => new SinglyLinkedListNode(ToArray());

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<SinglyLinkedListNode> GetEnumerator() => new SinglyLinkedListNodeEnum(this);
}

internal class SinglyLinkedListNodeEnum : IEnumerator<SinglyLinkedListNode>
{
    private readonly SinglyLinkedListNode _startNode;
    private SinglyLinkedListNode? _current;

    public SinglyLinkedListNodeEnum(SinglyLinkedListNode startNode) => (_startNode, _current) = (startNode, null);

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = _startNode;
            return true;
        }

        if (_current.NextNode == null)
            return false;
        
        _current = _current.NextNode;
        return true;
    }

    public void Reset() => _current = null;

    object? IEnumerator.Current => _current;

    public void Dispose() { }

    SinglyLinkedListNode IEnumerator<SinglyLinkedListNode>.Current => _current;
}

public static class Tasks
{
    /// <summary>
    /// Finds the first value in the list greater than the passed value.
    /// </summary>
    /// <param name="node">Node to find value</param>
    /// <param name="value">Value to find greater than</param>
    /// <returns>First value greater than passed or null if all values less than passed.</returns>
    public static float? FirstGreaterThan(this SinglyLinkedListNode node, float value) =>
        node.FirstOrDefault(n => n.Value > value)?.Value;

    /// <summary>
    /// Calculate sum of elements that less than first negative element of a list.
    /// </summary>
    /// <param name="node">Source of elements</param>
    /// <returns>Sum of elements that less than first negative or null if list doesn't have negative elements or all elements are greater than first negative element.</returns>
    public static float? SumOfElementsLessThanFirstNegative(this SinglyLinkedListNode node)
    {
        var firstNegative = node.FirstOrDefault(n => n.Value < 0)?.Value;
        if (firstNegative == null)
            return null;
        if (!node.Any(n => n.Value < firstNegative))
            return null;
        
        return node.Where(n => n.Value < firstNegative)
                .Select(n => n.Value)
                .Sum();
    }

    /// <summary>
    /// Creates new list with values that passed value.
    /// </summary>
    /// <param name="node">Source of elements</param>
    /// <param name="value">Value to find values greater than</param>
    /// <returns>New singly linked list with values greater than the passed one, if any, otherwise null.</returns>
    public static SinglyLinkedListNode? NewListGreaterThan(this SinglyLinkedListNode node, float value)
    {
        if (!node.Any(n => n.Value > value))
            return null;
        
        return new SinglyLinkedListNode(node.Where(n => n.Value > value && n.Value.HasValue)
                .Select(n => n.Value!.Value)
                .ToArray());
    }
    
    /// <summary>
    /// Deletes from singly linked list values less than the passed one.
    /// </summary>
    /// <param name="node">Source of elements</param>
    /// <param name="value">Value to delete elements less than</param>
    /// <returns></returns>
    public static SinglyLinkedListNode DeleteElementsLessThan(this SinglyLinkedListNode node, float value)
    {
        if (!node.Any(n => n.Value < value))
            return node;
        
        var nodeToReturn = node;
        node.Where(n => n.Value < value).ToList()
            .ForEach(n => nodeToReturn = nodeToReturn.DeleteNode(n.Value.Value));
        return nodeToReturn;
    }
}