using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GoalScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("OG3");
        }
        //if (Input.GetKeyDown(KeyCode.T))
        {
            //SceneManager.LoadScene("Stage2");
        }
    }
}
