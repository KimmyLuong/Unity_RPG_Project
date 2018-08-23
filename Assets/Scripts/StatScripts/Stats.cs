using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {

	[SerializeField]
	private int baseValue;

	List<int> valueList = new List<int>();

	public int GetValue(){
		int finalValue = baseValue;
		valueList.ForEach(value => finalValue += value);
		return finalValue;
	}

	public void AddValue(int value){
		if(value != 0){
			valueList.Add(value);
		}
	}

	public void RemoveValue(int value){
		if(value != 0){
			valueList.Add(value);
		}
	}
}
