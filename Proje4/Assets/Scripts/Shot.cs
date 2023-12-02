using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    RaycastHit hit;
    public AudioSource sound1, sound2;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound1.Play();
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
}
