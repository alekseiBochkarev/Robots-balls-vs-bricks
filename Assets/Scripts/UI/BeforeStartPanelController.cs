using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UI
{
    public class BeforeStartPanelController : MonoBehaviour
    {
      //  [SerializeField] private GameObject _shopButtonSmall;
      //  [SerializeField] private GameObject _shopButtonBig;
        [SerializeField] private GameObject _skinButtonSmall;
        [SerializeField] private GameObject _skinButtonBig;
        [SerializeField] private GameObject _homeButtonSmall;
        [SerializeField] private GameObject _homeButtonBig; //play button
     //   [SerializeField] private GameObject _gunButtonSmall;
     //   [SerializeField] private GameObject _gunButtonBig;
        [SerializeField] private GameObject _portalButtonSmall;
        [SerializeField] private GameObject _portalButtonBig;

        [SerializeField] private GameObject _backFonPanel; //for shop, skinsPanel, gunsPanel, portal
        [SerializeField] private GameObject _gunsShopPanel;
        [SerializeField] private GameObject _shopPanel;

        [SerializeField] private GameObject _baseSkinPanel;
        [SerializeField] private GameObject _scrollCasualSkinsPanel;
        [SerializeField] private GameObject _scrollLegendSkinsPanel;
        public void OpenShop()
        {
           // if (_shopButtonSmall != null) _shopButtonSmall.SetActive(false);
           // if (_shopButtonBig != null) _shopButtonBig.SetActive(true);
            if (_skinButtonSmall != null) _skinButtonSmall.SetActive(true);
            if (_skinButtonBig != null) _skinButtonBig.SetActive(false);
            if (_homeButtonSmall != null) _homeButtonSmall.SetActive(true);
            if (_homeButtonBig != null) _homeButtonBig.SetActive(false);
          //  if (_gunButtonSmall != null) _gunButtonSmall.SetActive(true);
          //  if (_gunButtonBig != null) _gunButtonBig.SetActive(false);
            if (_portalButtonSmall != null) _portalButtonSmall.SetActive(true);
            if (_portalButtonBig != null) _portalButtonBig.SetActive(false);

            if (_backFonPanel != null) _backFonPanel.SetActive(true);
            if (_gunsShopPanel != null) _gunsShopPanel.SetActive(false);
            if (_shopPanel != null) _shopPanel.SetActive(true);
            if (_baseSkinPanel != null) _baseSkinPanel.SetActive(false);
        }

        public void OpenSkinsPanel()
        {
          //  if (_shopButtonSmall != null) _shopButtonSmall.SetActive(true);
          //  if (_shopButtonBig != null) _shopButtonBig.SetActive(false);
            if (_skinButtonSmall != null) _skinButtonSmall.SetActive(false);
            if (_skinButtonBig != null) _skinButtonBig.SetActive(true);
            if (_homeButtonSmall != null) _homeButtonSmall.SetActive(true);
            if (_homeButtonBig != null) _homeButtonBig.SetActive(false);
         //   if (_gunButtonSmall != null) _gunButtonSmall.SetActive(true);
         //   if (_gunButtonBig != null) _gunButtonBig.SetActive(false);
            if (_portalButtonSmall != null) _portalButtonSmall.SetActive(true);
            if (_portalButtonBig != null) _portalButtonBig.SetActive(false);
            
            if (_backFonPanel != null) _backFonPanel.SetActive(true);
            if (_gunsShopPanel != null) _gunsShopPanel.SetActive(false);
            if (_shopPanel != null) _shopPanel.SetActive(false);
            if (_baseSkinPanel != null) _baseSkinPanel.SetActive(true);
            if (_scrollCasualSkinsPanel != null) _scrollCasualSkinsPanel.SetActive(true);
            if (_scrollLegendSkinsPanel != null) _scrollLegendSkinsPanel.SetActive(false);
        }

        public void OpenHome()
        {
          //  if (_shopButtonSmall != null) _shopButtonSmall.SetActive(true);
          //  if (_shopButtonBig != null) _shopButtonBig.SetActive(false);
            if (_skinButtonSmall != null) _skinButtonSmall.SetActive(true);
            if (_skinButtonBig != null) _skinButtonBig.SetActive(false);
            if (_homeButtonSmall != null) _homeButtonSmall.SetActive(false);
            if (_homeButtonBig != null) _homeButtonBig.SetActive(true);
          //  if (_gunButtonSmall != null) _gunButtonSmall.SetActive(true);
          //  if (_gunButtonBig != null) _gunButtonBig.SetActive(false);
            if (_portalButtonSmall != null) _portalButtonSmall.SetActive(true);
            if (_portalButtonBig != null) _portalButtonBig.SetActive(false);
            
            if (_backFonPanel != null) _backFonPanel.SetActive(false);
            if (_gunsShopPanel != null) _gunsShopPanel.SetActive(false);
            if (_shopPanel != null) _shopPanel.SetActive(false);
            if (_baseSkinPanel != null) _baseSkinPanel.SetActive(false);
        }

        public void OpenGunsPanel()
        {
         //   if (_shopButtonSmall != null) _shopButtonSmall.SetActive(true);
          //  if (_shopButtonBig != null) _shopButtonBig.SetActive(false);
            if (_skinButtonSmall != null) _skinButtonSmall.SetActive(true);
            if (_skinButtonBig != null) _skinButtonBig.SetActive(false);
            if (_homeButtonSmall != null) _homeButtonSmall.SetActive(true);
            if (_homeButtonBig != null) _homeButtonBig.SetActive(false);
          //  if (_gunButtonSmall != null) _gunButtonSmall.SetActive(false);
         //   if (_gunButtonBig != null) _gunButtonBig.SetActive(true);
            if (_portalButtonSmall != null) _portalButtonSmall.SetActive(true);
            if (_portalButtonBig != null) _portalButtonBig.SetActive(false);
            
            if (_backFonPanel != null) _backFonPanel.SetActive(true);
            if (_gunsShopPanel != null) _gunsShopPanel.SetActive(true);
            if (_shopPanel != null) _shopPanel.SetActive(false);
            if (_baseSkinPanel != null) _baseSkinPanel.SetActive(false);
        }

        public void OpenPortal()
        {
         //   if (_shopButtonSmall != null) _shopButtonSmall.SetActive(true);
         //   if (_shopButtonBig != null) _shopButtonBig.SetActive(false);
            if (_skinButtonSmall != null) _skinButtonSmall.SetActive(true);
            if (_skinButtonBig != null) _skinButtonBig.SetActive(false);
            if (_homeButtonSmall != null) _homeButtonSmall.SetActive(true);
            if (_homeButtonBig != null) _homeButtonBig.SetActive(false);
          //  if (_gunButtonSmall != null) _gunButtonSmall.SetActive(true);
          //  if (_gunButtonBig != null) _gunButtonBig.SetActive(false);
            if (_portalButtonSmall != null) _portalButtonSmall.SetActive(false);
            if (_portalButtonBig != null) _portalButtonBig.SetActive(true);
            
            if (_backFonPanel != null) _backFonPanel.SetActive(true);
            if (_gunsShopPanel != null) _gunsShopPanel.SetActive(false);
            if (_shopPanel != null) _shopPanel.SetActive(false);
            if (_baseSkinPanel != null) _baseSkinPanel.SetActive(true);
            if (_scrollCasualSkinsPanel != null) _scrollCasualSkinsPanel.SetActive(false);
            if (_scrollLegendSkinsPanel != null) _scrollLegendSkinsPanel.SetActive(true);
        }
    }
}