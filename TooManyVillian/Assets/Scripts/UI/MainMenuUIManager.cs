using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Serialization;
using System;

[RequireComponent(typeof(UIDocument))]
    public class MainMenuUIManager : MonoBehaviour
    {

        [Header("Modal Menu Screens")]
        [Tooltip("Only one modal interface can appear on-screen at a time.")]
        [SerializeField] HomeScreen m_HomeModalScreen;
        [SerializeField] ShopScreen m_ShopModalScreen;
        [SerializeField] VilScreen m_VilModalScreen;
        [SerializeField] EducationScreen m_EducationModalScreen;
        [SerializeField] EmployScreen m_EmployModalScreen;
        [SerializeField] QuestScreen m_QuestModalScreen;
        [SerializeField] MissionScreen m_MissionModalScreen;

        [Header("Toolbars")]
        [Tooltip("Toolbars remain active at all times unless explicitly disabled.")]
        [SerializeField] OptionsBar m_OptionsBar;
        [SerializeField] TopBar m_TopBar;
        
        [Header("Full-screen overlays")]
        [Tooltip("Full-screen overlays block other controls until dismissed.")]
        [SerializeField] SettingScreen m_SettingScreen;

        List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

        UIDocument m_MainMenuDocument;
        public UIDocument MainMenuDocument => m_MainMenuDocument;

        void OnEnable()
        {
            m_MainMenuDocument = GetComponent<UIDocument>();
            SetupModalScreens();
            ShowHomeScreen();
        }

        void Start()
        {
            Time.timeScale = 1f;
        }

        void SetupModalScreens()
        {
            if (m_HomeModalScreen != null)
                m_AllModalScreens.Add(m_HomeModalScreen);

            if (m_ShopModalScreen != null)
                m_AllModalScreens.Add(m_ShopModalScreen);

            if (m_VilModalScreen != null)
                m_AllModalScreens.Add(m_VilModalScreen);

            if (m_EducationModalScreen != null)
                m_AllModalScreens.Add(m_EducationModalScreen);

            if (m_EmployModalScreen != null)
                m_AllModalScreens.Add(m_EmployModalScreen);

            if (m_QuestModalScreen != null)
                m_AllModalScreens.Add(m_QuestModalScreen);

            if (m_MissionModalScreen != null)
                m_AllModalScreens.Add(m_MissionModalScreen);

        }

      
        void ShowModalScreen(MenuScreen modalScreen)
        {
            foreach (MenuScreen m in m_AllModalScreens)
            {
                if (m == modalScreen)
                {
                    m?.ShowScreen();
                }
                else
                {
                    m?.HideScreen();
                }
            }
        }

      
        public void ShowHomeScreen()
        {
            ShowModalScreen(m_HomeModalScreen);
            SetToolBar(null);
        }

        public void ShowShopScreen()
        {
            ShowModalScreen(m_ShopModalScreen);
            SetToolBar("상점");
        }

        public void ShowVilScreen()
        {
            ShowModalScreen(m_VilModalScreen);
            SetToolBar("빌런");
        }
       
        public void ShowEducationScreen()
        {
            ShowModalScreen(m_EducationModalScreen);
            SetToolBar("교육");
        }

        public void ShowEmployScreen()
        {
            m_EmployModalScreen.ShowMainPanel();
            ShowModalScreen(m_EmployModalScreen);
            SetToolBar("채용");
        }

        public void ShowQuestScreen()
        {
            ShowModalScreen(m_QuestModalScreen);
            SetToolBar("퀘스트");
        }

        public void ShowMissionScreen()
        {
            m_MissionModalScreen.ShowLocationPanel();
            ShowModalScreen(m_MissionModalScreen);
            SetToolBar("임무");
        }

        // overlay screen methods
        public void ShowSettingsScreen()
        {
            m_SettingScreen?.ShowScreen();
        }

        private void SetToolBar(string MenuName)
        {
            if(MenuName == null)
            {
                m_TopBar?.HideScreen();
                m_OptionsBar.OptionsBarAtHome(true);
            }
            else
            {
                m_TopBar.SetMenuName(MenuName);
                m_TopBar?.ShowScreen();
                m_OptionsBar.OptionsBarAtHome(false);
            }
           
        }

    }
