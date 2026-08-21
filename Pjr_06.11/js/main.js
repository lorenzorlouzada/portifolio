"use strict"

//const p1 = obterNota("p1");
//const p2 = obterNota("p2");
const btnCalcular = document.getElementById("btnCalcular");
const saida = document.getElementById("saida");

//Funções

function exibirSaida(mensagem){
    const saida = document.getElementById("saida");
    saida.textContent = mensagem;
}

function validarNota(nota){
        return nota>=0 && nota<=10;
    }

function obterNota(nota){
    return +document.getElementById(nota).value;
}

function calcularMedia(p1, p2){
    const media = (p1 + 2 * p2) / 3;
    return media;    
}

function onClick(){

    const p1 = obterNota("p1");
    const p2 = obterNota("p2");
    const mediaCalculada = calcularMedia(p1, p2);
    exibirSaida( "A média é: " + mediaCalculada.toFixed(2));

}

//Event listeners

btnCalcular.addEventListener("click", onClick);


    