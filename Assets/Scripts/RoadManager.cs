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
        for(int i=0; i<numberofRoads; i++)  // 6þar olarak yollarýn görünür olmasý için 
        {
            if (i == 0) {
                SpawnRoad(0); }

            else {
               int RandomNumber = Random.Range(0, roadPrefabs.Length); //rastgele olarak ayarladýðýmýz yollarýn tekrar etmesi için yani sonsuz yol döngüsü
                RandomNumber++; // biraz daha az tekrar
                

              SpawnRoad(Random.Range(0, roadPrefabs.Length));  // hep ayný yol seçenekleri geldiði için kullanmýyorum.

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

    private void DeleteRoad() //bilgisayarý yormamamak için kullanýlmayan yollarý geride kalýnca silme // çünkü sürekli döngüde
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

}
