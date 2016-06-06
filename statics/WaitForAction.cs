using UnityEngine;
using System.Collections;

public static class WaitForAction
{
    public static IEnumerator WaitForEndOfFrame(System.Action method)
    {
        yield return new WaitForEndOfFrame();
        method();
    }
}
