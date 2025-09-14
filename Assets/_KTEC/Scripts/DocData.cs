using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DocData", menuName = "KTEC/DocData")]
public class DocData : ScriptableObject
{
    [Header("ドキュメント設定")]
    [SerializeField] private string documentName = "新しいドキュメント";

    [Header("画像データ")]
    [SerializeField] private List<Texture2D> pageTextures = new List<Texture2D>();

    public string DocumentName => documentName;
    public int TotalPages => pageTextures.Count;
    public List<Texture2D> PageTextures => pageTextures;

    /// <summary>
    /// 指定されたページのテクスチャを取得
    /// </summary>
    /// <param name="pageIndex">ページ番号（0から開始）</param>
    /// <returns>指定されたページのテクスチャ、範囲外の場合は循環して取得</returns>
    public Texture2D GetPageTexture(int pageIndex)
    {
        if (pageTextures.Count == 0)
        {
            return null;
        }

        int cyclicIndex = pageIndex % pageTextures.Count;
        return pageTextures[cyclicIndex];
    }

    /// <summary>
    /// 画像データをクリア
    /// </summary>
    public void ClearImages()
    {
        pageTextures.Clear();
    }

    /// <summary>
    /// 画像データを追加
    /// </summary>
    /// <param name="texture">追加するテクスチャ</param>
    public void AddPage(Texture2D texture)
    {
        pageTextures.Add(texture);
    }
}
