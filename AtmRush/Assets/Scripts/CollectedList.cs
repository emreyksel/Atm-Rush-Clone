using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectedList : MonoBehaviour
{
    public static CollectedList instance;

    public List<GameObject> ýnventory = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public Transform player;
    [HideInInspector] public int score;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Follow();
    }

    public void Stack(GameObject obj, int index)
    {
        obj.transform.parent = player;
        Vector3 newPos = ýnventory[index].transform.localPosition;

        if (ýnventory[index].CompareTag("Character"))
        {
            newPos += new Vector3(0, 1, 2);
        }
        else
        {
            newPos.z += 1;
        }       
        
        obj.transform.localPosition = newPos;
        ýnventory.Add(obj);
        StartCoroutine(CubeScale());
        ScoreUpdate();
    }

    public void Follow()
    {
        for (int i = 1; i < ýnventory.Count; i++)
        {
            if (ýnventory[i].transform.localPosition != null)
            {
                Vector3 pos = ýnventory[i].transform.localPosition;
                pos.x = ýnventory[i - 1].transform.localPosition.x;
                ýnventory[i].transform.DOLocalMove(pos, 0.1f);
            }
        }
    }

    public IEnumerator CubeScale()
    {
        for (int i = ýnventory.Count - 1; i >= 1; i--)
        {
            int index = i; 
            Vector3 scale = Vector3.one * 1.5f;
            ýnventory[index].transform.DOScale(scale, 0.1f).OnComplete(() => ýnventory[index].transform.DOScale(Vector3.one, 0.1f));
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void ScoreUpdate()
    {
        score = 0;
        for (int i = 1; i < ýnventory.Count; i++)
        {
            score += ýnventory[i].GetComponent<Money>().value;
        }

        scoreText.text = score.ToString();
    }
}
