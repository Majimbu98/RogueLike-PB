using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Move
{

#region Variables & Properties

[SerializeField] private string name;
[SerializeField] private AudioClip clip;
[SerializeField] private ScriptableElementTyping elementTyping;
[SerializeField] private List<ArrowProperties> arrowPropertiesList;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
	
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#endregion

#region Methods

public List<ArrowProperties> GetArrowPropertiesList()
{
    return arrowPropertiesList;
}

public AudioClip GetAudioClip()
{
    return clip;
}

public string GetName()
{
    return name;
}

#endregion

}
