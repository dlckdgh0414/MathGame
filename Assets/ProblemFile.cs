using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ProblemFile : ScriptableObject
{
	public List<ProblemFilesDB> Problems; // Replace 'EntityType' to an actual type that is serializable.
}