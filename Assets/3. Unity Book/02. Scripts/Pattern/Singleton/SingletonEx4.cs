using UnityEngine;

public class SingletonEx4 : MonoBehaviour
{
    private static SingletonEx4 instance;
    public static SingletonEx4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonEx4();
            }

            return instance;
        }
    }
}