using APIdesafioFinal.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIdesafioFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("Vendas")]
        public async Task<IActionResult> getAllVendaAsync(
             [FromServices] Contexto contexto)
        {
            var vendas = await contexto
                .Venda
                .AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return vendas == null ? NotFound() : Ok(vendas);
        }

        [HttpGet]
        [Route("vendas/{id}")]
        public async Task<IActionResult> getVendaByIdAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            var venda = await contexto
                .Venda.AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .FirstOrDefaultAsync(p => p.Id == id);

            return venda == null ? NotFound() : Ok(venda);
        }

        [HttpPost]
        [Route("vendas")]
        public async Task<IActionResult> PostVendaAsync(
            [FromServices] Contexto contexto,
            [FromBody] Venda vend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await contexto.Venda.AddAsync(vend);
                await contexto.SaveChangesAsync();
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
            [FromServices] Contexto contexto,
            [FromBody] Venda vend,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Inválida");

            var v = await contexto.Venda
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

                contexto.Venda.Update(v);
                await contexto.SaveChangesAsync();
                return Ok(v);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("vendas/{id}")]
        public async Task<IActionResult> DeleteVendaAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            try
            {
                var v = await contexto.Venda.FirstOrDefaultAsync(x => x.Id == id);
                contexto.Venda.Remove(v);
                await contexto.SaveChangesAsync();
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
        public async Task<IActionResult> getAllComissaoAsync(
            [FromServices] Contexto contexto)
        {
            var comissoes = await contexto
                .Comissaos
                .AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return comissoes == null ? NotFound() : Ok(comissoes);
        }

        [HttpGet]
        [Route("comissoes/{id}")]
        public async Task<IActionResult> getComissaoByIdAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            var comissoes = await contexto
                .Comissaos.AsNoTracking()//só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .FirstOrDefaultAsync(p => p.Id == id);

            return comissoes == null ? NotFound() : Ok(comissoes);
        }

        [HttpPost]
        [Route("comissoes")]
        public async Task<IActionResult> PostComissaoAsync(
            [FromServices] Contexto contexto,
            [FromBody] Comissao comis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await contexto.Comissaos.AddAsync(comis);
                await contexto.SaveChangesAsync();

                return Created("$api/comissoes/{comissao.id}", comis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return comis == null ? NotFound() : Ok(comis);
        }

        [HttpPut]
        [Route("comissoes/{id}")]
        public async Task<IActionResult> PutComissaoAsync(
            [FromServices] Contexto contexto,
            [FromBody] Comissao comis,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model Inválida");

            var c = await contexto.Comissaos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (c == null)
                return NotFound("Comissão não encontrada!");
            try
            {
                c.Relatorio = comis.Relatorio;
                c.NotaFiscal = comis.NotaFiscal;
                c.Valor = comis.Valor;
                c.DataRebimento = comis.DataRebimento;
                c.FkVenda = comis.FkVenda;
                c.FkVendaNavigation = comis.FkVendaNavigation;
                contexto.Comissaos.Update(c);
                await contexto.SaveChangesAsync();
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
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            try
            {
                var c = await contexto.Comissaos.FirstOrDefaultAsync(x => x.Id == id);
                contexto.Comissaos.Remove(c);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}