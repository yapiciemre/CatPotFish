using UnityEngine;

public class Block : MonoBehaviour
{
    public float initialGravityScale = 0.25f; // Baþlangýç yerçekimi skalasý
    public float gravityScaleIncreaseRate = 0.025f; // Zorluk seviyesinin artýþ hýzý
    public float maxHeight = -3.0f; // Bloklarýn ne kadar yüksekliðe ulaþmasý gerektiði

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = initialGravityScale; // Baþlangýç yerçekimi skalasýný ayarla
    }

    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            Destroy(gameObject); // Blok belirli bir yüksekliðe ulaþýrsa yok et
        }
    }

    void FixedUpdate()
    {
        // Zorluk seviyesini artýr
        rb2d.gravityScale += gravityScaleIncreaseRate * Time.fixedDeltaTime;
    }
}
