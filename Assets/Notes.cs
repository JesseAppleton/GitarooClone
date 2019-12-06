using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    Rigidbody2D rb;
    public float hSpeed;
    public float vSpeed;
    public KeyCode key;
    public int points;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("key needed: " + key);
    }

    // Start is called before the first frame update
    void Start() {
        rb.velocity = new Vector2(hSpeed, vSpeed);
    }

}
