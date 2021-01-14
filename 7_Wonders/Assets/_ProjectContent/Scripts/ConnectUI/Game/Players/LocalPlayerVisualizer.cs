using TMPro;
using UnityEngine;
using WhiteTeam.GameLogic.Resources;

public class LocalPlayerVisualizer : Singleton<LocalPlayerVisualizer>
{
        [Header("Stats")] 
        [SerializeField] private TMP_Text MoneyText;

        [SerializeField] private TMP_Text MilitaryText;
        [SerializeField] private TMP_Text VictoryText;

        [SerializeField] private TMP_Text WarVictoryTokensText;
        [SerializeField] private TMP_Text WarLoseTokensText;

        [SerializeField] private TMP_Text Rune1Text;
        [SerializeField] private TMP_Text Rune2Text;
        [SerializeField] private TMP_Text Rune3Text;

        [SerializeField] private TMP_Text WoodText;
        [SerializeField] private TMP_Text OreText;
        [SerializeField] private TMP_Text ClayText;
        [SerializeField] private TMP_Text StoneText;

        [SerializeField] private TMP_Text PapyrusText;
        [SerializeField] private TMP_Text ClothText;
        [SerializeField] private TMP_Text GlassText;

        public void Show(OutputResources resources)
        {
            // STATS
            MoneyText.text = resources.Money.ToString();

            MilitaryText.text = resources.Military.ToString();
            VictoryText.text = resources.Victory.ToString();

            WarVictoryTokensText.text = resources.WarVictoryTokens.ToString();
            WarLoseTokensText.text = resources.WarLoseTokens.ToString();

            Rune1Text.text = resources.Rune1.ToString();
            Rune2Text.text = resources.Rune2.ToString();
            Rune3Text.text = resources.Rune3.ToString();

            WoodText.text = resources.Wood.ToString();
            OreText.text = resources.Ore.ToString();
            ClayText.text = resources.Clay.ToString();
            StoneText.text = resources.Stone.ToString();

            PapyrusText.text = resources.Papyrus.ToString();
            ClothText.text = resources.Cloth.ToString();
            GlassText.text = resources.Glass.ToString();
        }
}
