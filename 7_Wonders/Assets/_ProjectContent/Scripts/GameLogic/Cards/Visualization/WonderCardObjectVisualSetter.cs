using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WhiteTeam.GameLogic.Cards.Visualization
{
    public class WonderCardObjectVisualSetter : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameHolder;
        [SerializeField] private Image backgroundHolder;

        [SerializeField] private Image costFirstEraHolder;
        [SerializeField] private Image costSecondEraHolder;
        [SerializeField] private Image costThirdEraHolder;

        [SerializeField] private Image initialBonusHolder;
        [SerializeField] private Image currentEffectStepTwoHolder;

        public void SetName(string cardName)
        {
            Debug.Log($"cardName: {cardName}");
            nameHolder.text = cardName;
        }

        public void SetBackground(Sprite background)
        {
            Debug.Log($"background: {background != null}");
            backgroundHolder.sprite = background;
        }

        public void SetCostFirstEra(Sprite cost)
        {
            Debug.Log($"cost 1 era: {cost != null}");
            costFirstEraHolder.sprite = cost;
        }

        public void SetCostSecondEra(Sprite cost)
        {
            Debug.Log($"cost 2 era: {cost != null}");
            costSecondEraHolder.sprite = cost;
        }

        public void SetCostThirdEra(Sprite cost)
        {
            Debug.Log($"cost 3 era: {cost != null}");
            costThirdEraHolder.sprite = cost;
        }

        public void SetInitialBonus(Sprite initialEffect)
        {
            Debug.Log($"InitialBonus: {initialEffect != null}");
            initialBonusHolder.sprite = initialEffect;
        }

        public void SetCurrentEffectStepTwo(Sprite currentEffect)
        {
            Debug.Log($"CurrentEffectStepTwo: {currentEffect != null}");
            currentEffectStepTwoHolder.sprite = currentEffect;
        }
    }
}