using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditarProduto : MonoBehaviour
{
    public int Id;
    public TMP_InputField Nome, Descricao, Tamanho, Valor, Quantidade;
    public TMP_Dropdown Categoria, Unidade;
    Menu Menu; Produto produto;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void Carregar(int id, string categoria, string nome, string descricao, string tamanho, string valor, string unidade, string quantidade){
        Id = id;
        if(categoria == "Aviamento"){
            Categoria.value = 0;
        }else{
            Categoria.value = 1;
        }
        Nome.text = nome;
        Descricao.text = descricao;
        Tamanho.text = tamanho;
        Valor.text = valor;
        if(unidade == "Und"){
            Unidade.value = 0;
        }else{
            Unidade.value = 1;
        }
        Quantidade.text = quantidade;
    }

    public void ButtonSalvar(){
        produto = Menu.produtos[Id-1].GetComponent<Produto>();
        if(Categoria.value == 0){
            produto.categoria.text = "Aviamento";
        }else{
            produto.categoria.text = "Tecido";
        }
        produto.nome.text = Nome.text;
        produto.descricao.text = Descricao.text;
        produto.tamanho.text = Tamanho.text;
        produto.valor.text = Valor.text;
        if(Unidade.value == 0){
            produto.unidade.text = "Und";
        }else{
            produto.unidade.text = "Metros";
        }
        produto.quantidade.text = Quantidade.text;

        Destroy(gameObject);
        Menu.ButtonListaProdutos();
    }

    public void ButtonMenu(){
        Destroy(gameObject);
        Menu.panelMenu.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
