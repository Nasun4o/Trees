using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; private set; }
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var item in children)
        {
            this.Children.Add(item);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);
        foreach (var item in this.Children)
        {
            item.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var item in this.Children)
        {
            item.Each(action);
        }
    }
}
