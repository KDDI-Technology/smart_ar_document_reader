using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

[CustomEditor(typeof(DocData))]
public class DocDataEditor : Editor
{
    private DocData docData;

    private void OnEnable()
    {
        docData = (DocData)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("画像読み込み機能", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        if (GUILayout.Button("フォルダから画像を読み込み", GUILayout.Height(30)))
        {
            string selectedPath = EditorUtility.OpenFolderPanel("画像フォルダを選択", "Assets", "");
            if (!string.IsNullOrEmpty(selectedPath))
            {

                if (selectedPath.StartsWith(Application.dataPath))
                {
                    string relativePath = "Assets" + selectedPath.Substring(Application.dataPath.Length);
                    LoadImagesFromFolder(relativePath);
                }
                else
                {
                    Debug.LogWarning("選択されたフォルダはプロジェクト内にありません: " + selectedPath);
                }
            }
        }

        EditorGUILayout.Space();


        if (GUILayout.Button("画像をクリア", GUILayout.Height(25)))
        {
            docData.ClearImages();
            EditorUtility.SetDirty(docData);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("総ページ数", docData.TotalPages.ToString());
    }

    private void LoadImagesFromFolder(string folderPath)
    {
        if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
        {
            Debug.LogError("有効なフォルダパスを指定してください: " + folderPath);
            return;
        }

        docData.ClearImages();

        string[] supportedExtensions = { "*.png", "*.jpg", "*.jpeg", "*.tga", "*.tiff", "*.bmp" };
        List<string> imageFiles = new List<string>();

        foreach (string extension in supportedExtensions)
        {
            string[] files = Directory.GetFiles(folderPath, extension, SearchOption.TopDirectoryOnly);
            imageFiles.AddRange(files);
        }

        imageFiles.Sort((a, b) => {
            string fileNameA = Path.GetFileNameWithoutExtension(a);
            string fileNameB = Path.GetFileNameWithoutExtension(b);
            
            if (int.TryParse(fileNameA, out int numA) && int.TryParse(fileNameB, out int numB))
            {
                return numA.CompareTo(numB);
            }
            
            return fileNameA.CompareTo(fileNameB);
        });
        
        Debug.Log($"フォルダから {imageFiles.Count} 個の画像ファイルを発見: {folderPath}");


        foreach (string filePath in imageFiles)
        {
            string relativePath = filePath.Replace(Application.dataPath, "Assets");


            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(relativePath);

            if (texture != null)
            {
                docData.AddPage(texture);
            }
            else
            {
                Debug.LogWarning($"画像の読み込みに失敗: {relativePath}");
            }
        }

        EditorUtility.SetDirty(docData);
        AssetDatabase.SaveAssets();

        Debug.Log($"画像読み込み完了: {docData.TotalPages} ページ");
    }
}