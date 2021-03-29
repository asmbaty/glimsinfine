using UnityEditor;
using UnityEngine;
using System.Collections;


[CustomEditor(typeof(ObstacleEditor))]

class ObstacleEditorEditor : Editor {
	
  public override void OnInspectorGUI() {

	base.OnInspectorGUI();
    if(GUILayout.Button("Action"))
			((ObstacleEditor)target).Action();
  }

}