
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction; // 3 boyutlu bir eksende yaptýðýmýz için vector 3 bize y eksenini verir
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1; // sol þerit:0 orta þerit:1 sað þerit:2
    public float laneDistance = 1; //2 þerit arasý mesafe. Karakterimiz sýfýr noktasýnda böylece -1 ve 1 e giderek 1 birim yer deðiþtirmiþ olacak

    public Animator animator;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    void Update() //update oyun esnasýnda birçok kez çalýþtýðýndan bu tuþa basýlýp basýlmadýðýnýn kontrolünü burada yapacaðýz
    {

        if (!PlayerManager.GameStarted) //
            return; //

        animator.SetBool("GameStarted", true); // oyun baþlayýnca koþmasý için


        // animator.SetBool("GameOver",PlayerManager.GameOver); // çarpýnca düþme animasyonu gelmesi için


        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime; // gittikçe ana karakterimizin hýzlanmasý için 

        direction.z = forwardSpeed; //karakterimizin z ekseni üzerinde ilerlemesi için yani yolda ileri gitmesi için

        if (!PlayerManager.GameOver) { // sað ve sola yönlerini oyun bitmemiþ ise kullanabilmek için
            
        if (Input.GetKeyDown(KeyCode.RightArrow)) //kullanýcýdan aldýðýmýz klavye giriþi için getkeydown tuþa ilk dokunduðumuzda çalýþmasý için keycode ile de hangi tuþ olduðunu seçeriz. 
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2; //zaten saðda ise geri saðda kalýr.**** yani sað þerit 2 daha fazla artýp 3 olursa geri 2 yapar. yer deðiþmez
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //leftarrow bilgisayarda sol ok tuþundan giriþ aldýðýmýzda
        {
            desiredLane--; //sola gitmesi için azaltýyoruz çünkü 0 1 2 numaralý þeritlerimiz var gibi düþünebiliriz.
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

    }
        // sonraki asamada nerede olmamýz gerektigini hesaplayalým
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (desiredLane == 0) //sol tarafta olmamýz gerekiyor
        {
            targetPosition += Vector3.left * laneDistance; // o kadar gitmesi için serit mesafesi ile carptýk.
            }
        else if (desiredLane == 2) //sað taraf
        {
            targetPosition += Vector3.right*laneDistance;
        }

        // eðer 1 ise deðiþmeyecek zaten ortada. 1=orta þeritti.
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
            FindObjectOfType<SoundManager>().PlaySound("AnimeLost");//anime karakterinin çarpýnca çýkaracaðý ses

        }
    }

    
}
