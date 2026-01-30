using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scene", menuName = "Scene Maker Object")]
public class SceneMakerObject : ScriptableObject
{
    
    public int SceneID;
    public string SceneName;
    public List<DialogueLine> DialogueLines;
    public bool SceneCompleted = false;
    public bool AutoAdvance = false;




}
