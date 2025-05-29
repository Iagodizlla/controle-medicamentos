using ControleDeMedicamentos.Extensions;
using ControleDeMedicamentos.ModuloFuncionario;

namespace ControleDeMedicamentos.Model;

public abstract class FormularioFuncionarioViewModel
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CPF { get; set; }
}

public class CadastrarFuncionarioViewModel : FormularioFuncionarioViewModel
{
    public CadastrarFuncionarioViewModel() { }

    public CadastrarFuncionarioViewModel(string nome, string telefone, string cpf) : this()
    {
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
}

public class EditarFuncionarioViewModel : FormularioFuncionarioViewModel
{
    public int Id { get; set; }

    public EditarFuncionarioViewModel() { }

    public EditarFuncionarioViewModel(int id, string nome, string telefone, string cpf) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
}

public class ExcluirFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFuncionarioViewModel() { }

    public ExcluirFuncionarioViewModel(int id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFuncionariosViewModel
{
    public List<DetalhesFuncionarioViewModel> Registros { get; }

    public VisualizarFuncionariosViewModel(List<Funcionario> funcionarios)
    {
        Registros = [];

        foreach (var f in funcionarios)
        {
            var detalhesVM = f.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CPF { get; set; }

    public DetalhesFuncionarioViewModel(int id, string nome, string telefone, string cpf)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
}