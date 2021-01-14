﻿using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.ServerModules;

namespace WhiteTeam.GameLogic.Actions
{
    public class ExchangeAction : CardAction
    {
        public ExchangeAction(CommonCard card) : base(card)
        {
        }

        protected override void SendRequest(CommonCard card, string command)
        {
            ServerGameHandler.Instance.CardActionRequest(GameManager.Instance.CurrentSession.gameId,card.Data.Id, command);
        }

        public override string GetCommand() => Command.EXCHANGE.ToString();
    }
}