using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TakeScreenshot : MonoBehaviour
{
    public string pathFolder;
    private Camera mainCamera;

    public List<GameObject> sceneObjects;
    public List<InventoryItemData> dataObjects;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    [ContextMenu("Screenshot")]
    private void ProcessScreenshots()
    {
        StartCoroutine(Screenshot());
    }

    private IEnumerator Screenshot()
    {
        for(int i = 0; i < sceneObjects.Count; i++)
        {
            GameObject obj = sceneObjects[i];
            InventoryItemData data = dataObjects[i];

            obj.SetActive(true);

            yield return null;

            SnapScreenshot($"{Application.dataPath}/{pathFolder}/{data.id}_Icon.png");
            
            yield return null;

            obj.SetActive(false);

            Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/{pathFolder}/{data.id}_Icon.png");
            if (s != null)
            {
                data.icon = s;
                EditorUtility.SetDirty(data);
            }

            yield return null;
        }
    }

    public void SnapScreenshot(string fullPath)
    {
        if (mainCamera == null) { mainCamera = GetComponent<Camera>(); }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        mainCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        mainCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        mainCamera.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
