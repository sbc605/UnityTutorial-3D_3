using UnityEngine;

public class Movement : MonoBehaviour
{
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, 0, v);

        transform.position += dir * Time.deltaTime * 5f;
    }
}
