using UnityEngine;

public class Coin : MonoBehaviour
{
    public float initialGravityScale = 0.25f; // Ba�lang�� yer�ekimi skalas�
    public float gravityScaleIncreaseRate = 0.025f; // Zorluk seviyesinin art�� h�z�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = initialGravityScale; // Ba�lang�� yer�ekimi skalas�n� ayarla
    }

    void FixedUpdate()
    {
        // Zorluk seviyesini art�r
        rb.gravityScale += gravityScaleIncreaseRate * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ScoreManager �zerinden madeni paray� ekleyin
            ScoreManager.Instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
