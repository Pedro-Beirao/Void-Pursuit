using UnityEngine;

public class Powerups : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.left * 1 * Time.deltaTime;
    }
}
