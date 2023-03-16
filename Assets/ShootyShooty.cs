using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyShooty : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletForce;
    float InitDelay = 1;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
