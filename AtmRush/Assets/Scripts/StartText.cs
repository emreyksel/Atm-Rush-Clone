using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public Animator playerAnim;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.insance.isGameStart = true;
            playerAnim.SetTrigger("Run");
            gameObject.SetActive(false);
        }
    }
}
