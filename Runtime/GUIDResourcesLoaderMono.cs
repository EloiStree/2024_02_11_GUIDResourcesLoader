using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDResourcesLoaderMono : MonoBehaviour
{

    public Transform m_whereToCreateRoot;
    public GameObject m_currentViewObject;

    public string m_defaultNameToGive = "HeRCArena";
    public string m_folderGUID="GUID Here";

    public bool m_loadAtAwake;
    void Awake()
    {
        if (m_loadAtAwake) {
            LoadGUID(m_folderGUID);
        }
    }

    public void LoadGUID(string guid) {
        m_folderGUID = guid;
        GameObject prefab = Resources.Load($"{m_folderGUID}/{m_defaultNameToGive}") as GameObject;
        if (prefab != null)
        {
            GameObject created = Instantiate(prefab, transform.position, transform.rotation);
            if (created)
            {
                if (m_currentViewObject != null)
                    Destroy(m_currentViewObject);
                created.transform.parent = m_whereToCreateRoot;
                created.transform.localRotation = Quaternion.identity;
                created.transform.localScale = Vector3.one;
                created.transform.localPosition = Vector3.zero;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
