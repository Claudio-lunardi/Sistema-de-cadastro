
using DevPrimeiraAula.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace DevPrimeiraAula.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly IOptions<DadosBase> _dadosBase;
        public FuncionarioController(IOptions<DadosBase> dadosBase)
        {
            _dadosBase = dadosBase;


        }

        //string urlBase = "https://localhost:7018/api/Funcionario";
        string mensagem = "";

        // GET: FuncionarioController
        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario/ObterTodosFuncionarios").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<FuncionarioModel>>(conteudo));

            }
            else
            {
                throw new Exception("DEU ZIKA");
            }
            //List<FuncionarioModel> funcionario = new FuncionarioDB().ObterTodosFuncionarios();

        }

        // GET: FuncionarioController/Details/5
        public ActionResult Details(string valor)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario/ObterDadosFuncionario?cpf={valor}").Result;


            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FuncionarioModel>(conteudo));
            }
            else
            {
                throw new Exception("DEU ZIKA");
            }
            //FuncionarioModel funcionario = new FuncionarioDB().ObterDadosFuncionario(valor);
        }

        // GET: FuncionarioController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] FuncionarioModel funcionarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient Client = new HttpClient();
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicarion/json"));

                    HttpResponseMessage response = Client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario", funcionarioModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Salvo!", sucesso = true });
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

        // GET: FuncionarioController/Edit/5
        public ActionResult Edit(string valor)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicarion/json"));

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario/ObterDadosFuncionario?cpf={valor}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FuncionarioModel>(conteudo));
            }
            else
            {

                throw new Exception("DEU ZIKA");
            }





            //FuncionarioModel funcionario = new FuncionarioDB().ObterDadosFuncionario(valor);

        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] FuncionarioModel funcionarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario", funcionarioModel).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "registro salvo!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("DEU ZIKA");
                    }
                    //new ClienteDB().Alterar(clienteModel);
                    //return RedirectToAction(nameof(Index), new { mensagem = "Registro editado", sucesso = true });
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
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario?cpf={valor}").Result;

                if (Response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { mensagem = "registro salvo!", sucesso = true });
                }
                else
                {
                    throw new Exception("DEU ZIKA");
                }



            }
            catch
            {
                return View();
            }
        }
    }
}
