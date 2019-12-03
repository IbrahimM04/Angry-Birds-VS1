using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDummy : MonoBehaviour
{
    Text txt;
    public int amountOfBlocks = 0;

    // Use this for initialization
    void Start() {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Score : " + amountOfBlocks;
    }

    // Update is called once per frame
    void Update() {
        txt.text = "Score : " + (amountOfBlocks * 20);
    }
}
