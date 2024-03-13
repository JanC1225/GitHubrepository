using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FuncLicensing : MonoBehaviour
{
    Vector3 playerFirstCardPos;
    Vector3 comFirstCardPos;
    Vector3 cardGap;

    float licensingSec;

    public bool isEnd;

    void Start()
    {
        cardGap = new Vector3(55, 0, 0);
        playerFirstCardPos = new Vector3(-275f, -120, 0);
        comFirstCardPos = new Vector3(-275f, 120, 0);
        licensingSec = 0.2f;
        isEnd = false;
    }

    public void Reset()
    {
        isEnd = false;
    }

    public IEnumerator Licensing(GameObject[] playCardGroup, GameObject[] comCardGroup)
    {
        for (int i = 0; i < playCardGroup.Length; i++)
        {
            playCardGroup[i].transform.DOLocalMove(playerFirstCardPos + cardGap * i, licensingSec);
            yield return new WaitForSeconds(licensingSec);

            comCardGroup[i].transform.DOLocalMove(comFirstCardPos + cardGap * i, licensingSec);
            yield return new WaitForSeconds(licensingSec);
        }

        isEnd = true;
    }
}
