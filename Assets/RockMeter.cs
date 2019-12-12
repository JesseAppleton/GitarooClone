using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{
    float rm;
    GameObject needle;


    // Start is called before the first frame update
    void Start() {
        needle = transform.Find("Needle").gameObject;

    }

    // Update is called once per frame
    void Update() {
        rm = PlayerPrefs.GetInt("RockMeter");

        // Moves the needle
        needle.transform.localPosition = new Vector3((rm-25)/16.666f, 0, 0);
    }
}
