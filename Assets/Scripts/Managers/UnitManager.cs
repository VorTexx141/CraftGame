using System;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    public static event Action OnSpown;

    [SerializeField] private GameObject gameOneUnit;
    [SerializeField] private Transform[] spownPoints;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        OnSpown += Spown;
    }

    private void OnDisable()
    {
        OnSpown -= Spown;
    }

    private void Start()
    {
        Spown();
    }

    public void Spown()
    {
        var rnd = new System.Random();

        int ranSpown = rnd.Next(0, spownPoints.Length);
        Instantiate(gameOneUnit, spownPoints[ranSpown]);
    }
}
