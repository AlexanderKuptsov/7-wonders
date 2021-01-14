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
        [SerializeField] private WonderCardCostAndBonusLayoutController layoutController;

        public void SetName(string cardName)
        {
            if (nameHolder == null) return;
            // Debug.Log($"cardName: {cardName}");
            nameHolder.text = cardName;
        }

        public void SetBackground(Sprite background)
        {
            // Debug.Log($"background: {background != null}");
            backgroundHolder.sprite = background;
            backgroundHolder.enabled = background != null;
        }

        public void SetCostFirstEra(Sprite cost)
        {
            // Debug.Log($"cost 1 era: {cost != null}");
            costFirstEraHolder.sprite = cost;
            Debug.Log($"WIDTH: {cost.rect.width}");
            layoutController.SetLayoutSize((int)cost.rect.width, 1);
            costFirstEraHolder.enabled = cost != null;
        }

        public void SetCostSecondEra(Sprite cost)
        {
            // Debug.Log($"cost 2 era: {cost != null}");
            costSecondEraHolder.sprite = cost;
            layoutController.SetLayoutSize((int)cost.rect.width, 2);
            costSecondEraHolder.enabled = cost != null;
        }

        public void SetCostThirdEra(Sprite cost)
        {
            // Debug.Log($"cost 3 era: {cost != null}");
            costThirdEraHolder.sprite = cost;
            layoutController.SetLayoutSize((int)cost.rect.width, 3);
            costThirdEraHolder.enabled = cost != null;
        }

        public void SetInitialBonus(Sprite initialEffect)
        {
            // Debug.Log($"InitialBonus: {initialEffect != null}");
            initialBonusHolder.sprite = initialEffect;
            initialBonusHolder.enabled = initialEffect != null;
        }

        public void SetCurrentEffectStepTwo(Sprite currentEffect)
        {
            // Debug.Log($"CurrentEffectStepTwo: {currentEffect != null}");
            currentEffectStepTwoHolder.sprite = currentEffect;
            layoutController.SetLayoutSize((int)currentEffect.rect.width, 4);
            currentEffectStepTwoHolder.enabled = currentEffect != null;
        }
    }
}