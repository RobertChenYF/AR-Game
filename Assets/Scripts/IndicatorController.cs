using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorController : MonoBehaviour
{
    [SerializeField] private GameObject indicator;

    [HideInInspector]public Vector3 PositionLastFrame;
    [HideInInspector] public Vector3 RotationLastFrame;
    [HideInInspector] public Vector3 PositionCurrentFrame;
    [HideInInspector] public Vector3 RotationCurrentFrame;


    private float movementSum;
    private float rotationSum;

    public float totalValue;
    private float currentValue;
    public float MovementFactor;
    public float RotationFactor;
    [SerializeField]private Text ValueInput;
    [SerializeField] private Text MovementFactorInput;
    [SerializeField] private Text RotationFactorInput;
    // Start is called before the first frame update
    private void Awake()
    {
        Service.indicatorController = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalValue = float.Parse(ValueInput.text);
        MovementFactor = float.Parse(MovementFactorInput.text);
        RotationFactor = float.Parse(RotationFactorInput.text);

        if (indicator.activeSelf)//place holder bool
        {
            movementSum = movementSum + Mathf.Abs(PositionCurrentFrame.x - PositionLastFrame.x)
                + Mathf.Abs(PositionCurrentFrame.y - PositionLastFrame.y)+
                Mathf.Abs(PositionCurrentFrame.z - PositionLastFrame.z);
            rotationSum = rotationSum + Mathf.Abs(RotationCurrentFrame.x - RotationLastFrame.x)
                + Mathf.Abs(RotationCurrentFrame.y - RotationLastFrame.y);
            currentValue = movementSum * MovementFactor + rotationSum * RotationFactor;
            indicator.GetComponent<Image>().fillAmount = (totalValue - currentValue) / totalValue;
            if (totalValue - currentValue <=0 )
            {
                //turn off 
                while (Service.arLinkManager.HitObject.Count > 0)
                {
                    GameObject a = Service.arLinkManager.HitObject[0];
                    //play an effect?
                    Service.arLinkManager.HitObject.RemoveAt(0);
                    a.GetComponent<BoxController>().Normal();
                }
            }
            Debug.Log(movementSum + rotationSum);
        }

        PositionLastFrame = PositionCurrentFrame;
        RotationLastFrame = RotationCurrentFrame;
    }

    public void ShowIndicator()
    {
        ResetSum();
        indicator.SetActive(true);


    }
    public void SetPos(Vector2 position)
    {
        indicator.transform.position = position;
    }
    public void CloseIndicator()
    {
        ResetSum();
        indicator.SetActive(false);
    }

    void ResetSum()
    {
        movementSum = 0;
        rotationSum = 0;
    }
}

public class Service : MonoBehaviour
{
    public static LinkRaycast linkRaycast;
    public static ARLinkManager arLinkManager;
    public static IndicatorController indicatorController;
}
