using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Die Variablen
     Rigidbody2D rb;
    SpriteRenderer rendern;

    // verlinken des anderen Scripts 
    [SerializeField]
    SceneManager sm;

    // Sprite für das Basis Auto
    [SerializeField]
    Sprite basis;

    // Sprite für das Auto, das ein Item trägt
    [SerializeField]
    Sprite carry;

    bool carriesPickup;

    // 
    [SerializeField]
    float drivingSpeed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rendern = GetComponent<SpriteRenderer>();

        rendern.sprite = basis;
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
            rendern.sprite = carry;
            Destroy(collision.gameObject);
            carriesPickup = true;

        }
        else if (collision.CompareTag("DropOff") && carriesPickup)
        {
            rendern.sprite = basis;
            sm.SpawnItem();
            SceneManager.pickUpCount++;
            carriesPickup = false;
        }
    }
}
