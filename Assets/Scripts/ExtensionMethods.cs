using UnityEngine;
using System.Collections.Generic;

public static class ExtensionMethods  {

    #region List
    
        #region  Stack List
        //Use List as a Stack.
    /// <summary>
    /// Get the top element of the stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T Pop<T>(this List<T> list )
    {
        if(list.Count <= 0)
        {
            return default(T);
        }
        T tmp = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return tmp;
    }

    /// <summary>
    /// Add an element to the top of the stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="value"></param>
    public static void Push<T>(this List<T> list, T value )
    {
        list.Add(value);
    }

    /// <summary>
    /// Look at the top element of the stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T Peek<T>(this List<T> list)
    {
        if (list.Count <= 0)
        {
            return default(T);
        }
        return list[list.Count - 1];
    }

    #endregion
    public static T Random<T>(this List<T> list)
    {
        var count = list.Count;
        if( count == 0 )
            return default(T);
        return list[UnityEngine.Random.Range(0,count)];
    }

    public static T Random<T>(this T[] array)
    {
        var lenght = array.Length;
        if( lenght == 0 )
            return default( T );
        return array[UnityEngine.Random.Range( 0, lenght )];
    }

    #endregion

    #region Dictionary
    /// <summary>
    /// Add if the dictionary doesnt contain the key. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>True if pair added</returns>
    public static bool AddUnique<T,K>(this Dictionary<T,K> dictionary, T key, K value)
    {
        if(!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
            return true;
        }
        return false;  

    }

    #endregion
    
    #region Component
    /// <summary>
    /// Get the attached component or add a new one.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="component"></param>
    /// <returns>The attached component</returns>
    public static T  GetOrAddComponent<T>(this Component component) where T: Component 
    {
        T tmp = component.GetComponent<T>();
        if(tmp == null)
        {
            tmp = component.gameObject.AddComponent<T>();
        }
        return tmp;
    }
    #endregion
    
    #region GameObject
    /// <summary>
    /// Get the attached component or add a new one.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="component"></param>
    /// <returns>The attached component</returns>
    public static T GetOrAddComponent<T>(this GameObject component) where T : Component
    {
        T tmp = component.GetComponent<T>();
        if (tmp == null)
        {
            tmp = component.AddComponent<T>();
        }
        return tmp;
    }
    #endregion

    #region Transform
    /// <summary>
    /// Return the first transform with the desired Name.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="grandchildName">Name to search</param>
    /// <returns>First transform with the the desired name.</returns>
    public static Transform FindGrandchild(this Transform transform, string grandchildName)
    {
        var result = transform.Find(grandchildName);
        if (result != null)
            return result;
        foreach (Transform child in transform)
        {
            result = child.FindGrandchild(grandchildName);
            if (result != null)
                return result;
        }
        return null;
    }
    /// <summary>
    /// Search for all the children that have the desired name.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="grandchildrenName"></param>
    /// <returns></returns>
    public static Transform[] FindGrandchildren(this Transform transform, string grandchildrenName)
    {
        List<Transform> result = new List<Transform>();
        var tmp = transform.Find(grandchildrenName);
        if (tmp != null)
            result.Add(tmp);
        foreach (Transform child in transform)
        {
            tmp = child.FindGrandchild(grandchildrenName);
            if (result != null)
                result.Add(tmp);
        }
        return result.ToArray();
    }

    #endregion

    #region Animator
    /// <summary>
    /// Check if the animator contains a parameter.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="parameter">the parameter name to search</param>
    /// <returns>true if parameter found in the Animator; otherwise false</returns>
    public static bool Contains(this Animator animator, string parameter)
    {
        for(int i = 0; i < animator.parameterCount; ++i)
        {
            if (animator.parameters[i].name == parameter)
            {
                return true;
            }
        }
        return false;
    }
    #endregion

}
