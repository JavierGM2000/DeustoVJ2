using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody riggidB;
    
    [SerializeField]
    public float jumpForce;
    

    // Start is called before the first frame update
    void Start()
    {
        riggidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            riggidB.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
