using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishControl : MonoBehaviour
{
    public Camera mainCamera;
    public Camera finisCamera;
    public FinalMoneyCreate fmc;
    public GameObject dublör;
    private bool once = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Conveyor") && !once)
        {
            if (GetComponent<CollectedList>().ýnventory.Count ==1)
            {
                StartCoroutine(NewCamera());
            }

            once = true;
        }
    }

    public IEnumerator NewCamera()
    {
        yield return new WaitForSeconds(2);
        finisCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);

        foreach (GameObject item in fmc.finalMoneys)
        {
            item.SetActive(true);
        }

        dublör.SetActive(true);
    }
}
