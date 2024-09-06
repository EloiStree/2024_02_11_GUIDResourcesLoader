using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDResourcesLoaderMono : MonoBehaviour
{

    public Transform m_whereToCreateRoot;
    public string m_prefabNameGivenToLoad = "Default";
    public string m_folderNameAsGUID= "7b40a7c4-534b-4f8d-96cf-ccb3cd4031a2";
    public bool m_loadAtAwake;

    [Header("Debugging")]
    public GameObject m_currentCreatedObject;

    void Awake()
    {
        if (m_loadAtAwake) {
            LoadGUID(m_folderNameAsGUID);
        }
    }

    [ContextMenu("Load GUID")]
    public void LoadGUIDFromInspector()
    {
        LoadGUID(m_folderNameAsGUID);
    }
        public void LoadGUID(string guid)
        {
            m_folderNameAsGUID = guid;
        GameObject prefab = Resources.Load($"{m_folderNameAsGUID}/{m_prefabNameGivenToLoad}") as GameObject;
        if (prefab != null)
        {
            GameObject created = Instantiate(prefab, transform.position, transform.rotation);
            if (created)
            {
                if (m_currentCreatedObject != null)
                { 
                    if(Application.isPlaying)
                    Destroy(m_currentCreatedObject);
                    else DestroyImmediate(m_currentCreatedObject);
                }
                created.transform.parent = m_whereToCreateRoot;
                created.transform.localRotation = Quaternion.identity;
                created.transform.localScale = Vector3.one;
                created.transform.localPosition = Vector3.zero;
            }

        }
    }

  
}
