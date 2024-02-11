using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ArrowType { normal, explosive, poison }

public class ArrowSelector : MonoBehaviour
{
    
    public ArrowType selectedArrowType;
    public Button ArrowButtonNormal;
    public Button ArrowButtonExplosive;
    public Button ArrowButtonPoison;
    public Image ArrowImageNormal;
    public Image ArrowImageExplosive;
    public Image ArrowImagePoison;
    
    void Start()
    {
        ArrowButtonNormal.onClick.AddListener(()=>OnArrowButtonClicked(ArrowType.normal));
        ArrowButtonExplosive.onClick.AddListener(()=>OnArrowButtonClicked(ArrowType.explosive));
        ArrowButtonPoison.onClick.AddListener(()=>OnArrowButtonClicked(ArrowType.poison));
        SetSelectedArrowType(ArrowType.normal);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSelectedArrowType(ArrowType.normal);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSelectedArrowType(ArrowType.explosive);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSelectedArrowType(ArrowType.poison);
        }
    }
    private void OnArrowButtonClicked(ArrowType arrowtype) {
        SetSelectedArrowType(arrowtype);
    }

    private void SetSelectedArrowType(ArrowType arrowtype)
    {
        selectedArrowType = arrowtype;
        ArrowImageNormal.color = arrowtype==ArrowType.normal ? Color.yellow : Color.white;
        ArrowImageExplosive.color = arrowtype==ArrowType.explosive ? Color.yellow : Color.white;
        ArrowImagePoison.color = arrowtype==ArrowType.poison ? Color.yellow : Color.white;
    }
}
