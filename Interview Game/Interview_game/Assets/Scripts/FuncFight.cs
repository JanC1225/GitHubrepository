using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FuncFight : MonoBehaviour
{
    public GameObject Model;

    public FuncCardManager GetFuncCardManager;

    public int comCardNum;
    public float answer;
    public int round;

    bool isRandom;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        Model.transform.DOMove(Vector3.zero, 0);
        round = 0;
    }

    public void PlayCard(int cardNum)
    {
        GetFuncCardManager.playCardGroup[cardNum].transform.DOLocalMove(new Vector3(-120, 0, 0), 0.3f);
        StartCoroutine(Fight(cardNum));
        round += 1;

    }

    public IEnumerator Fight(int cardNum)
    {
        RandomComCard();
        yield return new WaitUntil(() => isRandom == true);

        GetFuncCardManager.comCardGroup[comCardNum].transform.DOLocalMove(new Vector3(120, 0, 0), 0.35f);
        GetFuncCardManager.comCardIsUsed[comCardNum] = true;
        yield return new WaitForSeconds(1);

        GetFuncCardManager.comCardImageGroup[comCardNum].SetActive(true);
        ValueCompare(cardNum, comCardNum);
        yield return new WaitForSeconds(2);

        this.gameObject.transform.DOLocalMove(new Vector3(290, 0, 0), 0.1f);
        GetFuncCardManager.comCardGroup[comCardNum].transform.DOLocalMove(new Vector3(290, 0, 0), 0.1f);
        GetFuncCardManager.playCardGroup[cardNum].transform.DOLocalMove(new Vector3(290, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.5f);

        ModelMove();
        isRandom = false;
    }

    public void RandomComCard()
    {
        int randomNum = Random.Range(0, 10);
        if (GetFuncCardManager.comCardIsUsed[randomNum] == true)
        {
            RandomComCard();
        }
        else
        {
            comCardNum = randomNum;
        }

        isRandom = true;
    }

    public void ValueCompare(int cardNum, int comCardNum)
    {
        if (GetFuncCardManager.playerValve[cardNum] > GetFuncCardManager.comValve[comCardNum])
        {
            answer = -1;
        }
        else if (GetFuncCardManager.playerValve[cardNum] < GetFuncCardManager.comValve[comCardNum])
        {
            answer = 0.5f;
        }
        else if (GetFuncCardManager.playerValve[cardNum] == GetFuncCardManager.comValve[comCardNum])
        {
            if (GetFuncCardManager.playerSymbol[cardNum] > GetFuncCardManager.comSymbol[comCardNum])
            {
                answer = -1;
            }
            else if (GetFuncCardManager.playerSymbol[cardNum] < GetFuncCardManager.comSymbol[comCardNum])
            {
                answer = 0.5f;
            }
            else if (GetFuncCardManager.playerSymbol[cardNum] == GetFuncCardManager.comSymbol[comCardNum])
            {
                answer = 0;
            }
        }
    }

    public void ModelMove()
    {
        Model.transform.position += new Vector3(answer, 0, 0);
    }
}