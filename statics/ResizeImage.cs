using UnityEngine;
using UnityEngine.UI;

public static class ResizeImage
{
    public static void ResizeToFill(Texture textureToResize, RectTransform objRectToBeFilled)
    {
        //Debug.Log("imgObj width, height: " + objRect.rect.width + ", " + objRect.rect.height);
        //Debug.Log("mediaRequest width, height: " + image.width + ", " + image.height);
        //Debug.Log("mediaObj anchorMin, anchorMax: " + objRect.anchorMin + ", " + objRect.anchorMax);

        objRectToBeFilled.anchorMin = new Vector2(0, 0);
        objRectToBeFilled.anchorMax = new Vector2(1, 1);

        if (textureToResize.width != textureToResize.height)
        {
            float safetyMargin = 0.1f;
            float widthDiffInPixels = 0;
            float HeightDiffInPixels = 0;
            float widthProportion = 0;
            float heightProportion = 0;

            //Case 1 & 2 - Both measures are bigger or both are smaller
            if ((textureToResize.width > objRectToBeFilled.rect.width && textureToResize.height > objRectToBeFilled.rect.height) ||
                (textureToResize.width < objRectToBeFilled.rect.width && textureToResize.height < objRectToBeFilled.rect.height))
            {
                //Debug.Log("Case 2");

                if (textureToResize.width > textureToResize.height)
                    widthProportion = ((float)textureToResize.width / (float)textureToResize.height) - 1.0f;
                else
                    heightProportion = ((float)textureToResize.height / (float)textureToResize.width) - 1.0f;

                //Debug.Log("widthProportion: " + widthProportion);
                //Debug.Log("heightProportion: " + heightProportion);
            }

            //Caso 3 - Bigger Width and Smaller Height
            if (textureToResize.width >= objRectToBeFilled.rect.width &&
                textureToResize.height <= objRectToBeFilled.rect.height)
            {
                //Debug.Log("Caso 3");

                widthDiffInPixels = (float)textureToResize.width - objRectToBeFilled.rect.width;
                HeightDiffInPixels = objRectToBeFilled.rect.height - (float)textureToResize.height;

                widthProportion = widthDiffInPixels / objRectToBeFilled.rect.width;
                heightProportion = HeightDiffInPixels / objRectToBeFilled.rect.height;
            }

            //Caso 4 - Smaller Width and Bigger Height
            if (textureToResize.width <= objRectToBeFilled.rect.width &&
                textureToResize.height >= objRectToBeFilled.rect.height)
            {
                //Debug.Log("Case 4");

                widthDiffInPixels = objRectToBeFilled.rect.width - (float)textureToResize.width;
                HeightDiffInPixels = (float)textureToResize.height - objRectToBeFilled.rect.height;

                widthProportion = widthDiffInPixels / objRectToBeFilled.rect.width;
                heightProportion = HeightDiffInPixels / objRectToBeFilled.rect.height;
            }

            float totalAmountToIncrease = widthProportion + heightProportion + safetyMargin;
            //Debug.Log("totalAmountToIncrease: " + totalAmountToIncrease);

            objRectToBeFilled.anchorMin = new Vector2(0 - (totalAmountToIncrease / 2), 0 - (totalAmountToIncrease / 2));
            objRectToBeFilled.anchorMax = new Vector2(1 + (totalAmountToIncrease / 2), 1 + (totalAmountToIncrease / 2));
        }
    }


    public static void ResizeFromBaseToScreenProportion(float canvasWidth, float canvasHeight, RectTransform objRectToResize)
    {
        float widthPercentageDiff = canvasWidth / (float)EditorBaseSize.unityEditorBaseScreenWidth;
        float heightPercentageDiff = canvasHeight / (float)EditorBaseSize.unityEditorBaseScreenHeight;

        if ((canvasHeight / canvasWidth) != ((float)EditorBaseSize.unityEditorBaseScreenHeight / (float)EditorBaseSize.unityEditorBaseScreenWidth))
        {
            if ((canvasHeight / canvasWidth) > ((float)EditorBaseSize.unityEditorBaseScreenHeight / (float)EditorBaseSize.unityEditorBaseScreenWidth))
            {
                //It means that the canvas is taller and "thinner" than the base
                float percentageToShrinkTo = widthPercentageDiff / heightPercentageDiff;
                float actualAnchorsYDelta = objRectToResize.anchorMax.y - objRectToResize.anchorMin.y;
                float finalAnchorsYDelta = actualAnchorsYDelta * percentageToShrinkTo;
                float amountToShrinkEachAnchor = (actualAnchorsYDelta - finalAnchorsYDelta) / 2;

                //Debug.Log("widthPercentageDiff: " + widthPercentageDiff);
                //Debug.Log("heightPercentageDiff: " + heightPercentageDiff);
                //Debug.Log("percentageToShrinkTo: " + percentageToShrinkTo);
                //Debug.Log("actualAnchorsDelta: " + actualAnchorsYDelta);
                //Debug.Log("finalAnchorsDelta: " + finalAnchorsYDelta);
                //Debug.Log("amountToShrinkEachAnchor: " + amountToShrinkEachAnchor);

                objRectToResize.anchorMin = new Vector2(objRectToResize.anchorMin.x, objRectToResize.anchorMin.y + amountToShrinkEachAnchor);
                objRectToResize.anchorMax = new Vector2(objRectToResize.anchorMax.x, objRectToResize.anchorMax.y - amountToShrinkEachAnchor);
            }
            else
            {
                //It means that the canvas is wider and "fatter" than the base
                float percentageToShrinkTo = heightPercentageDiff / widthPercentageDiff;
                float actualAnchorsXDelta = objRectToResize.anchorMax.x - objRectToResize.anchorMin.x;
                float finalAnchorsXDelta = actualAnchorsXDelta * percentageToShrinkTo;
                float amountToShrinkEachAnchor = (actualAnchorsXDelta - finalAnchorsXDelta) / 2;

                objRectToResize.anchorMin = new Vector2(objRectToResize.anchorMin.x + amountToShrinkEachAnchor, objRectToResize.anchorMin.y);
                objRectToResize.anchorMax = new Vector2(objRectToResize.anchorMax.x - amountToShrinkEachAnchor, objRectToResize.anchorMax.y);
            }
        }
    }



}
