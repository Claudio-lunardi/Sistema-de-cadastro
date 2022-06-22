
using DevPrimeiraAula.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DevPrimeiraAula.Controllers
{
    public class FornecedorController : Controller
    {

        private readonly IOptions<DadosBase> _DadosBase;


        public FornecedorController(IOptions<DadosBase> dadosBase)
        {
            _DadosBase = dadosBase;
        }
        private string mensagem = "";





        //string urlBase = "https://localhost:7018/api/Fornecedor";
        // GET: FornecedorController
        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
            {
                TempData["sucesso"] = mensagem;
            }
            else
            {
                TempData["erro"] = mensagem;

            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor/ObterTodosFornecedores").Result;


            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<FornecedorModel>>(conteudo));
            }
            else
            {

                throw new Exception("DEU ZIKA");
            }



        }

        // GET: FornecedorController/Details/5
        public ActionResult Details(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor/ObterDadosFornecedor?cnpj={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FornecedorModel>(conteudo));
            }
            else
            {

                throw new Exception("DEU ZIKA");
            }
        }

        // GET: FornecedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] FornecedorModel valor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor", valor).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro salvo!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("DEU ZIKA");
                    }
                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        // GET: FornecedorController/Edit/5
        public ActionResult Edit(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor/ObterDadosFornecedor?cnpj={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FornecedorModel>(conteudo));
            }
            else
            {
                throw new Exception("DEU ZIKA");
            }
        }

        // POST: FornecedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] FornecedorModel fornecedorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor", fornecedorModel).Result;

                    //new FornecedorDB().Alterar(fornecedorModel);


                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro editado", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("DEU ZIKA");
                    }
                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }

            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        public ActionResult Delete(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync($"{_DadosBase.Value.API_URL_BASE}Fornecedor?cnpj={valor}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { mensagem = "Registro excluído!", sucesso = true });
            }
            else
            {
                throw new Exception("DEU ZICA!");
            }



        }





    }
}

