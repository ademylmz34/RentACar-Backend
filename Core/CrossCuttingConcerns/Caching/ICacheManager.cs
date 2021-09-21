using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);//generic olmadan yazarsak.
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//cache de var mı yoksa veritabanından getirecek.
        void Remove(string key);//cache den uçurma.
        void RemoveByPattern(string pattern);

    }
}
