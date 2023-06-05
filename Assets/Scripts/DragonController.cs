using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float stoppingDistance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void DragonFollow() //ejderhanýn ana karakterimizi sürekli takip etmesi için
    {
        if (PlayerManager.GameStarted) // oyun baþlamadýysa takip etmemesi için
            if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

   
    void Update()
    {
        DragonFollow();
    }
}
