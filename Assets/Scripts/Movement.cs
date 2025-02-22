using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal")*10, body.linearVelocity.y);
    }
}
