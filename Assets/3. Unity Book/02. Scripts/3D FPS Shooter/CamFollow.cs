using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = target.position;
    }
}