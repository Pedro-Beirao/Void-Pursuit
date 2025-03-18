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
        Debug.Log(mat.mainTextureOffset);
        mat.mainTextureOffset += direction * Time.deltaTime;
    }
}
