using System.Collections.Generic;
using UnityEngine;

public static class WaitForSecondsCache
{
    private static Dictionary<float, WaitForSeconds> cache = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds Wait(float seconds)
    {
        if (!cache.ContainsKey(seconds))
            cache[seconds] = new WaitForSeconds(seconds);

        return cache[seconds];
    }
}