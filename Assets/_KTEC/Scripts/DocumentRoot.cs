using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocumentRoot : MonoBehaviour
{
    [Header("ドキュメントデータ")]
    [SerializeField] private DocData docData;

    [Header("UI表示")]
    [SerializeField] private Image page;
    [SerializeField] private TMP_Text docTitle;
    [SerializeField] private TMP_Text pageNumber;

    private int currentPageIndex = 0;

    void Start()
    {
        UpdatePageDisplay();
        docTitle.text = docData.DocumentName;
    }

    public void NextPage()
    {
        currentPageIndex = (currentPageIndex + 1) % docData.TotalPages;
        UpdatePageDisplay();
    }

    public void PreviousPage()
    {
        currentPageIndex = (currentPageIndex - 1 + docData.TotalPages) % docData.TotalPages;
        UpdatePageDisplay();
    }

    private void UpdatePageDisplay()
    {
        pageNumber.text = $"{currentPageIndex + 1} / {docData.TotalPages}";
        Texture2D currentTexture = docData.GetPageTexture(currentPageIndex);
        if (currentTexture != null)
        {
            Sprite sprite = Sprite.Create(
                currentTexture,
                new Rect(0, 0, currentTexture.width, currentTexture.height),
                new Vector2(0.5f, 0.5f)
            );

            page.sprite = sprite;
        }
        else
        {
            page.sprite = null;
        }
    }
}