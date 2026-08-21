using System;
using System.Collections.Generic;

namespace TP06_multiF
{
    internal class ProdutoBLL
    {
        public string ValidarProduto(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.descricao) ||
                string.IsNullOrWhiteSpace(produto.codigo) ||
                string.IsNullOrWhiteSpace(produto.qtdEstoque) ||
                string.IsNullOrWhiteSpace(produto.valorUnitario) ||
                string.IsNullOrWhiteSpace(produto.fornecedor))
            {
                return "Todos os campos são obrigatórios.";
            }

            if (!int.TryParse(produto.qtdEstoque, out int qtd) || qtd <= 0)
            {
                return "Quantidade em estoque deve ser inteiro maior que zero.";
            }

            if (!double.TryParse(produto.valorUnitario.Replace(",", "."), out double valor) || valor <= 0)
            {
                return "Valor unitário deve ser numérico maior que zero.";
            }

            return "OK";
        }

        public string Salvar(Produto produto)
        {
            string resultado = ValidarProduto(produto);

            if (resultado != "OK")
                return resultado;

            return ProdutoDAL.Inserir(produto);
        }

        public List<string> ListarCodigos()
        {
            return ProdutoDAL.ListarCodigos();
        }

        public Produto Buscar(string codigo)
        {
            return ProdutoDAL.Buscar(codigo);
        }

        public string Deletar(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "Informe o código.";

            return ProdutoDAL.Deletar(codigo);
        }
    }
}