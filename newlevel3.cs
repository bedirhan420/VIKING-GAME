using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newlevel3 : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level4");
    }
}
