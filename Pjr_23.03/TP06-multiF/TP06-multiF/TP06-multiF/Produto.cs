using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06_multiF
{
    public class Produto
    {

        public String codigo;
        public String descricao;
        public String fornecedor;
        public String qtdEstoque;
        public String valorUnitario;

        public void setCodigo(String _codigo) { codigo = _codigo; }

        public void setDescricao(String _descricao) { descricao = _descricao; }
        public void setFornecedor(String _fornecedor) { fornecedor = _fornecedor; }
        public void setQtdEstoque(String _qtdEstoque) { qtdEstoque = _qtdEstoque; }
        public void setValorUnitario(String _valorUnitario) { valorUnitario = _valorUnitario; }

        public String getCodigo() { return codigo; }
        public String getDescricao() { return descricao; }
        public String getFornecedor() { return fornecedor; }
        public String getQtdEstoque() { return qtdEstoque; }
        public String getValorUnitario() { return valorUnitario; }


    }
}
