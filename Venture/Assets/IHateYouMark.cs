using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IHateYouMark : MonoBehaviour {
    void Start()
    {
        StreamWriter w = new StreamWriter("WeHateYouMark.WhyUDoDis");
        for (int i = 0; i < Inventory.Resources.Length; i++) {
            w.WriteLine(Inventory.Resources[i].Name);
        }
        w.Close();
    }
}
