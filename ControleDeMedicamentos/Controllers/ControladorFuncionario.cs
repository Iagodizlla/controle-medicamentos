using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.Extensions;
using ControleDeMedicamentos.Model;
using ControleDeMedicamentos.ModuloFuncionario;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.Controllers;

[Route("/funcionarios")]
public class ControladorFuncionario : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioFuncionario repositorioFuncionario;

    public ControladorFuncionario()
    {
        contextoDados = new ContextoDados(true);
        repositorioFuncionario = new RepositorioFuncionario(contextoDados);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarFuncionarioViewModel();

        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVM)
    {
        var novoFuncionario = cadastrarVM.ParaEntidade();

        repositorioFuncionario.CadastrarRegistro(novoFuncionario);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Funcionário Cadastrado!",
            $"O registro \"{novoFuncionario.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var registroSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);

        var editarVM = new EditarFuncionarioViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Telefone,
            registroSelecionado.CPF
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarFuncionarioViewModel editarVM)
    {
        var registroEditado = editarVM.ParaEntidade();

        repositorioFuncionario.EditarRegistro(id, registroEditado);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Funcionário Editado!",
            $"O registro \"{registroEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var registroSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFuncionarioViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        repositorioFuncionario.ExcluirRegistro(id);

        NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
            "Funcionário Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var registros = repositorioFuncionario.SelecionarTodos();

        var visualizarVM = new VisualizarFuncionariosViewModel(registros);

        return View(visualizarVM);
    }
}