using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 15f;
    public float mapWidth = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = 0f;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        // Bilgisayar veya web platformunda klavye kullan�m�
        x = Input.GetAxis("Horizontal");
#else
        // Mobil platformlarda ivme�l�er kullan�m�
        x = Input.acceleration.x;
#endif

        x *= Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
