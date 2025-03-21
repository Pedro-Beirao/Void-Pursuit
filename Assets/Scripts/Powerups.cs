using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] float speed = 1;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
