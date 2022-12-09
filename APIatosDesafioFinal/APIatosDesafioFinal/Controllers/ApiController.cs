using APIatosDesafioFinal.DataModels;
using APIatosDesafioFinal.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace APIatosDesafioFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ApiController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("vendas")]
        public async Task<ActionResult> getAllVenda()
        {
            var vendas = await _contexto
                .Venda
                .AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return vendas == null ? NotFound() : Ok(vendas);
        }

        [HttpGet]
        [Route("vendas/{id}")]
        public async Task<ActionResult> getVendaByIdAsync(int id)
        {
            var venda = await _contexto
                .Venda.AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .FirstOrDefaultAsync(p => p.Id == id);

            return venda == null ? NotFound() : Ok(venda);
        }

        [HttpPost]
        [Route("vendas")]
        public async Task<IActionResult> PostVendaAsync(
            [FromBody] Venda vend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _contexto.Venda.AddAsync(vend);
                await _contexto.SaveChangesAsync();
                return Created("$api/vendas/{venda.id}", vend);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return vend == null ? NotFound() : Ok(vend);
        }

        [HttpPut]
        [Route("vendas/{id}")]
        public async Task<IActionResult> PutVendaAsync(
            [FromBody] Venda vend,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Inválida");

            var v = await _contexto.Venda
                .FirstOrDefaultAsync(x => x.Id == id);

            if (v == null)
                return NotFound("Venda não encontrada!");
            try
            {
                v.DataVenda = vend.DataVenda;
                v.Operadora = vend.Operadora;
                v.Cliente = vend.Cliente;
                v.Apelido = vend.Apelido;
                v.Tipo = vend.Tipo;
                v.ValorContrato = vend.ValorContrato;
                v.Comissao = vend.Comissao;
                v.Parcela = vend.Parcela;

                _contexto.Venda.Update(v);
                await _contexto.SaveChangesAsync();
                return Ok(v);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("vendas/{id}")]
        public async Task<IActionResult> DeleteVendaAsync(int id)
        {
            try
            {
                var v = await _contexto.Venda.FirstOrDefaultAsync(x => x.Id == id);
                _contexto.Venda.Remove(v);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Routes Comissoes
        //----------------------------------------------------------------------------------
        [HttpGet]
        [Route("comissoes")]
        public async Task<ActionResult> getAllComissaoAsync()
        {
            var comissoes = await _contexto
                .Comissao
                .AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return comissoes == null ? NotFound() : Ok(comissoes);
        }

        [HttpGet]
        [Route("comissoesVenda/{id}")]
        public async Task<ActionResult<List<Comissao>>> getAllComissoesVenda([FromRoute] int id)
        {
            var comissoes = await _contexto.Comissao
                .Where(x => x.VendaId == id).ToListAsync();
            return comissoes;
        }

        [HttpGet]
        [Route("comissoes/{id}")]
        public async Task<ActionResult> getComissaoByIdAsync(int id)
        {
            var comissoes = await _contexto
                .Comissao.AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .FirstOrDefaultAsync(p => p.Id == id);

            return comissoes == null ? NotFound() : Ok(comissoes);
        }

        [HttpPost]
        [Route("comissoes")]
        public async Task<ActionResult> PostComissaoAsync(CreateComissaoDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var venda = await  _contexto.Venda.FindAsync(request.VendaId);
                if (venda == null)
                    return NotFound();
                var newComissao = new Comissao
                {
                    Relatorio = request.Relatorio,
                    NotaFiscal = request.NotaFiscal,
                    Valor = request.Valor,
                    DataRebimento = request.DataRebimento,
                    Venda = venda
                };
                await _contexto.Comissao.AddAsync(newComissao);
                await _contexto.SaveChangesAsync();
                return Created("$api/comissoes/{comissao.id}", newComissao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return request == null ? NotFound() : Ok(request);
        }

        [HttpPut]
        [Route("comissoes/{id}")]
        public async Task<ActionResult> PutComissaoAsync(EditComissaoDTO request, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Inválida");

            var c = await _contexto.Comissao
                .FirstOrDefaultAsync(x => x.Id == id);

            if (c == null)
                return NotFound("Comissão não encontrada!");
            try
            {
                var venda = await _contexto.Venda.FindAsync(request.VendaId);
                if (venda == null)
                    return NotFound();

                c.Relatorio = request.Relatorio;
                c.NotaFiscal = request.NotaFiscal;
                c.Valor = request.Valor;
                c.DataRebimento = request.DataRebimento;
                c.Venda = venda;
                _contexto.Comissao.Update(c);
                await _contexto.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("comissoes/{id}")]
        public async Task<IActionResult> DeleteComissaoAsync(
            [FromRoute] int id)
        {
            try
            {
                var c = await _contexto.Comissao.FirstOrDefaultAsync(x => x.Id == id);
                _contexto.Comissao.Remove(c);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
