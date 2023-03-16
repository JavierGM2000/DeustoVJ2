using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPlano : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Debug.Log("Bala impactada en objeto destructible");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
