using ControleDeMedicamentos.Model;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.Extensions;

public static class MedicamentoExtensions
{
    public static Medicamento ParaEntidade(
        this FormularioMedicamentoViewModel formularioVM,
        List<Fornecedor> fornecedores
    )
    {
        Fornecedor fornecedorSelecionado = null;

        foreach (var f in fornecedores)
        {
            if (f.Id == formularioVM.FornecedorId)
                fornecedorSelecionado = f;
        }

        return new Medicamento(
            formularioVM.Nome,
            formularioVM.Descricao,
            fornecedorSelecionado, 
            0
        );
    }

    public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento medicamento)
    {
        return new DetalhesMedicamentoViewModel(
            medicamento.Id,
            medicamento.NomeMedicamento,
            medicamento.Descricao,
            medicamento.Fornecedor.Nome,
            medicamento.Quantidade,
            medicamento.Quantidade >= 20
        );
    }
}