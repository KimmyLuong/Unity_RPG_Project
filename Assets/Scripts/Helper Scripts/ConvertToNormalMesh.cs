using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToNormalMesh : MonoBehaviour {

[ContextMenu("Convert To MeshRenderer")]
void Convert(){
		SkinnedMeshRenderer skinnedMeshRender = GetComponent<SkinnedMeshRenderer>();
		MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

		meshFilter.sharedMesh = skinnedMeshRender.sharedMesh;
		meshRender.sharedMaterials = skinnedMeshRender.sharedMaterials;

		DestroyImmediate(skinnedMeshRender);
		DestroyImmediate(this);
		
	}
}
