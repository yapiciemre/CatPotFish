using UnityEngine;

public class Coin : MonoBehaviour
{
    public float initialGravityScale = 0.25f; // Baþlangýç yerçekimi skalasý
    public float gravityScaleIncreaseRate = 0.025f; // Zorluk seviyesinin artýþ hýzý

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = initialGravityScale; // Baþlangýç yerçekimi skalasýný ayarla
    }

    void FixedUpdate()
    {
        // Zorluk seviyesini artýr
        rb.gravityScale += gravityScaleIncreaseRate * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ScoreManager üzerinden madeni parayý ekleyin
            ScoreManager.Instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
