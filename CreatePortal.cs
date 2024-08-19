using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
   public GameObject spawnObjects; // Oluşturulacak nesnelerin dizisi
    public float spawnInterval = 5f; // Nesne oluşturma aralığı
    public float destroyInterval;
    private float timer = 0f; // Zamanlayıcı

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            // Rastgele bir nesne oluştur
            
            GameObject newObject = Instantiate(spawnObjects, transform.position, Quaternion.identity);

            // Nesneyi 5 saniye sonra yok et
            Destroy(newObject, destroyInterval);

            timer = 0f;
        }
    }
}








