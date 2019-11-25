using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotLine : MonoBehaviour
{
    private LineRenderer lineRendererFront;
    private LineRenderer lineRendererBack;

    [SerializeField] private GameObject currentBird;

    private void Awake() //Defines all the variables that need Finding in the scene
    {
        lineRendererFront = GameObject.Find(Constants.lineRendererFront).GetComponent<LineRenderer>();
        lineRendererBack = GameObject.Find(Constants.lineRendererBack).GetComponent<LineRenderer>();
    }

    private void Update() //Puts the line renderer on the correct positions of the bird and the slingshot
    {
        lineRendererFront.SetPosition(0, new Vector3(lineRendererFront.transform.position.x, lineRendererFront.transform.position.y, 0f));
        lineRendererBack.SetPosition(0, new Vector3(lineRendererBack.transform.position.x, lineRendererBack.transform.position.y, 0f));
        lineRendererFront.SetPosition(1, new Vector3(currentBird.transform.position.x, currentBird.transform.position.y, 0f));
        lineRendererBack.SetPosition(1, new Vector3(currentBird.transform.position.x, currentBird.transform.position.y, 0f));
   
    }

    public void setLineRendererActive(bool active) //sets the liner renderer true of false
    {
        if(active == false)
        {
            lineRendererBack.enabled = false;
            lineRendererFront.enabled = false;
        }
        else if(active == true)
        {
            lineRendererBack.enabled = true;
            lineRendererFront.enabled = true;
        }
    }

    public void setCurrentBird(GameObject bird) //set the bird it has to look at for the line renderer
    {
        currentBird = bird;
    }
}
