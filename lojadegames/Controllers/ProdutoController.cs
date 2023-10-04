using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using lojadegames.Model;
using lojadegames.Service;
using lojadegames.Service.Implements;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace lojadegames.Controllers
{
        [Authorize]
        [Route("~/produtos")]
        //[ApiController] indica que a classe é do tipo Controller
        [ApiController]
        public class ProdutoController : ControllerBase
        {
            private readonly IProdutoService _produtoService;
            private readonly IValidator<Produto> _produtoValidator;

            public ProdutoController(

                IProdutoService produtoService,
                    IValidator<Produto> produtoValidator
            )
            {
                _produtoService = produtoService;
                _produtoValidator = produtoValidator;
            }

            //[HttpGet] é um método dentre os 4 tipos para informar para a API
            //se vai puxar(Get), incluir(Post), alterar(Put) ou deletar(delete) algum dado do backend
            //No caso abaixo [HttpGet] = "chama" um valor
            [HttpGet]
            public async Task<ActionResult> GetAll()
            {
                return Ok(await _produtoService.GetAll());
            }

        //Path de caminho (id = variavel) 
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        }

        
        // o que está em () é um titulo de caminho
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }
        //[HttpPost] = Cria um valor
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Tema não encontrado!");

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);

        }

        //[HttpPut] = altera um valor
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id da Produto é inválido");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);
            if (!validarProduto.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            }
            var Resposta = await _produtoService.Update(produto);
            if (Resposta is null)
                return NotFound("Produto e/ou Tema não encontrados!");


            return Ok(Resposta);
        }

        //[HttpDelete] = Deleta um valor, especificamente chamando pelo id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var BuscaProduto = await _produtoService.GetById(id);
            if (BuscaProduto is null)
                return NotFound("Produto não foi encontrada!");
            await _produtoService.Delete(BuscaProduto);
            return NoContent();
        }

        [HttpGet("preco/{numero1}/{numero2}")]

        public async Task<ActionResult> GetByPreco(decimal numero1, decimal numero2)
        {
            if (numero1 > numero2)
                return BadRequest("Valor minimo não pode ser maior que valor máximo");

            var Resposta = await _produtoService.GetByPreco(numero1, numero2);

            return Ok(Resposta);

        }

    }
}
