using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DadosCrud;
using CrudTakubo.Models;

namespace CrudTakubo.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult Index()
        {
            //cria a listagem que será exibida na tela
            List<CidadeViewModel> lista = new List<CidadeViewModel>();

            //abre a conexao com o banco
            using (CrudModel connection = new CrudModel())
            {
                //faz o select no banco
                List<cidade> listaCidades = connection.cidades.ToList();

                //percorre todos os itens retornados do select
                foreach (var item in listaCidades)
                {
                    //cria um objeto da listagem da tela
                    CidadeViewModel cidadeTela = new CidadeViewModel();
                    //preenche as informações do objeto da tela com o item corrente do select
                    cidadeTela.Id = item.id;
                    cidadeTela.Nome = item.nome;
                    //adiciona o objeto da tela na listagem da tela
                    lista.Add(cidadeTela);
                }
            }

            //retorna a lista para a tela
            return View(lista);
        }

        public ActionResult Novo()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Novo(string cidade)
        {
            using (CrudModel connection = new CrudModel())
            {
                cidade cid = new DadosCrud.cidade();
                cid.nome = cidade;

                connection.cidades.Add(cid);
                connection.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(CidadeViewModel model)
        {
            using (CrudModel connection = new CrudModel())
            {
                cidade cid = connection.cidades.FirstOrDefault(cidade => cidade.id == model.Id);
                cid.nome = model.Nome;
                
                connection.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            CidadeViewModel model = new CidadeViewModel();
            using (CrudModel connection = new CrudModel())
            {
                cidade cid = connection.cidades.FirstOrDefault(cidade => cidade.id == id);

                if (cid != null)
                {
                    model.Id = cid.id;
                    model.Nome = cid.nome;
                }

            }

            return View(model);
        }
    }
}