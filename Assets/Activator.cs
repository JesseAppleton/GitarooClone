using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Base variables
    bool active = false;
    GameObject note,gm;
    SpriteRenderer sr;
    Color old;

    // Variables from notes
    KeyCode noteKey;
    int notePoints;

    // Variables to help line up songs to BPM
    public bool createMode;
    public GameObject tNote;
    public GameObject lNote;
    public GameObject bNote;
    public GameObject rNote;

    // Called when constructed
    void Awake() {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Start is called before the first frame update
    void Start() {
        old = sr.color;
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update() {
        FaceMouse();

        // song creation/tracking...find a better way with spawners?
        if (createMode) {
            if (Input.GetKeyDown("w")) {
                Instantiate(tNote, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown("a")) {
                Instantiate(lNote, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown("s")) {
                Instantiate(bNote, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown("d")) {
                Instantiate(rNote, transform.position, Quaternion.identity);
            }
        }
        // regular play
        else {
            if (Input.anyKeyDown) {
                StartCoroutine(Pressed());
            }
            if (Input.GetKeyDown(noteKey) && active) {
                Destroy(note);
                AddingScore();
                AddingStreak();
                active = false;
            }
            else if (Input.anyKeyDown && !active) {
                ResettingStreak();
                active = false;
            }
        }
    }

    // When the note enters the activator
    void OnTriggerEnter2D(Collider2D col) {
        active = true;
        if (col.gameObject.tag == "WinNote") {
            gm.GetComponent<GameManager>().WinGame();
        }
        if (col.gameObject.tag == "Note") {
            note = col.gameObject;
            noteKey = col.GetComponent<Notes>().key;
            notePoints = col.GetComponent<Notes>().points;
        }
    }

    // When the note exits the activator
    void OnTriggerExit2D(Collider2D col) {
        active = false;
        // ResettingStreak();
    }

    // Yep
    void AddingScore() {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 
            (notePoints * gm.GetComponent<GameManager>().multiplier));
    }

    // Also yep
    void AddingStreak() {
        gm.GetComponent<GameManager>().AddStreak();
    }

    // Another yep
    void ResettingStreak() {
        gm.GetComponent<GameManager>().ResetStreak();
    }

    // When player presses a button
    IEnumerator Pressed() {
        sr.color = new Color (0,0,0);
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
