using UnityEngine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.ConnectingUI.Cards
{
    public class CardActionsUI : MonoBehaviour
    {
        [SerializeField] private GameObject cardObject;
        [SerializeField] private CardElement cardElement;

        [SerializeField] private GameObject actionsHolder;

        private PlayerData localPlayer => GameManager.Instance.CurrentSession.LocalPlayerData;

        private bool localPlayerIsMoved => localPlayer.MoveState == PlayerData.MoveStateType.COMPLETED;

        public void Show()
        {
            if (localPlayerIsMoved) return;
            actionsHolder.SetActive(true);
        }

        public void Close()
        {
            actionsHolder.SetActive(false);
        }

        public void Use()
        {
            if (localPlayerIsMoved) return;

            var card = cardElement.Card;
            if (card.Data.CanBuy(localPlayer))
            {
                card.Data.Buy(localPlayer);
                card.Use(localPlayer);
                CardActionsControllerUI.Instance.ActivateCard(card);
                Close();
                Destroy(cardObject);
            }
            else
            {
                Close();
            }
        }

        public void Exchange()
        {
            if (localPlayerIsMoved) return;

            cardElement.Card.Exchange(localPlayer);

            Close();
            Destroy(cardObject);
        }

        public void BuildWonder()
        {
            if (localPlayerIsMoved) return;

            var wonderCard = localPlayer.WonderCard;
            if (wonderCard.Data.CanBuildCurrentStep(localPlayer))
            {
                wonderCard.Build(localPlayer, cardElement.Card);
                WonderCardGameSetup.Instance.WonderBuild();
                Close();
                Destroy(cardObject);
            }
            else
            {
                Close();
            }
        }
    }
}