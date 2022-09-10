# MinBenchmark

``` c#
[Benchmark]
public int Min() => _items.Min(c => c.Age);

[Benchmark]
public Person? MinBy() => _items.MinBy(c => c.Age);

[Benchmark]
public Person MinFirst()
{
    int[] ages = _items.Select(c => c.Age).ToArray();
    int v = ages.Min();
    return _items.First(c => c.Age == v);
}

[Benchmark]
public Person[] MinWhere()
{
    int[] ages = _items.Select(c => c.Age).ToArray();
    int v = ages.Min();
    return _items.Where(c => c.Age == v).ToArray();
}
```

![image](https://user-images.githubusercontent.com/3414748/189478201-1c6a8999-4908-4d2c-92ec-1fe3eb9b49ee.png)
