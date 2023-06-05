
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction; // 3 boyutlu bir eksende yapt���m�z i�in vector 3 bize y eksenini verir
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1; // sol �erit:0 orta �erit:1 sa� �erit:2
    public float laneDistance = 1; //2 �erit aras� mesafe. Karakterimiz s�f�r noktas�nda b�ylece -1 ve 1 e giderek 1 birim yer de�i�tirmi� olacak

    public Animator animator;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    void Update() //update oyun esnas�nda bir�ok kez �al��t���ndan bu tu�a bas�l�p bas�lmad���n�n kontrol�n� burada yapaca��z
    {

        if (!PlayerManager.GameStarted) //
            return; //

        animator.SetBool("GameStarted", true); // oyun ba�lay�nca ko�mas� i�in


        // animator.SetBool("GameOver",PlayerManager.GameOver); // �arp�nca d��me animasyonu gelmesi i�in


        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime; // gittik�e ana karakterimizin h�zlanmas� i�in 

        direction.z = forwardSpeed; //karakterimizin z ekseni �zerinde ilerlemesi i�in yani yolda ileri gitmesi i�in

        if (!PlayerManager.GameOver) { // sa� ve sola y�nlerini oyun bitmemi� ise kullanabilmek i�in
            
        if (Input.GetKeyDown(KeyCode.RightArrow)) //kullan�c�dan ald���m�z klavye giri�i i�in getkeydown tu�a ilk dokundu�umuzda �al��mas� i�in keycode ile de hangi tu� oldu�unu se�eriz. 
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2; //zaten sa�da ise geri sa�da kal�r.**** yani sa� �erit 2 daha fazla art�p 3 olursa geri 2 yapar. yer de�i�mez
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //leftarrow bilgisayarda sol ok tu�undan giri� ald���m�zda
        {
            desiredLane--; //sola gitmesi i�in azalt�yoruz ��nk� 0 1 2 numaral� �eritlerimiz var gibi d���nebiliriz.
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

    }
        // sonraki asamada nerede olmam�z gerektigini hesaplayal�m
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (desiredLane == 0) //sol tarafta olmam�z gerekiyor
        {
            targetPosition += Vector3.left * laneDistance; // o kadar gitmesi i�in serit mesafesi ile carpt�k.
            }
        else if (desiredLane == 2) //sa� taraf
        {
            targetPosition += Vector3.right*laneDistance;
        }

        // e�er 1 ise de�i�meyecek zaten ortada. 1=orta �eritti.
         transform.position = targetPosition;
        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.GameStarted) 
            return;
        controller.Move(direction * Time.fixedDeltaTime);

    }

   
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {

            PlayerManager.GameOver = true;
            FindObjectOfType<SoundManager>().PlaySound("AnimeLost");//anime karakterinin �arp�nca ��karaca�� ses

        }
    }

    
}
