using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins ;
    public TMP_Text coinUI ;
    public ShopItemSO[ ] shopItemsSO ;
    public GameObject [ ] shopPanelsGO ;
    public ShopTemplate[ ] shopPanels ;
    public Button [ ] myPurchaseBtns ;
    public Button [ ] mySelectBtns ;
    private int currentlySelectedIndex = -1; 
    private void Start() {
        coins=PlayerPrefs.GetInt("coins",coins);
         for ( int i =0;i < shopItemsSO.Length ; i ++ )
             shopPanelsGO [ i ] .SetActive ( true ) ;
        coinUI.text= "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
        currentlySelectedIndex = PlayerPrefs.GetInt("selectedPrefabIndex", 0);
        mySelectBtns[currentlySelectedIndex].interactable = false;
    }
    public void LoadPanels ( ){
        for ( int i = 0 ; i < shopItemsSO.Length ; i ++ )
            {
            shopPanels [ i ] .tittleTxt.text = shopItemsSO [ i ] .title ;
            shopPanels [ i ] .descriptionTxt.text=shopItemsSO [ i ] .description ;
            shopPanels [ i ] .costTxt.text = "Coins: "+ shopItemsSO [ i ] .price.ToString ( ) ;
                                                
            }
        }
    public void CheckPurchaseable ( ){
        PlayerPrefs.SetInt("coins",coins);
        for ( int i = 0 ; i < shopItemsSO.Length ; i ++ ){

            if(PlayerPrefs.GetInt("btn"+i)==1)
                myPurchaseBtns[i].gameObject.SetActive(false);

            if(PlayerPrefs.GetInt("btn"+i)==1)
                mySelectBtns[i].gameObject.SetActive(true);

            if ( coins >= shopItemsSO [i].price ) // if I have enough money .
                myPurchaseBtns[i].interactable = true ;
            else{
                myPurchaseBtns[i].interactable = false ;            
                }
         }
        }

    public void PurchaseItem ( int btnNo ){
        if ( coins >= shopItemsSO [ btnNo ] .price ){
            coins =coins - shopItemsSO [ btnNo ] .price ;
            coinUI . text = "Coins: "+coins.ToString ( ) ;
            CheckPurchaseable();
            UnlockItem(btnNo);
            }
    }

    public void UnlockItem(int btnNo){
        PlayerPrefs.SetInt("btn"+btnNo,1);
        CheckPurchaseable();
    }
    

    public void SelectItem(int btnNo)
    {
        if (PlayerPrefs.GetInt("btn" + btnNo) == 1) // Si el elemento está desbloqueado
        {
            if (currentlySelectedIndex == btnNo) // Si el botón ya está seleccionado, no hacer nada
            {
                return;
            }

            // Si hay un botón seleccionado previamente, habilítalo para que pueda ser seleccionado nuevamente
            if (currentlySelectedIndex >= 0)
            {
                mySelectBtns[currentlySelectedIndex].interactable = true;
            }

            // Guardar el índice del prefab seleccionado en PlayerPrefs
            PlayerPrefs.SetInt("selectedPrefabIndex", btnNo);
            PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs

            // Deshabilitar el botón seleccionado y actualizar el índice del botón seleccionado actualmente
            mySelectBtns[btnNo].interactable = false;
            currentlySelectedIndex = btnNo;
        }
    }
    public void AddCoins()
    {
        coins += 100;
        coinUI.text = "Coins: " + coins.ToString(); 
        PlayerPrefs.SetInt("coins", coins); 
        CheckPurchaseable(); 
    }

}
