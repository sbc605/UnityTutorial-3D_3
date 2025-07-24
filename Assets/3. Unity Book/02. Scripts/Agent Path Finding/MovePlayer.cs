using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, v, 0).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
