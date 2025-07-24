using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    void Start()
    {
        ShuffleFunction();
    }

    private void ShuffleFunction()
    {
        for (int i = 0; i < 100; i++)
        {
            int ranInt1 = Random.Range(0, array.Length);
            int ranInt2 = Random.Range(0, array.Length);

            Swap(ranInt1, ranInt2);
        }
    }
    
    public void Swap(int i, int j)
    {
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}