using System;

class Program
{
    static void Main(string[] args)
    {
        SomeGlobalClass SGC = new SomeGlobalClass();
        BigData d = new BigData();
        BigData d2 = new BigData();
        d.DescribeAll();
        d2.DescribeAll();
        d = null;
        d2 = null;

        GC.Collect();

        while (true)
        {

        }
    }
}

class SomeGlobalClass
{
    public static SomeGlobalClass Instance;
    public event Action OnSomething;

    public SomeGlobalClass()
    {
        Instance = this;
    }

    public void DoSomething()
    {
        OnSomething?.Invoke();
    }
}

class BigData
{
    public int[] Data;

    public BigData()
    {
        Data = new int[100000];
        SomeGlobalClass.Instance.OnSomething += EventHandler;
    }

    public void EventHandler()
    {

    }

    public void DescribeAll() => SomeGlobalClass.Instance.OnSomething -= EventHandler;
}