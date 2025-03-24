using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPos;
    public float shakeAmmount = 0.05f;
    public float shakeDampening = 0.2f;

    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, originalPos + Random.insideUnitSphere * shakeAmmount, shakeDampening);
    }
}
