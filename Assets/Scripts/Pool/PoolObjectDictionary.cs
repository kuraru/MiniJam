using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectDictionary : MonoBehaviour
{
    private readonly Dictionary<GameObject, PoolObjectContainer> _poolDictionary = new Dictionary<GameObject, PoolObjectContainer>();
    [SerializeField] Transform _parent;
    
    public GameObject Get(GameObject template)
    {
        PoolObjectContainer pool;
        if(!_poolDictionary.TryGetValue(template, out pool))
        {
            pool = gameObject.AddComponent<PoolObjectContainer>( );
            var parent = _parent;
            if(parent == null)
                parent = transform;
            pool.Init( template, parent, 1 );
            _poolDictionary.Add( template, pool );
        }
        return pool.Get(); 
    }

    public T Get<T>(T template) where T:Component
    {
        var obj = Get(template.gameObject);
        return obj.GetComponent<T>( );
    }
}
