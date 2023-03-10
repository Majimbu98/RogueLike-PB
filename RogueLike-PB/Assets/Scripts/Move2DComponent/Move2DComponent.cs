using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2DComponent : MonoBehaviour
{

#region Variables & Properties

private ScriptableMove scriptableMove;
private Move move = new Move();
[SerializeField] private Text text;
private bool isSelected=false;

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

public void InitObject(ScriptableMove newMove)
{
    scriptableMove = newMove;
    move = newMove.GetMove();
    SetMoveName();
}

private void SetMoveName()
{
    text.text = move.GetName();
}

public void OnMouseDown()
{
    if (CombatSystem.Instance.GetEnumBattlePhase() == EnumBattlePhase.SelectingPhase)
    {
        isSelected = true;
    }
}

public void DeactiveIsSelected()
{
    isSelected = false;
}

public bool GetIsSelected()
{
    return isSelected;
}

public ScriptableMove GetScriptableMove()
{
    return scriptableMove;
}

#endregion

}
