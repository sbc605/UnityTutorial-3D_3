using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log("정렬 전 : " + string.Join(", ", array));

        Selection(array);
        Debug.Log("정렬 후 : " + string.Join(", ", array));
    }
    
    private void Selection(int[] arr)
    {
        int n = arr.Length;
        
        // 인덱스 값 선택
        for (int i = 0; i < n - 1; i++) // i : 선택한 인덱스
        {
            int minIdx = i;
            
            // 뒤에 있는 값들과 비교
            for (int j = i + 1; j < n; j++) // j : 비교할 인덱스
            {
                if (arr[j] < arr[minIdx])
                    minIdx = j;
            }

            int temp = arr[i];
            arr[i] = arr[minIdx];
            arr[minIdx] = temp;
        }
    }
}