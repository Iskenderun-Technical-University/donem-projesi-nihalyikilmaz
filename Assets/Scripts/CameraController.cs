using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,offset.z+target.position.z);
        transform.position = newPosition;
        // transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime); //  Lateupdate yap�p bir�stteki sat�r yerine bunu da kullanabiliriz. Karakterin ilerleyi�i belli olsun diye. Ama suni durdu�u i�in kullanad�m
    
    }
}
