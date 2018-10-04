//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;

public static class UnityUtil {

    private static bool debugThis = false;
	
    public static void DestroyThis(Object target) {
        if (debugThis) Debug.Log(string.Format("DestroyThis ( target: {0} )", target.name), target);
        Object.Destroy(target);
    }

    public static void DestroyThis (Object target, float delay) {
        if (debugThis) Debug.Log(string.Format("DestroyThis ( target: {0} , delay: {1} )", target.name, delay), target);
        Object.Destroy(target, delay);
    }

}
