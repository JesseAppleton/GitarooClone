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
    bool called = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("key needed: " + key);
    }

    void Update() {
        if (PlayerPrefs.GetInt("Start") == 1 && !called) {
            rb.velocity = new Vector2(hSpeed, vSpeed);
            called = true;
        }
    }
}
