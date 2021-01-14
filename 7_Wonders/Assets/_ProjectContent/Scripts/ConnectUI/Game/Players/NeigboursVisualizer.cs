using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic.Resources;

public class NeigboursVisualizer : MonoBehaviour
{
    [Header("Stats")] [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text MoneyText;

    [SerializeField] private TMP_Text WoodText;
    [SerializeField] private TMP_Text OreText;
    [SerializeField] private TMP_Text ClayText;
    [SerializeField] private TMP_Text StoneText;

    [SerializeField] private TMP_Text PapyrusText;
    [SerializeField] private TMP_Text ClothText;
    [SerializeField] private TMP_Text GlassText;

    public void Show(string playerName, OutputResources resources)
    {
        // STATS
        NameText.text = $"({playerName})";

        MoneyText.text = resources.Money.ToString();

        WoodText.text = resources.Wood.ToString();
        OreText.text = resources.Ore.ToString();
        ClayText.text = resources.Clay.ToString();
        StoneText.text = resources.Stone.ToString();

        PapyrusText.text = resources.Papyrus.ToString();
        ClothText.text = resources.Cloth.ToString();
        GlassText.text = resources.Glass.ToString();
    }
}