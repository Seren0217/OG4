using UnityEngine;
using System.Collections;

public class Heli : MonoBehaviour {
    float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        time += Time.deltaTime;
        if (time <= 1.5f)
        {
            transform.Translate(Vector3.up * 0.05f);
        }
        if(time >= 1.5f)
        {
            transform.Translate(Vector3.up * -0.05f);
        }
        if(time >= 3.0f)
        {
            time = 0;
        }


        
    }
}
