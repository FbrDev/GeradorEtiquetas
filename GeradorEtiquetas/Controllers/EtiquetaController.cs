using GeradorEtiquetas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeradorEtiquetas.Controllers
{
    public class EtiquetaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GerarEtiqueta(EnderecoViewModel enderecoViewModel)
        {
            return View("Etiqueta", enderecoViewModel);
        }

        public async Task<ActionResult> BuscarCep(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                var url = $"https://viacep.com.br/ws/{cep}/json/";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Endereco endereco = JsonConvert.DeserializeObject<Endereco>(json);
                        return Json(endereco);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(null);
            }

            return Json(null);
        }
    }
}