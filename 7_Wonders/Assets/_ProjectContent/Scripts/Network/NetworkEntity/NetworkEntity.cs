using System.Collections.Generic;
using System.Linq;

namespace WhiteTeam.Network.Entity
{
    public class NetworkEntity
    {
        public static T FindEntityById<T>(IEnumerable<T> entities, string id) where T : INetworkEntity
        {
            return entities.FirstOrDefault(entity => entity.GetIdentifierInfo().Id == id);
        }

        public static bool FindEntityById<T>(IEnumerable<T> entities, string id, out T foundEntity)
            where T : INetworkEntity
        {
            foundEntity = FindEntityById(entities, id);
            return foundEntity != null;
        }
    }
}