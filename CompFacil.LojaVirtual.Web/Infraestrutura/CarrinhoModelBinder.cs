using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using CompFacil.LojaVirtual.Dominio.Entidades;

namespace CompFacil.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            //Obtendo o carrinho da sessão

            Carrinho oCarrinho = null;

            if (controllerContext.HttpContext.Session != null)
                oCarrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];

            //Crio  o carrinho
            if (oCarrinho == null)
            {
                oCarrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[SessionKey] = oCarrinho;
            }

            return oCarrinho;
        }

        public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }
}