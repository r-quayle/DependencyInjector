using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.DependencyInjector
{
    public class Container
    {
        Dictionary<Type, BaseFactory> _factories = new Dictionary<Type, BaseFactory>();
        Dictionary<Type, object> _cache = new Dictionary<Type, object>();
        bool _firstCall = false;
        public void Add<T>(Func<T> getter, Lifetimes lifetime = Lifetimes.OnRequest) where T : class
        {
            if (_factories.ContainsKey(typeof(T)))
            {
                throw new Exception($"Type {typeof(T).ToString()} has already been added.");
            }
            _factories.Add(typeof(T), new Factory<T>(getter, lifetime));
        }
        public void AddAsConstant<T>(T obj) where T : class
        {
            if (_factories.ContainsKey(typeof(T)))
            {
                throw new Exception($"Type {typeof(T).ToString()} has already been added.");
            }
            _factories.Add(typeof(T), new Factory<T>(() => obj, Lifetimes.Singleton));
        }
        public void Replace<T>(Func<T> getter, Lifetimes lifetime = Lifetimes.OnRequest) where T : class
        {
            if (_factories.ContainsKey(typeof(T)))
            {
                _factories[typeof(T)] = new Factory<T>(getter, lifetime);
            }
            else
            {
                _factories.Add(typeof(T), new Factory<T>(getter, lifetime));
            }
        }
        public void ReplaceWithConstant<T>(T obj) where T : class
        {
            if (_factories.ContainsKey(typeof(T)))
            {
                _factories[typeof(T)] = new Factory<T>(() => obj, Lifetimes.Singleton);
            }
            else
            {
                _factories.Add(typeof(T), new Factory<T>(() => obj, Lifetimes.Singleton));
            }
        }
        public T Get<T>() where T : class
        {
            if(_firstCall == true)
            {
                //throw new Exception("All DI initi must be carried before first call");

            }
            _firstCall = true;
            Factory<T> factory = _factories[typeof(T)] as Factory<T>;
            T result;
            if (factory.Lifetime == Lifetimes.Singleton)
            {
                if (!_cache.ContainsKey(typeof(T)))
                {
                    _cache[typeof(T)] = factory.Build() as T;
                }
                result = _cache[typeof(T)] as T;
            }
            else
            {
                result = factory.Build() as T;
            }
            return result;
        }
        public void Load(List<DIModule> dIModules)
        {
            dIModules.ForEach(dim => dim.Load(this));
        }
    }
    public abstract class BaseFactory
    {
        public abstract object Build();
        public Lifetimes Lifetime { get; set; }
    }
    public class Factory<T> : BaseFactory where T : class
    {
        Func<T> _getter;
        public Factory(Func<T> getter, Lifetimes lifetime)
        {
            _getter = getter;
            Lifetime = lifetime;
        }
        public override object Build()
        {
            return _getter();
        }
    }
}
