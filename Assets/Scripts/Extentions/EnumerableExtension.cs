using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class EnumerableExtension 
{
    public static T PickRandom<T>(this List<T> source)
    {
        if (source.Count == 0)
        {
          Debug.Log("List count is null");    
        }
        var index = Random.Range(0, source.Count);
        return source[index];
    }
}
