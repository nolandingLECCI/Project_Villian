using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Demon,
}
public enum Weapon
{
    LongSword,
    Dagger,
    Spear,
    Gun,
    Club,
}


[CreateAssetMenu(fileName ="Assets/Resources/GameData/Characters/CharacterGO 00", menuName = "vil/Character", order = 1)]
    public class CharacterBaseSO : ScriptableObject
    {
        [Header("Desciption")]
        public uint id;
        public string Vil_Name;
        public Sprite characterProfile;
        public Sprite characterProfile_Battle;
        public GameObject characterVisualsPrefab;

        [Header("Data")]
        public Rarity rarity;
        public SynergyBaseSO Vil_Synergy_1;
        public SynergyBaseSO Vil_Synergy_2;
        public SkillBaseSO skill;
        public Weapon weapon;
        public bool Vil_Demon;

        [Header("Stats")]
        public uint     Range_Normal;
        public uint     Range_Escape;
        public float    Vil_Cooltime;
        public uint     Vil_Hp_Min;
        public uint     Vil_Hp_Max;
        public uint     Vil_Str_Min;
        public uint     Vil_Str_Max;
        public uint     Vil_Loyalty;
    }   

