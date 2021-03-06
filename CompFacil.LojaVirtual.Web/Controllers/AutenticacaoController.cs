﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CompFacil.LojaVirtual.Dominio.Entidades;
using CompFacil.LojaVirtual.Dominio.Repositório;

namespace CompFacil.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        public AdministradoresRepositorio _repositorio;

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if (admin != null)
                {
                    if (!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("", "Senha incorreta!");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl != "0" && returnUrl.StartsWith("/") && returnUrl.StartsWith("//") && returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Produto", new { area = "Administrativo" });
                }
                else
                {
                    ModelState.AddModelError("", "Administrador não localizado!");
                }
            }

            return View(new Administrador());
        }
    }
}