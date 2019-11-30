using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    // public KeyCode key;
    bool active = false;
    GameObject note;
    KeyCode noteKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(noteKey) && active) {
            Destroy(note);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        active = true;
        if (col.gameObject.tag == "Note") {
            note = col.gameObject;
            noteKey = col.GetComponent<Notes>().key;
        }

    }

    void OnTriggerExit2D(Collider2D col) {
        active = false;
    }
}
