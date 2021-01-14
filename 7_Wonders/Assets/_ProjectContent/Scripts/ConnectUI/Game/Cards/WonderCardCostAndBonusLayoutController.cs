using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WonderCardCostAndBonusLayoutController : MonoBehaviour
{
    [SerializeField] private LayoutElement firstCost;
    [SerializeField] private LayoutElement secondCost;
    [SerializeField] private LayoutElement thirdCost;
    [SerializeField] private LayoutElement secondBonus;


    private const int ONE_WIDTH = 100;
    private const int TWO_WIDTH = 140;
    private const int THREE_WIDTH = 180;
    private const int FOUR_WIDTH = 220;

    public void SetLayoutSize(int spriteWidth, int partNum)
    {
        switch (spriteWidth)
        {
            case 48:
                ChoosePart(ONE_WIDTH, partNum);
                break;
            case 96:
                ChoosePart(TWO_WIDTH, partNum);
                break;
            case 144:
                ChoosePart(THREE_WIDTH, partNum);
                break;
            case 192:
                ChoosePart(FOUR_WIDTH, partNum);
                break;
            default:
                ChoosePart(THREE_WIDTH, partNum);
                break;
        }
    }

    private void ChoosePart(int prefWidth, int partNum)
    {
        switch (partNum)
        {
            case 1:
                firstCost.preferredWidth = prefWidth;
                break;
            case 2:
                secondCost.preferredWidth = prefWidth;
                break;
            case 3:
                thirdCost.preferredWidth = prefWidth;
                break;
            case 4:
                secondBonus.preferredWidth = prefWidth;
                break;
        }
    }
}