using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class jikan : MonoBehaviour {
    public static float time = 0;
    public Text showTime;
	// Use this for initialization
	void Start () {
        time = Mathf.Floor(time);
        showTime.text = Player.time.ToString() + "秒";
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
