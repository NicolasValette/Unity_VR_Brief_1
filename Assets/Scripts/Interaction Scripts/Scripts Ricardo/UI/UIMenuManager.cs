using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.Universal;

public class UIMenuManager : MonoBehaviour
{
    public GameObject gameMenu;
    public FlexibleColorPicker PickColorMenu;

    public ContextualMenu contextualMenu;

    public GameObject HighlightedObject;      


    public void OnEnable()
    {
        if (PickColorMenu == null)
            PickColorMenu = FindObjectOfType<FlexibleColorPicker>();

    }

    public void OpenGameMenu()
    {
        if (gameMenu != null)
        {
            gameMenu.SetActive(true); 
        }
    }

    public void CloseGameMenu()
    {
        if (gameMenu != null)
        {
            gameMenu.SetActive(false);
        }
    }

    public void OpenContextualMenu(EnvironmentElement element)
    {
        if (gameMenu != null)
        {
            contextualMenu.SelectedEnvironmentElement = element;
            contextualMenu.gameObject.SetActive(true);
            contextualMenu.CreateListContent(element);

            UnlockMouse();
        }
    }


    public void OpenContextualMenu(ObjectSpawner selectedSpawner)
    {
        if (gameMenu != null)
        {
            contextualMenu.SelectedObjectSpawner = selectedSpawner;
            contextualMenu.gameObject.SetActive(true);
            contextualMenu.CreateListContent(selectedSpawner);

            UnlockMouse();
        }
    }

    public void OpenContextualMenu(LightData selectedSpawner)
    {
        if (gameMenu != null)
        {
            /*    contextualMenu.SelectedObjectSpawner = selectedSpawner;
                contextualMenu.gameObject.SetActive(true);
                contextualMenu.CreateListContent();*/

            UnlockMouse();
        }
    }

    public void CloseContextualMenu()
    {
        contextualMenu.gameObject.SetActive(false);

        LockMouse();
    }

    public void OpenPickColor(ObjectSpawner selectedSpawner)
    {
        contextualMenu.SelectedObjectSpawner = selectedSpawner;
        PickColorMenu.gameObject.SetActive(true);

        UnlockMouse();
    }

    public void ClosePickColor()
    {
        PickColorMenu.gameObject.SetActive(false);

        ChangeLightColor(contextualMenu.SelectedObjectSpawner);
        LockMouse();
    }
    /*
    private void Update()
    {
        if (PickColorMenu == null) PickColorMenu = FindObjectOfType<FlexibleColorPicker>();
        if (PickColorMenu.gameObject.activeInHierarchy)
        {
            ChangeLightColor();
        }
    }*/

    

    public void ChangeLightColor(ObjectSpawner spawner)
    {
        Color color = PickColorMenu.GetColorFullAlpha();

        for (int i = 0; i < spawner.SpawnersGroup.Count; i++)
        {
            if (spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>() != null)
            {
                spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>().light.color = color;
                spawner.SpawnersGroup[i].spawnedGameObject.GetComponent<InteractableLight>().EmissionRenderer.material.SetColor("_EmissionColor", color);
            }
            contextualMenu.SelectedObjectSpawner = null;
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
