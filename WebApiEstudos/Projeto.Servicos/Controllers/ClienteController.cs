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

        [HttpGet]
        [Route("consultar")] //URL:/api/cliente/consultar
        public HttpResponseMessage Consultar()
        {
            try
            {
                //lista da model de clienteconsulta
                List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

                ClienteRepositorio rp = new ClienteRepositorio();

                

                foreach (Cliente c in rp.Buscar())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    lista.Add(model);
                }


                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("consultaporid")] //URL:/api/cliente/consultaporid
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {
                ClienteRepositorio rp = new ClienteRepositorio();
                Cliente c = rp.BuscarPorId(id);

                if (c != null)
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, " Cliente não encontrado !");
                }

                
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
