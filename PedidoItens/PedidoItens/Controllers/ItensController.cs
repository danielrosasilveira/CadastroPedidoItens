using PedidoItens.Context;
using PedidoItens.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace PedidoItens.Controllers
{
    public class ItensController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Itens
        public ActionResult ListarItens(int id)
        {
            var lista = db.Itens.Where(m => m.Pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }

        public ActionResult SalvarItens(int quantidade, string produto, decimal valorunitario, int idPedido)
        {
            var item = new Itens()
            {
                Quantidade = quantidade,
                Produto = produto,
                ValorUnitario = valorunitario,
                Pedido = db.Pedidos.Find(idPedido)
            };
            db.Itens.Add(item);
            db.SaveChanges();
            return Json(new { Resultado = item.Id }, JsonRequestBehavior.AllowGet);
        }
    }
}