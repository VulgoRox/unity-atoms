﻿using UnityEngine;

namespace UnityAtoms
{
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Vector3")]
    public class Vector3Variable : EquatableScriptableObjectVariable<Vector3, Vector3Event, Vector3Vector3Event> { }
}