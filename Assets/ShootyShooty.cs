using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyShooty : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletForce;
    public bool shooting;
    public bool shootOnce;
    float InitDelay = 1;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        shootOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            shooting = true;
            
        }
        else
        {
            shooting = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            shootOnce = true;
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (delay <= 0)
            {
                delay = InitDelay;
                Vector3 newPos = transform.position + transform.forward*0.8f;
                GameObject SpawnBullet = Instantiate(Bullet,newPos, transform.rotation);
                SpawnBullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.transform.forward* BulletForce);
            }
        }
    }

    void FixedUpdate()
    {
        if (shooting==true && shootOnce==true)
        {
            shootOnce = false;
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit " + hit.transform.gameObject.name);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
        
    }
}
