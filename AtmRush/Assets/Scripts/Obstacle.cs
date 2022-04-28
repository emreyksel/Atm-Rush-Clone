using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (CollectedList.instance.ýnventory.Count-1 == CollectedList.instance.ýnventory.IndexOf(other.gameObject)) //listenin son elemaný ise
            {
                CollectedList.instance.ýnventory.Remove(other.gameObject);
                Destroy(other.gameObject);
                CollectedList.instance.ScoreUpdate();
            }

            else
            {
                int crashObjIndex = CollectedList.instance.ýnventory.IndexOf(other.gameObject);
                int lastIndex = CollectedList.instance.ýnventory.Count - 1;

                for (int i = crashObjIndex; i <= lastIndex; i++)
                {
                    RemoveList(CollectedList.instance.ýnventory[crashObjIndex]);
                    CollectedList.instance.ScoreUpdate();
                }
            }
        }

        else if (other.CompareTag("Character"))
        {
            StartCoroutine(Crash());
            other.transform.DOMove(other.transform.position - new Vector3(0, 0, 20), 1).SetEase(Ease.OutBounce);
        }
    }

    IEnumerator Crash()
    {
        Forward.insance.speed = 0;
        yield return new WaitForSeconds(1.5f);
        Forward.insance.speed = 15;
    }

    public void RemoveList(GameObject crashObj)
    {
        CollectedList.instance.ýnventory.Remove(crashObj);
        crashObj.tag = "Money";
        crashObj.GetComponent<BoxCollider>().isTrigger = true;
        crashObj.GetComponent<Collect>().enabled = false;

        GameObject bounceMoney = Instantiate(crashObj,RandomPos(transform),Quaternion.identity);
        Destroy(bounceMoney.GetComponent<Rigidbody>());
        bounceMoney.transform.DOMove(bounceMoney.transform.position - new Vector3(0, 2, 0), 1).SetEase(Ease.OutBounce);
        Destroy(crashObj);      
    }

    public Vector3 RandomPos(Transform obstacle)
    {
        float x = Random.Range(-4, 4);
        float z = Random.Range(20, 30);
        Vector3 posisiton = new Vector3(x, 3, obstacle.position.z + z);
        return posisiton;
    }
}
