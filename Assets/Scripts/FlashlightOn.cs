using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOn : MonoBehaviour, IHandGrabUseDelegate
{

    [SerializeField]
    private List<Light> _lights;
    [SerializeField]
    private Material _lightEmmissive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ToggleLight()
    {
        for (int i = 0; i < _lights.Count; i++)
        {
            _lights[i].enabled = !_lights[i].enabled;
          
        }
        if (_lights[0].enabled)
        {
            _lightEmmissive.EnableKeyword("_EMMISSION");
        }
        else
        {
            _lightEmmissive.DisableKeyword("_EMMISSION");
        }
    }

    public void BeginUse()
    {
        ToggleLight() ;
    }

    public void EndUse()
    {
        ToggleLight();
    }

    public float ComputeUseStrength(float strength)
    {
        throw new System.NotImplementedException();
    }
}
