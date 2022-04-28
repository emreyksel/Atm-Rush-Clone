using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void Start()
    {       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            if (!CollectedList.instance.ýnventory.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false; 
                other.gameObject.tag = "Collected";
                other.gameObject.GetComponent<Collect>().enabled = true;
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; 

                CollectedList.instance.Stack(other.gameObject, CollectedList.instance.ýnventory.Count - 1);
            }
        }
    }
}
