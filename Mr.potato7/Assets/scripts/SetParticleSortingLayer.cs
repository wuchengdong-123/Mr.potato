using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleSortingLayer : MonoBehaviour
{
	// Start is called before the first frame update
	public string sortingLayerName;     // The name of the sorting layer the particles should be set to.


	void Start()
	{
		// Set the sorting layer of the particle system.
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortingLayerName;
	}
}
