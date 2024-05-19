using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    RaycastHit hit;
    public AudioSource sound1, sound2;
    public GameObject bulletObject;
    public Transform bulletPoint;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound1.Play();
            Fire();
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))  
            {
                if (hit.collider.gameObject.tag == "enemy")
                {
                    sound2.Play();  
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletObject, bulletPoint.position, bulletPoint.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletPoint.forward * 1000f;
        Destroy(bullet.gameObject, 0.2f);
    }
}
