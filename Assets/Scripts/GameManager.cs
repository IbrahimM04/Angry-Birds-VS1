using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Transform spawnLocation;
    private SlingShotLine slingShotLine;
    [SerializeField] private GameObject birdPrefab;

    private bool spawn;
    private float timer;
    private int birdsFired;

    private void Awake() //Defines all the variables that need Finding in the scene
    {
        DontDestroyOnLoad(gameObject);
        slingShotLine = GameObject.Find("SlingshotBack").GetComponent<SlingShotLine>();
        spawnLocation = GameObject.Find("CentrePoint").GetComponent<Transform>();
    }

    private void Start() //Spawns bird and set the line renderer on the spawned bird + set's line renderer active
    {
        spawn = false;
        GameObject obj = Instantiate(birdPrefab, spawnLocation.position, spawnLocation.rotation);
        slingShotLine.setCurrentBird(obj);
        slingShotLine.setLineRendererActive(true);
        birdsFired = 1;
    }

    void Update() //Spawns the new bird and does the same thing as in the start but waits for a setter input from an external script
    {
        timer += Time.deltaTime;

        if (spawn && timer >= 1.5)
        {
            spawn = false;
            GameObject obj = Instantiate(birdPrefab, spawnLocation.position, spawnLocation.rotation);
            slingShotLine.setCurrentBird(obj);
            birdsFired++;
            StartCoroutine(FuckJou());
        }
    }

    public void setBool(bool set) //Hier komt de bool binnen om een nieuwe spawn the accepteren
    {
        spawn = set;
        timer = 0;
    }

    private IEnumerator FuckJou()
    {
        //Dit is een KUT FIX
        yield return new WaitForSeconds(0.1f);

        slingShotLine.setLineRendererActive(true);
    }
}
