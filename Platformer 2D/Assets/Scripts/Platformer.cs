using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Player,
    InteracableObject
}

public interface IObjectType
{
    ObjectType ObjectType { get; }
}

public interface IInteracable
{
    void CheckIfInteract();
}