using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody riggidB;
    private bool canJump;
    [SerializeField]
    public float jumpForce;
    

    // Start is called before the first frame update
    void Start()
    {
        riggidB = GetComponent<Rigidbody>();
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.W))
        {
            riggidB.AddForce(new Vector3(0, jumpForce, 0));
            
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //La layer con id 3 es ground
        if (collision.gameObject.layer == 3)
        {
            canJump = true;
        }
        //La layer con id 6 son objetos que matan al jugador
        if (collision.gameObject.layer == 6)
        {
            //quitamos la camara como hijo del objeto
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
}
