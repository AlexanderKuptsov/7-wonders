using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpochChanger : Singleton<EpochChanger>
{
    [SerializeField] private Sprite firstEpochSprite;
    [SerializeField] private Sprite secondEpochSprite;
    [SerializeField] private Sprite thirdEpochSprite;
    [SerializeField] private Image epochHolder;
    private int epoch = 1;

    public void ChangeEpoch()
    {
        switch (epoch)
        {
            case 1:
                epochHolder.sprite = secondEpochSprite;
                epoch += 1;
                break;
            case 2:
                epochHolder.sprite = thirdEpochSprite;
                epoch += 1;
                break;
            default:
                epochHolder.sprite = firstEpochSprite;
                break;
        }
    }
}