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
        cardUse, // исользование/продажа/перевыбор
        wonderUse,
        turnEnd,
        newEpoch,
        move,
        endGameScore
    }

    public class ServerGameHandler : ServerModuleHandler<ServerGameHandler>
    {
        private void Start()
        {
            var initMessage =
                "{\"status\":\"SUCCESS\",\"results\":{\"initInfo\": {\"cards\": [], \"wonderCards\"}},\"module\":\"Game\",\"type\":\"init\"}";
        }

        protected override void OnTextMessageReceived(string text)
        {
            var result = GameJsonReceiver.Instance.Deserialize(text);
            var type = AssistanceFunctions.GetEnumByNameUsual<GameMessageType>(result.type);
            switch (type)
            {
                case GameMessageType.init:
                    //var cardType = AssistanceFunctions.GetEnumByNameUsual<CardType>(result.results.cards[].type);
                    //GameManager.Instance.Init(result.results.initInfo);
                    break;
                case GameMessageType.start:
                    //GameManager.Instance.Start(result.results.startInfo);
                    break;
                case GameMessageType.cardUse:
                    //GameManager.Instance.On
                    break;
                case GameMessageType.wonderUse:
                    //GameManager.Instance.On
                    break;
                case GameMessageType.move:
                    //GameManager.Instance.On
                    break;
                case GameMessageType.newEpoch:
                    break;
                case GameMessageType.turnEnd:
                    break;
                case GameMessageType.endGameScore:
                    //GameManager.Instance.On
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