using UnityEngine;
using System.Collections;

public static class EditorBaseSize
{
    public static int unityEditorBaseScreenHeight = 0; //Replace with the editor window height
    public static int unityEditorBaseScreenWidth = 0; //Replace with the editor window width

    public static float ScaleFactorByHeight { get; private set; }
    public static float ScaleFactorByWidth { get; private set; }


    //Call both Setter methods at application's first start
    public static void SetScaleFactorByHeight()
    {
        ScaleFactorByHeight = (float)Screen.height / (float)unityEditorBaseScreenHeight;
    }

    public static void SetScaleFactorByWidth()
    {
        ScaleFactorByWidth = (float)Screen.width / (float)unityEditorBaseScreenWidth;
    }


    //For Mobile
    public static int GetIntNewSizeByHeight(int oldIntSize)
    {
        return Mathf.RoundToInt(oldIntSize * EditorBaseSize.ScaleFactorByHeight);
    }

    public static int GetIntNewSizeByWidth(int oldIntSize)
    {
        return Mathf.RoundToInt(oldIntSize * EditorBaseSize.ScaleFactorByWidth);
    }

    public static float GetFloatNewSizeByHeight(float oldFloatSize)
    {
        return oldFloatSize * EditorBaseSize.ScaleFactorByHeight;
    }

    public static float GetNewSizeByWidth(float oldFloatSize)
    {
        return oldFloatSize * EditorBaseSize.ScaleFactorByWidth;
    }

}
