using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;

public class Util : MonoBehaviour {

    public static Uri AppContentDataUri
    {
        get
        {
            string dataPath = Application.dataPath;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new UriBuilder
                {
                    Scheme = "file",
                    Path = Path.Combine(dataPath, "Raw/")
                }.Uri;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                return new Uri("jar:file//" + dataPath + "!/assets/");
            }

            return new UriBuilder
            {
                Scheme = "file",
                Path = Path.Combine(dataPath, "StreamingAssets/")
            }.Uri;
        }

    }

    public static Uri AppPersistentDataUri
    {
        get
        {
            return new UriBuilder
            {
                Scheme = "file",
                Path = Application.persistentDataPath + "/"
            }.Uri;
        }
    }

    public static void SafeDestroy(GameObject go)
    {
        if (go != null)
        {
            UnityEngine.Object.Destroy(go);
        }
    }

    public static void SafeDestroy(Transform trans)
    {
        if (trans != null)
        {
            Util.SafeDestroy(trans.gameObject);
        }
    }

    public static void ClearMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }
}
