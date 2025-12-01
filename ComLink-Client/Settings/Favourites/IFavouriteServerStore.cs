using System.Collections.Generic;

namespace ORBIT.ComLink.Client.Settings.Favourites;

public interface IFavouriteServerStore
{
    IEnumerable<ServerAddress> LoadFromStore();

    bool SaveToStore(IEnumerable<ServerAddress> addresses);
}