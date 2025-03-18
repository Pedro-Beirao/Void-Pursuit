using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Vector2 direction;

    Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        mat.mainTextureOffset += direction * Time.deltaTime;
    }
}
