using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditarCostura : MonoBehaviour
{
    public int Id;
    public TMP_InputField Resumo, Nome, Telefone, Descricao, Valor, Data;
    public Toggle Pago, Entregue;
    Menu Menu; Costura costura;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void Carregar(int id, string resumo, string nome, string telefone, string descricao, string valor, string data, string pago, string entregue){
        Id = id;
        Resumo.text = resumo;
        Nome.text = nome;
        Telefone.text = telefone;
        Descricao.text = descricao;
        Valor.text = valor;
        Data.text = data;
        if(pago == "Sim"){
            Pago.isOn = true;
        }else{
            Pago.isOn = false;
        }
        if(entregue == "Sim"){
            Entregue.isOn = true;
        }else{
            Entregue.isOn = false;
        }
    }

    public void ButtonSalvar(){
        costura = Menu.costuras[Id-1].GetComponent<Costura>();
        costura.resumo.text = Resumo.text;
        costura.nome.text = Nome.text;
        costura.telefone.text = Telefone.text;
        costura.descricao.text = Descricao.text;
        costura.valor.text = Valor.text;
        costura.data.text = Data.text;
        if(Pago.isOn){
            costura.pago.text = "Sim";
        }else{
            costura.pago.text = "Não";
        }
        if(Entregue.isOn){
            costura.entregue.text = "Sim";
        }else{
            costura.entregue.text = "Não";
        }
        Destroy(gameObject);
        Menu.ButtonListaCosturas();
    }

    public void ButtonMenu(){
        Destroy(gameObject);
        Menu.panelMenu.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
