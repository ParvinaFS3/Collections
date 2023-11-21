using System;

class CustomArrayList
{
    private object[] items;
    private int capacity;
    private int count;

    public int Capacity
    {
        get { return capacity; }
    }

    public int Count
    {
        get { return count; }
    }

    public CustomArrayList(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }

        this.capacity = capacity;
        this.items = new object[capacity];
        this.count = 0;
    }

    public void Add(object item)
    {
        EnsureCapacity();
        items[count] = item;
        count++;
    }

    public void Remove(object item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            RemoveAt(index);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[count - 1] = null;
        count--;
    }

    public void TrimToSize()
    {
        if (count < capacity)
        {
            ResizeArray(count);
        }
    }

    public void AddRange(params object[] collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        foreach (object item in collection)
        {
            Add(item);
        }
    }

    private void EnsureCapacity()
    {
        if (count == capacity)
        {
            int newCapacity = capacity == 0 ? 4 : capacity * 2;
            ResizeArray(newCapacity);
        }
    }

    private void ResizeArray(int newCapacity)
    {
        object[] newItems = new object[newCapacity];
        Array.Copy(items, newItems, count);
        items = newItems;
        capacity = newCapacity;
    }

    private int IndexOf(object item)
    {
        for (int i = 0; i < count; i++)
        {
            if (object.Equals(items[i], item))
            {
                return i;
            }
        }

        return -1;
    }
}

class Program
{
    static void Main()
    {
        CustomArrayList customArrayList = new CustomArrayList(3);

        customArrayList.Add("Item 1");
        customArrayList.Add("Item 2");
        customArrayList.Add("Item 3");

        Console.WriteLine($"Capacity: {customArrayList.Capacity}, Count: {customArrayList.Count}");

        customArrayList.Add("Item 4");

        Console.WriteLine($"Capacity: {customArrayList.Capacity}, Count: {customArrayList.Count}");

        customArrayList.Remove("Item 2");

        Console.WriteLine($"Capacity: {customArrayList.Capacity}, Count: {customArrayList.Count}");

        customArrayList.TrimToSize();

        Console.WriteLine($"Capacity: {customArrayList.Capacity}, Count: {customArrayList.Count}");
    }
}









