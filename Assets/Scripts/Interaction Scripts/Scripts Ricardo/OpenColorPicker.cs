using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenColorPicker : MonoBehaviour, UsableObjectInterface
{
    public UIMenuManager menuManager;

    public ObjectSpawner ControledSpawner;

    public void UseObject(GameObject hitObject)
    {
        menuManager.contextualMenu.SelectedObjectSpawner = ControledSpawner;
        OpenPickColor();
    }

    void OpenPickColor()
    {
        menuManager.OpenPickColor(ControledSpawner);
    }
}
