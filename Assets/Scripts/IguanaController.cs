using UnityEngine;

public class IguanaController : MonoBehaviour
{
	Animator iguanaAnimator;
	
	void Start ()
    {
		iguanaAnimator = GetComponent<Animator> ();
	}
		
	public void Move(float v, float h){
		iguanaAnimator.SetFloat("Forward", v);
		iguanaAnimator.SetFloat("Turn", h);
	}
}
