using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
     Rigidbody2D rb;

    [SerializeField]
    SceneManager sm;

    [SerializeField]
    float drivingSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  

    void FixedUpdate()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*(drivingSpeed/4));
        rb.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical")) * drivingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            sm.SpawnItem();
            Destroy(collision.gameObject);

        }
    }
}
