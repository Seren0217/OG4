using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    // Use this for initialization
    float speed = 0f;
    float yspeed = 5f;
    public static float time = 0;
    int coin = 0;
    int nowState;
    float Ro = 270;
    const int STOP_STATE = 0;
    const int SPEED_UP_STATE = 1;
    const int SPEED_DOWN_STATE = 2;
    float maxSpeed = 3.0f;
    public GameObject TextSpeed;
    public GameObject CoinScore;
    public GameObject Second;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3)
        {
            SceneManager.LoadScene("GameOver");
        }
        //↓自動で進むアレ
        //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        // if (Input.GetKey("right"))
        //  {
        //transform.position += new Vector3(yspeed * Time.deltaTime, 0, 0);
        // }
        // if (Input.GetKey("left"))
        // {
        //transform.position += new Vector3(-yspeed * Time.deltaTime, 0, 0);
        // }
        //if (Input.GetKey("up"))
        //{
        //transform.position += new Vector3(0,0,speed * Time.deltaTime);
        //speed += 0.5f;
        //}
        if (Input.GetKey("up"))
        {
            nowState = SPEED_UP_STATE;
        }
        if ((!Input.GetKey("up")) && (speed > 0.1f))
        {
            nowState = SPEED_DOWN_STATE;
        }
        if (speed < 0)
        {
            nowState = STOP_STATE;
        }
        move(nowState);
        transform.Translate(Vector3.right * speed);
        // if ((!Input.GetKeyUp("up"))&& (speed > 3.0f)){
        // speed -= 0.5f;
        // }
       // Debug.Log(speed);

        SpeedText(speed);
        CoinText(coin);
        ShowTime();


        if (Input.GetKey(KeyCode.LeftArrow))
        {
           // Debug.Log(Ro);
            transform.Rotate(Vector3.up * -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           // Debug.Log(Ro);
            transform.Rotate(Vector3.up * +1);
        }




    }
    void move(int state)
    {
        switch (state)
        {
            case SPEED_UP_STATE:
                if (speed < maxSpeed)
                {
                    speed += 0.01f;
                }
                break;
            case SPEED_DOWN_STATE:
                speed -= 0.015f;
                break;
            case STOP_STATE:
                speed = 0;
                break;
            default:
                speed = 0;
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SpeedDown")
        {
            maxSpeed = 0.0f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SpeedDown")
        {
            maxSpeed = 1.0f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin += 1;
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "けーさつ")
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    void SpeedText(float spd)
    {
        float displaySpeed;
        displaySpeed = Mathf.Floor(spd * 40.0f);
        TextSpeed.GetComponent<Text>().text = displaySpeed.ToString() + "km/h";
    }
    void CoinText(int c)
    {
        CoinScore.GetComponent<Text>().text = "Coin:" + c.ToString() + "個";
    }
    void ShowTime()
    {
        time += Time.deltaTime;
        float textTime = Mathf.Floor(time);
        Second.GetComponent<Text>().text = textTime.ToString() + "秒";
    }

}

