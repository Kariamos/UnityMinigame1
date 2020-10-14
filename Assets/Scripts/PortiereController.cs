using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortiereController : MonoBehaviour
{

    Rigidbody rb;
    float newPosition;
    bool adder = true;
    float fps = 5f;
    float maxValue = 0.75f;
    float minValue = -0.75f;

   
   // Start is called before the first frame update
   void Start()
    {
        rb = GetComponent<Rigidbody>();
        newPosition = 0f;
       
    }

    // Update is called once per frame
    void Update()
    {

        
        //float newPosition = Random.Range(-0.75f, 0.75f);

        /*
        if (rb.transform.position.z > 0.75f)
        {
            newPosition = -0.75f;
            // newPosition -= (0.01f / 100);
        }
        else if (rb.transform.position.z < -0.75f)
            newPosition = 0f;
        else
            newPosition += (0.01f / 100);*/
        if (adder)
            newPosition += (0.1f / fps);
        else
            newPosition -= (0.1f / fps);

        if (newPosition > maxValue)
            adder = false;
        if (newPosition < minValue)
            adder = true;

        //transform.Translate(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z * Random.value));
        rb.transform.position = new Vector3(rb.transform.position.x , rb.transform.position.y , newPosition );

        
    }

   
}
