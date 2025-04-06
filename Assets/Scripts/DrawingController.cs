using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DrawingController : MonoBehaviour
{
    public RawImage canvas;
    public int textureSize = 512;
    public Color drawColor = Color.black;
    public int brushSize = 10;

    private Texture2D drawTexture;
    private bool isDrawing;
    public bool isActive = false;
    private bool isComplete = false;

    public IEnumerator StartDraw()
    {
        canvas.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Cursor.lockState = CursorLockMode.None;

        drawTexture = new Texture2D(textureSize, textureSize);
        Color[] blankPixels = new Color[textureSize * textureSize];
        for (int i = 0; i < blankPixels.Length; i++) blankPixels[i] = Color.white;
        drawTexture.SetPixels(blankPixels);
        drawTexture.Apply();
        canvas.texture = drawTexture;
        isActive = true;
        StartCoroutine(CheckIsComplete());
        yield return new WaitUntil(() => isComplete == true);

        isActive = false;
        isDrawing = false;

        canvas.DOFade(0f, 0.1f);
        G.UI.blackScreen.DOFade(1f, 0f);
        yield return new WaitForSeconds(0.1f);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private IEnumerator CheckIsComplete()
    {
        while (!isComplete)
        {
            isComplete = IsFullyPainted();
            yield return new WaitForSeconds(2f);
        }
    }
    void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0)) isDrawing = true;
            if (Input.GetMouseButtonUp(0)) isDrawing = false;    
        }
        // AI stuff
        if (isDrawing)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.rectTransform, 
                Input.mousePosition, 
                null, 
                out Vector2 localPoint
            );

            Vector2 normalizedPoint = new Vector2(
                (localPoint.x / canvas.rectTransform.rect.width) + 0.5f,
                (localPoint.y / canvas.rectTransform.rect.height) + 0.5f
            );

            int pixelX = Mathf.Clamp((int)(normalizedPoint.x * textureSize), 0, textureSize-1);
            int pixelY = Mathf.Clamp((int)(normalizedPoint.y * textureSize), 0, textureSize-1);

            for (int x = -brushSize; x <= brushSize; x++)
            {
                for (int y = -brushSize; y <= brushSize; y++)
                {
                    if (x*x + y*y > brushSize*brushSize) continue;
                    
                    int texX = pixelX + x;
                    int texY = pixelY + y;
                    if (texX >= 0 && texX < textureSize && texY >= 0 && texY < textureSize)
                    {
                        drawTexture.SetPixel(texX, texY, drawColor);
                    }
                }
            }
            drawTexture.Apply();
        }
    }
    public bool IsFullyPainted(float threshold = 0.99f)
    {
        Color[] pixels = drawTexture.GetPixels();
        int paintedPixels = 0;

        foreach (Color pixel in pixels)
        {
            if (pixel != Color.white) paintedPixels++;
        }

        float coverage = (float)paintedPixels / pixels.Length;
        return coverage >= threshold;
    }
}
