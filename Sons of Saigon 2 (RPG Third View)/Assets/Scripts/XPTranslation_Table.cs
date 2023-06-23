using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class XPTranslationTableEntry
{
    public int Level;
    public int XPRequired;
}

[CreateAssetMenu(menuName = "RPG/XP Table", fileName = "XPTranslation_Table")]
public class XPTranslation_Table : BaseXPTranslation
{
    [SerializeField] List<XPTranslationTableEntry> Table;

    public override bool AddXP(int amount)
    {

        if (AtLevelCap)
        {
            return false;
        }

        CurrentXP += amount;
        for(int i=Table.Count - 1; i >= 0; i--)
        {
            var entry = Table[i];
            //found a matching entry
            if(CurrentXP >= entry.XPRequired)
            {
                //level changed 
                if(entry.Level != CurrentLevel)
                {
                    CurrentLevel = entry.Level;

                    AtLevelCap = Table[^1].Level == CurrentLevel;

                    return true;
                }
                break;
            }

        }
        return false;
    }

    public override void SetLevel(int level)
    {
        CurrentXP = 0;
        CurrentLevel = 1;
        AtLevelCap = false;
        foreach (var entry in Table)
        {

            if(entry.Level == level)
            {
                AddXP(entry.XPRequired);
                return;
            }
        }
        throw new System.ArgumentOutOfRangeException($"Could not find any entry for level {level}");
    }

    protected override int GetXPRequiredForNextLevel()
    {
        if (AtLevelCap)
        {
            return int.MaxValue;
        }
        for (int i = 0; i < Table.Count; i++)
        {
            var entry = Table[i];
            if(entry.Level == CurrentLevel)
            {
                return Table[i +1 ].XPRequired - CurrentXP;
            }
        }
        throw new System.ArgumentOutOfRangeException($"Could not find any entry for level {CurrentLevel}");
    }
}



