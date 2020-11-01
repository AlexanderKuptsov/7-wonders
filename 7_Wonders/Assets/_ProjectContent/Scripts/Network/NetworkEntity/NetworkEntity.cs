using System.Collections.Generic;
using System.Linq;

namespace WhiteTeam.Network.Entity
{
    public class NetworkEntity
    {
        public static T GetEntityById<T>(IEnumerable<T> entities, string id) where T : INetworkEntity
        {
            return entities.FirstOrDefault(entity => entity.GetIdentifierInfo().Id == id);
        }
    }
}