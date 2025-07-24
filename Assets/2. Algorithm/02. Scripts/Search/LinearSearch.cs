using System;
using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public int target = 7;

    void Start()
    {
        LSearch(array, target);
    }

    private void LSearch(int[] arr, int t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == t)
            {
                Debug.Log($"{t}은 {i}번째에 있습니다.");
            }
        }
    }
}