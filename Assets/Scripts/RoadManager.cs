using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLength = 14;
    public int numberofRoads = 6;
    public Transform playerTransform;
    private List<GameObject> activeRoads = new List<GameObject>();

    void Start()
    {
        for(int i=0; i<numberofRoads; i++)  // 6�ar olarak yollar�n g�r�n�r olmas� i�in 
        {
            if (i == 0) {
                SpawnRoad(0); }

            else {
               int RandomNumber = Random.Range(0, roadPrefabs.Length); //rastgele olarak ayarlad���m�z yollar�n tekrar etmesi i�in yani sonsuz yol d�ng�s�
                RandomNumber++; // biraz daha az tekrar
                

              SpawnRoad(Random.Range(0, roadPrefabs.Length));  // hep ayn� yol se�enekleri geldi�i i�in kullanm�yorum.

            } 
        }
    }

    

    void Update()
    {
        if (playerTransform.position.z -14> zSpawn - (numberofRoads * roadLength))
        {
            
            SpawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoad(int roadIndex)
    {
        GameObject go = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);
       // GameObject go = gameObject1;
        activeRoads.Add(go);
        zSpawn += roadLength;
        
    }

    private void DeleteRoad() //bilgisayar� yormamamak i�in kullan�lmayan yollar� geride kal�nca silme // ��nk� s�rekli d�ng�de
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

}
