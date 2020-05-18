using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, 2.5f);
            HealthManager.health += 50;
        }
        else
        {

        }
    }
}
