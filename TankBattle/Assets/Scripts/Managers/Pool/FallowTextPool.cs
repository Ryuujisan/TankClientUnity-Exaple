using System.Collections.Generic;
using UnityEngine;

public class FallowTextPool : MonoBehaviour
{

    [SerializeField]
    private GameObject ballPrefab;

    private List<FallowText> fallowtextList = new List<FallowText>();
    private Stack<FallowText> freeText = new Stack<FallowText>();

    private int countPool = 64;

    void Awake()
    {
        for (int i = 0; i < countPool; i++)
        {
            GameObject temp = Instantiate(ballPrefab) as GameObject;
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1f, 1f, 0);

            FallowText tempScript = temp.GetComponent<FallowText>();

            if (tempScript != null)
            {
                fallowtextList.Add(tempScript);
                freeText.Push(tempScript);
            }

            temp.SetActive(false);
        }
    }

    private void ExtendPool()
    {
        //TODO: na później
    }

    public FallowText GetPool()
    {
        FallowText fallowText = freeText.Pop();
        fallowText.gameObject.SetActive(true);

        return fallowText;
    }

    public void ReturnPool(FallowText fallowText)
    {
        fallowText.gameObject.SetActive(false);

        freeText.Push(fallowText);
    }
}
