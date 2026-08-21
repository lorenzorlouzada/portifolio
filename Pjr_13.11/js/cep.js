"use strict"

//Variáveis

const cep = document.getElementById("cep");
const btnPesquisar = document.getElementById("btnPesquisar");
const saida = document.getElementById("saida");

//Funções

function obterCep(){
    return cep.value;
}

function gerarStringEndereco(obj){
    return`
    <p>Logradouro:${obj.logradouro}</p>
    <p>Bairro:${obj.bairro}</p>
    <p>Localidade:${obj.localidade}</p>
    <p>UF:${obj.uf}</p>`;
}


async function buscarDadosCep(){

    const urlViaCep = `https://viacep.com.br/ws/${obterCep()}/json/`;

    try{
        const resposta = await fetch(urlViaCep);
        
        if (!resposta.ok){
            throw new Error("Erro na requisição HTTP.");
        }

        const dadosJson = await resposta.json();

        if(!dadosJson.erro){
            saida.innerHTML = gerarStringEndereco(dadosJson);
        }else{
            saida.innerHTML = "CEP inexistente"
        }

        //saida.innerHTML = gerarStringEndereco(dadosJson);
        
        //console.log(typeof dadosJson);
        //console.log(dadosJson);
        
        }catch(error){

            saida.innerHTML = `Erro ao buscar cep (${error.message}).`;

        }
}

//Event listeners

btnPesquisar.addEventListener("click", buscarDadosCep);
