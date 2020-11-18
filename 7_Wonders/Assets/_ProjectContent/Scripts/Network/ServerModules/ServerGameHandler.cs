using System;
using SK_Engine;
using WhiteTeam.GameLogic;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Managers;

namespace WhiteTeam.Network.ServerModules
{

    public enum GameMessageType
    {
        init,
        start,
        card,
        turn_end,
        move,
        counts
    }

    public class ServerGameHandler : ServerModuleHandler<ServerGameHandler>
    {

        protected override void OnTextMessageReceived(string text)
        {
            var result = CardsJsonReceiver.Instance.Deserialize(text);
            var type = AssistanceFunctions.GetEnumByNameUsual<GameMessageType>(result.type);
            switch (type)
            {
                case GameMessageType.init:
                    break;
                case GameMessageType.start:
                    break;
                case GameMessageType.card:
                    var cardType = AssistanceFunctions.GetEnumByNameUsual<CardType>(result.results.type);
                    //GameManager.Instance.On
                    break;
                case GameMessageType.move:
                    //GameManager.Instance.On
                    break;
                case GameMessageType.counts:
                    //GameManager.Instance.On
                    break;
                case GameMessageType.turn_end:
                    break;
                default:
                    break;
            }

        }
        
        public void NextMoveRequest()
        {
            throw new NotImplementedException();
        }
    }
}