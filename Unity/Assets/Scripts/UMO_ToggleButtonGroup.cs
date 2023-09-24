using UnityEngine;
using UnityEngine.UI;

public class UMO_ToggleButtonGroup : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private GameObject[] onObjects;

    int selected = 0;

    public void Awake()
    {
        UpdateState();
        for(int i = 0; i < buttons.Length; i++)
        {
            int idx = i;
            buttons[i].onClick.AddListener(() =>
            {
                selected = idx;
                UpdateState();
            });
        }
    }

    private void UpdateState()
    {
        for(int i = 0; i < onObjects.Length; i++)
        {
            if(onObjects[i] != null)
                onObjects[i].SetActive(false);
        }
        if(onObjects.Length > selected && selected >= 0)
        {
            if(onObjects[selected] != null)
            {
                onObjects[selected].SetActive(true);
            }
        }
    }

    public void SetSelected(int selected_)
    {
        selected = selected_;
        UpdateState();
    }

    public int GetSelected()
    {
        return selected;
    }
}