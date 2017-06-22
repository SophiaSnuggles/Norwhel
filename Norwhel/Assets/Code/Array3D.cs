using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Array3D : MonoBehaviour {
    public GameObject prefab;
	public Vector3 spacingOffset = new Vector3(2.0f, 2.0f, 2.0f);
	public Vector3 positionOffset = new Vector3(9.0f, 9.0f, 9.0f);
	private Vector3 position;
	public int count = 10;
	public bool ThreeDee = false;
	private float rnd = 0.0f;
	private float MIN = 0.0f;
	public float RANDOMNESS = 2.0F;

	// START:
    void Start() {
        for (int x = 0; x < count; x++){
			for (int y = 0; y < count; y++){
				if (ThreeDee) {
					for (int z = 0; z < count; z++) {
						rnd = Random.Range (MIN, RANDOMNESS);
						position = new Vector3 ((x * spacingOffset.x) - positionOffset.x + rnd, (y * spacingOffset.y) - positionOffset.y + rnd, (z * spacingOffset.z) - positionOffset.z + rnd);
						Instantiate(prefab, position, Quaternion.identity);
					}
				} else {
					rnd = Random.Range(MIN, RANDOMNESS);
					position = new Vector3 ((x * spacingOffset.x) - positionOffset.x + rnd, 0, (y * spacingOffset.y) - positionOffset.y + rnd);
					Instantiate(prefab, position, Quaternion.identity);
				}
			}
		}
    }
}