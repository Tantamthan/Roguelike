using UnityEngine;

public class test : MonoBehaviour
{
    public Transform player;
    private float speed = 3f;
    [SerializeField] private bool isFacingRight = true;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Flower();
    }
    private void Flower()
    {
        Vector2 direction = (player.position - transform.position).normalized;
    
        transform.position += (Vector3)(direction * Time.deltaTime * speed);
        if (direction.x > 0 && !isFacingRight) Flip();
        else if (direction.x < 0 && isFacingRight) Flip();
    }
    void Flip()
    {
        isFacingRight = !isFacingRight; // đảo hướng
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
