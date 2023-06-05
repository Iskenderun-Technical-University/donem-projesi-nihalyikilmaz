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

    void DragonFollow() //ejderhan�n ana karakterimizi s�rekli takip etmesi i�in
    {
        if (PlayerManager.GameStarted) // oyun ba�lamad�ysa takip etmemesi i�in
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
