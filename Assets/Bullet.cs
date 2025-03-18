using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;

    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime;
    }
}
