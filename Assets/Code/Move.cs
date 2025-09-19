using UnityEngine;



public class Move : MonoBehaviour
{
     public float speed = 5f;
    Rigidbody2D rb;
    [SerializeField] private bool isFacingRight = true;


    private void Start()
    {
          rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       Mover();
    }
    void  Mover ()
    {
          Vector2 player= new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       rb.linearVelocity = player.normalized * speed;
        if (player.x > 0 && !isFacingRight)
            Flip();
        else if (player.x < 0 && isFacingRight)
            Flip();
    }
    void Flip()
    {
        isFacingRight = !isFacingRight; // đảo hướng
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}


