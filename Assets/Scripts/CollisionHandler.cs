using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly": Debug.Log("Bumped into friendly object."); break;
            case "Finish": Debug.Log("You finished the level!"); break;
            default: Debug.Log("Damage taken!"); break;
        }    
    }
}
