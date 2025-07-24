using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();
    
    public Button[] buttons;
    public GameObject[] popupUIs;

    void Start()
    {
        buttons[0].onClick.AddListener(PopupOn1);
        buttons[1].onClick.AddListener(PopupOn2);
        buttons[2].onClick.AddListener(PopupOn3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject currUI = uiStack.Pop();
            currUI.SetActive(false);
        }
    }
    
    private void PopupOn1()
    {
        popupUIs[0].SetActive(true);
        uiStack.Push(popupUIs[0]);
    }
    
    private void PopupOn2()
    {
        popupUIs[1].SetActive(true);
        uiStack.Push(popupUIs[1]);
    }
    
    private void PopupOn3()
    {
        popupUIs[2].SetActive(true);
        uiStack.Push(popupUIs[2]);
    }
}