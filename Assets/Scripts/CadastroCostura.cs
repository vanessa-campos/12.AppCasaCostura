using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CadastroCostura : MonoBehaviour
{
    public TMP_InputField resumo, nome, telefone, descricao, valor, data;
    public Toggle pago;
    [SerializeField] GameObject prefabCostura;
    Menu Menu;

    private void Start(){
        Menu = FindObjectOfType<Menu>();
    }

    public void ButtonSalvar(){
        GameObject novaCostura = Instantiate(prefabCostura, Menu.contentCosturas);
        Costura costura = novaCostura.GetComponent<Costura>();
        costura.Id = Menu.costuras.Count + 1;
        costura.id.text = costura.Id.ToString();
        costura.resumo.text = resumo.text;
        costura.nome.text = nome.text;
        costura.telefone.text = telefone.text;
        costura.descricao.text = descricao.text;
        costura.valor.text = valor.text;
        costura.data.text = data.text;
        if(pago.isOn){
            costura.pago.text = "Sim";
        }else{
            costura.pago.text = "Não";
        }
        costura.entregue.text = "Não";
        Menu.costuras.Add(costura);
        Menu.ButtonListaCosturas();
    }

    
}
