using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.y += Input.GetAxis("Vertical");
        dir.x += Input.GetAxis("Horizontal");

        this.transform.position += dir * speed * Time.deltaTime;
    }
}
