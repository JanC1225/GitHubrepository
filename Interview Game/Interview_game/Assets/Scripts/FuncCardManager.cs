using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class FuncCardManager : MonoBehaviour
{
    public FuncLicensing GetFuncLicensing;
    public FuncShuffle GetFuncShuffle;

    public GameObject[] playCardGroup;
    public GameObject[] comCardGroup;

    public GameObject[] playCardImageGroup;
    public GameObject[] comCardImageGroup;

    public TextMeshProUGUI[] playCardTextGroup;
    public TextMeshProUGUI[] comCardTextGroup;

    public int[] playerSymbol;
    public int[] playerValve;

    public int[] comSymbol;
    public int[] comValve;

    public bool[] comCardIsUsed;

    // Start is called before the first frame update
    void Start()
    {
        playerSymbol = new int[playCardGroup.Length];
        playerValve = new int[playCardGroup.Length];
        comSymbol = new int[comCardGroup.Length];
        comValve = new int[comCardGroup.Length];
        comCardIsUsed = new bool[comCardGroup.Length];

        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        foreach (var card in playCardGroup)
        {
            card.transform.DOLocalMove(new Vector3(290, 0, 0), 0.1f);
        }
        foreach (var card in comCardGroup)
        {
            card.transform.DOLocalMove(new Vector3(290, 0, 0), 0.1f);
        }

        foreach (var iamge in playCardImageGroup)
        {
            iamge.SetActive(false);
        }
        foreach (var iamge in comCardImageGroup)
        {
            iamge.SetActive(false);
        }
        for (int i = 0; i < comCardGroup.Length; i++)
        {
            comCardIsUsed[i] = false;
        }

        GetFuncLicensing.Reset();
    }

    public IEnumerator CardActive()
    {
        StartCoroutine(GetFuncLicensing.Licensing(playCardGroup, comCardGroup));
        GetFuncShuffle.Shuffle(playCardTextGroup, comCardTextGroup);

        yield return new WaitUntil(() => GetFuncLicensing.isEnd == true);
        foreach (var iamge in playCardImageGroup)
        {
            iamge.SetActive(true);
        }
    }
}
