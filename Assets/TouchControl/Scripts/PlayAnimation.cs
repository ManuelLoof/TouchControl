using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class PlayAnimation : MonoBehaviour
{

	private Animation _animation;

	// Use this for initialization
	void Start () {

		_animation = this.GetComponent<Animation>();
	
	}


	public void PlayOnce()
	{
		_animation.Play("Resize");
	}
	

}
