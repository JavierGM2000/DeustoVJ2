using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformScript : MonoBehaviour
{
    int dir = 1;
    int drops = 0;
    GameObject[] wagons;
    float speed = 5.0f;
    float rotateSpeed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoverTeclado();
        EscalarTeclado();
    }


    private void EscalarTeclado()
    {
        Vector3 esc = new Vector3();
        if (Input.GetKey(KeyCode.H))
        {
            esc.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.K))
        {
            esc.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.U))
        {
            esc.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.J))
        {
            esc.y = -1.0f;
        }
        this.transform.localScale += esc*4*Time.deltaTime;
    }

    private void MoverTeclado()
    {
        Vector3 mov = new Vector3();
        if (Input.GetKey(KeyCode.A))
        {
            mov.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mov.z = 1.0f;
        }
        transform.Translate(mov * speed * Time.deltaTime);
    }
}
