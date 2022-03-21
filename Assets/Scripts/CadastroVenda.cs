using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CadastroVenda : MonoBehaviour
{    
    public TMP_Dropdown categoria, nome;
    public TMP_InputField quantidade;
    [SerializeField] TMP_Text message;
    [SerializeField] GameObject prefabVenda, prefabResumo;                    
    Menu Menu; String Mes; int v, vt, qt, vQt, pV; TMP_Dropdown.OptionData option; 

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void Listar(){
        nome.ClearOptions();
        option = new TMP_Dropdown.OptionData();
        option.text = "- Produto";
        nome.options.Add(option);
        nome.captionText.text = "- Produto";

        switch (categoria.value){
            
            case 1:
                foreach (var item in Menu.produtos){
                    int qt = 0;
                    int.TryParse(item.quantidade.text, out qt);

                    if(item.categoria.text == "Aviamento" && qt > 0){
                        option = new TMP_Dropdown.OptionData();
                        option.text = item.nome.text + " - " + item.descricao.text + " - " + item.tamanho.text;
                        nome.options.Add(option);
                    }
                }
                break;
            case 2:
                foreach (var item in Menu.produtos){
                    int qt = 0;
                    int.TryParse(item.quantidade.text, out qt);

                    if(item.categoria.text == "Tecido" && qt > 0){
                        option = new TMP_Dropdown.OptionData();
                        option.text = item.nome.text + " - " + item.descricao.text + " - " + item.tamanho.text;
                        nome.options.Add(option);
                    }   
                }
                break;
        }          
    }

    public void ButtonSalvar(){
        if(nome.captionText.text == "- Produto"){            
            StartCoroutine(ShowMessage("Produto não selecionado!"));
        }else{
            foreach (var p in Menu.produtos){                
                int.TryParse(p.quantidade.text, out pV);
                int qt; int.TryParse(quantidade.text, out qt);
                if(nome.captionText.text == p.nome.text + " - " + p.descricao.text + " - " + p.tamanho.text && pV >= qt){                    
                
                    //VENDA
                    GameObject novaVenda = Instantiate(prefabVenda, Menu.contentVendas);
                    Venda venda = novaVenda.GetComponent<Venda>();
                    venda.Id = Menu.vendas.Count + 1;
                    venda.id.text = venda.Id.ToString();
                    venda.nome.text = p.nome.text;
                    venda.descricao.text = p.descricao.text;
                    venda.tamanho.text = p.tamanho.text;
                    venda.valor.text = p.valor.text;
                    venda.quantidade.text = quantidade.text;   
                    int.TryParse(venda.quantidade.text, out vQt);
                    p.quantidade.text = (pV - vQt).ToString();
                    int.TryParse(venda.valor.text, out v);
                    vt = v * vQt;
                    venda.valorTotal.text = vt.ToString();
                    Mes = DateTime.Today.Month.ToString();
                    venda.data.text = DateTime.Today.ToString();
                    Menu.vendas.Add(venda);

                    //RESUMO  
                    if(Menu.resumo.Count == 0){            
                        GameObject novoResumo = Instantiate(prefabResumo, Menu.contentResumo);
                        ResumoMes resumo = novoResumo.GetComponent<ResumoMes>();
                        resumo.id.text =  (Menu.resumo.Count + 1).ToString();
                        resumo.mes.text = Mes;
                        resumo.quantidade.text = vQt.ToString();
                        resumo.valor.text = vt.ToString();
                        Menu.resumo.Add(resumo);
                    }else{
                        foreach (var item in Menu.resumo){
                            if(item.mes.text == Mes){                    
                                int.TryParse(item.valor.text, out v);
                                int.TryParse(item.quantidade.text, out qt);
                                item.quantidade.text = (qt + vQt).ToString();
                                item.valor.text = (v + vt).ToString();
                            }
                        }
                    }        
                    Menu.ButtonListaVendas();
                }else{
                    StartCoroutine(ShowMessage("Quantidade indisponível!"));
                }       
            }    
        }
    }
    
    IEnumerator ShowMessage(string messageText){
        message.gameObject.SetActive(true);
        message.text = messageText; 
        yield return new WaitForSeconds(3);
        message.gameObject.SetActive(false); 
    }

}
