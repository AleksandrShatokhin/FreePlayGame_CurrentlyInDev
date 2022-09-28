using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesToComponents : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    public MainUIController GetMainUIController() => mainUI.GetComponent<MainUIController>();
}
