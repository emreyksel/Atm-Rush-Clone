using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectedList : MonoBehaviour
{
    public static CollectedList instance;

    public List<GameObject> �nventory = new List<GameObject>();
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
        Vector3 newPos = �nventory[index].transform.localPosition;

        if (�nventory[index].CompareTag("Character"))
        {
            newPos += new Vector3(0, 1, 2);
        }
        else
        {
            newPos.z += 1;
        }       
        
        obj.transform.localPosition = newPos;
        �nventory.Add(obj);
        StartCoroutine(CubeScale());
        ScoreUpdate();
    }

    public void Follow()
    {
        for (int i = 1; i < �nventory.Count; i++)
        {
            if (�nventory[i].transform.localPosition != null)
            {
                Vector3 pos = �nventory[i].transform.localPosition;
                pos.x = �nventory[i - 1].transform.localPosition.x;
                �nventory[i].transform.DOLocalMove(pos, 0.1f);
            }
        }
    }

    public IEnumerator CubeScale()
    {
        for (int i = �nventory.Count - 1; i >= 1; i--)
        {
            int index = i; 
            Vector3 scale = Vector3.one * 1.5f;
            �nventory[index].transform.DOScale(scale, 0.1f).OnComplete(() => �nventory[index].transform.DOScale(Vector3.one, 0.1f));
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void ScoreUpdate()
    {
        score = 0;
        for (int i = 1; i < �nventory.Count; i++)
        {
            score += �nventory[i].GetComponent<Money>().value;
        }

        scoreText.text = score.ToString();
    }
}
