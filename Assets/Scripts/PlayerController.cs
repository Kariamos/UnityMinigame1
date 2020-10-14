using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private float power;

    public Text points;

    int counter;

    // Start is called before the first frame update
    void Start()
    {
        power = 1;

        counter = 0;

        points.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyUp(KeyCode.Space))
        {
            Kickball();

        }
        CheckBallPosition();
    }


    void Kickball()
    {
        Vector3 angleX = this.transform.forward;
        GetComponent<Rigidbody>().AddForce(new Vector3(-angleX.x * power + Random.Range(-10, 0), angleX.y * power + Random.Range(0, 10), Random.Range(0, 1)), ForceMode.Impulse);
        // GetComponent<Rigidbody>().velocity = new Vector3(-angleX.x * power + Random.Range(-10, 0), angleX.y * power + Random.Range(0, 10), Random.Range(0, 1));
    }


    void CheckBallPosition()
    {
        if (GetComponent<Rigidbody>().transform.position.x < -5f || GetComponent<Rigidbody>().transform.position.x > 5f || GetComponent<Rigidbody>().transform.position.z < -5f || GetComponent<Rigidbody>().transform.position.z > 5f)
        {
            DecreaseScore();

            //GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            ResetBall();
            
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rete"))
        {
            counter++;
            points.text = counter.ToString();
            ResetBall();
        }


    }

    void DecreaseScore()
    {
        if (counter >= 0)
        {
            counter--;
            points.text = counter.ToString();
        }
    }


    void ResetBall()
    {
        GetComponent<Rigidbody>().Sleep();
        transform.position = new Vector3(-0.67f, 0.09f, 0f);
        //GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 0f), ForceMode.VelocityChange);
    }

}


