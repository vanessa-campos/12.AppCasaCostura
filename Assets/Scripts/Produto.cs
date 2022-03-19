using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Produto : MonoBehaviour
{
    public int Id;
    public TMP_Text id, categoria, nome, descricao, tamanho, valor, unidade, quantidade;
    Menu Menu;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void ButtonEditar(){      
        Menu.panelListaProdutos.SetActive(false);
        Screen.orientation = ScreenOrientation.Portrait;
        Instantiate(Menu.prefabEditarProdutos, Menu.transform);
        EditarProduto editarProduto = FindObjectOfType<EditarProduto>();
        editarProduto.Carregar(Id, categoria.text, nome.text, descricao.text, tamanho.text, valor.text, unidade.text, quantidade.text);
    }
}
