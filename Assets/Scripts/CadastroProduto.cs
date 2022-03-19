using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CadastroProduto : MonoBehaviour
{
    public TMP_InputField nome, descricao, tamanho, valor, quantidade;
    public TMP_Dropdown categoria, unidade;
    [SerializeField] GameObject prefabProduto;
    Menu Menu;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void ButtonSalvar(){
        GameObject novoproduto = Instantiate(prefabProduto, Menu.contentProduto);
        Produto produto = novoproduto.GetComponent<Produto>();
        produto.Id = Menu.produtos.Count + 1;
        produto.id.text = produto.Id.ToString();
        if(categoria.value == 0){
            produto.categoria.text = "Aviamento";
        }else{
            produto.categoria.text = "Tecido";
        }
        produto.nome.text = nome.text;
        produto.descricao.text = descricao.text;
        produto.tamanho.text = tamanho.text;
        produto.valor.text = valor.text;
        if(unidade.value == 0){
            produto.unidade.text = "Und";
        }else{
            produto.unidade.text = "Metros";
        }
        produto.quantidade.text = quantidade.text;

        Menu.produtos.Add(produto);
        Menu.ButtonListaProdutos();
    }

    
}
