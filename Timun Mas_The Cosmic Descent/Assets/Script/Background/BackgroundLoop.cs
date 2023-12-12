using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;


    //public float LoopSpeed;
    //public Renderer BackgroundRenderer;
    void Start(){
        startpos = transform.position.x;
        length = GetComponent<SpiriteRenderer>().bounds.size.x;
    }


    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect)

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -+= length;
        //BackgroundRenderer.material.mainTextureOffset += new Vector2(LoopSpeed * Time.deltaTime, 0f);
    }
}
