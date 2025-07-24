using UnityEngine;

public class SingletonEx1 : MonoBehaviour
{
    public static SingletonEx1 Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}