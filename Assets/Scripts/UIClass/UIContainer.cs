using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIContainer : MonoBehaviour {

    public GameObject loginPanel;
    public GameObject mainPanel;
    public GameObject fightPanel;
    public GameObject duplicatePanel;
    public GameObject worldPanel;
    public GameObject taskPanel;

    public List<GameObject> panels = new List<GameObject>();

    public List<GameObject> AllPanel
    {
        get
        {
            this.panels.Clear();
            this.panels.Add(loginPanel);
            this.panels.Add(mainPanel);
            this.panels.Add(fightPanel);
            this.panels.Add(duplicatePanel);
            this.panels.Add(worldPanel);
            this.panels.Add(taskPanel);

            return this.panels;
        }
    }

    private void AddPanel(GameObject go)
    {
        if (go != null)
        {
            this.panels.Add(go);
        }
    }

    public void ClearAll()
    {
        List<GameObject> all = AllPanel;
        foreach (var p in all)
        {
            if (p != null)
            {
                DestroyImmediate(p, true);
            }
        }

        panels.Clear();
    }

    public static UIContainer instance;

    void Start()
    {
        DontDestroyOnLoad(base.gameObject);
        instance = this;
    }
}
