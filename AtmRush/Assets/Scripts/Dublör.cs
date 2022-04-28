using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Dublör : MonoBehaviour
{
    public FinishCam finishCam;
    public TextMeshProUGUI score;

    private void Start()
    {
        transform.DOMove(new Vector3(0, 0.7f, 230),1);
        transform.DORotate(new Vector3(0, 180, 0), 1).OnComplete(() => finishCam.target = transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RankCube"))
        {
            other.transform.DOMoveZ(other.transform.position.z - 5, 0.5f);
        }
    }

    private void Update()
    {
        score.text = Mathf.Ceil(transform.position.y).ToString();
    }
}
