using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsController : MonoBehaviour
{
    public Button button;
    public StatsPanel statsPanel;
    private bool isStatsPanelOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(StatsPanelToggle);
        statsPanel.SetActive(false);
    }

    public void StatsPanelToggle()
    {
        isStatsPanelOpen = !isStatsPanelOpen;
        statsPanel.SetActive(isStatsPanelOpen);

        if (isStatsPanelOpen)
        {
            statsPanel.UpdateUi();
        }
    }
}
