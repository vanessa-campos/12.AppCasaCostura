using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("PANELS")]
    public GameObject panelMenu;
    public GameObject panelVender, panelCosturar, panelProduto, panelListaProdutos, panelListaVendas, panelListaCosturas, panelListaResumo;
    public GameObject prefabEditarProdutos, prefabEditarCosturas;
    GameObject panelEditarProduto, panelEditarCostura;

    [Header("LISTS")]
    public List<Produto> produtos;
    public List<Costura> costuras;
    public List<Venda> vendas;
    public List<ResumoMes> resumo;


    [Header("CONTENTS")]
    public Transform contentProduto;
    public Transform contentCosturas, contentVendas, contentResumo;

    private void Start()
    {
        ButtonMenu();
    }

    public void ButtonMenu(){
        panelVender.SetActive(false);
        panelCosturar.SetActive(false);
        panelProduto.SetActive(false);
        panelListaProdutos.SetActive(false);
        panelListaVendas.SetActive(false);
        panelListaCosturas.SetActive(false);
        panelListaResumo.SetActive(false);
        panelMenu.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void ButtonVender(){
        panelMenu.SetActive(false);
        panelVender.SetActive(true);
        CadastroVenda cadastroVenda = panelVender.GetComponent<CadastroVenda>();
        cadastroVenda.categoria.value = 0;
        cadastroVenda.nome.value = 0;
        cadastroVenda.quantidade.text = "";
    }
    public void ButtonCosturar(){
        panelMenu.SetActive(false);
        panelCosturar.SetActive(true);
        CadastroCostura cadastroCostura = panelCosturar.GetComponent<CadastroCostura>();
        cadastroCostura.resumo.text = "";
        cadastroCostura.nome.text = "";
        cadastroCostura.telefone.text = "";
        cadastroCostura.descricao.text = "";
        cadastroCostura.valor.text = "";
        cadastroCostura.data.text = "";
    }
    public void ButtonProduto(){        
        panelMenu.SetActive(false);
        panelProduto.SetActive(true);        
        CadastroProduto cadastroProduto = panelProduto.GetComponent<CadastroProduto>();
        cadastroProduto.categoria.value = 0;
        cadastroProduto.nome.text = "";
        cadastroProduto.descricao.text = "";
        cadastroProduto.tamanho.text = "";
        cadastroProduto.valor.text = "";
        cadastroProduto.unidade.value = 0;
        cadastroProduto.quantidade.text = "";
    }
    public void ButtonListaProdutos(){
        panelMenu.SetActive(false);
        panelProduto.SetActive(false);
        panelListaProdutos.SetActive(true);
        Screen.orientation = ScreenOrientation.Landscape;
        foreach (var item in produtos){
            item.transform.SetParent(contentProduto);
        }
    }
    public void ButtonListaVendas(){
        panelMenu.SetActive(false);
        panelVender.SetActive(false);
        panelListaVendas.SetActive(true);    
        Screen.orientation = ScreenOrientation.Landscape;   
        foreach (var item in vendas){
            item.transform.SetParent(contentVendas);
        } 
    }
    public void ButtonListaCosturas(){
        panelMenu.SetActive(false);
        panelCosturar.SetActive(false);
        panelListaCosturas.SetActive(true);  
        Screen.orientation = ScreenOrientation.Landscape;
        foreach (var item in costuras){
            item.transform.SetParent(contentCosturas);
        }      
    }
    public void ButtonListaResumo(){
        panelMenu.SetActive(false);
        panelListaResumo.SetActive(true);
        Screen.orientation = ScreenOrientation.Landscape;
        foreach (var item in resumo){
            item.transform.SetParent(contentResumo);
        }
    }



}
