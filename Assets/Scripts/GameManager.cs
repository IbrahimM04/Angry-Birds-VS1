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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        slingShotLine = GameObject.Find("SlingshotBack").GetComponent<SlingShotLine>();
        spawnLocation = GameObject.Find("CentrePoint").GetComponent<Transform>();
    }

    private void Start()
    {
        spawn = false;
        GameObject obj = Instantiate(birdPrefab, spawnLocation.position, spawnLocation.rotation);
        slingShotLine.setCurrentBird(obj);
        slingShotLine.setLineRendererActive(true);
        birdsFired = 1;
    }

    void Update()
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

    public void setBool(bool set)
    {
        spawn = set;
        timer = 0;
    }

    private IEnumerator FuckJou()
    {
        yield return new WaitForSeconds(1);

        slingShotLine.setLineRendererActive(true);
    }
}
