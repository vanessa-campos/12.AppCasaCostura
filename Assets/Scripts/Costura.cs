using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Costura : MonoBehaviour
{
    public int Id;
    public TMP_Text id, resumo, nome, telefone, descricao, valor, data, pago, entregue;
    Menu Menu;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void ButtonEditar(){      
        Menu.panelListaCosturas.SetActive(false);
        Screen.orientation = ScreenOrientation.Portrait;
        Instantiate(Menu.prefabEditarCosturas,Menu.transform);
        EditarCostura editarCostura = FindObjectOfType<EditarCostura>();
        editarCostura.Carregar(Id, resumo.text, nome.text, telefone.text, descricao.text, valor.text, data.text, pago.text, entregue.text);
    }
}
