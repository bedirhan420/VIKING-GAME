using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulThrow : MonoBehaviour
{
    public Transform hedef; // Mermi tarafından takip edilecek hedef
    public float hiz = 5f; // Mermi hızı

    void Update()
    {
        if (hedef != null)
        {
            // Hedefin pozisyonuna doğru hareket etmek için vektör hesaplaması yapılır
            Vector2 hareketYonu = hedef.position - transform.position;
            hareketYonu.Normalize(); // Hareket yönü vektörü normalize edilir (uzunluğu 1'e getirilir)

            // Hareket yönünde hızla ilerlemek için rigidbody bileşenine kuvvet uygulanır
            GetComponent<Rigidbody2D>().velocity = hareketYonu * hiz;
        }
    }
}
