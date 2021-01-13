using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class CardObjectVisualSetter : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameHolder;
        [SerializeField] private Image costHolder;
        [SerializeField] private Image backgroundColorHolder;
        [SerializeField] private Image backgroundHolder;
        [SerializeField] private Image currentEffectHolder;
        [SerializeField] private Image endGameEffectHolder;

        public void SetName(string cardName)
        {
            // Debug.Log($"cardName: {cardName}");
            nameHolder.text = cardName;
        }

        public void SetColor(Color cardColor)
        {
            // Debug.Log($"cardColor: {cardColor}");
            backgroundColorHolder.color = cardColor; // TODO -- background?
        }

        public void SetCostEffect(Sprite cost)
        {
            // Debug.Log($"cost: {cost != null}");
            costHolder.sprite = cost;
            costHolder.enabled = cost != null;
        }

        public void SetBackground(Sprite background)
        {
            // Debug.Log($"background: {background != null}");
            backgroundHolder.sprite = background;
            backgroundHolder.enabled = background != null;
        }

        public void SetCurrentEffect(Sprite currentEffect)
        {
            // Debug.Log($"currentEffect: {currentEffect != null}");
            currentEffectHolder.sprite = currentEffect;
            currentEffectHolder.enabled = currentEffect != null;
        }

        public void SetEndGameEffect(Sprite endGameEffect)
        {
            // Debug.Log($"endGameEffect: {endGameEffect != null}");
            endGameEffectHolder.sprite = endGameEffect;
            endGameEffectHolder.enabled = endGameEffect != null;
        }
    }
}