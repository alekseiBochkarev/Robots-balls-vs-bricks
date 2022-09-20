using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpecialAttackController : MonoBehaviour
{
    [Header("List of attacks, Combos, buffs")]
    [SerializeField] private ScriptableObject[] specialAttacksSO;
    [SerializeField] private ScriptableObject[] comboAttacksSO;
    [SerializeField] private ScriptableObject[] heroBuffsSO;
    [SerializeField] private int amountOfUpgradeTabs;
    private List<SpecialAttackSO> selectedSpecAttacks;

    [Header("Settings")]
    [SerializeField] private GameObject displayPrefab;
    [SerializeField] private SpecialAttackDisplay specialAttackDisplay;

    public static SpecialAttackController Instance;



    private void Awake()
    {
        Instance = this;
        SelectSpecialAttack();
        ShowScriptableObjectLists(); // In this place for debugging
    }

    public List<SpecialAttackSO> GetScriptableObjectsList()
    {
        // Create a new list and add all specAttacks/comboAttacks/heroBuffs to it
        List<ScriptableObject> list = new List<ScriptableObject>();
        list.AddRange(specialAttacksSO.ToList());
        list.AddRange(comboAttacksSO.ToList());
        list.AddRange(heroBuffsSO.ToList());
        List<SpecialAttackSO> specList = new List<SpecialAttackSO>();
        foreach (SpecialAttackSO specialAttack in list)
        {
            specList.Add(specialAttack);
        }
        return specList;
    }

    public void SelectSpecialAttack()
    {
        // Get list of all specAttacks and remove used attacks by maxUseAmount
        var listOfSpecialAttacks = GetScriptableObjectsList();
        List<SpecialAttackSO> specList = new List<SpecialAttackSO>(listOfSpecialAttacks);
        listOfSpecialAttacks.RemoveAll(el => el.currentUseAmount >= el.maxUseAmount);

        // Create new list to pass on UI later on
        selectedSpecAttacks = new List<SpecialAttackSO>();
        for (int i = 0; i < amountOfUpgradeTabs; i++)
        {
            if (listOfSpecialAttacks.Count == 0)
                break;
            var specAttack = listOfSpecialAttacks[Random.Range(0, listOfSpecialAttacks.Count)];
            selectedSpecAttacks.Add(specAttack);
            listOfSpecialAttacks.Remove(specAttack);
        }
    }

    public void ShowScriptableObjectLists()
    {
        for (int i = 0; i < selectedSpecAttacks.Count; i++)
        {
            Debug.Log("Index of SO ->>>>" + i);
            GameObject tabPrefab = Instantiate(displayPrefab, transform.position, Quaternion.identity);
            tabPrefab.gameObject.transform.SetParent(this.transform);
            tabPrefab.GetComponent<SpecialAttackDisplay>().DisplaySpecialAttack(selectedSpecAttacks[i]);
        }
    }

    public void ShowSpecAttackPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void HideSpecAttackPanel()
    {
        this.gameObject.SetActive(false);
    }
}
