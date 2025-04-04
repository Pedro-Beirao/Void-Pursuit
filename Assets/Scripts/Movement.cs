using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector] public float speed = 5;
    public float normalSpeed = 5;
    public float boostSpeed = 10;


    [Header("Anim")]
    [SerializeField] Animator engineFxAnimator;

    [Header("Boundary")]
    [SerializeField] Vector2 top_left;
    [SerializeField] Vector2 bottom_right;

    void Update()
    {
        Vector3 vertical = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        if (CheckBounds(this.transform.position + vertical))
            this.transform.position += vertical;

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if (CheckBounds(this.transform.position + horizontal))
            this.transform.position += horizontal;

        engineFxAnimator.SetBool("boosting", Input.GetAxis("Horizontal") > 0.1);


    }

    bool CheckBounds(Vector3 newPos)
    {
        if (newPos.x > top_left.x && newPos.x < bottom_right.x &&
            newPos.y > bottom_right.y && newPos.y < top_left.y)
            return true;

        return false;
    }
}
