using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject CharacterBase;

    public void Start()
    {
        CharacterBase.SetActive(false);
    }

    public void CreateNewCharacter(Vector2 position)
    {
        var NewCharacter = Instantiate(CharacterBase);
        NewCharacter.transform.position = position;
        NewCharacter.SetActive(true);
    }
}
