using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monitorManager : MonoBehaviour
{
    public GameObject spawnTool;

    public GameObject objectText;
    public GameObject materialText;
    public GameObject sizeText;
    public GameObject massText;

    private SpawnObject spawnObjectScript;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjectScript = spawnTool.GetComponent<SpawnObject>();
    }

    public void updateMonitorValues()
    {
        //update object name
        string prefabName = spawnObjectScript.selectedPrefab.name;
        if(prefabName == "SpawnableCube")
            objectText.GetComponent<TextMeshProUGUI>().text = "Cube";
        if(prefabName == "SpawnableSphere")
            objectText.GetComponent<TextMeshProUGUI>().text = "Sphere";

        materialText.GetComponent<TextMeshProUGUI>().text = spawnObjectScript.selectedMaterial.name;
        sizeText.GetComponent<TextMeshProUGUI>().text = spawnObjectScript.selectedSize.ToString();
        massText.GetComponent<TextMeshProUGUI>().text = spawnObjectScript.selectedMass.ToString();
    }
}
