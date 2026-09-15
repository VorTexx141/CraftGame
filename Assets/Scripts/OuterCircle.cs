using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class OuterCircle : MonoBehaviour
{
    //[SerializeField] private Transform outerCircle;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 scaleTo;

    private void Start()
    {
        transform.localScale = scale;
    }

    private void Update()
    {
        transform.localScale = new Vector3(scaleTo.x, scaleTo.y, scaleTo.z);
    }
}
