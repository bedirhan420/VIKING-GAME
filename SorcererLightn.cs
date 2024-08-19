using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererLightn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ll;
    public GameObject rl;
   public float activationInterval = 1f;
    public float activeDuration = 1f;

    private float timeSinceLastActivation;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastActivation += Time.deltaTime;

        if (timeSinceLastActivation >= activationInterval)
        {
            ll.SetActive(true);
            rl.SetActive(true);
            Invoke("DeactivateObject", activeDuration);
            timeSinceLastActivation = 0f;
        }
    }
    private void DeactivateObject()
    {
        ll.SetActive(false);
        rl.SetActive(false);
    }
}
