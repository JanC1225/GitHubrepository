using TMPro;
using UnityEngine;

public class FuncShuffle : MonoBehaviour
{
    public FuncCardManager GetFuncCardManager;

    string num;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shuffle(TextMeshProUGUI[] playCardTextGroup, TextMeshProUGUI[] comCardTextGroup)
    {
        for (int i = 0; i < playCardTextGroup.Length; i++)
        {
            int symbol = Random.Range(0, 4);
            int number = Random.Range(2, 15);
            GetFuncCardManager.playerSymbol[i]=symbol;
            GetFuncCardManager.playerValve[i]=number;

            if (number == 11)
            {
                num = "J";
            }
            else if (number == 12)
            {
                num = "Q";
            }
            else if (number == 13)
            {
                num = "K";
            }
            else if (number == 14)
            {
                num = "A";
            }
            else
            {
                num = number.ToString();
            }

            switch (symbol)
            {
                case 0:
                    playCardTextGroup[i].text = "Club " + num;
                    break;
                case 1:
                    playCardTextGroup[i].text = "Diamond " + num;
                    break;
                case 2:
                    playCardTextGroup[i].text = "Heart " + num;
                    break;
                case 3:
                    playCardTextGroup[i].text = "Spade " + num;
                    break;
            }
        }

        for (int i = 0; i < comCardTextGroup.Length; i++)
        {
            int symbol = Random.Range(0, 4);
            int number = Random.Range(2, 15);
            GetFuncCardManager.comSymbol[i] = symbol;
            GetFuncCardManager.comValve[i] = number;

            if (number == 11)
            {
                num = "J";
            }
            else if (number == 12)
            {
                num = "Q";
            }
            else if (number == 13)
            {
                num = "K";
            }
            else if (number == 14)
            {
                num = "A";
            }
            else
            {
                num = number.ToString();
            }

            switch (symbol)
            {
                case 0:
                    comCardTextGroup[i].text = "Club " + num;
                    break;
                case 1:
                    comCardTextGroup[i].text = "Diamond " + num;
                    break;
                case 2:
                    comCardTextGroup[i].text = "Heart " + num;
                    break;
                case 3:
                    comCardTextGroup[i].text = "Spade " + num;
                    break;
            }
        }
    }
}
