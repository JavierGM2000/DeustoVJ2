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

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if (collision.gameObject.name == "DeathStar")
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
