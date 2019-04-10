using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackServices.Services.Interfaces
{
    public interface ICacheWrapperService
    {
        void SaveToCache<T>(string key, T data);

        void RemoveFromCache(string key);

        T GetFromCache<T>(string key);

    }
}
