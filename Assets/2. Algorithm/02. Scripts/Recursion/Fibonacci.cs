using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int result = FibonacciFunction(i);
            Debug.Log(result);
        }
    }

    private int FibonacciFunction(int n)
    {
        if (n <= 1)
            return n;
        
        return FibonacciFunction(n - 1) + FibonacciFunction(n - 2);
    }
}