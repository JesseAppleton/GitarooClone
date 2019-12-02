using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Base variables
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;

    // Variables from points
    KeyCode noteKey;
    int notePoints;

    // Called when constructed
    void Awake() {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Start is called before the first frame update
    void Start() {
        old = sr.color;
    }

    // Update is called once per frame
    void Update() {

        if (Input.anyKeyDown) {
            StartCoroutine(Pressed());
        }

        if (Input.GetKeyDown(noteKey) && active) {
            Destroy(note);
            AddScore();
            active = false;
        }

        FaceMouse();
    }

    // When the note enters the activator
    void OnTriggerEnter2D(Collider2D col) {
        active = true;
        if (col.gameObject.tag == "Note") {
            note = col.gameObject;
            noteKey = col.GetComponent<Notes>().key;
            notePoints = col.GetComponent<Notes>().points;
        }
    }

    // When the note exits the activator
    void OnTriggerExit2D(Collider2D col) {
        active = false;
    }

    // Yep
    void AddScore() {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + notePoints );
    }

    // When player presses a button
    IEnumerator Pressed() {
        sr.color = new Color(0,0,0);
        yield return new WaitForSeconds(0.2f);
        sr.color = old;
    }

    // Gets players mouse position and turns to it
    void FaceMouse() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}
