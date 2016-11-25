using UnityEngine;
using System.Collections;

public class ServerTimeout : MonoBehaviour
{
    public IEnumerator WaitForDoneProcess(WWW www, float timeout)
    {
        while (!www.isDone)
        {
            yield return null;
            timeout -= Time.deltaTime;

            if (timeout <= 0f)
                break;
        }
    }

    public IEnumerator WaitForDoneProcess(bool condition, float timeout)
    {
        while (!condition)
        {
            yield return null;
            timeout -= Time.deltaTime;

            if (timeout <= 0f)
                break;
        }
    }

    public YieldInstruction WaitForDone(WWW www, float timeout)
    {
        return StartCoroutine(WaitForDoneProcess(www, timeout));
    }

    public YieldInstruction WaitForDone(bool condition, float timeout)
    {
        return StartCoroutine(WaitForDoneProcess(condition, timeout));
    }
	
}
