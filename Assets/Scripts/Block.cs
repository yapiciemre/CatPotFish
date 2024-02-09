using UnityEngine;

public class Block : MonoBehaviour
{
    public float initialGravityScale = 0.25f; // Ba�lang�� yer�ekimi skalas�
    public float gravityScaleIncreaseRate = 0.025f; // Zorluk seviyesinin art�� h�z�
    public float maxHeight = -3.0f; // Bloklar�n ne kadar y�ksekli�e ula�mas� gerekti�i

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = initialGravityScale; // Ba�lang�� yer�ekimi skalas�n� ayarla
    }

    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            Destroy(gameObject); // Blok belirli bir y�ksekli�e ula��rsa yok et
        }
    }

    void FixedUpdate()
    {
        // Zorluk seviyesini art�r
        rb2d.gravityScale += gravityScaleIncreaseRate * Time.fixedDeltaTime;
    }
}
