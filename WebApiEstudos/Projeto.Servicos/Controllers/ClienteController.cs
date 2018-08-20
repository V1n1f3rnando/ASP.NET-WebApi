using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Servicos.Models;
using Projeto.Entidades;
using Projeto.DAL.Repositorios;

namespace Projeto.Servicos.Controllers
{
    [RoutePrefix("api/Cliente")]//url padrão
    public class ClienteController : ApiController
    {
        //Serviço de cadastro de Cliente
        [HttpPost]
        [Route("cadastrar")] //URL: /api/cliente/cadastrar
        public HttpResponseMessage Cadastrar(ClienteCadastroViewModel model)
        {
            try
            {
                var cliente = new Cliente();

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;

                //Instanciando repositório
                ClienteRepositorio rp = new ClienteRepositorio();

                //gravando cliente
                rp.Inserir(cliente);
               
                //Retornar um status de sucesso  (HTTP 200)
                return Request.CreateResponse(HttpStatusCode.OK, "Cliente cadastrado com sucesso !");
            }
            catch (Exception ex)
            {
                // status (HTTP 500) ERROR
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //Seviço de atualização de cliente
        [HttpPut]
        [Route("atualizar")] //URL: /api/cliente/atualizar
        public HttpResponseMessage Atualizar(ClienteEdicaoViewModel model)
        {
            try
            {
                var cliente = new Cliente();

                cliente.IdCliente = model.IdCliente;
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;

                ClienteRepositorio rp = new ClienteRepositorio();
                rp.Alterar(cliente);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente atualizado com sucesso !");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //Serviço de exclusão de cliente
        [HttpDelete]
        [Route("excluir")]//URL: /api/cliente/excluir
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                ClienteRepositorio rp = new ClienteRepositorio();
                rp.Deletar(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente deletado com sucesso !");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
